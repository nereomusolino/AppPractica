using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClasesDominio;
using System.Data.SqlClient;

namespace ClasesNegocio
{
    public class CancionesNegocio
    {
        public List<Canciones> Listar()
        {
            List<Canciones> lista = new List<Canciones>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Select D.Titulo, D.FechaLanzamiento, D.CantidadCanciones, D.UrlImagenTapa, D.IdEstilo, D.IdTipoEdicion, E.Descripcion as Estilo, T.Descripcion as TiposEdicion from DISCOS D, ESTILOS E, TIPOSEDICION T where D.IdEstilo = E.Id and D.IdTipoEdicion = T.Id");
                datos.ejecutarConsulta();

                while (datos.Lector.Read())
                {
                    Canciones aux = new Canciones();
                    aux.Estilos = new Estilos();
                    aux.TiposEdicion = new TiposEdicion();
                    aux.Titulo = (string)datos.Lector["Titulo"];
                    aux.FechaLanzamiento = (DateTime)datos.Lector["FechaLanzamiento"];
                    aux.CantidadCanciones = (int)datos.Lector["CantidadCanciones"];
                    aux.UrlImagenTapa = (string)datos.Lector["UrlImagenTapa"];
                    aux.Estilos.IdEstilos = (int)datos.Lector["IdEstilo"];
                    aux.Estilos.Descripcion = (string)datos.Lector["Estilo"].ToString();
                    aux.TiposEdicion.IdTiposEdicion = (int)datos.Lector["IdTipoEdicion"];
                    aux.TiposEdicion.Descripcion = (string)datos.Lector["TiposEdicion"].ToString();

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally 
            {
                datos.cerrarConsulta();
            }

        }
        
    }
}
