using System;
using Volo.Abp.Application.Dtos;

namespace Gestor.Citas.Modules.Clientes;

public class ClienteDto : AuditedEntityDto<Guid>
{
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Telefono { get; set; }
    public string Email { get; set; }
    public string Direccion { get; set; }
    public DateTime FechaNacimiento { get; set; }
}