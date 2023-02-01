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
            CancionesNegocio cancionesNegocio = new CancionesNegocio();
            listaCanciones = cancionesNegocio.Listar();
            dgvLista.DataSource = listaCanciones;
            dgvLista.Columns["UrlImagenTapa"].Visible = false;
            cargarImagen(listaCanciones[0].UrlImagenTapa);

        }

        private void dgvLista_SelectionChanged(object sender, EventArgs e)
        {
            Canciones dataFoto = (Canciones)dgvLista.CurrentRow.DataBoundItem;
            cargarImagen(dataFoto.UrlImagenTapa);
        }

        private void cargarImagen(string url)
        {
            try
            {
                pbImagenes.Load(url);
            }
            catch (Exception)
            {
                pbImagenes.Load("https://static.vecteezy.com/system/resources/previews/004/141/669/non_2x/no-photo-or-blank-image-icon-loading-images-or-missing-image-mark-image-not-available-or-image-coming-soon-sign-simple-nature-silhouette-in-frame-isolated-illustration-vector.jpg");
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FormAgregar formAgregar = new FormAgregar();
            formAgregar.ShowDialog();

        }
    }
}
