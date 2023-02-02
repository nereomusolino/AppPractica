using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using ClasesDominio;
using ClasesNegocio;

namespace FormApp
{
    public partial class Form : System.Windows.Forms.Form
    {
        private List<Canciones> listaCanciones;
        public Form()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            CancionesNegocio CancionesNegocio = new CancionesNegocio();
            dgvLista.DataSource = CancionesNegocio.Listar();
        }
    }
}
