using System;
using System.ComponentModel.DataAnnotations;
using Gestor.Citas.Modules.Profesionales;
using Volo.Abp.Application.Dtos;

namespace Gestor.Citas.Modules.CitasDto;

public class CreateUpdateCitaDto
{
    [Required]
    public Guid ClienteId { get; set; }

    [Required]
    public Guid ProfesionalId { get; set; }
    
    [Required]
    public DateTime FechaCita { get; set; }

    [Required]
    [StringLength(500)]
    public string Motivo { get; set; }
}