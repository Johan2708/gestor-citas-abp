using System;
using System.Threading.Tasks;
using Gestor.Citas.Modules.Clientes;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;
using Volo.Abp.MultiTenancy;

namespace Gestor.Citas.Seeders;

public class ClientStoreDataSeederContributor: IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<Cliente, Guid> _clientRepository;
    private readonly IGuidGenerator _guidGenerator;
    private readonly ICurrentTenant _currentTenant;

    public ClientStoreDataSeederContributor(
        IRepository<Cliente, Guid> clientRepository,
        IGuidGenerator guidGenerator,
        ICurrentTenant currentTenant)
    {
        _clientRepository = clientRepository;
        _guidGenerator = guidGenerator;
        _currentTenant = currentTenant;
    }
        
    public async Task SeedAsync(DataSeedContext context)
    {
        using (_currentTenant.Change(context?.TenantId))
        {
            if (await _clientRepository.GetCountAsync() > 0)
            {
                return;
            }
            
            await _clientRepository.InsertAsync(
                new Cliente{
                    Nombre = "John",
                    Apellido = "Doe",
                    Telefono = "1234567890",
                    Email = "john.doe@mail.com",
                    Direccion = "123 Main St",
                    FechaNacimiento = new DateTime(1990, 1, 1)
                }, 
                autoSave: true
            );

            await _clientRepository.InsertAsync(
                new Cliente
                {
                    Nombre = "Jane",
                    Apellido = "Smith",
                    Telefono = "0987654321",
                    Email = "jane.smith@mail.com",
                    Direccion = "456 Elm St",
                    FechaNacimiento = new DateTime(1992, 2, 2)
                },
                autoSave: true
            );
        }
    }
}