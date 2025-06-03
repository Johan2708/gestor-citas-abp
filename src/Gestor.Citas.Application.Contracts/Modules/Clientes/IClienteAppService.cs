using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Gestor.Citas.Modules.Clientes;

public interface IClienteAppService: 
    ICrudAppService<
        ClienteDto, 
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateClienteDto>
{
    
}