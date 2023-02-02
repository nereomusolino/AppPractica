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
    }
}
