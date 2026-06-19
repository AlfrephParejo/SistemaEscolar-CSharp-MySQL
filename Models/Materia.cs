using System;
using System.Collections.Generic;
using System.Text;

namespace CrudEstudiantes.Models
{
    public class Materia
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;

        public int MaestroId { get; set; }
        public int CursoId { get; set; }    

    }
}
