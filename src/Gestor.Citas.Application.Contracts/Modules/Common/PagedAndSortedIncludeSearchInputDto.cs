using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace Gestor.Citas.Modules.Common;

public class PagedAndSortedIncludeSearchInputDto: PagedAndSortedResultRequestDto
{
    public string? GeneralSearch { get; set; }
    public List<string> Includes { get; set; } = new();
}