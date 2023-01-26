using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecnologiaSoftwate.Reto.entidades
{
    public class TipoEmpresa
    {
        public Guid Identificador { get; set; }
        public string NombreTipoEmpresa { get; set; }

        public TipoEmpresa() : this(Guid.Empty, "") { }

        public TipoEmpresa(Guid identificador, string nombreTipoEmpresa)
        {
            this.Identificador = identificador;
            this.NombreTipoEmpresa = nombreTipoEmpresa;
        }
        
    }

   
}
