using System;
using Gestor.Citas.Modules.Profesionales;
using Gestor.Citas.Permissions;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Gestor.Citas.Modules.Profesionales
{
    [Authorize(CitasPermissions.Profesionales.Default)]
    public class ProfesionalAppService : CrudAppService<
            Profesional, 
            ProfesionalDto, 
            Guid, 
            PagedAndSortedResultRequestDto, 
            CreateUpdateProfesionalDto>, 
        IProfesionalAppService
    {
        public ProfesionalAppService(IRepository<Profesional, Guid> repository)
            : base(repository)
        {
            GetListPolicyName = CitasPermissions.Profesionales.Default;
            GetPolicyName = CitasPermissions.Profesionales.Create;
            CreatePolicyName = CitasPermissions.Profesionales.Create;
            UpdatePolicyName = CitasPermissions.Profesionales.Edit;
            DeletePolicyName = CitasPermissions.Profesionales.Delete;
        }
    }
}