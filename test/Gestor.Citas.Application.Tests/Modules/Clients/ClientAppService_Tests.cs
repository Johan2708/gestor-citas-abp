using System;
using System.Linq;
using System.Threading.Tasks;
using Gestor.Citas.Modules.Clientes;
using Shouldly;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Modularity;
using Volo.Abp.Validation;
using Xunit;

namespace Gestor.Citas.Modules.Clients;

public abstract class ClientAppService_Tests<TStartupModule> : CitasApplicationTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{
    private readonly IClienteAppService _clienteAppService;
    
    protected ClientAppService_Tests()
    {
        _clienteAppService = GetRequiredService<IClienteAppService>();
    }
    
    [Fact]
    public async Task Should_Get_List_Of_Clients()
    {
        //Act
        var result = await _clienteAppService.GetListAsync(
            new PagedAndSortedResultRequestDto()
        );

        //Assert
        result.TotalCount.ShouldBeGreaterThan(0);
        result.Items.ShouldContain(c => c.Nombre == "John");
    }

    [Fact]
    public async Task Should_Create_A_Valid_Client()
    {
        //Act
        var result = await CreateClient();

        //Assert
        result.Id.ShouldNotBe(Guid.Empty);
        result.Nombre.ShouldBe("New test client 42");
    }

    [Fact]
    public async Task Should_Not_Create_A_Client_Without_Name()
    {
        var exception = await Assert.ThrowsAsync<AbpValidationException>(async () =>
        {
            await CreateClient("");
        });

        exception.ValidationErrors
            .Any(e => e.MemberNames.Contains(nameof(CreateUpdateClienteDto.Nombre)))
            .ShouldBeTrue();
    }
    
    [Fact]
    public async Task Should_Get_Client_By_Id()
    {
        // Arrange
        var listResult = await _clienteAppService.GetListAsync(new PagedAndSortedResultRequestDto());
        var client = listResult.Items.First();

        // Act
        var result = await _clienteAppService.GetAsync(client.Id);

        // Assert
        result.ShouldNotBeNull();
        result.Id.ShouldBe(client.Id);
    }

    [Fact]
    public async Task Should_Update_Client()
    {
        // Arrange
        var listResult = await _clienteAppService.GetListAsync(new PagedAndSortedResultRequestDto());
        var client = listResult.Items.First();

        var updateDto = new CreateUpdateClienteDto
        {
            Nombre = "Updated Name",
            Apellido = client.Apellido,
            Email = client.Email,
            Telefono = client.Telefono,
            FechaNacimiento = client.FechaNacimiento,
            Direccion = client.Direccion
        };

        // Act
        var result = await _clienteAppService.UpdateAsync(client.Id, updateDto);

        // Assert
        result.Nombre.ShouldBe("Updated Name");
    }

    [Fact]
    public async Task Should_Delete_Client()
    {
        // Arrange
        var createResult = await CreateClient();

        // Act
        await _clienteAppService.DeleteAsync(createResult.Id);

        // Assert
        var listResult = await _clienteAppService.GetListAsync(new PagedAndSortedResultRequestDto());
        listResult.Items.Any(c => c.Id == createResult.Id).ShouldBeFalse();
    }
    
    private async Task<ClienteDto> CreateClient(string name = "New test client 42")
    {
        var response = await _clienteAppService.CreateAsync(
            new CreateUpdateClienteDto
            {
                Nombre = name,
                Apellido = "Test",
                Email = "test@mail.com",
                Telefono = "123456789",
                FechaNacimiento = DateTime.Now.AddYears(-30),
                Direccion = "123 Test St, Test City, TC 12345"
            }
        );
        return response;
    }
}