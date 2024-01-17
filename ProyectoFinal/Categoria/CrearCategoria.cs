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
    public partial class CrearCategoria : Form
    {
        public CrearCategoria()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conexiones crearCate = new conexiones();
            if (TxtNombre.Text.Trim() == string.Empty || TxtStock.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Por favor, asegúrate de revisar que todos los campos estén completos antes de continuar", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtNombre.Focus();
            }
            else
            {
                try
                {
                    string nombre = TxtNombre.Text.Trim();
                    int stock = Convert.ToInt32(TxtStock.Text);
                    crearCate.CrearCategoria(nombre, stock);
                    MessageBox.Show("Los datos se han creado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TxtNombre.Clear();
                    TxtStock.Clear();
                    TxtNombre.Focus();
                }
                catch
                {

                    MessageBox.Show("Se ha producido un error. Por favor, revisa los campos e inténtalo de nuevo.", "AVISO", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    TxtNombre.Focus();
                }

            }
        }

        private void Btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
