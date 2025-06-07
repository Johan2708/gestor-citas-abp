using System;

namespace Gestor.Citas.Modules.Profesionales
{
    public class ProfesionalDto
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Especializacion { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
    }
}