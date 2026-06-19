using CrudEstudiantes.Data;
using CrudEstudiantes.Models;
using CrudEstudiantes.Helpers;

namespace CrudEstudiantes.Menus
{
    public class MenusCursos
    {
        private CursoDAO dao = new CursoDAO();

        public void MostrarMenu()
        {
            bool volver = false;

            while (!volver)
            {
                //Limpia la pantalla antes de volver a mostrar el menú.
                Console.Clear();

                Console.WriteLine("=================================");
                Console.WriteLine("      GESTION DE CURSOS          ");
                Console.WriteLine("=================================");
                Console.WriteLine("1. Listar cursos");
                Console.WriteLine("2. Buscar curso por ID");
                Console.WriteLine("3. Crear curso");
                Console.WriteLine("4. Actualizar curso");
                Console.WriteLine("5. Eliminar curso");
                Console.WriteLine("0. VOLVER");
                Console.WriteLine();    

                Console.Write("Seleccione una opción: ");


                string opcion = Console.ReadLine()!;

                switch (opcion)
                {
                    case "1":
                        dao.Listar();
                        break;
                    case "2":
                        int idBuscar =
                            Utilidades.LeerEntero("ID del curso a buscar: ");
                        dao.BuscarPorId(idBuscar);
                        break;
                    case "3":
                            Curso curso = new Curso();

                        curso.Nombre =
                                Utilidades.LeerTexto("Nombre del curso: ");
                        dao.Crear(curso);
                        break;

                    case "4":
                        Curso cursoActualizar = new Curso
                        {
                            Id =
                                Utilidades.LeerEntero("ID del curso a actualizar: "),

                            Nombre =
                                Utilidades.LeerTexto("Nuevo nombre del curso: ")
                        };

                        dao.Update(cursoActualizar);


                        break; 
    
                        case "5":
                            int idEliminar =
                                Utilidades.LeerEntero("ID del curso a eliminar: ");

                        dao.Delete(idEliminar);

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
