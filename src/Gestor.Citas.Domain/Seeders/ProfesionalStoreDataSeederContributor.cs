using System;
using System.Threading.Tasks;
using Gestor.Citas.Modules.Profesionales;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;
using Volo.Abp.MultiTenancy;

namespace Gestor.Citas.Seeders
{
    public class ProfesionalStoreDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Profesional, Guid> _profesionalRepository;
        private readonly IGuidGenerator _guidGenerator;
        private readonly ICurrentTenant _currentTenant;

        public ProfesionalStoreDataSeederContributor(
            IRepository<Profesional, Guid> profesionalRepository,
            IGuidGenerator guidGenerator,
            ICurrentTenant currentTenant)
        {
            _profesionalRepository = profesionalRepository;
            _guidGenerator = guidGenerator;
            _currentTenant = currentTenant;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            using (_currentTenant.Change(context?.TenantId))
            {
                if (await _profesionalRepository.GetCountAsync() > 0)
                {
                    return;
                }

                await _profesionalRepository.InsertAsync(
                    new Profesional
                    {
                        Nombre = "Dra. Ana López",
                        Especializacion = "Cardiología",
                        Direccion = "Av. Salud 100",
                        Telefono = "22223333"
                    },
                    autoSave: true
                );

                await _profesionalRepository.InsertAsync(
                    new Profesional
                    {
                        Nombre = "Dr. Juan Pérez",
                        Especializacion = "Pediatría",
                        Direccion = "Calle falsa 200",
                        Telefono = "33334444"
                    },
                    autoSave: true
                );
            }
        }
    }
}