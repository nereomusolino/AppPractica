using ClasesNegocio;
using ClasesDominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Configuration;

namespace FormApp
{
    public partial class FormAgregar : System.Windows.Forms.Form
    {
        private OpenFileDialog archivo = null;
        public FormAgregar()
        {
            InitializeComponent();
        }

        private void FormAgregar_Load(object sender, EventArgs e)
        {         
            EstilosNegocio estilosLectura = new EstilosNegocio();
            TiposEdicionNegocio tiposLectura = new TiposEdicionNegocio();

            cbEstilos.DataSource = estilosLectura.Listar();
            cbTiposEdicion.DataSource = tiposLectura.Listar();

        }

        private void txbCantidadCanciones_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 59) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void btnAgregar2_Click(object sender, EventArgs e)
        {
            Canciones aux = new Canciones();
            CancionesNegocio negocio = new CancionesNegocio();
            try
            {          
                aux.Titulo = txbTitulo.Text;
                aux.FechaLanzamiento = (DateTime)dtpFechaLanzamiento.Value;
                aux.CantidadCanciones = int.Parse(txbCantidadCanciones.Text);
                aux.UrlImagenTapa = txbUrlImagenTapa.Text;
                aux.Estilos = (Estilos)cbEstilos.SelectedItem;
                aux.TiposEdicion = (TiposEdicion)cbTiposEdicion.SelectedItem;

                negocio.Agregar(aux);
                MessageBox.Show("Agregado exitosamente");
                this.Close();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("jajaja xd lol");
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            if (archivo != null && !(txbUrlImagenTapa.Text.ToUpper().Contains("HTTP")))
            {
                File.Copy(archivo.FileName, ConfigurationManager.AppSettings["images-folder"] + archivo.SafeFileName);
            }
        }

        private void btnCancelar2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CargarImagen(string imagen)
        {
            try
            {
                pbAgregar.Load(imagen);
            }
            catch (Exception)
            {
                pbAgregar.Load("https://cdn-icons-png.flaticon.com/512/85/85488.png");
            }
        }

        private void txbUrlImagenTapa_Leave(object sender, EventArgs e)
        {
            CargarImagen(txbUrlImagenTapa.Text);
        }

        private void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            archivo = new OpenFileDialog();
            archivo.Filter = "jpg|*.jpg;|png|*.png";
            if(archivo.ShowDialog() == DialogResult.OK)
            {
                txbUrlImagenTapa.Text = archivo.FileName;
                CargarImagen(archivo.FileName);
            }
        }
    }
}
