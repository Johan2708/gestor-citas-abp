using System;
using System.Threading.Tasks;
using Gestor.Citas.Modules.Common;
using Gestor.Citas.Permissions;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Gestor.Citas.Modules.Clientes;

[Authorize(CitasPermissions.Clientes.Default)]
public class ClienteAppService: CrudAppService<
    Cliente,
    ClienteDto, 
    Guid,
    PagedAndSortedResultRequestDto,
    CreateUpdateClienteDto>, IClienteAppService
{
    public ClienteAppService(IRepository<Cliente, Guid> repository)
        : base(repository)
    {
        GetPolicyName = CitasPermissions.Clientes.Default;
        GetListPolicyName = CitasPermissions.Clientes.Default;
        CreatePolicyName = CitasPermissions.Clientes.Create;
        UpdatePolicyName = CitasPermissions.Clientes.Edit;
        DeletePolicyName = CitasPermissions.Clientes.Delete;
    }

    public async Task<CreateResponse> CreateNewAsync(CreateUpdateClienteDto input)
    {
        var cliente = ObjectMapper.Map<CreateUpdateClienteDto, Cliente>(input);
        var response = await Repository.InsertAsync(cliente);
        return new CreateResponse(response.Id);
    }
}