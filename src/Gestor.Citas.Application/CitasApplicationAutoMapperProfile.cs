using AutoMapper;
using Gestor.Citas.Books;
using Gestor.Citas.Modules.Cita;
using Gestor.Citas.Modules.CitasDto;
using Gestor.Citas.Modules.Clientes;

namespace Gestor.Citas;

public class CitasApplicationAutoMapperProfile : Profile
{
    public CitasApplicationAutoMapperProfile()
    {
        CreateMap<Book, BookDto>();
        CreateMap<CreateUpdateBookDto, Book>();
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<Cliente, ClienteDto>();
        CreateMap<CreateUpdateClienteDto, Cliente>();
        CreateMap<Cita, CitaDto>();
        CreateMap<CreateUpdateCitaDto, Cita>();
    }
}
