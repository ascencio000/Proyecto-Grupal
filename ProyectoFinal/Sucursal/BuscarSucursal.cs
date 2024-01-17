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
    public partial class BuscarSucursal : Form
    {
        public BuscarSucursal()
        {
            InitializeComponent();
        }
        List<Sucursales> Sucursales = new List<Sucursales>();
        conexiones busSucursal = new conexiones();
        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            List<Sucursales> sucur = new List<Sucursales>();
            if (TxtIDSucursal.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Por favor revisa que el ID este correcto", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtIDSucursal.Focus();

            }
            else
            {
                try
                {
                    int id = Convert.ToInt32(Sucursales[ComboBoxSucursal.SelectedIndex].IdSucursal.ToString());


                    sucur = busSucursal.BuscarSucursal(id);
                    TxtIDSucursal.Focus();
                }
                catch
                {

                    MessageBox.Show("Por favor revisa que el ID este correcto", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TxtIDSucursal.Clear();
                    TxtIDSucursal.Focus();
                }

            }
            if (sucur.Count != 0)
            {

                TxtDireccionS.Text = sucur[0].Direccion.ToString();
                MessageBox.Show("Se ha encontrado el dato solicitado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                TxtIDSucursal.Clear();
                TxtIDSucursal.Focus();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TxtIDSucursal.Text = Sucursales[ComboBoxSucursal.SelectedIndex].IdSucursal.ToString();
        }

        private void BuscarSucursal_Load(object sender, EventArgs e)
        {
            Sucursales = busSucursal.MostrarSucursales();
            ComboBoxSucursal.DataSource = Sucursales;
            ComboBoxSucursal.DisplayMember = "Nombre";
        }
    }
}
