using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesDominio
{
    public class Canciones
    {
        public String Titulo { get; set; }
        public DateTime FechaLanzamiento { get; set; }
        public int CantidadCanciones { get; set; }
        public String UrlImagenTapa { get; set; }
        public Estilos Estilos { get; set; }
        public TiposEdicion TiposEdicion { get; set; }
    }
}
