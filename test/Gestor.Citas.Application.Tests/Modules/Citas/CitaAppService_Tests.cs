using System;
using System.Linq;
using System.Threading.Tasks;
using Gestor.Citas.Modules.Citas;
using Gestor.Citas.Modules.CitasDto;
using Gestor.Citas.Modules.Clientes;
using Gestor.Citas.Modules.Profesionales;
using Shouldly;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Modularity;
using Volo.Abp.Validation;
using Xunit;

namespace Gestor.Citas.Modules.Citas;

public abstract class CitaAppService_Tests<TStartupModule> : CitasApplicationTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{
    private readonly ICitaAppService _citaAppService;
    private readonly IClienteAppService _clienteAppService;
    private readonly IProfesionalAppService _profesionalAppService;

    protected CitaAppService_Tests()
    {
        _citaAppService = GetRequiredService<ICitaAppService>();
        _clienteAppService = GetRequiredService<IClienteAppService>();
        _profesionalAppService = GetRequiredService<IProfesionalAppService>();
    }

    [Fact]
    public async Task Should_Get_List_Of_Citas()
    {
        // Act
        var result = await _citaAppService.GetListAsync(
            new PagedAndSortedResultRequestDto()
        );

        // Assert
        result.TotalCount.ShouldBeGreaterThan(0);
        result.Items.ShouldContain(c => c.Motivo == "Segunda cita de ejemplo");
    }

    [Fact]
    public async Task Should_Create_A_Valid_Cita()
    {
        // Act
        var result = await CreateCita();

        // Assert
        result.Id.ShouldNotBe(Guid.Empty);
        result.Motivo.ShouldBe("Nueva cita de prueba 42");
    }

    [Fact]
    public async Task Should_Not_Create_A_Cita_Without_Titulo()
    {
        var exception = await Assert.ThrowsAsync<AbpValidationException>(async () =>
        {
            await CreateCita("");
        });

        exception.ValidationErrors
            .Any(e => e.MemberNames.Contains(nameof(CreateUpdateCitaDto.Motivo)))
            .ShouldBeTrue();
    }

    [Fact]
    public async Task Should_Get_Cita_By_Id()
    {
        // Arrange
        var listResult = await _citaAppService.GetListAsync(new PagedAndSortedResultRequestDto());
        var cita = listResult.Items.First();

        // Act
        var result = await _citaAppService.GetAsync(cita.Id);

        // Assert
        result.ShouldNotBeNull();
        result.Id.ShouldBe(cita.Id);
    }

    [Fact]
    public async Task Should_Update_Cita()
    {
        // Arrange
        var listResult = await _citaAppService.GetListAsync(new PagedAndSortedResultRequestDto());
        var cita = listResult.Items.First();

        var updateDto = new CreateUpdateCitaDto
        {
            Motivo = "Cita Actualizada",
            FechaCita = cita.FechaCita,
            ClienteId = cita.ClienteId,
            ProfesionalId = cita.ProfesionalId
        };

        // Act
        var result = await _citaAppService.UpdateAsync(cita.Id, updateDto);

        // Assert
        result.Motivo.ShouldBe("Cita Actualizada");
    }

    [Fact]
    public async Task Should_Delete_Cita()
    {
        // Arrange
        var createResult = await CreateCita();

        // Act
        await _citaAppService.DeleteAsync(createResult.Id);

        // Assert
        var listResult = await _citaAppService.GetListAsync(new PagedAndSortedResultRequestDto());
        listResult.Items.Any(c => c.Id == createResult.Id).ShouldBeFalse();
    }

    private async Task<CitaDto> CreateCita(string titulo = "Nueva cita de prueba 42")
    {
        var cliente = await _clienteAppService.GetListAsync(new PagedAndSortedResultRequestDto());
        var profesional = await _profesionalAppService.GetListAsync(new PagedAndSortedResultRequestDto());
        
        var firstCliente = cliente.Items.FirstOrDefault();
        var firstProfesional = profesional.Items.FirstOrDefault();
        
        var response = await _citaAppService.CreateAsync(
            new CreateUpdateCitaDto
            {
                Motivo = titulo,
                FechaCita = DateTime.Now.AddDays(1),
                ClienteId = firstCliente.Id,
                ProfesionalId = firstProfesional.Id
            }
        );
        return response;
    }
}