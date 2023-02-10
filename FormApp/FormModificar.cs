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
        private Canciones auxiliar = null;
        public FormModificar()
        {         
            InitializeComponent();
        }
        public FormModificar(Canciones aux)
        {
            auxiliar = aux;
            InitializeComponent();
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

                if (auxiliar != null)
                {
                    txbTitulo.Text = auxiliar.Titulo;
                    dtpFechaLanzamiento.Value = auxiliar.FechaLanzamiento;
                    txbCantidadCanciones.Text = auxiliar.CantidadCanciones.ToString();
                    txbUrlImagenTapa.Text = auxiliar.UrlImagenTapa;
                    cbEstilos.SelectedValue = auxiliar.Estilos.IdEstilos;
                    cbTiposEdicion.SelectedValue = auxiliar.TiposEdicion.IdTiposEdicion;
                    CargarImagen(auxiliar.UrlImagenTapa);
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

        private void btnModificar_Click(object sender, EventArgs e)
        {
            CancionesNegocio negocio = new CancionesNegocio();
            try
            {
                auxiliar.Titulo = txbTitulo.Text;
                auxiliar.FechaLanzamiento = dtpFechaLanzamiento.Value;
                auxiliar.CantidadCanciones = int.Parse(txbCantidadCanciones.Text);
                auxiliar.UrlImagenTapa = txbUrlImagenTapa.Text;
                auxiliar.Estilos = (Estilos)cbEstilos.SelectedItem;
                auxiliar.TiposEdicion = (TiposEdicion)cbTiposEdicion.SelectedItem;

                negocio.Modificar(auxiliar);
                MessageBox.Show("Modificado exitosamente");
                this.Close();
            }
            catch (NullReferenceException) 
            {
                MessageBox.Show("Referencia nula.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
