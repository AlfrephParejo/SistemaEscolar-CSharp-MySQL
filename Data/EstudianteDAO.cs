using CrudEstudiantes.Models;
using MySql.Data.MySqlClient;
using System;


namespace CrudEstudiantes.Data 
{
    public class EstudianteDAO
    {
        public void Crear(Estudiante estudiante)
        {
            string sql = "INSERT INTO estudiantes (Nombre, Apellido, Edad, Correo, CursoId) VALUES (@Nombre, @Apellido, @Edad, @Correo, @CursoId)";

            //Obtener la conexión a la base de datos
            ConexionDB conexionDB = new ConexionDB();
            using (var conexion = conexionDB.ObtenerConexion())
            {
                conexion.Open();
                // Crear el comando
                //El comando ejecutará el SQL.
                MySqlCommand comando = new MySqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@Nombre", estudiante.Nombre);
                comando.Parameters.AddWithValue("@Apellido", estudiante.Apellido);
                comando.Parameters.AddWithValue("@Edad", estudiante.Edad);
                comando.Parameters.AddWithValue("@Correo", estudiante.Correo);
                comando.Parameters.AddWithValue("@CursoId", estudiante.CursoId);

                //ingresar registros

                //Aquí aparece por primera vez el MySqlDataReader.
                comando.ExecuteNonQuery();
                Console.WriteLine("Estudiante creado exitosamente.");

            };

        }



        //Crear el método Listar()
        public void Listar()
        {
            string sql = "SELECT e.Id,\r\n    e.Nombre,\r\n    e.Apellido,\r\n    e.Edad,\r\n    e.Correo,\r\n    c.Nombre AS Curso\r\nFROM estudiantes e\r\nINNER JOIN cursos c\r\n    ON e.CursoId = c.Id";


            //Obtener la conexión a la base de datos
            ConexionDB conexionDB = new ConexionDB();
            using(var conexion = conexionDB.ObtenerConexion())
                {
                conexion.Open();


                // Crear el comando
                //El comando ejecutará el SQL.
                MySqlCommand comando = new MySqlCommand(sql, conexion);



                //Leer los registros
                //Aquí aparece por primera vez el MySqlDataReader.
                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {

                    Console.WriteLine(
     $"ID: {reader["Id"]}, " +
     $"Nombre: {reader["Nombre"]}, " +
     $"Apellido: {reader["Apellido"]}, " +
     $"Edad: {reader["Edad"]}, " +
     $"Correo: {reader["Correo"]}, " +
     $"Curso: {reader["Curso"]}"
 );
                }                                  

            }         

        }

        public void Update(Estudiante estudiante)
        {
            string sql = "UPDATE estudiantes SET  Nombre = @Nombre, Apellido = @Apellido, Edad = @Edad, Correo = @Correo, CursoId = @CursoId WHERE Id = @Id ";


            //Obtener la conexión a la base de datos
            ConexionDB conexionDB = new ConexionDB();
            using ( var conexion = conexionDB.ObtenerConexion() )
            {

                conexion.Open();


                // Crear el comando
                //El comando ejecutará el SQL.
                MySqlCommand comando = new MySqlCommand(sql, conexion);

                comando.Parameters.AddWithValue("@Id", estudiante.Id);
                comando.Parameters.AddWithValue("@Nombre", estudiante.Nombre);
                comando.Parameters.AddWithValue("@Apellido", estudiante.Apellido);
                comando.Parameters.AddWithValue("@Edad", estudiante.Edad);
                comando.Parameters.AddWithValue("@Correo", estudiante.Correo);  
                comando.Parameters.AddWithValue("@CursoId", estudiante.CursoId);

                //Leer los registros o ejecutar registros
                comando.ExecuteNonQuery();

                Console.WriteLine("Estudiante actualizado exitosamente.");

            }

        }


        public void Delete(int Id)
        {
            string sql = "DELETE FROM estudiantes WHERE id = @ID";


            //Obtener la conexión a la base de datos
            ConexionDB conexionDB = new ConexionDB();
            using (var conexion = conexionDB.ObtenerConexion())
            {
                conexion.Open();

                MySqlCommand comando = new MySqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@ID", Id);

                //Leer los registros o ejecutar registros
                int filasAfectadas = comando.ExecuteNonQuery();

                if (filasAfectadas > 0)
                {
                    Console.WriteLine("Estudiante eliminado exitosamente.");
                }
                else
                {
                    Console.WriteLine("Estudiante no encontrado.");
                }

               


            }


        }


        public void BuscarPorId(int id)
        {
            string sql = "SELECT * FROM estudiantes Where Id = @Id";

            //Obtener la conexión a la base de datos
            ConexionDB conexionDB = new ConexionDB();
            using (var conexion = conexionDB.ObtenerConexion())
            { conexion.Open();

                // Crear el comando
                //El comando ejecutará el SQL.
                MySqlCommand comando = new MySqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@Id", id);

                //Leer los registros
                //Aquí aparece por primera vez el MySqlDataReader.
                MySqlDataReader reader = comando.ExecuteReader();


                if (reader.Read())
                {
                    Console.WriteLine($"ID: {reader["Id"]}, Nombre: {reader["Nombre"]}, Apellido: {reader["Apellido"]}, Edad: {reader["Edad"]}, Correo: {reader["Correo"]}");
                }
                else
                {
                    Console.WriteLine("Estudiante no encontrado.");

                }

            }



        }

        //public void Update(Estudiante estudiante)
        //{
        //    string sql = "UPDATE estudiantes SET Nombre = @Nombre, Apellido = @Apellido, Edad = @Edad, Correo = @Correo WHERE Id = @Id";
        //}





    }
}
