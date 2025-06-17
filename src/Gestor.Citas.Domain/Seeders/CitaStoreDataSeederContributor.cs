using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Gestor.Citas.Domain; // Add this if 'Cita' is in this namespace, or update to the correct one
using Volo.Abp.Domain.Repositories;
using Gestor.Citas.Modules.Cita;
using Volo.Abp.Guids;
using Volo.Abp.MultiTenancy;

namespace Gestor.Citas.Domain.Seeders
{
    public class CitaStoreDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
    private readonly IRepository<Cita, Guid> _citaRepository;
    private readonly IGuidGenerator _guidGenerator;
    private readonly ICurrentTenant _currentTenant;

         public CitaStoreDataSeederContributor(
        IRepository<Cita, Guid> citaRepository,
        IGuidGenerator guidGenerator,
        ICurrentTenant currentTenant)
    {
        _citaRepository = citaRepository;
        _guidGenerator = guidGenerator;
        _currentTenant = currentTenant;
    }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _citaRepository.GetCountAsync() > 0)
            {
                return;
            }

            var cita1 = new Cita
            {
                ClienteId = _guidGenerator.Create(),
                ProfesionalId = _guidGenerator.Create(),
                FechaCita = DateTime.Now,
                Motivo = "Primera cita de ejemplo"
            };

            var cita2 = new Cita
            {
                 ClienteId = _guidGenerator.Create(),
                 ProfesionalId = _guidGenerator.Create(),
                 FechaCita = DateTime.Now.AddDays(1),
                 Motivo = "Segunda cita de ejemplo"
            };

            await _citaRepository.InsertAsync(cita1, autoSave: true);
            await _citaRepository.InsertAsync(cita2, autoSave: true);
        }
    }
}