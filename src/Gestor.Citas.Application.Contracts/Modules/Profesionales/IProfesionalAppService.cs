using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Gestor.Citas.Modules.Profesionales
{
    public interface IProfesionalAppService :
        ICrudAppService<
            ProfesionalDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateProfesionalDto>
    {
    }
}