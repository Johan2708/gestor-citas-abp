using System;
using Gestor.Citas.Modules.Profesionales;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Gestor.Citas.Modules.Profesionales
{
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
        }
    }
}