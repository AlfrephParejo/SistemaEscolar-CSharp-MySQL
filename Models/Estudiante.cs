using System;
using System.Collections.Generic;
using System.Text;


namespace CrudEstudiantes.Models
{
    public class Estudiante
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public string Correo { get; set; }
        public int CursoId { get; set; }


    }
}
