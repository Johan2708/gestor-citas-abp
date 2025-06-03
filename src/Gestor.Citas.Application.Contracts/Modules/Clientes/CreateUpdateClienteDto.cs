using System;
using System.ComponentModel.DataAnnotations;

namespace Gestor.Citas.Modules.Clientes;

public class CreateUpdateClienteDto
{
    [Required]
    [StringLength(250)]
    public string Nombre { get; set; }
    
    [Required]
    [StringLength(250)]
    public string Apellido { get; set; }
    
    [Required]
    [StringLength(15)]
    public string Telefono { get; set; }
    
    [Required]
    [StringLength(250)]
    public string Email { get; set; }
    
    [Required]
    [StringLength(500)]
    public string Direccion { get; set; }
    
    [DataType(DataType.Date)]
    public DateTime FechaNacimiento { get; set; }
}