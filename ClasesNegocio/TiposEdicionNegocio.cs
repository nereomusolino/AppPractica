using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using ClasesDominio;

namespace ClasesNegocio
{
    public class TiposEdicionNegocio
    {
        public List<TiposEdicion> Listar()
        {
            List<TiposEdicion> tiposEdicionLista = new List<TiposEdicion>();
            AccesoDatos acceso = new AccesoDatos();

            try
            {
                acceso.setearConsulta("Select Id, Descripcion from tiposedicion");
                acceso.ejecutarConsulta();

                while (acceso.Lector.Read())
                {
                    TiposEdicion aux = new TiposEdicion();
                    {
                        aux.IdTiposEdicion = (int)acceso.Lector["Id"];
                        aux.Descripcion = (string)acceso.Lector["Descripcion"];
                    };

                    tiposEdicionLista.Add(aux);
                }
    
                return tiposEdicionLista;
            }


            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                acceso.cerrarConsulta();
            }
        }
    }
}


