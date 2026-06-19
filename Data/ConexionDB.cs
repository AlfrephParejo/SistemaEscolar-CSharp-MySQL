using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace CrudEstudiantes.Data
{
    public class ConexionDB
    {
        private string cadenaConexion =
            "server=localhost;port=3306;database=colegio;user=root;password=Root2016";

        public MySqlConnection ObtenerConexion()
        {      
            return new MySqlConnection(cadenaConexion);
        }


    }
}
