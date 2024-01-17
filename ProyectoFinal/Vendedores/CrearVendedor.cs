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
    public partial class CrearVendedor : Form
    {
        public CrearVendedor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conexiones CrVendedor = new conexiones();
            if (TxtNombreV.Text.Trim() == string.Empty || TxtApellidoV.Text.Trim() == string.Empty || TxtDUI.Text.Trim() == string.Empty || TxtTelefono.Text.Trim() == string.Empty || TxtEmail.Text.Trim() == string.Empty || TxtDireccion.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Por Favor rellene los espacios en blanco", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtNombreV.Focus();
            }
            else
            {
                try
                {
                    string nombre = TxtNombreV.Text.Trim();
                    string apellido = TxtApellidoV.Text.Trim();
                    string dui = TxtDUI.Text.Trim();
                    string telefono = TxtTelefono.Text.Trim();
                    string email = TxtEmail.Text.Trim();
                    string direccion = TxtDireccion.Text.Trim();
                    CrVendedor.CrearVendedor(nombre, apellido, dui, telefono, email, direccion);
                    MessageBox.Show("Los datos se han creado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TxtApellidoV.Clear();
                    TxtDireccion.Clear();
                    TxtDUI.Clear();
                    TxtEmail.Clear();
                    TxtNombreV.Clear();
                    TxtTelefono.Clear();
                    TxtNombreV.Focus();
                }
                catch
                {

                    MessageBox.Show("Se ha producido un error. Por favor, revisa los campos e inténtalo de nuevo.", "AVISO", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    TxtNombreV.Focus();
                }

            }

        }

        private void Btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
