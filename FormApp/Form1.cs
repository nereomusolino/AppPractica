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
            listaCanciones = CancionesNegocio.Listar();
            dgvLista.DataSource= listaCanciones;
            CargarImagen(listaCanciones[0].UrlImagenTapa);

        }
        private void dgvLista_SelectionChanged(object sender, EventArgs e)
        {
            Canciones aux = (Canciones)dgvLista.CurrentRow.DataBoundItem;
            CargarImagen(aux.UrlImagenTapa);
        }

        private void CargarImagen(string imagen)
        {
            try
            {
                pbImagenes.Load(imagen);
            }
            catch (Exception)
            {

                pbImagenes.Load("https://cdn-icons-png.flaticon.com/512/85/85488.png");
            }
            

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FormAgregar formAgregar = new FormAgregar();
            formAgregar.ShowDialog();
        }
    }
}
