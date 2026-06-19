using CrudEstudiantes.Data;
using MySql.Data.MySqlClient;
using CrudEstudiantes.Models;
using CrudEstudiantes.Helpers;
using CrudEstudiantes.Menus;


bool continuar = true;



while(continuar)
{
    //Limpia la pantalla antes de volver a mostrar el menú.
    Console.Clear();


    Console.WriteLine("=================================");
    Console.WriteLine("      SISTEMA ESCOLAR            ");
    Console.WriteLine("=================================");
    Console.WriteLine("1. Gestión de estudiantes");
    Console.WriteLine("2. Gestión de cursos");
    Console.WriteLine("3. Gestión de maestros");
    Console.WriteLine("4. Gestión de materias");
    Console.WriteLine("5. Reportes");
    Console.WriteLine("0. Salir");
    Console.WriteLine();

    Console.Write("Seleccione una opción: ");

    string opcion = Console.ReadLine();

    switch(opcion)
    {
        case "1":
           new MenuEstudiantes().MostrarMenu();
            break;

        case "2":
           new MenusCursos().MostrarMenu();
            break;

        case "3":
            new MenuMaestros().MostrarMenu();
            break;

        case "4":
            new MenuMaterias().MostrarMenu();
            break;

        case "5":
            new MenuReportes().MostrarMenu();
            break;

        case "0":
            continuar = false;
            break;

        default:
            Console.WriteLine("Opción no válida.");
            break;


    }

}
