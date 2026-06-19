using CrudEstudiantes.Models;
using MySql.Data.MySqlClient;
using System;

namespace CrudEstudiantes.Data
{
    internal class MateriaDAO
    {
        public void Crear(Materia materia)
        {
            string sql = "INSERT INTO materias (Nombre, CursoId, MaestroId) VALUES (@Nombre, @CursoId, @MaestroId)";

            //obtenemos la conexion a la base de datos
            ConexionDB conexionDB = new ConexionDB();
            using (var conexion = conexionDB.ObtenerConexion())
            {
                conexion.Open();


                //Crear el comando
                MySqlCommand comando = new MySqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@Id", materia.Id);
                comando.Parameters.AddWithValue("@Nombre", materia.Nombre);
                comando.Parameters.AddWithValue("@CursoId", materia.CursoId);
                comando.Parameters.AddWithValue("@MaestroId", materia.MaestroId);

                //Ejecutar INSERT

                comando.ExecuteNonQuery();

                Console.WriteLine("Materia Agregada Satisfactoriamente");


            }

        }


        public void Listar()
        {
            string sql = "SELECT\r\n" +
                "    m.Id,\r\n" +
                "    m.Nombre AS Materia,\r\n" +
                "    c.Nombre AS Curso,\r\n" +
                "    CONCAT(ma.Nombre, ' ', ma.Apellido) AS Maestro\r\n" +
                "FROM materias m\r\nINNER JOIN cursos c\r\n" +
                "    ON m.CursoId = c.Id\r\n" +
                "INNER JOIN maestro ma\r\n" +
                "    ON m.MaestroId = ma.Id;";

            //Obtener la conexión a la base de datos
            ConexionDB conexionDB = new ConexionDB();
            using (var conexion = conexionDB.ObtenerConexion())
            {
                conexion.Open();

                //crear comando
                MySqlCommand comando = new MySqlCommand(sql, conexion);


                //Leer los registros
                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine(
        $"ID: {reader["Id"]}, " +
        $"Materia: {reader["Materia"]}, " +
        $"Curso: {reader["Curso"]}, " +
        $"Maestro: {reader["Maestro"]}"
    );
                }

                Console.WriteLine();
                Console.WriteLine("Fin de la lista.");
                Console.ReadKey();
            }
        }







        public void BuscarPorId(int Id)
        {
            string sql = "SELECT\r\n" +
                  "    m.Id,\r\n" +
                  "    m.Nombre AS Materia,\r\n" +
                  "    c.Nombre AS Curso,\r\n" +
                  "    CONCAT(ma.Nombre, ' ', ma.Apellido) AS Maestro\r\n" +
                  "FROM materias m\r\nINNER JOIN cursos c\r\n" +
                  "    ON m.CursoId = c.Id\r\n" +
                  "INNER JOIN maestro ma\r\n" +
                  "    ON m.MaestroId = ma.Id;" +
                  "WHERE m.Id = @Id"; 

            // Obtener la conexion a la base de datos 
            ConexionDB conexionDB = new ConexionDB();
            using (var conexion = conexionDB.ObtenerConexion())
            {
                conexion.Open();


                //Crear comando
                MySqlCommand comando = new MySqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@Id", Id);

                //leer los resgistros
                MySqlDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    Console.WriteLine();
                    Console.WriteLine($"ID: {reader["Id"]}");
                    Console.WriteLine($"Materia: {reader["Materia"]}");
                    Console.WriteLine($"Curso: {reader["Curso"]}");
                    Console.WriteLine($"Maestro: {reader["Maestro"]}");
     
                }
                else
                {
                    Console.WriteLine("Materia no encontrada");
                }



            }
        }


        public void Actualizar(Materia materia)
        {
            string sql = @"UPDATE materias
                   SET Nombre = @Nombre,
                       CursoId = @CursoId,
                       MaestroId = @MaestroId
                   WHERE Id = @Id";

            //obtener conexion a base de datos
            ConexionDB conexionDB = new ConexionDB();
            using (var conexion = conexionDB.ObtenerConexion())
            {
                conexion.Open();

                //crear comando
                MySqlCommand comando = new MySqlCommand(sql, conexion);

                comando.Parameters.AddWithValue("@Id", materia.Id);
                comando.Parameters.AddWithValue("@Nombre", materia.Nombre);
                comando.Parameters.AddWithValue("@CursoId", materia.CursoId);
                comando.Parameters.AddWithValue("@MaestroId", materia.MaestroId);

                int filasAfectadas = comando.ExecuteNonQuery();

                if (filasAfectadas > 0)
                {
                    Console.WriteLine("Materia actualizada...");

                }
                else
                {
                    Console.WriteLine("No se encontró materia o no se realizó ninguna modificación.");
                }


            }

        }

        public void Delete(int Id)
        {
            string sql = "DELETE FROM Materias WHERE Id = @Id";

            ConexionDB conexionDB = new ConexionDB();
            using (var conexion = conexionDB.ObtenerConexion())
            {
                conexion.Open();

                // crear comando
                MySqlCommand comando = new MySqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@Id", Id);


                int filasAfectadas = comando.ExecuteNonQuery();

                if (filasAfectadas > 0)
                {
                    Console.WriteLine("materia eliminada satisfactoriamente");
                }
                else
                {
                    Console.WriteLine("No se encontró el curso.");
                }

            }

        }


    }
}
