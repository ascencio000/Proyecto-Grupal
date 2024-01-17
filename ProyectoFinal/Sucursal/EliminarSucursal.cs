using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal.Sucursal
{
    public partial class EliminarSucursal : Form
    {
        public EliminarSucursal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conexiones eliminar = new conexiones();
            if (TxtIDSucursal.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Antes de continuar, por favor ingresa un ID.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    int id = Convert.ToInt32(TxtIDSucursal.Text);
                    DialogResult oks;
                    oks = MessageBox.Show("Estas Seguro De Elimnar Esta Sucursal", "AVISO", MessageBoxButtons.YesNo);
                    if (oks == DialogResult.Yes)
                    {
                        eliminar.EliminarSucursal(id);//MESNAJE DE CONFIRMACION FALTA
                        MessageBox.Show("Los datos se han eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        TxtIDSucursal.Clear();
                        TxtIDSucursal.Focus();
                    }
                    else
                    {
                        TxtIDSucursal.Clear();
                        TxtIDSucursal.Focus();
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Hay un error " + ex.Message, "AVISO", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                }


            }
        }

        private void Btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
