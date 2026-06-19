using MySql.Data.MySqlClient;

namespace CrudEstudiantes.Data
{
    public class ReporteDao
    {
        public void EstudiantePorCurso()
        {
            string sql = @"SELECT
                    e.Nombre,
                    e.Apellido,
                    c.Nombre AS Curso
                  FROM estudiantes e
                  INNER JOIN cursos c
                    ON e.CursoId = c.Id
                  ORDER BY c.Nombre, e.Apellido";

            //Obtener la conexión a la base de datos
            ConexionDB conexionDB = new ConexionDB();
            using (var conexion = conexionDB.ObtenerConexion())

            {
                conexion.Open();

                // Crear el comando
                MySqlCommand comando =
                    new MySqlCommand(sql, conexion);


                MySqlDataReader reader =
                   comando.ExecuteReader();

                string cursoActual = "";


                while (reader.Read())
                {
                    string curso =
                        reader["Curso"].ToString()!;

                    if (curso != cursoActual)
                    {
                        cursoActual = curso;

                        Console.WriteLine();
                        Console.WriteLine($"===== CURSO {curso} =====");

                    }
                    Console.WriteLine(
                         $"- {reader["Nombre"]} {reader["Apellido"]}");
                }



            }


        }



        public void MateriasPorCurso()
        {

            string sql = @"SELECT 
                          m.Nombre,
                          c.Nombre AS Curso
                          FROM materias m
                          INNER JOIN cursos c
                          ON m.CursoId = c.Id
                          ORDER BY c.Id, m.Nombre";


            //Obtener la conexión a la base de datos
            ConexionDB conexionDB = new ConexionDB();
            using (var conexion = conexionDB.ObtenerConexion())
            {
                conexion.Open();


                // Crear el comando
                MySqlCommand comando =
                    new MySqlCommand(sql, conexion);


                MySqlDataReader reader =
                 comando.ExecuteReader();


                string cursoActual = "";

                while (reader.Read())
                {
                    string curso =
                        reader["Curso"].ToString()!;

                    if (curso != cursoActual)
                    {
                        cursoActual = curso;

                        Console.WriteLine();
                        Console.WriteLine($"===== CURSO {curso} =====");

                    }
                    Console.WriteLine(
                         $"- {reader["Nombre"]}" +
                         $"");


                }

            }

        }



        public void MaestrosYMaterias()
        {
            string sql = @"SELECT
                         CONCAT( ma.Nombre,' ',ma.Apellido) AS maestro,
                          m.Nombre AS Materia,
                          c.Nombre AS Curso                      
                         FROM maestro ma
                         INNER JOIN materias m
                            ON m.MaestroId = ma.Id
                         INNER JOIN cursos c
                            ON m.CursoId = c.Id                    
                         ORDER BY ma.Apellido, c.Nombre";

            //Obtener la conexión a la base de datos
            ConexionDB conexionDB = new ConexionDB();
            using (var conexion = conexionDB.ObtenerConexion())
            {
                conexion.Open();

                // Crear el comando
                MySqlCommand comando =
                    new MySqlCommand(sql, conexion);


                MySqlDataReader reader =
                     comando.ExecuteReader();


                string maestroActual = "";

                while (reader.Read())
                {
                    string maestro =
                      reader["Maestro"].ToString()!;

                    if (maestro != maestroActual)
                    {

                        maestroActual = maestro;

                        Console.WriteLine();
                        Console.WriteLine($"===== Maestro {maestro} =====");


                    }
                    Console.WriteLine(
               $"- {reader["Materia"]} ({reader["Curso"]})");


                }


            }



        }


    }
}
