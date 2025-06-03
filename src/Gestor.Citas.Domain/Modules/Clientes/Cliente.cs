using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Gestor.Citas.Modules.Clientes;

//AggregateRoot<Guid>
//CreationAuditedEntity

public class Cliente : AuditedAggregateRoot<Guid>
{
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Telefono { get; set; }
    public string Email { get; set; }
    public string Direccion { get; set; }
    public DateTime FechaNacimiento { get; set; }
}
    