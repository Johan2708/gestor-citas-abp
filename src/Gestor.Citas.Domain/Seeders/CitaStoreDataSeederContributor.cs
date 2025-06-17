using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Gestor.Citas.Modules.Cita;
using Gestor.Citas.Modules.Clientes;
using Gestor.Citas.Modules.Profesionales;
using Volo.Abp.Guids;
using Volo.Abp.MultiTenancy;

namespace Gestor.Citas.Domain.Seeders
{
    public class CitaStoreDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
    private readonly IRepository<Cita, Guid> _citaRepository;
    private readonly IGuidGenerator _guidGenerator;
    private readonly ICurrentTenant _currentTenant;
    private readonly IRepository<Cliente, Guid> _clientRepository;
    private readonly IRepository<Profesional, Guid> _profesionalRepository;

         public CitaStoreDataSeederContributor(
        IRepository<Cita, Guid> citaRepository,
        IRepository<Cliente, Guid> clientRepository,
        IRepository<Profesional, Guid> profesionalRepository,
        IGuidGenerator guidGenerator,
        ICurrentTenant currentTenant)
    {
        _citaRepository = citaRepository;
        _guidGenerator = guidGenerator;
        _currentTenant = currentTenant;
        _clientRepository = clientRepository;
        _profesionalRepository = profesionalRepository;
    }

        public async Task SeedAsync(DataSeedContext context)
        {
            using (_currentTenant.Change(context?.TenantId))
            {
                if (await _citaRepository.GetCountAsync() > 0)
                {
                    return;
                }

                var client = await _clientRepository.InsertAsync(
                    new Cliente{
                        Nombre = "Pedro",
                        Apellido = "Lopez",
                        Telefono = "9998122",
                        Email = "pedro.lopez@mail.com",
                        Direccion = "Calle Falsa 123",
                        FechaNacimiento = new DateTime(1990, 1, 1)
                    }, 
                    autoSave: true
                );
                var profesional = await _profesionalRepository.InsertAsync(
                    new Profesional
                    {
                        Nombre = "Dr. Smith",
                        Especializacion = "Cardiología",
                        Telefono = "9876543210",
                        Direccion = "",
                    },
                    autoSave: true
                );

                var cita1 = new Cita
                {
                    ClienteId = client.Id,
                    ProfesionalId = profesional.Id,
                    FechaCita = DateTime.Now,
                    Motivo = "Primera cita de ejemplo"
                };

                var cita2 = new Cita
                {
                    ClienteId = client.Id,
                    ProfesionalId = profesional.Id,
                    FechaCita = DateTime.Now.AddDays(1),
                    Motivo = "Segunda cita de ejemplo"
                };

                await _citaRepository.InsertAsync(cita1, autoSave: true);
                await _citaRepository.InsertAsync(cita2, autoSave: true);
            }
        }
    }
}