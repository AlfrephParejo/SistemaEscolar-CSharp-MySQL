using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Text;
using CrudEstudiantes.Models;

namespace CrudEstudiantes.Data
{
    public class MaestroDAO
    {

        public void Crear(Maestro maestro)
        {
            string sql = "INSERT INTO maestro (Nombre, Apellido, Correo, Asignatura) VALUES (@Nombre, @Apellido, @Correo, @Asignatura)";


            //obtenemos la conexion a la base de datos
            ConexionDB conexionDB = new ConexionDB();
            using (var conexion = conexionDB.ObtenerConexion())
            {
                conexion.Open();

                //Crear el comando
                MySqlCommand comando = new MySqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@Nombre", maestro.Nombre);
                comando.Parameters.AddWithValue("@Apellido", maestro.Apellido);
                comando.Parameters.AddWithValue("@Correo", maestro.Correo);
                comando.Parameters.AddWithValue("@Asignatura", maestro.Asignatura);


                //Ejecutar el comando
                comando.ExecuteNonQuery();

                Console.WriteLine("Maestro creado exitosamente.");

            }



        }



        public void Listar()
        {
            string sql = "SELECT * FROM maestro";

            //Obtener la conexión a la base de datos
            ConexionDB conexionDB = new ConexionDB();
            using (var conexion = conexionDB.ObtenerConexion())
            {
                conexion.Open();

                // Crear el comando
                MySqlCommand comando = new MySqlCommand(sql, conexion);


                //Leer los registros
                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"ID: {reader["Id"]}, Nombre: {reader["Nombre"]}, Apellido: {reader["Apellido"]}, Correo: {reader["Correo"]}, Asignatura: {reader["Asignatura"]}");

                }

                Console.WriteLine();
                Console.WriteLine("Fin de la lista.");
                Console.ReadKey();


            }


        }




        public List<Maestro> ObtenerTodos()

        {
            List<Maestro> maestros = new List<Maestro>();


            string sql = "SELECT * FROM Maestro";

            //Obtener la conexión a la base de datos
            ConexionDB conexionDB = new ConexionDB();
            using (var conexion = conexionDB.ObtenerConexion())
            {
                conexion.Open();

                //crear comando
                MySqlCommand comando = new MySqlCommand(sql, conexion);


                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {

                    Maestro maestro = new Maestro();

                    maestro.Id = Convert.ToInt32(reader["Id"]);
                    maestro.Nombre = reader["Nombre"].ToString()!;
                    maestro.Apellido = reader["Apellido"].ToString()!;
                    maestro.Correo = reader["Correo"].ToString()!;
                    maestro.Asignatura = reader["Asignatura"].ToString()!;

                    maestros.Add(maestro);
                }

                //que hace esta List?
                //                Antes imprimías directamente:

                //                Console.WriteLine(...)

                //Ahora guardamos cada curso en una lista:

                //                List<Curso> cursos

                //y la devolvemos:

                //                return cursos;

            }

            return maestros;
        }









        public void BuscarPorId(int Id)
        {
            string sql = "SELECT * FROM maestro WHERE Id = @Id";

            //Obtener la conexión a la base de datos
            ConexionDB conexionDB = new ConexionDB();
            using (var conexion = conexionDB.ObtenerConexion())

            {
                conexion.Open();

                // Crear el comando
                MySqlCommand comando = new MySqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@Id", Id);


                //Leer los registros
                MySqlDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    Console.WriteLine($"ID: {reader["Id"]}, Nombre: {reader["Nombre"]}, Apellido: {reader["Apellido"]}, Correo: {reader["Correo"]}, Asignatura: {reader["Asignatura"]}");
                }
                else
                {
                    Console.WriteLine("Maestro no encontrado.");


                }


            }


        }


        public void Actualizar(Maestro maestro)
        {
            string sql = "UPDATE maestro SET Nombre = @Nombre, Apellido = @Apellido, Correo = @Correo, Asignatura = @Asignatura WHERE Id = @Id";

            // Obtener la conexión a la base de datos
            ConexionDB conexionDB = new ConexionDB();
            using(var conexion = conexionDB.ObtenerConexion())
            {

                conexion.Open();

                // Crear el comando
                MySqlCommand comando = new MySqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@Id", maestro.Id);
                comando.Parameters.AddWithValue("@Nombre", maestro.Nombre);
                comando.Parameters.AddWithValue("@Apellido", maestro.Apellido);
                comando.Parameters.AddWithValue("@Correo", maestro.Correo);
                comando.Parameters.AddWithValue("@Asignatura", maestro.Asignatura);


                // Ejecutar el comando

                int filasAfectadas = comando.ExecuteNonQuery();

                if (filasAfectadas > 0)
                {
                    Console.WriteLine("Maestro actualizado exitosamente.");
                }
                else
                {
                    Console.WriteLine("no se encontro maestro");
                }

            }


        }


        public void Eliminar(int Id)
        {
            string sql = "DELETE FROM maestro WHERE Id = @Id";

            // Obtener la conexión a la base de datos
            ConexionDB conexionDB = new ConexionDB();
            using (var conexion = conexionDB.ObtenerConexion())
            {
                conexion.Open();


                // Crear el comando
                MySqlCommand comando = new MySqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@Id", Id);

                // Ejecutar el comando
                int filasAfectadas = comando.ExecuteNonQuery();

                if (filasAfectadas > 0)
                {
                    Console.WriteLine("Maestro eliminado exitosamente.");
                }
                else
                {
                    Console.WriteLine("Error al eliminar el maestro.");
                }

            }




        }

    }
}
