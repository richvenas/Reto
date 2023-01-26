using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using TecnologiaSoftwate.Reto.entidades;
using TecnologiaSoftwate.Reto.LogicaNegocios;

namespace TecnologiaSoftwate.Reto.WEB
{
    public partial class Empresas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static List<Empresa> empresas() 
        {
            List<Empresa> Lista = null;
            try 
            {
                Lista = EmpresaLN.getInstance().listarEmpresa();
            }
            catch (Exception)
            { 
            }
            return Lista;
        }

        [WebMethod]
        public static bool EliminarEmpresa(Guid id)
        {
            bool ok = false;
            ok = EmpresaLN.getInstance().EliminarEmpresa(id);
            return ok;
        }

        [WebMethod]
        public static bool RegistrarEmpresa(string nombre,DateTime fechaConstitucion,Guid tipoEmpresaId,string comentarios)
        {
            bool ok = false;
            Empresa empresa = new Empresa();
            empresa.Identificador = Guid.NewGuid();
            empresa.Nombre = nombre;
            empresa.FechaConstitucion = fechaConstitucion;
            empresa.TipoEmpresa.Identificador = tipoEmpresaId;
            empresa.Comentarios = comentarios;
            ok = EmpresaLN.getInstance().RegistrarEmpresa(empresa);
            return ok;
        }

        [WebMethod]
        public static bool modEmpresa(Guid id,string nombre, DateTime fechaConstitucion, Guid tipoEmpresaId, string comentarios)
        {
            bool ok = false;
            Empresa empresa = new Empresa();
            empresa.Identificador = id;
            empresa.Nombre = nombre;
            empresa.FechaConstitucion = fechaConstitucion;
            empresa.TipoEmpresa.Identificador = tipoEmpresaId;
            empresa.Comentarios = comentarios;
            ok = EmpresaLN.getInstance().ModificarEmpresa(empresa);
            return ok;
        }

        [WebMethod]
        public static Empresa EditEmpresa(Guid id)
        {           
            Empresa empresa = new Empresa();
            empresa = EmpresaLN.getInstance().BuscarEmpresa(id);
            return empresa;
        }

    }
}