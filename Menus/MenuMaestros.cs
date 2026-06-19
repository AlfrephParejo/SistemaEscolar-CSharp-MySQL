using CrudEstudiantes.Data;
using CrudEstudiantes.Models;
using CrudEstudiantes.Helpers;




namespace CrudEstudiantes.Menus
{
    public class MenuMaestros
    {
        private MaestroDAO dao = new MaestroDAO();

        public void MostrarMenu()
        {

           bool volver = false;
            while (!volver)
            {

            //Limpia la pantalla antes de volver a mostrar el menú.
            Console.Clear();


            Console.WriteLine("=================================");
            Console.WriteLine("      GESTION DE MAESTROS        ");
            Console.WriteLine("=================================");
            Console.WriteLine("1. Listar Maestros");
            Console.WriteLine("2. Buscar maestro por ID");
            Console.WriteLine("3. Crear maestro");
            Console.WriteLine("4. Actualizar maestro");
            Console.WriteLine("5. Eliminar maestro");
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
                            Utilidades.LeerEntero("ID del maestro a buscar: ");
                        dao.BuscarPorId(idBuscar);
                        break;

                    case "3":
                            Maestro maestro = new Maestro();
                        maestro.Nombre =
                                Utilidades.LeerTexto("Nombre del maestro: ");
                        maestro.Apellido =
                                Utilidades.LeerTexto("Apellido del maestro: ");
                        maestro.Asignatura =
                                Utilidades.LeerTexto("Asignatura del maestro: ");
                        maestro.Correo =
                                Utilidades.LeerTexto("Correo del maestro: ");

                        Console.WriteLine("Creando maestro...");
                        dao.Crear(maestro);
                        break;
                
                        case "4":

                        Maestro ActualizarMaestro = new Maestro();
                        ActualizarMaestro.Id =
                            Utilidades.LeerEntero("Id del maestro");
                            ActualizarMaestro.Nombre =
                                Utilidades.LeerTexto("Nombre del maestro: ");
                            ActualizarMaestro.Apellido =
                                Utilidades.LeerTexto("Apellido del maestro: ");
                            ActualizarMaestro.Asignatura =
                                Utilidades.LeerTexto("Asignatura del maestro: ");
                            ActualizarMaestro.Correo =
                                Utilidades.LeerTexto("Correo del maestro: ");
                        
                        
                        dao.Actualizar(ActualizarMaestro);
                        break;

                        case "5":
                            int idEliminar = Utilidades.LeerEntero("ID del maestro a eliminar: ");
                            dao.Eliminar(idEliminar);
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
