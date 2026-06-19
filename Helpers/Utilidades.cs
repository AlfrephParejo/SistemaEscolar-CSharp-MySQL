using System;
using System.Collections.Generic;
using System.Text;

namespace CrudEstudiantes.Helpers
{
    internal class Utilidades
    {

        public static string LeerTexto(string mensaje)
        {

            string valor;

            do
            {
                Console.Write(mensaje);
                valor = Console.ReadLine();


            }
            while (string.IsNullOrWhiteSpace(valor));

            return valor;
        }



        public static int LeerEntero(string mensaje)
        {
            int valor;

            Console.Write(mensaje);


            while (!int.TryParse(Console.ReadLine(), out valor))
            {
                Console.Write("Entrada inválida. Por favor, ingrese un número entero: ");

            }

            return valor;


        }




    }
}
