using System;
using Gestor.Citas.Modules.CitasDto;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Gestor.Citas.Modules.Citas;

public class CitaAppService : CrudAppService<
    Cita.Cita,
    CitaDto,
    Guid,
    PagedAndSortedResultRequestDto,
    CreateUpdateCitaDto>, ICitaAppService
{
    public CitaAppService(IRepository<Cita.Cita, Guid> repository) :
        base(repository)
    {
        
    }
    
}
