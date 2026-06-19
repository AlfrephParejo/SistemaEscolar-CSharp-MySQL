using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Text;
using CrudEstudiantes.Models;

namespace CrudEstudiantes.Data
{
    public class CursoDAO
    {

        public void Crear(Curso curso)
        {
            string sql = "INSERT INTO cursos (Nombre) VALUES (@Nombre)";

            // creamos una conexion a la base de datos
             ConexionDB conexionDB = new ConexionDB();
            using (var conexion = conexionDB.ObtenerConexion())
            {
                conexion.Open();

                // Crear el comando
                MySqlCommand comando = new MySqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@Nombre", curso.Nombre);


                // Ejecutar INSERT
                // Guardar el curso en la base de datos
                comando.ExecuteNonQuery();

                // mostrar mensaje de éxito
                Console.WriteLine("Curso creado satisfactoriamente.");

            }


        }

        public void Update(Curso curso)
        {

            string sql = "UPDATE cursos SET Nombre = @nombre WHERE Id = @Id";


            // creamos una conexion a la base de datos
            ConexionDB conexionDB = new ConexionDB();
            using ( var conexion = conexionDB.ObtenerConexion())
            {

                conexion.Open();

                // Crear el comando
                MySqlCommand comando = new MySqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@nombre", curso.Nombre);
                comando.Parameters.AddWithValue("@Id", curso.Id);


                // Ejecutar UPDATE
                
                int filasAfectadas = comando.ExecuteNonQuery();


                // CONDICIONAL PARA VER SI SE ACTUALIZÓ O NO EL CURSO
                if (filasAfectadas > 0)
                {
                    Console.WriteLine("Curso actualizado satisfactoriamente.");
                }
                else
                {
                    Console.WriteLine("No se encontró el curso o no se realizó ninguna modificación.");
                }

            }




        }



        public void Delete (int Id)
        {
            string sql = "DELETE FROM cursos WHERE Id = @Id";

            // creamos una conexion a la base de datos
            ConexionDB conexionDB = new ConexionDB();
            using (var conexion = conexionDB.ObtenerConexion())
            {
                conexion.Open();

                //Create the commando
                MySqlCommand comando = new MySqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@Id", Id);

                // Ejecutar DELETE
                int filasAfectadas = comando.ExecuteNonQuery();


                // CONDICIONAL PARA VER SI SE ELIMINÓ O NO EL CURSO
                if (filasAfectadas > 0)
                {
                    Console.WriteLine("Curso eliminado satisfactoriamente.");
                }
                else
                {
                    Console.WriteLine("No se encontró el curso.");
                }



            }


        }




        public void BuscarPorId(int Id)
        {

            string sql = "SELECT * FROM cursos WHERE Id = @Id";

            //Obtener la conexión a la base de datos
            ConexionDB conexionDB = new ConexionDB();
            using (var conexion = conexionDB.ObtenerConexion())
            {
                conexion.Open();

                // Crear el comando
                //El comando ejecutará el SQL.
                MySqlCommand comando = new MySqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@Id", Id);


                //Leer los registros
                MySqlDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    Console.WriteLine($"ID: {reader["Id"]}, Nombre: {reader["Nombre"]}");
                }
                else
                {
                    Console.WriteLine("Curso no encontrado.");
                }


            }


        }




        //Crear un método para listar cursos ya que el anterior solo imprime en pantalla
        //para que devuelva una lista de objetos.
        public List<Curso> ObtenerTodos()
        {
            List<Curso> cursos = new List<Curso>();

            string sql = "SELECT * FROM cursos";


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
                    Curso curso = new Curso();

                    curso.Id =
                        Convert.ToInt32(reader["Id"]);

                    curso.Nombre =
                        reader["Nombre"].ToString()!;


                    cursos.Add(curso);

                }


            }

            return cursos;

        }


        public void Listar()
        {
            string sql = "SELECT * FROM cursos";

            //Obtener la conexión a la base de datos
            ConexionDB conexionDB = new ConexionDB();
            using (var conexion = conexionDB.ObtenerConexion())
            {

                conexion.Open();

                // Crear el comando
                //El comando ejecutará el SQL.
                MySqlCommand comando = new MySqlCommand(sql, conexion);


                //Leer los registros
                //Aquí aparece por primera vez el MySqlDataReader.
                MySqlDataReader reader = comando.ExecuteReader();


                // Recorremos todos los registros devueltos por la consulta
                 while (reader.Read())
                {
                    Console.WriteLine($"ID: {reader["Id"]}, Nombre: {reader["Nombre"]}");
                    
                }

                Console.WriteLine();
                Console.WriteLine("Fin de la lista.");


            }




        }

    }
}
