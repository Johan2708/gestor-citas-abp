using System;
using Gestor.Citas.Modules.Clientes;
using Volo.Abp.Domain.Entities.Auditing;

namespace Gestor.Citas.Modules.Cita;

public class Cita : AuditedAggregateRoot<Guid>
{
    public Guid Id { get; set; }
    public Guid ClienteId { get; set; } 
    public virtual Cliente Cliente { get; set; } 

    public Guid EmpleadoId { get; set; } 
    //public virtual Empleado Empleado { get; set; } 

    public DateTime FechaCita { get; set; }
    public string Motivo { get; set; }

    public Cita()
    {
        Id = Guid.NewGuid();
    }
}