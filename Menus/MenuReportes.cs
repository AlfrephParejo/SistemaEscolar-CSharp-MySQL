using CrudEstudiantes.Data;
using CrudEstudiantes.Models;
using CrudEstudiantes.Helpers;

namespace CrudEstudiantes.Menus
{
    public class MenuReportes
    {

        private ReporteDao dao = new ReporteDao();


        public void MostrarMenu()
        {

            bool volver = false;

            while (!volver)
            {
                Console.Clear();

                Console.WriteLine("=================================");
                Console.WriteLine("           REPORTES"              );
                Console.WriteLine("=================================");
                Console.WriteLine("1. Estudiantes por curso");
                Console.WriteLine("2. Materias por curso");
                Console.WriteLine("3. Maestros y materias");
                Console.WriteLine("0. Volver");

                Console.WriteLine();
                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine()!;

                switch(opcion)
                {
                    case "1":
                        dao.EstudiantePorCurso();
                        break;

                    case "2":
                        dao.MateriasPorCurso();
                        break;
                
                    case "3":
                        dao.MaestrosYMaterias();
                        break;

                    case "0":
                        volver = true;
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;

                }


                if (!volver)
                {
                    Console.WriteLine();
                    Console.WriteLine("Presione una tecla para continuar...");
                    Console.ReadKey();
                }

            }

        }



    }
}
