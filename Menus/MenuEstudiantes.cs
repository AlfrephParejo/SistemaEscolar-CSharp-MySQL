using CrudEstudiantes.Data;
using CrudEstudiantes.Models;
using CrudEstudiantes.Helpers;


namespace CrudEstudiantes.Menus
{
    public class MenuEstudiantes
    {


        private EstudianteDAO dao = new EstudianteDAO();


        public void MostrarMenu()

        {

            bool volver = false;

            while (!volver)
            {
                //Limpia la pantalla antes de volver a mostrar el menú.
                Console.Clear();

                Console.WriteLine("=================================");
                Console.WriteLine("      GESTION DE ESTUDIANTES        ");
                Console.WriteLine("=================================");
                Console.WriteLine("1. Listar estudiantes");
                Console.WriteLine("2. Buscar estudiante por ID");
                Console.WriteLine("3. Crear estudiante");
                Console.WriteLine("4. Actualizar estudiante");
                Console.WriteLine("5. Eliminar estudiante");
                Console.WriteLine("0. VOLVER");
                Console.WriteLine();

                Console.Write("Seleccione una opción: ");


                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        dao.Listar();
                        break;

                    case "2":

                        int idBuscar =
                            Utilidades.LeerEntero("ID del estudiante a buscar: ");

                        dao.BuscarPorId(idBuscar);
                        break;

                    case "3":
                        Console.WriteLine("===Crear estudiante===");

                        Estudiante estudiante = new Estudiante();

                        estudiante.Nombre =
                                Utilidades.LeerTexto("Nombre: ");

                        estudiante.Apellido =
                            Utilidades.LeerTexto("Apellido: ");

                        estudiante.Edad =
                            Utilidades.LeerEntero("Edad: ");

                        estudiante.Correo =
                            Utilidades.LeerTexto("Correo: ");



                        // Mostrar cursos disponibles
                        CursoDAO cursoDAO = new CursoDAO();

                        Console.WriteLine();
                        Console.WriteLine("Cursos disponibles:");

                        foreach (var curso in cursoDAO.ObtenerTodos())
                        {
                            Console.WriteLine(
                                $"{curso.Id} - {curso.Nombre}");
                        }

                        Console.WriteLine();

                        estudiante.CursoId =
                            Utilidades.LeerEntero(
                                "Seleccione el curso: ");

                        Console.WriteLine("Creando estudiante...");

                        dao.Crear(estudiante);

                        break;

                    case "4":
                        Console.WriteLine("===Actualizar estudiante===");

                        Estudiante estudianteActualizar = new Estudiante();

                        estudianteActualizar.Id =
                                Utilidades.LeerEntero("ID del estudiante: ");

                        estudianteActualizar.Nombre =
                            Utilidades.LeerTexto("Nuevo nombre: ");

                        estudianteActualizar.Apellido =
                            Utilidades.LeerTexto("Nuevo apellido: ");

                        estudianteActualizar.Edad =
                            Utilidades.LeerEntero("Nueva edad: ");

                        estudianteActualizar.Correo =
                            Utilidades.LeerTexto("Nuevo correo: ");

                        dao.Update(estudianteActualizar);

                        break;


                    case "5":

                        Console.WriteLine("===Eliminar estudiante===");


                        int idEliminar =
                            Utilidades.LeerEntero("ID del estudiante a eliminar: ");

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