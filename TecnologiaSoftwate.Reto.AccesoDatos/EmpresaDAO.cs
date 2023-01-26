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
   public class EmpresaDAO
    {
         #region "PATRON SINGLETON"
        private static EmpresaDAO daoEmpresa = null;
        private EmpresaDAO() { }
        public static EmpresaDAO getInstance()
        {
            if (daoEmpresa == null)
            {
                daoEmpresa = new EmpresaDAO();
            }
            return daoEmpresa;
        }
        #endregion

        public bool RegistrarEmpresa(Empresa objEmpresa)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            bool response = false;
            con = Conexion.getInstance().ConexionBD();
            cmd = new SqlCommand("spRegistrarEmpresa", con);
            con.Open();

            try
            {
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmEmpresaId", objEmpresa.Identificador);
                cmd.Parameters.AddWithValue("@prmNombre", objEmpresa.Nombre);
                cmd.Parameters.AddWithValue("@prmFechaConstitucion", objEmpresa.FechaConstitucion);
                cmd.Parameters.AddWithValue("@prmTipoEmpresaId", objEmpresa.TipoEmpresa.Identificador);
                cmd.Parameters.AddWithValue("@prmComentarios", objEmpresa.Comentarios);
                int filas = cmd.ExecuteNonQuery();
                if (filas > 0) response = true;
            }
            catch (Exception ex)
            {
                response = false;
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return response;
        }

        public Empresa BuscarEmpresa(Guid Identificador)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            con = Conexion.getInstance().ConexionBD();
            cmd = new SqlCommand("spBuscarEmpresa", con);
            cmd.Parameters.AddWithValue("@prmIdentificador", Identificador);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            dr = cmd.ExecuteReader();
            dr.Read();
            Empresa objEmpresa = new Empresa();
            objEmpresa.Identificador = Guid.Parse(dr["Identificador"].ToString());
            objEmpresa.Nombre = dr["Nombre"].ToString();
            objEmpresa.TipoEmpresa.Identificador = Guid.Parse(dr["TipoEmpresaId"].ToString());
            objEmpresa.FechaConstitucion = DateTime.Parse( dr["FechaConstitucion"].ToString());
            objEmpresa.Comentarios = dr["Comentarios"].ToString();
            con.Close();
            return objEmpresa;
        }
        public List<Empresa> listarEmpresa()
        {
            List<Empresa> Lista = new List<Empresa>();
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                con = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("sp_Empresas", con);                
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Empresa objEmpresa = new Empresa();
                    objEmpresa.Identificador = Guid.Parse(dr["Identificador"].ToString());
                    objEmpresa.Nombre = dr["Nombre"].ToString();
                    objEmpresa.FechaConstitucion = DateTime.Parse( dr["FechaConstitucion"].ToString());
                    objEmpresa.TipoEmpresa.Identificador = Guid.Parse( dr["TipoEmpresaId"].ToString());
                    objEmpresa.TipoEmpresa.NombreTipoEmpresa = dr["NombreTipoEmpresa"].ToString();
                    objEmpresa.Comentarios = dr["Comentarios"].ToString();
                    Lista.Add(objEmpresa);
                }
            }
            catch (Exception ex)
            { throw ex; }
            finally { con.Close(); }
            return Lista;
        }

        public bool EliminarEmpresa(Guid Identificador)
        {
            SqlConnection conexion = null;
            SqlCommand cmd = null;
            bool ok = false;
            try
            {
                conexion = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spEliminarEmpresa", conexion);
                cmd.Parameters.AddWithValue("@prmEmpresaId", Identificador);
                cmd.CommandType = CommandType.StoredProcedure;

                conexion.Open();

                int filas = cmd.ExecuteNonQuery();
                if (filas == 1) ok = true;

            }
            catch (Exception)
            {
                ok = false;
            }
            conexion.Close();
            return ok;
        }


        public bool ModificarEmpresa(Empresa objEmpresa)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            bool response = false;
            try
            {
                con = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spModificarEmpresa", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@prmEmpresaId", objEmpresa.Identificador);
                cmd.Parameters.AddWithValue("@prmNombre", objEmpresa.Nombre);
                cmd.Parameters.AddWithValue("@prmFechaConstitucion", objEmpresa.FechaConstitucion);
                cmd.Parameters.AddWithValue("@prmTipoEmpresaId", objEmpresa.TipoEmpresa.Identificador);
                cmd.Parameters.AddWithValue("@prmComentarios", objEmpresa.Comentarios);
                con.Open();
                int filas = cmd.ExecuteNonQuery();
                if (filas > 0) response = true;
            }
            catch (Exception ex)
            {
                response = false;
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return response;
        }

    }
}
