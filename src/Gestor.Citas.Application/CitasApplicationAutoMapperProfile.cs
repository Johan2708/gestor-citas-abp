using AutoMapper;
using Gestor.Citas.Books;

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
    }
}
