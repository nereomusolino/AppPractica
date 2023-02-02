using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClasesDominio;

namespace ClasesNegocio
{
    public class EstilosNegocio
    {

        public List<Estilos> Listar()
        {
            List<Estilos> listaEstilos = new List<Estilos>();
            AccesoDatos acceso = new AccesoDatos();
            try
            {
                acceso.setearConsulta("Select Id, Descripcion from estilos");
                acceso.ejecutarConsulta();

                while (acceso.Lector.Read())
                {
                    Estilos aux = new Estilos();
                    aux.IdEstilos = (int)acceso.Lector["Id"];
                    aux.Descripcion = (string)acceso.Lector["Descripcion"];

                    listaEstilos.Add(aux);
                }

                return listaEstilos;

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
