using System;
using Gestor.Citas.Modules.Clientes;
using Gestor.Citas.Modules.Profesionales;
using Volo.Abp.Domain.Entities.Auditing;

namespace Gestor.Citas.Modules.Cita;

<<<<<<< Updated upstream
public class Cita : AuditedAggregateRoot<Guid>
{
    public Guid ClienteId { get; set; } 
    public Guid ProfesionalId { get; set; } 
    public DateTime FechaCita { get; set; }
    public string Motivo { get; set; }

    public virtual Profesional Profesional { get; set; } 
    public virtual Cliente Cliente { get; set; } 
=======
public class Cita : FullAuditedAggregateRoot<Guid>
{
    public string  Cliente { get; set; } 

    public Guid ProfesionalId { get; set; }
    public virtual Profesional Profesional { get; set; } 
    public DateTime FechaCita { get; set; }
    public string Motivo { get; set; }
>>>>>>> Stashed changes
}