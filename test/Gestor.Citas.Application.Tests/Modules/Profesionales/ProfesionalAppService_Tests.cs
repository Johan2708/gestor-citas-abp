using System;
using System.Linq;
using System.Threading.Tasks;
using Gestor.Citas.Modules.Profesionales;
using Shouldly;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Modularity;
using Volo.Abp.Validation;
using Xunit;

namespace Gestor.Citas.Modules.Profesionales;

public abstract class ProfesionalAppService_Tests<TStartupModule> : CitasApplicationTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{
    private readonly IProfesionalAppService _profesionalAppService;

    protected ProfesionalAppService_Tests()
    {
        _profesionalAppService = GetRequiredService<IProfesionalAppService>();
    }

    [Fact]
    public async Task Should_Get_List_Of_Profesionales()
    {
        //Act
        var result = await _profesionalAppService.GetListAsync(new PagedAndSortedResultRequestDto());

        //Assert
        result.TotalCount.ShouldBeGreaterThan(0);
        result.Items.ShouldContain(p => p.Nombre == "Dra. Ana López");
    }

    [Fact]
    public async Task Should_Create_A_Valid_Profesional()
    {
        //Act
        var result = await CreateProfesional();

        //Assert
        result.Id.ShouldNotBe(Guid.Empty);
        result.Nombre.ShouldBe("Nuevo Profesional 42");
    }

    [Fact]
    public async Task Should_Not_Create_A_Profesional_Without_Name()
    {
        var exception = await Assert.ThrowsAsync<AbpValidationException>(async () =>
        {
            await CreateProfesional("");
        });

        exception.ValidationErrors
            .Any(e => e.MemberNames.Contains(nameof(CreateUpdateProfesionalDto.Nombre)))
            .ShouldBeTrue();
    }

    [Fact]
    public async Task Should_Get_Profesional_By_Id()
    {
        // Arrange
        var listResult = await _profesionalAppService.GetListAsync(new PagedAndSortedResultRequestDto());
        var profesional = listResult.Items.First();

        // Act
        var result = await _profesionalAppService.GetAsync(profesional.Id);

        // Assert
        result.ShouldNotBeNull();
        result.Id.ShouldBe(profesional.Id);
    }

    [Fact]
    public async Task Should_Update_Profesional()
    {
        // Arrange
        var listResult = await _profesionalAppService.GetListAsync(new PagedAndSortedResultRequestDto());
        var profesional = listResult.Items.First();

        var updateDto = new CreateUpdateProfesionalDto
        {
            Nombre = "Nombre Actualizado",
            Especializacion = profesional.Especializacion,
            Direccion = profesional.Direccion,
            Telefono = profesional.Telefono
        };

        // Act
        var result = await _profesionalAppService.UpdateAsync(profesional.Id, updateDto);

        // Assert
        result.Nombre.ShouldBe("Nombre Actualizado");
    }

    [Fact]
    public async Task Should_Delete_Profesional()
    {
        // Arrange
        var createResult = await CreateProfesional();

        // Act
        await _profesionalAppService.DeleteAsync(createResult.Id);

        // Assert
        var listResult = await _profesionalAppService.GetListAsync(new PagedAndSortedResultRequestDto());
        listResult.Items.Any(p => p.Id == createResult.Id).ShouldBeFalse();
    }

    private async Task<ProfesionalDto> CreateProfesional(string name = "Nuevo Profesional 42")
    {
        var response = await _profesionalAppService.CreateAsync(
            new CreateUpdateProfesionalDto
            {
                Nombre = name,
                Especializacion = "Test Especialidad",
                Direccion = "Test Direccion",
                Telefono = "99999999"
            }
        );
        return response;
    }
}