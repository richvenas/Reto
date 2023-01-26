using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecnologiaSoftwate.Reto.entidades;
using TecnologiaSoftwate.Reto.AccesoDatos;

namespace TecnologiaSoftwate.Reto.LogicaNegocios
{
    class TipoEmpresaLN
    {
        #region "PATRON SINGLETON"
        private static TipoEmpresaLN objTipoEmpresa = null;
        private TipoEmpresaLN() { }
        public static TipoEmpresaLN getInstance()
        {
            if (objTipoEmpresa == null)
            {
                objTipoEmpresa = new TipoEmpresaLN();
            }
            return objTipoEmpresa;
        }
        #endregion

        public List<TipoEmpresa> listarTipoEmpresa()
        {
            try
            {
                return TipoEmpresaDAO.getInstance().listarTipoEmpresa();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
