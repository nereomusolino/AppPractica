using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesDominio
{
    public class Estilos
    {
        public int IdEstilos { get; set; }
        public String Descripcion { get; set; }

        public override string ToString()
        {
            return Descripcion;
        }
    }
}
