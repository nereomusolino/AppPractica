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
using System.Collections;

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
            cbxCampo.Items.Add("Título Album");
            cbxCampo.Items.Add("Cantidad Canciones");

        }

        private void CargarBase()
        {
            CancionesNegocio CancionesNegocio = new CancionesNegocio();
            try
            {
                listaCanciones = CancionesNegocio.Listar();
                dgvLista.DataSource = listaCanciones;
                OcultarColumnas();
                CargarImagen(listaCanciones[0].UrlImagenTapa);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void OcultarColumnas()
        {
            dgvLista.Columns["UrlImagenTapa"].Visible = false;
            dgvLista.Columns["Id"].Visible = false;
        }

        private void dgvLista_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvLista.CurrentRow != null)
            {
                Canciones aux = (Canciones)dgvLista.CurrentRow.DataBoundItem;
                CargarImagen(aux.UrlImagenTapa);

            }
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
            eliminar();
        }

        private void btnEliminarLogicamente_Click(object sender, EventArgs e)
        {
            eliminar(true);
        }

        private void eliminar(bool estado = false)
        {
            Canciones objCan = new Canciones();
            CancionesNegocio objNeg = new CancionesNegocio();

            try
            {
                if (estado)
                {
                    DialogResult respuesta = MessageBox.Show("Desea eliminar la cancion?", "eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (respuesta == DialogResult.Yes)
                    {
                        objCan = (Canciones)dgvLista.CurrentRow.DataBoundItem;
                        objNeg.EliminarLogicamente(objCan);
                        CargarBase();
                    }
                }
                else
                {
                    DialogResult respuesta = MessageBox.Show("Desea eliminar la cancion de forma permanente?", "eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (respuesta == DialogResult.Yes)
                    {
                        objCan = (Canciones)dgvLista.CurrentRow.DataBoundItem;
                        objNeg.EliminarFisicamente(objCan);
                        CargarBase();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo eliminar");
            }                
        }

        private void txbBuscar_TextChanged(object sender, EventArgs e)
        {
            List<Canciones> listaFiltrada;
            string filtro = txbBuscar.Text;

            if (filtro.Length > 2)
            {
                listaFiltrada = listaCanciones.FindAll(x => x.Titulo.ToUpper().Contains(filtro.ToUpper()));
            }
            else
            {
                listaFiltrada = listaCanciones;
            }

            dgvLista.DataSource = null;
            dgvLista.DataSource = listaFiltrada;
            OcultarColumnas();
        }

        private void cbxCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string opcion = cbxCampo.SelectedItem.ToString();
            if (opcion == "Título Album")
            {
                cbxCriterio.Items.Clear();
                cbxCriterio.Items.Add("Empiece con");
                cbxCriterio.Items.Add("Termine con");
                cbxCriterio.Items.Add("Contenga");
            } 
            else
            {
                cbxCriterio.Items.Clear();
                cbxCriterio.Items.Add("Mayor a");
                cbxCriterio.Items.Add("Menor a");
                cbxCriterio.Items.Add("Sea igual a");
            }
        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            AccesoDatos datos= new AccesoDatos();
            CancionesNegocio negocio = new CancionesNegocio();

            try
            {
                string campo = cbxCampo.SelectedItem.ToString();
                string criterio = cbxCriterio.SelectedItem.ToString();
                string filtro = txbFiltro.Text;
                dgvLista.DataSource = negocio.FiltrarAvanzado(campo, criterio, filtro);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());               
            }
        }
    }
}
