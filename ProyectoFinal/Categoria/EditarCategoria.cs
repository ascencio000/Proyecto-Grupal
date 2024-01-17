using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal
{
    public partial class EditarCategoria : Form
    {
        public EditarCategoria()
        {
            InitializeComponent();
        }

        private void BtnBuscar_Click(object sender, EventArgs e) 

        {
            //FALTA CONTROLAR ERRORES
            conexiones buscar = new conexiones();

            List<Categoria> categorias = new List<Categoria>();


            if (TxtCategoria.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Antes de continuar, por favor ingresa un ID.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtCategoria.Clear();
                TxtCategoria.Focus();

            }
            else
            {
                TxtCategoria.Enabled = false;
                TxtNombre.Enabled = true;
                TxtStock.Enabled = true;
                try
                {
                    int id = Convert.ToInt32(TxtCategoria.Text);
                    categorias = buscar.BuscarCategoria(id);
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Hay un error " + ex.Message, "AVISO", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    TxtCategoria.Enabled=true;
                    TxtCategoria.Clear();
                    TxtCategoria.Focus();

                    TxtNombre.Enabled = false;
                    TxtStock.Enabled = false;
                }

            }
            if (categorias.Count != 0)
            {
                TxtNombre.Text = categorias[0].Nombre.ToString();
                TxtStock.Text = categorias[0].Stock.ToString();
            }
            else
            {
                TxtCategoria.Enabled = true;
                TxtCategoria.Clear();
                TxtCategoria.Focus();
                TxtNombre.Enabled = false;
                TxtStock.Enabled = false;


            }
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            conexiones editar = new conexiones();


            if (TxtNombre.Text.Trim() == string.Empty || TxtStock.Text.Trim() == string.Empty || TxtCategoria.Text.Trim() == string.Empty) //Controlar errores de texbox vacios int o string
            {
                MessageBox.Show("Por Favor rellene los espacios en blanco", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtNombre.Focus();

            }
            else
            {
                try
                {
                    int stock = Convert.ToInt32(TxtStock.Text);
                    int id = Convert.ToInt32(TxtCategoria.Text);
                    string nombre = TxtNombre.Text;
                    editar.EditarCategoria(nombre, stock, id);

                    dataGridView1.DataSource = editar.MostrarCategoria();
                    MessageBox.Show("Los datos se han actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TxtCategoria.Clear();
                    TxtNombre.Clear();
                    TxtStock.Clear();
                    
                    TxtCategoria.Enabled = true;
                    TxtCategoria.Focus();
                    TxtNombre.Enabled = false;
                    TxtStock.Enabled = false;
                }
                catch
                {
                    
                    MessageBox.Show("Se ha producido un error. Por favor, revisa los campos e inténtalo de nuevo.", "AVISO", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                }

            }



        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditarCategoria_Load(object sender, EventArgs e)
        {
            conexiones fun = new conexiones();
            dataGridView1.DataSource = fun.MostrarCategoria();
            TxtCategoria.Focus();
            TxtNombre.Enabled = false;
            TxtStock.Enabled = false;

        }
    }
}
