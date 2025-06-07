using System;
using Gestor.Citas.Modules.Clientes;
using Volo.Abp.Application.Dtos;

namespace Gestor.Citas.Modules.CitasDto;

public class CitaDto : AuditedEntityDto<Guid>
{
    public Guid Id { get; set; }
    public Guid ClienteId { get; set; }
    public ClienteDto Cliente { get; set; }
    public Guid EmpleadoId { get; set; }
   // public ProfesionalDto Profesional { get; set; } 
    public DateTime FechaCita { get; set; }
    public string Motivo { get; set; }

}