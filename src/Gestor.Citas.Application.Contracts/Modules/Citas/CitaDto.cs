using System;
using System.ComponentModel.DataAnnotations;
using Gestor.Citas.Modules.Clientes;
using Gestor.Citas.Modules.Profesionales;
using Volo.Abp.Application.Dtos;

namespace Gestor.Citas.Modules.CitasDto;

public class CitaDto : AuditedEntityDto<Guid>
{
    public Guid Id { get; set; }
    public Guid ClienteId { get; set; }
    public Guid ProfesionalId { get; set; }
    public DateTime FechaCita { get; set; }
    public string Motivo { get; set; }
}