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
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader Lector;

            try
            {
                conexion.ConnectionString = "server = NEREO\\SQLEXPRESS; database = DISCOS_DB; integrated security = true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "Select D.Titulo, D.FechaLanzamiento, D.CantidadCanciones, D.UrlImagenTapa, D.IdEstilo, D.IdTipoEdicion, E.Descripcion as Estilo, T.Descripcion as TiposEdicion from DISCOS D, ESTILOS E, TIPOSEDICION T where D.IdEstilo = E.Id and D.IdEstilo = T.Id";
                comando.Connection = conexion;
                conexion.Open();
                Lector= comando.ExecuteReader();

                

                while (Lector.Read())
                {
                    Canciones aux = new Canciones();
                    aux.Estilos = new Estilos();
                    aux.TiposEdicion = new TiposEdicion();
                    aux.Titulo = (string)Lector["Titulo"];
                    aux.FechaLanzamiento = (DateTime)Lector["FechaLanzamiento"];
                    aux.CantidadCanciones = (int)Lector["CantidadCanciones"];
                    aux.UrlImagenTapa = (string)Lector["UrlImagenTapa"];
                    aux.Estilos.IdEstilos = (int)Lector["IdEstilo"];
                    aux.Estilos.Descripcion = (string)Lector["Estilo"].ToString();
                    aux.TiposEdicion.IdTiposEdicion = (int)Lector["IdTipoEdicion"];
                    aux.TiposEdicion.Descripcion = (string)Lector["TiposEdicion"].ToString();

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
                conexion.Close();

            }

        }

    }
}
