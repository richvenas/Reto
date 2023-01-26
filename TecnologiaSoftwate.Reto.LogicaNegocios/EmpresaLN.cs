using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecnologiaSoftwate.Reto.AccesoDatos;
using TecnologiaSoftwate.Reto.entidades;

namespace TecnologiaSoftwate.Reto.LogicaNegocios
{
   public  class EmpresaLN
    {

        #region "PATRON SINGLETON"
        private static EmpresaLN objEmpresa = null;
        private EmpresaLN() { }
        public static EmpresaLN getInstance()
        {
            if (objEmpresa == null)
            {
                objEmpresa = new EmpresaLN();
            }
            return objEmpresa;
        }
        #endregion


        public bool RegistrarEmpresa(Empresa objEmpresa)
        {
            try
            {
                return EmpresaDAO.getInstance().RegistrarEmpresa(objEmpresa);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool ModificarEmpresa(Empresa objEmpresa)
        {
            try
            {
                return EmpresaDAO.getInstance().ModificarEmpresa(objEmpresa);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Empresa> listarEmpresa()
        {
            try
            {
                return EmpresaDAO.getInstance().listarEmpresa();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public Empresa BuscarEmpresa(Guid empresaId)
        {
            try
            {
                return EmpresaDAO.getInstance().BuscarEmpresa(empresaId);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool EliminarEmpresa(Guid Identificador)
        {
            try
            {

                return EmpresaDAO.getInstance().EliminarEmpresa(Identificador);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
