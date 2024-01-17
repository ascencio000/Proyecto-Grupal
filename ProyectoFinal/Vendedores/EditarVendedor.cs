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
    public partial class EditarVendedor : Form
    {
        public EditarVendedor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conexiones busVendedor = new conexiones();
            List<Vendedor> Vende = new List<Vendedor>();

            if (TxtIDVendedor.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Por Favor rellene los espacios en blanco", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtIDVendedor.Focus();
            }

            else
            {
                TxtIDVendedor.Enabled = false;

                TxtApellidoV.Enabled = true;
                TxtDireccion.Enabled = true;
                TxtDUI.Enabled = true;
                TxtEmail.Enabled = true;
                TxtNombreV.Enabled = true;
                TxtTelefono.Enabled = true;
                try
                {
                    int id = Convert.ToInt32(TxtIDVendedor.Text);
                    Vende = busVendedor.BuscarVendedor(id);
                }
                catch
                {

                    MessageBox.Show("Por favor revisa que el ID este correcto", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TxtIDVendedor.Enabled = true;
                    TxtIDVendedor.Clear();
                    TxtIDVendedor.Focus();

                    TxtApellidoV.Enabled = false;
                    TxtDireccion.Enabled = false;
                    TxtDUI.Enabled = false;
                    TxtEmail.Enabled = false;
                    TxtNombreV.Enabled = false;
                    TxtTelefono.Enabled = false;
                }

            }

            if (Vende.Count != 0)
            {
                TxtNombreV.Text = Vende[0].Nombre;
                TxtApellidoV.Text = Vende[0].Apellido;
                TxtDUI.Text = Vende[0].DUI;
                TxtTelefono.Text = Vende[0].Telefono;
                TxtEmail.Text = Vende[0].Email;
                TxtDireccion.Text = Vende[0].Direccion;
            }
            else
            {
                TxtIDVendedor.Enabled = true;
                TxtIDVendedor.Clear();
                TxtIDVendedor.Focus();

                TxtApellidoV.Enabled = false;
                TxtDireccion.Enabled = false;
                TxtDUI.Enabled = false;
                TxtEmail.Enabled = false;
                TxtNombreV.Enabled = false;
                TxtTelefono.Enabled = false;
            }
        }




        private void EditarVendedor_Load(object sender, EventArgs e)
        {
            conexiones fun = new conexiones();
            dataGridView1.DataSource = fun.MostrarVendedores();

            TxtApellidoV.Enabled = false;
            TxtDireccion.Enabled = false;
            TxtDUI.Enabled = false;
            TxtEmail.Enabled = false;
            TxtNombreV.Enabled = false;
            TxtTelefono.Enabled = false;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            conexiones editar = new conexiones();
            if (TxtIDVendedor.Text.Trim() == string.Empty || TxtNombreV.Text.Trim() == string.Empty || TxtApellidoV.Text.Trim() == string.Empty || TxtDUI.Text.Trim() == string.Empty || TxtTelefono.Text.Trim() == string.Empty || TxtEmail.Text.Trim() == string.Empty || TxtDireccion.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Por Favor rellene los espacios en blanco", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    int id = Convert.ToInt32(TxtIDVendedor.Text);
                    editar.EditarVendedor(nombre, apellido, dui, telefono, email, direccion, id);
                    conexiones fun = new conexiones();
                    dataGridView1.DataSource = fun.MostrarVendedores();
                    MessageBox.Show("Los datos se han actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TxtApellidoV.Clear();
                    TxtDireccion.Clear();
                    TxtDUI.Clear();
                    TxtEmail.Clear();
                    TxtIDVendedor.Clear();
                    TxtNombreV.Clear();
                    TxtTelefono.Clear();
                    
                    TxtIDVendedor.Enabled = true;
                    TxtIDVendedor.Focus();

                    TxtApellidoV.Enabled = false;
                    TxtDireccion.Enabled = false;
                    TxtDUI.Enabled = false;
                    TxtEmail.Enabled = false;
                    TxtNombreV.Enabled = false;
                    TxtTelefono.Enabled = false;
                }
                catch
                {

                    MessageBox.Show("Se ha producido un error. Por favor, revisa los campos e inténtalo de nuevo.", "AVISO", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                }

            }
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
