using System;
using System.Threading.Tasks;
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

    Task<CreateResponse> CreateNewAsync(CreateUpdateClienteDto input);
}