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
    public partial class BuscarCategoria : Form
    {
        public BuscarCategoria()
        {
            InitializeComponent();
        }
        conexiones buscar = new conexiones();
        List<Categoria> categorias1 = new List<Categoria>();


        private void BtnBuscar_Click(object sender, EventArgs e)
        {


            List<Categoria> categorias = new List<Categoria>();
            if (TxtCategoria.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Antes de continuar, por favor ingresa un ID.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtCategoria.Focus();

            }
            else
            {
                try
                {
                    int id = Convert.ToInt32(categorias1[ComboBoxCategoria.SelectedIndex].IdCategoria.ToString());
                    categorias = buscar.BuscarCategoria(id);
                    TxtCategoria.Focus();
                }
                catch
                {

                    MessageBox.Show("Por favor revisa que el ID este correcto", "AVISO", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    TxtCategoria.Clear();
                    TxtCategoria.Focus();
                }

            }
            if (categorias.Count != 0)
            {

                TxtStock.Text = categorias[0].Stock.ToString();
                MessageBox.Show("Se ha encontrado el dato solicitado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                TxtCategoria.Clear();
                TxtCategoria.Focus();
            }
        }

        private void Btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TxtCategoria.Text = categorias1[ComboBoxCategoria.SelectedIndex].IdCategoria.ToString();
        }

        private void BuscarCategoria_Load(object sender, EventArgs e)
        {
            categorias1 = buscar.MostrarCategoria();
            ComboBoxCategoria.DataSource = categorias1;
            ComboBoxCategoria.DisplayMember = "nombre";
        }
    }
}
