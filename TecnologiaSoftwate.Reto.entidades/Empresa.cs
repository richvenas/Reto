using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecnologiaSoftwate.Reto.entidades
{
    public class Empresa
    {       
        public Guid Identificador { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaConstitucion { get; set; }
        public TipoEmpresa TipoEmpresa { get; set; }
        public string Comentarios { get; set; }

        public Empresa() : this(Guid.Empty, "", DateTime.Parse("1990-01-01"), new TipoEmpresa(),"") { }

        public Empresa(Guid identificador, string nombre,  DateTime FechaConstitucion,TipoEmpresa tipoEmpresa,string comentarios) 
        {
            this.Identificador = identificador;
            this.Nombre = nombre;
            this.FechaConstitucion = FechaConstitucion;
            this.TipoEmpresa = tipoEmpresa;
            this.Comentarios = comentarios;
        }
    }
}

 
