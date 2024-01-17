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
    public partial class EliminarProducto : Form
    {
        public EliminarProducto()
        {
            InitializeComponent();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            conexiones EliminarPro = new conexiones();
            if (txtProducto.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Antes de continuar, por favor ingresa un ID.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    int idP = Convert.ToInt32(txtProducto.Text);
                    DialogResult oks;
                    oks = MessageBox.Show("Estas Seguro De Elimnar Este Producto", "AVISO",MessageBoxButtons.YesNo);
                    if (oks == DialogResult.Yes)
                    {
                        int idproducto = Convert.ToInt32(txtProducto.Text);
                        EliminarPro.actualizartablaproductos(idproducto);
                        EliminarPro.EliminarProducto(idP);//MESNAJE DE CONFIRMACION FALTA
                        MessageBox.Show("Los datos se han eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtProducto.Clear();
                        txtProducto.Focus();
                    }
                    else
                    {
                        txtProducto.Clear();
                        txtProducto.Focus();
                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hay un error " + ex.Message, "AVISO", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    txtProducto.Clear();
                    txtProducto.Focus();
                }

            }
        }

        private void Txt_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
