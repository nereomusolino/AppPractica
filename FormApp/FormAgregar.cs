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

namespace FormApp
{
    public partial class FormAgregar : System.Windows.Forms.Form
    {
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void btnCancelar2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
