using System;
using System.ComponentModel.DataAnnotations;
<<<<<<< Updated upstream
=======
using Gestor.Citas.Modules.Profesionales;
>>>>>>> Stashed changes
using Volo.Abp.Application.Dtos;

namespace Gestor.Citas.Modules.CitasDto;

public class CreateUpdateCitaDto
{
<<<<<<< Updated upstream
    [Required]
    public Guid ClienteId { get; set; }

    [Required]
    public Guid ProfesionalId { get; set; }
    
    [Required]
    public DateTime FechaCita { get; set; }

    [Required]
    [StringLength(500)]
=======
    public string Cliente { get; set; }
    public Guid ProfesionalId { get; set; }
    public DateTime FechaCita { get; set; }
>>>>>>> Stashed changes
    public string Motivo { get; set; }
}
