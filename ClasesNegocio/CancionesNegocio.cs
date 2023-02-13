using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClasesDominio;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

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
                datos.setearConsulta("Select D.Id, D.Titulo, D.FechaLanzamiento, D.CantidadCanciones, D.UrlImagenTapa, D.IdEstilo, D.IdTipoEdicion, E.Descripcion as Estilo, T.Descripcion as TiposEdicion from DISCOS D, ESTILOS E, TIPOSEDICION T where D.IdEstilo = E.Id and D.IdTipoEdicion = T.Id and D.Activo = 1");
                datos.ejecutarConsulta();

                while (datos.Lector.Read())
                {
                    Canciones aux = new Canciones();
                    aux.Estilos = new Estilos();
                    aux.TiposEdicion = new TiposEdicion();
                    aux.Id = (int)datos.Lector["Id"];
                    if (!(datos.Lector["Titulo"] is DBNull))
                        aux.Titulo = (string)datos.Lector["Titulo"];
                    if (!(datos.Lector["FechaLanzamiento"] is DBNull))
                        aux.FechaLanzamiento = (DateTime)datos.Lector["FechaLanzamiento"];
                    if (!(datos.Lector["CantidadCanciones"] is DBNull))
                        aux.CantidadCanciones = (int)datos.Lector["CantidadCanciones"];
                    if (!(datos.Lector["UrlImagenTapa"] is DBNull))
                        aux.UrlImagenTapa = (string)datos.Lector["UrlImagenTapa"];
                    if (!(datos.Lector["IdEstilo"] is DBNull))
                        aux.Estilos.IdEstilos = (int)datos.Lector["IdEstilo"];
                    if (!(datos.Lector["Estilo"] is DBNull))
                        aux.Estilos.Descripcion = (string)datos.Lector["Estilo"].ToString();
                    if (!(datos.Lector["IdTipoEdicion"] is DBNull))
                        aux.TiposEdicion.IdTiposEdicion = (int)datos.Lector["IdTipoEdicion"];
                    if (!(datos.Lector["TiposEdicion"] is DBNull))
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

        public void Agregar(Canciones obj)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Insert into DISCOS (titulo, FechaLanzamiento, CantidadCanciones, UrlImagenTapa, IdEstilo, IdTipoEdicion) values (@Titulo,@FechaLanzamiento,@CantidadCanciones,@UrlImagenTapa,@IdEstilos,@IdTipoEdicion)");
                datos.setearParametros("@Titulo", obj.Titulo);
                datos.setearParametros("@FechaLanzamiento", obj.FechaLanzamiento);
                datos.setearParametros("@CantidadCanciones", obj.CantidadCanciones);
                datos.setearParametros("@UrlImagenTapa", obj.UrlImagenTapa);
                datos.setearParametros("@IdEstilos", obj.Estilos.IdEstilos);
                datos.setearParametros("@IdTipoEdicion", obj.TiposEdicion.IdTiposEdicion);

                datos.ejecutarAccion();

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

        public void Modificar(Canciones obj)
        {
            AccesoDatos access = new AccesoDatos();

            try
            {
                access.setearConsulta("Update DISCOS set Titulo = @Titulo, FechaLanzamiento = @FechaLanzamiento, CantidadCanciones = @CantidadCanciones, UrlImagenTapa = @Url, IdEstilo = @IdEstilo, IdTipoEdicion = @IdTipoEdicion where Id = @Id");
                access.setearParametros("@Titulo", obj.Titulo);
                access.setearParametros("@FechaLanzamiento", obj.FechaLanzamiento);
                access.setearParametros("@CantidadCanciones", obj.CantidadCanciones);
                access.setearParametros("@Url", obj.UrlImagenTapa);
                access.setearParametros("@IdEstilo", obj.Estilos.IdEstilos);
                access.setearParametros("@IdTipoEdicion", obj.TiposEdicion.IdTiposEdicion);
                access.setearParametros("Id", obj.Id);
                
                access.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                access.cerrarConsulta();
            }
        }

        public void EliminarFisicamente(Canciones obj)
        {
            AccesoDatos acceso = new AccesoDatos();

            try
            {
                acceso.setearConsulta("delete from DISCOS where Id = @Id");
                acceso.setearParametros("@Id",obj.Id);

                acceso.ejecutarAccion();

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

        public void EliminarLogicamente(Canciones obj)
        {
            AccesoDatos acceso = new AccesoDatos();

            try
            {
                acceso.setearConsulta("update DISCOS set Activo = 0 where Id = @Id");
                acceso.setearParametros("@Id", obj.Id);

                acceso.ejecutarAccion();

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

        public List<Canciones> FiltrarAvanzado(string campo, string criterio, string filtro)
        {
            AccesoDatos datos = new AccesoDatos();
            List<Canciones> lista = new List<Canciones>();

            try
            {
                string consulta = "Select D.Id, D.Titulo, D.FechaLanzamiento, D.CantidadCanciones, D.UrlImagenTapa, D.IdEstilo, D.IdTipoEdicion, E.Descripcion as Estilo, T.Descripcion as TiposEdicion from DISCOS D, ESTILOS E, TIPOSEDICION T where D.IdEstilo = E.Id and D.IdTipoEdicion = T.Id and D.Activo = 1 and ";
                switch (campo)
                {
                    case "Título Album":
                        switch (criterio)
                        {
                            case "Empiece con":
                                consulta += "D.Titulo like '" + filtro + "%' ";
                                break;
                            case "Termine con":
                                consulta += "D.Titulo like '%" + filtro + "' ";
                                break;
                            case "Contenga":
                                consulta += "D.Titulo like '%" + filtro + "%' ";
                                break;
                        }
                        break;

                    case "Cantidad Canciones":
                        switch (criterio)
                        {
                            case "Mayor a":
                                consulta += "D.CantidadCanciones > " + filtro;
                                break;
                            case "Menor a":
                                consulta += "D.CantidadCanciones < " + filtro;
                                break;
                            case "Sea igual a":
                                consulta += "D.CantidadCanciones = " + filtro;
                                break;
                        }
                        break;

                    default:
                        break;
                }

                datos.setearConsulta(consulta);
                datos.ejecutarConsulta();

                while (datos.Lector.Read())
                {
                    Canciones aux = new Canciones();
                    aux.Estilos = new Estilos();
                    aux.TiposEdicion = new TiposEdicion();
                    aux.Id = (int)datos.Lector["Id"];
                    if (!(datos.Lector["Titulo"] is DBNull))
                        aux.Titulo = (string)datos.Lector["Titulo"];
                    if (!(datos.Lector["FechaLanzamiento"] is DBNull))
                        aux.FechaLanzamiento = (DateTime)datos.Lector["FechaLanzamiento"];
                    if (!(datos.Lector["CantidadCanciones"] is DBNull))
                        aux.CantidadCanciones = (int)datos.Lector["CantidadCanciones"];
                    if (!(datos.Lector["UrlImagenTapa"] is DBNull))
                        aux.UrlImagenTapa = (string)datos.Lector["UrlImagenTapa"];
                    if (!(datos.Lector["IdEstilo"] is DBNull))
                        aux.Estilos.IdEstilos = (int)datos.Lector["IdEstilo"];
                    if (!(datos.Lector["Estilo"] is DBNull))
                        aux.Estilos.Descripcion = (string)datos.Lector["Estilo"].ToString();
                    if (!(datos.Lector["IdTipoEdicion"] is DBNull))
                        aux.TiposEdicion.IdTiposEdicion = (int)datos.Lector["IdTipoEdicion"];
                    if (!(datos.Lector["TiposEdicion"] is DBNull))
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
