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
            CargarBase();
        }

        private void CargarBase()
        {
            CancionesNegocio CancionesNegocio = new CancionesNegocio();
            try
            {
                listaCanciones = CancionesNegocio.Listar();
                dgvLista.DataSource = listaCanciones;
                dgvLista.Columns["UrlImagenTapa"].Visible = false;
                dgvLista.Columns["Id"].Visible= false;
                CargarImagen(listaCanciones[0].UrlImagenTapa);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
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
            CargarBase();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Canciones aux;
            aux = (Canciones)dgvLista.CurrentRow.DataBoundItem;

            FormModificar formModificar = new FormModificar(aux);
            formModificar.ShowDialog();
            CargarBase();


        }

        private void btnEliminarFisicamente_Click(object sender, EventArgs e)
        {
            Canciones objCan = new Canciones();
            CancionesNegocio objNeg = new CancionesNegocio();
            try
            {
                DialogResult respuesta = MessageBox.Show("Desea eliminar la cancion?", "eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (respuesta == DialogResult.Yes)
                {
                    objCan = (Canciones)dgvLista.CurrentRow.DataBoundItem;
                    objNeg.EliminarFisicamente(objCan);
                    CargarBase();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
