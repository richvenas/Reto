using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecnologiaSoftwate.Reto.AccesoDatos
{
    class Conexion
    {
        #region "PATRON SINGLETON"
        private static Conexion conexion = null;
        private Conexion()
        {
        }

        public static Conexion getInstance()
        {
            if (conexion == null)
            {
                conexion = new Conexion();
            }
            return conexion;
        }
        #endregion

        public SqlConnection ConexionBD()
        {
            SqlConnection conexion = new SqlConnection();
            //conexion.ConnectionString = " User ID = sa; Password = P@ssw0rd; Initial Catalog = BD_TomaUNO; Server=.";
            conexion.ConnectionString = " User ID = sa; Password = SaSql-16; Initial Catalog = BD_Empresa; Server=.";
            return conexion;
        }
    }
}
