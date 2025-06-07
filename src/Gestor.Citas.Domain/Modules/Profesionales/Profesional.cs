using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Gestor.Citas.Modules.Profesionales
{
    public class Profesional : FullAuditedAggregateRoot<Guid>
    {
        public string Nombre { get; set; }
        public string Especializacion { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
    }
}