using CrudEstudiantes.Data;
using CrudEstudiantes.Models;
using CrudEstudiantes.Helpers;


namespace CrudEstudiantes.Menus
{
    public class MenuMaterias
    {
        private MateriaDAO dao = new MateriaDAO();
        private CursoDAO cursoDAO = new CursoDAO();
        private MaestroDAO maestroDAO = new MaestroDAO();


        public void MostrarMenu()
        {
            
            
            bool volver = false;


            while (!volver)
            {
                //Limpia la pantalla antes de volver a mostrar el menú.
                Console.Clear();


                Console.WriteLine("=================================");
                Console.WriteLine("      GESTION MATERIAS           ");
                Console.WriteLine("=================================");
                Console.WriteLine("1. Listar Materias");
                Console.WriteLine("2. Buscar Materia por ID");
                Console.WriteLine("3. Asignar nueva Materia");
                Console.WriteLine("4. Actualizar Materia");
                Console.WriteLine("5. Eliminar Materia");
                Console.WriteLine("0. VOLVER");
                Console.WriteLine();


                Console.Write("Seleccione una opción: ");


                string opcion = Console.ReadLine();

                switch(opcion)
                {
                    case "1":
                        dao.Listar();

                        break; 
                    
                    case "2":
                        int idBuscar =
                            Utilidades.LeerEntero("ID del maestro a buscar: ");
                        dao.BuscarPorId(idBuscar);
                     break;

                   case "3":

                        Materia materia = new Materia();

                        materia.Nombre =
                            Utilidades.LeerTexto("Nombre de la materia ");

                        Console.WriteLine();
                        Console.WriteLine("Cursos disponibles:");

                        List<Curso> cursos = cursoDAO.ObtenerTodos();

                        foreach (Curso curso in cursos)
                        {
                            Console.WriteLine($"{curso.Id} - {curso.Nombre}");
                        }

                        materia.CursoId =
                       Utilidades.LeerEntero("Selecciona el curso");


                        Console.WriteLine();
                        Console.WriteLine("Maestros disponibles:");

                        List<Maestro> maestros = maestroDAO.ObtenerTodos();

                        foreach (Maestro maestro in maestros)
                        {
                            Console.WriteLine($"{maestro.Id} - {maestro.Nombre} {maestro.Apellido}");
                        }
                                                                   
                        materia.MaestroId =
                            Utilidades.LeerEntero("Sleccion de MAestro");


                        Console.WriteLine("Asignando Materia...");
                        dao.Crear(materia);

                        break;

                   case "4":

                        Materia materiaActualizar = new Materia();

                        materiaActualizar.Id =
                            Utilidades.LeerEntero("Id de la materia");

                        materiaActualizar.Nombre =
                            Utilidades.LeerTexto("Nombre de la materia ");


                   
                        Console.WriteLine();
                        Console.WriteLine("Cursos disponibles:");

                        foreach (Curso curso in cursoDAO.ObtenerTodos())
                        {
                            Console.WriteLine($"{curso.Id} - {curso.Nombre}");
                        }


                        materiaActualizar.CursoId =
                            Utilidades.LeerEntero("Id del curso");


                        Console.WriteLine();
                        Console.WriteLine("Maestros disponibles:");

                        foreach (Maestro maestro in maestroDAO.ObtenerTodos())
                        {
                            Console.WriteLine($"{maestro.Id} - {maestro.Nombre} {maestro.Apellido}");
                        }

                        materiaActualizar.MaestroId =
                            Utilidades.LeerEntero("Sleccionar maestro: ");



                        dao.Actualizar(materiaActualizar);

                       break;


                   case "5":

                        int idEliminar =
                        Utilidades.LeerEntero("ID de la materia a eliminar: ");

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

