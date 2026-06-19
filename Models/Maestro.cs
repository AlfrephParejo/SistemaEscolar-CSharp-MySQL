using System;
using System.Collections.Generic;
using System.Text;

namespace CrudEstudiantes.Models
{
    public class Maestro
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Asignatura { get; set; } = string.Empty; 
        public string Correo { get; set; } = string.Empty;



    }
}
