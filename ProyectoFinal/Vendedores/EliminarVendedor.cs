using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal.Vendedores
{
    public partial class EliminarVendedor : Form
    {
        public EliminarVendedor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conexiones eliminar = new conexiones();
            if (TxtIDVendedor.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Antes de continuar, por favor ingresa un ID.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    int id = Convert.ToInt32(TxtIDVendedor.Text);
                    DialogResult oks;
                    oks = MessageBox.Show("Esta Seguro De Eliminar El Siguiente Vendedor", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (oks == DialogResult.Yes)
                    {
                        eliminar.EliminarVendedor(id);
                        MessageBox.Show("Los datos se han eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        TxtIDVendedor.Clear();
                        TxtIDVendedor.Focus();
                    }
                    else
                    {
                        TxtIDVendedor.Clear();
                        TxtIDVendedor.Focus();

                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show("Hay un error " + ex.Message, "AVISO", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                }

            }

        }

        private void Btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
