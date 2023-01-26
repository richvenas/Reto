using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecnologiaSoftwate.Reto.entidades;

namespace TecnologiaSoftwate.Reto.AccesoDatos
{
  public  class TipoEmpresaDAO
    {
          #region "PATRON SINGLETON"
        private static TipoEmpresaDAO daoTipoTipoEmpresa = null;
        private TipoEmpresaDAO() { }
        public static TipoEmpresaDAO getInstance()
        {
            if (daoTipoTipoEmpresa == null)
            {
                daoTipoTipoEmpresa = new TipoEmpresaDAO();
            }
            return daoTipoTipoEmpresa;
        }
        #endregion

        public List<TipoEmpresa> listarTipoEmpresa()
        {
            List<TipoEmpresa> Lista = new List<TipoEmpresa>();
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                con = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("sp_TiposEmpresa", con);
                
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    TipoEmpresa objTipoEmpresa = new TipoEmpresa();
                    objTipoEmpresa.Identificador = Guid.Parse(dr["Identificador"].ToString());
                    objTipoEmpresa.NombreTipoEmpresa = dr["NombreTipoEmpresa"].ToString();                    
                    Lista.Add(objTipoEmpresa);
                }
            }
            catch (Exception ex)
            { throw ex; }
            finally { con.Close(); }
            return Lista;
        }
    }
}
