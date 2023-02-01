﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ClasesNegocio
{
    public class AccesoDatos
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;
        public SqlDataReader Lector
        {
            get { return lector; }
        }

        public AccesoDatos()
        {
            conexion = new SqlConnection("server = DESKTOP-U3MQGDJ\\SQLEXPRESS; database = DISCOS_DB; integrated security = true");
            // conexion = new SqlConnection("server = NEREO\\SQLEXPRESS; database = DISCOS_DB; integrated security = true");
            comando = new SqlCommand();
        }

        public void setearConsulta (string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }

        public void ejecutarConsulta()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void cerrarConsulta()
        {
            if (lector != null)
                lector.Close();
            conexion.Close();
        }
    }
}
