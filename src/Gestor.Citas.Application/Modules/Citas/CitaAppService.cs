using System;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Gestor.Citas.Modules.CitasDto;
using Gestor.Citas.Modules.Clientes;
using Gestor.Citas.Modules.Common;
using Gestor.Citas.Modules.Profesionales;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Gestor.Citas.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities; // Add this line or update with the correct namespace

namespace Gestor.Citas.Modules.Citas;

public class CitaAppService : CrudAppService<
    Cita.Cita,
    CitaDto,
    Guid,
    PagedAndSortedIncludeSearchInputDto,
    CreateUpdateCitaDto>, ICitaAppService
{
    private readonly IRepository<Cliente, Guid> _clienteRepository;
    public CitaAppService(IRepository<Cita.Cita, Guid> repository,
        IRepository<Cliente, Guid> clienteRepository) :
        base(repository)
    {
        _clienteRepository = clienteRepository;
        GetPolicyName = CitasPermissions.Citas.Default;
        GetListPolicyName = CitasPermissions.Citas.Default;
        CreatePolicyName = CitasPermissions.Citas.Create;
        UpdatePolicyName = CitasPermissions.Citas.Edit;
        DeletePolicyName = CitasPermissions.Citas.Delete;
        
    }
    
    public override async Task<CitaDto> GetAsync(Guid id)
    {
        var citaQueryable = await Repository.GetQueryableAsync();
        var clienteQueryable = await _clienteRepository.GetQueryableAsync();
        
        //Include related entities if necessary
        var query = from cita in citaQueryable
            join cliente in clienteQueryable on cita.ClienteId equals cliente.Id
            where cita.Id == id
            select new
            {
                Cita = cita,
                Cliente = cliente
            };
        
        //Execute the query and get the book with author
        var queryResult = await AsyncExecuter.FirstOrDefaultAsync(query);
        if (queryResult == null)
        {
            throw new EntityNotFoundException(typeof(Cita.Cita), id);
        }
        
        var citaDto = ObjectMapper.Map<Cita.Cita, CitaDto>(queryResult.Cita);
        citaDto.Cliente = ObjectMapper.Map<Cliente, ClienteDto>(queryResult.Cliente);
        return citaDto;
    }
    
    public override async Task<PagedResultDto<CitaDto>> GetListAsync(PagedAndSortedIncludeSearchInputDto input)
    {
        var citaQueryable = await Repository.GetQueryableAsync();
        var clienteQueryable = await _clienteRepository.GetQueryableAsync();

        var query = from cita in citaQueryable
            select new
            {
                Cita = cita,
                Cliente = (Cliente?)null,
                Profesional = (Profesional?)null
            };

        if (input.Includes?.Contains("cliente", StringComparer.OrdinalIgnoreCase) == true)
        {
            query = query.Join(clienteQueryable,
                citaJoin => citaJoin.Cita.ClienteId,
                cliente => cliente.Id,
                (citaJoin, cliente) => new
                {
                    citaJoin.Cita,
                    Cliente = cliente,
                    citaJoin.Profesional
                });
        }
        
        //PagingAndSorting
        // Obtener las propiedades válidas de la entidad Cita
        var validProperties = typeof(Cita.Cita).GetProperties()
            .Select(p => p.Name)
            .ToHashSet(StringComparer.OrdinalIgnoreCase);

        // Validar que input.Sorting sea una propiedad válida
        var sorting = validProperties.Contains(input.Sorting)
            ? $"Cita.{input.Sorting}"
            : "Cita.FechaCita"; // Propiedad por defecto si no es válida

        // Aplicar ordenamiento dinámico
        query = query.OrderBy(sorting)
            .Skip(input.SkipCount)
            .Take(input.MaxResultCount);

        //Execute the query and get a list
        var queryResult = await AsyncExecuter.ToListAsync(query);
        
        //Convert the query result to a list of CitaDto objects
        var citaDtos = queryResult.Select(x =>
        {
            var citaDto = ObjectMapper.Map<Cita.Cita, CitaDto>(x.Cita);
            citaDto.Cliente = ObjectMapper.Map<Cliente, ClienteDto>(x.Cliente);
            return citaDto;
        }).ToList();
        
        //Get the total count with another query
        var totalCount = await Repository.GetCountAsync();
        
        return new PagedResultDto<CitaDto>(
            totalCount,
            citaDtos
        );
    }
}
