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
    public partial class BuscarVendedor : Form
    {
        public BuscarVendedor()
        {
            InitializeComponent();
        }
        conexiones busVendedor = new conexiones();
        List<Vendedor> Vendedor = new List<Vendedor>();

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            List<Vendedor> Vende = new List<Vendedor>();

            if (TxtVendedor.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Antes de continuar, por favor ingresa un ID.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtVendedor.Focus();
                TxtVendedor.Clear();
            }

            else
            {
                try
                {
                    int id = Convert.ToInt32(Vendedor[ComboBoxVendedores.SelectedIndex].IdVendedor.ToString());
                    Vende = busVendedor.BuscarVendedor(id);

                }
                catch
                {

                    MessageBox.Show("Por favor revisa que el ID este correcto", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TxtVendedor.Focus();
                    TxtVendedor.Clear();
                }


                if (Vende.Count != 0)
                {

                    TxtApellidoV.Text = Vende[0].Apellido;
                    TxtDUI.Text = Vende[0].DUI;
                    TxtTelefono.Text = Vende[0].Telefono;
                    TxtEmail.Text = Vende[0].Email;
                    TxtDireccion.Text = Vende[0].Direccion;
                    MessageBox.Show("Se ha encontrado el dato solicitado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {

                    TxtVendedor.Focus();
                    TxtVendedor.Clear();
                }

            }
        }

       

        private void Btn_Salir_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TxtVendedor.Text = Vendedor[ComboBoxVendedores.SelectedIndex].IdVendedor.ToString();
        }

        private void BuscarVendedor_Load(object sender, EventArgs e)
        {
            Vendedor = busVendedor.MostrarVendedores();
            ComboBoxVendedores.DataSource = Vendedor;
            ComboBoxVendedores.DisplayMember = "Nombre";
        }
    }
}
