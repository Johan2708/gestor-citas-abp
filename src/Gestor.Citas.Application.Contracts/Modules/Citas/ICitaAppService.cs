using System;
using Gestor.Citas.Modules.Clientes;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Gestor.Citas.Modules.CitasDto;

public interface ICitaAppService:
    ICrudAppService<
    CitaDto,
    Guid,
    PagedAndSortedResultRequestDto,
    CreateUpdateCitaDto>

{
    
}