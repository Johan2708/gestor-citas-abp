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
    private readonly IRepository<Profesional, Guid> _profesionalRepository;

    public CitaAppService(
        IRepository<Cita.Cita, Guid> repository,
        IRepository<Cliente, Guid> clienteRepository,
        IRepository<Profesional, Guid> profesionalRepository)
        : base(repository)
    {
        _clienteRepository = clienteRepository;
        _profesionalRepository = profesionalRepository;
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
        var profesionalQueryable = await _profesionalRepository.GetQueryableAsync();

        //Include related entities if necessary
        var query = from cita in citaQueryable
                    join cliente in clienteQueryable on cita.ClienteId equals cliente.Id
                    join profesional in profesionalQueryable on cita.ProfesionalId equals profesional.Id
                    where cita.Id == id
                    select new
                    {
                        Cita = cita,
                        Cliente = cliente,
                        Profesional = profesional
                    };

        //Execute the query and get the cita with cliente and profesional
        var queryResult = await AsyncExecuter.FirstOrDefaultAsync(query);
        if (queryResult == null)
        {
            throw new EntityNotFoundException(typeof(Cita.Cita), id);
        }

        var citaDto = ObjectMapper.Map<Cita.Cita, CitaDto>(queryResult.Cita);
        citaDto.Cliente = ObjectMapper.Map<Cliente, ClienteDto>(queryResult.Cliente);
        citaDto.Profesional = ObjectMapper.Map<Profesional, ProfesionalDto>(queryResult.Profesional);
        return citaDto;
    }

    public override async Task<PagedResultDto<CitaDto>> GetListAsync(PagedAndSortedIncludeSearchInputDto input)
    {
        var citaQueryable = await Repository.GetQueryableAsync();
        var clienteQueryable = await _clienteRepository.GetQueryableAsync();
        var profesionalQueryable = await _profesionalRepository.GetQueryableAsync();

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

        if (input.Includes?.Contains("profesional", StringComparer.OrdinalIgnoreCase) == true)
        {
            query = query.Join(profesionalQueryable,
                citaJoin => citaJoin.Cita.ProfesionalId,
                profesional => profesional.Id,
                (citaJoin, profesional) => new
                {
                    citaJoin.Cita,
                    citaJoin.Cliente,
                    Profesional = profesional
                });
        }

        //PagingAndSorting
        var validProperties = typeof(Cita.Cita).GetProperties()
            .Select(p => p.Name)
            .ToHashSet(StringComparer.OrdinalIgnoreCase);

        var sorting = !string.IsNullOrWhiteSpace(input.Sorting) && validProperties.Contains(input.Sorting)
            ? $"Cita.{input.Sorting}"
            : "Cita.FechaCita";

        query = query.OrderBy(sorting)
            .Skip(input.SkipCount)
            .Take(input.MaxResultCount);

        var queryResult = await AsyncExecuter.ToListAsync(query);

        var citaDtos = queryResult.Select(x =>
        {
            var citaDto = ObjectMapper.Map<Cita.Cita, CitaDto>(x.Cita);
            if (x.Cliente != null)
                citaDto.Cliente = ObjectMapper.Map<Cliente, ClienteDto>(x.Cliente);
            if (x.Profesional != null)
                citaDto.Profesional = ObjectMapper.Map<Profesional, ProfesionalDto>(x.Profesional);
            return citaDto;
        }).ToList();

        var totalCount = await Repository.GetCountAsync();

        return new PagedResultDto<CitaDto>(
            totalCount,
            citaDtos
        );
    }
}
