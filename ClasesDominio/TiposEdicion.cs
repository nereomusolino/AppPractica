using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesDominio
{
    public class TiposEdicion
    {
        public int IdTiposEdicion { get; set; }
        public String Descripcion { get; set; }

        public override string ToString()
        {
            return Descripcion;
        }

    }
}
