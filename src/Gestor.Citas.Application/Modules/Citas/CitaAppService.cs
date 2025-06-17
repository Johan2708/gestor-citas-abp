using System;
using Gestor.Citas.Modules.CitasDto;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Gestor.Citas.Permissions; // Add this line or update with the correct namespace

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

        GetPolicyName = CitasPermissions.Citas.Default;
        GetListPolicyName = CitasPermissions.Citas.Default;
        CreatePolicyName = CitasPermissions.Citas.Create;
        UpdatePolicyName = CitasPermissions.Citas.Edit;
        DeletePolicyName = CitasPermissions.Citas.Delete;
        
    }
    
}
