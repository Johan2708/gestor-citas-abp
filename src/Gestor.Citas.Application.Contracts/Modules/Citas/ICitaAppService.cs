using System;
using Gestor.Citas.Modules.Clientes;
using Gestor.Citas.Modules.Common;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Gestor.Citas.Modules.CitasDto;

public interface ICitaAppService:
    ICrudAppService<
    CitaDto,
    Guid,
    PagedAndSortedIncludeSearchInputDto,
    CreateUpdateCitaDto>

{
    
}