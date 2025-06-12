using System;
<<<<<<< Updated upstream
using Gestor.Citas.Modules.Clientes;
=======
using System.ComponentModel.DataAnnotations;
using Gestor.Citas.Modules.Clientes;
using Gestor.Citas.Modules.Profesionales;
>>>>>>> Stashed changes
using Volo.Abp.Application.Dtos;

namespace Gestor.Citas.Modules.CitasDto;

public class CitaDto : AuditedEntityDto<Guid>
{
    public Guid Id { get; set; }
<<<<<<< Updated upstream
    public Guid ClienteId { get; set; }
    public Guid ProfesionalId { get; set; }
=======
    public ProfesionalDto Profesional { get; set; } 
    public string  Cliente { get; set; }
>>>>>>> Stashed changes
    public DateTime FechaCita { get; set; }
    public string Motivo { get; set; }

}