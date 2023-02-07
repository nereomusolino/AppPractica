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
    public partial class FormModificar : System.Windows.Forms.Form
    {
        private Canciones aux = null;
        public FormModificar()
        {         
            InitializeComponent();
        }
        public FormModificar(Canciones aux)
        {
            InitializeComponent();
            this.aux = aux;
        }

        private void FormModificar_Load(object sender, EventArgs e)
        {
            EstilosNegocio esNegocio = new EstilosNegocio();
            TiposEdicionNegocio tiNegocio = new TiposEdicionNegocio();

            try
            {
                cbEstilos.DataSource = esNegocio.Listar();
                cbEstilos.ValueMember = "IdEstilos";
                cbEstilos.DisplayMember = "Descripcion";
                cbTiposEdicion.DataSource = tiNegocio.Listar();
                cbTiposEdicion.ValueMember = "IdTiposEdicion";
                cbTiposEdicion.DisplayMember = "Descripcion";

                if (aux != null)
                {
                    txbTitulo.Text = aux.Titulo;
                    dtpFechaLanzamiento.Value = aux.FechaLanzamiento;
                    txbCantidadCanciones.Text = aux.CantidadCanciones.ToString();
                    txbUrlImagenTapa.Text = aux.UrlImagenTapa;
                    cbEstilos.SelectedValue = aux.Estilos.IdEstilos;
                    cbTiposEdicion.SelectedValue = aux.TiposEdicion.IdTiposEdicion;
                    CargarImagen(aux.UrlImagenTapa);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void CargarImagen(string imagen)
        {
            try
            {
                pbModificar.Load(imagen);
            }
            catch (Exception)
            {
                pbModificar.Load("https://cdn-icons-png.flaticon.com/512/85/85488.png");
            }       
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
