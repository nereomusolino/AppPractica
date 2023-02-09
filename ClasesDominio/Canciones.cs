using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ClasesDominio
{
    public class Canciones
    {
        public int Id { get; set; }

        [DisplayName("Título Album")]
        public String Titulo { get; set; }
        [DisplayName("Fecha de Lanzamiento")]
        public DateTime FechaLanzamiento { get; set; }
        [DisplayName("Cantidad de Canciones")]
        public int CantidadCanciones { get; set; }
        public String UrlImagenTapa { get; set; }
        [DisplayName("Tipo de Estilo")]
        public Estilos Estilos { get; set; }
        [DisplayName("Tipo de Edición")]
        public TiposEdicion TiposEdicion { get; set; }
    }
}
