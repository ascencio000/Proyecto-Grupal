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
    public partial class CrearSucursal : Form
    {
        public CrearSucursal()
        {
            InitializeComponent();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            conexiones CrSucursal = new conexiones();
            if (TxtDireccionS.Text.Trim() == string.Empty || TxtNombreS.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Por Favor rellene los espacios en blanco", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtNombreS.Focus();
            }
            else
            {
                try
                {
                    string nombre = TxtNombreS.Text.Trim();
                    string direccion = TxtDireccionS.Text.Trim();
                    CrSucursal.CrearSucursal(nombre, direccion);
                    MessageBox.Show("Los datos se han creado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TxtDireccionS.Clear();
                    TxtNombreS.Clear();
                    TxtNombreS.Focus();
                }
                catch
                {

                    MessageBox.Show("Se ha producido un error. Por favor, revisa los campos e inténtalo de nuevo.", "AVISO", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    TxtNombreS.Focus();
                }
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
