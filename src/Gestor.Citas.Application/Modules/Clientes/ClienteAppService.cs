using System;
using Gestor.Citas.Permissions;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Gestor.Citas.Modules.Clientes;

//[Authorize(CitasPermissions.Clientes.Default)]
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
}