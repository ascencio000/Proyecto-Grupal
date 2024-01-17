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
    public partial class BuscarProducto : Form
    {
        public BuscarProducto()
        {
            InitializeComponent();
        }
        conexiones buscar = new conexiones();
        List<Productos> combo = new List<Productos>();
        List<Sucursales> Sucursal = new List<Sucursales>();
        List<Categoria> Categorias = new List<Categoria>();

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            
            int id = 0;
            List<Productos> BuscarPro = new List<Productos>();
            if (txtProducto.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Antes de continuar, por favor ingresa un ID.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtProducto.Clear();
                txtProducto.Focus();

            }

            else
            {
                try
                {
                    id = Convert.ToInt32(combo[ComboBoxProductos.SelectedIndex].IdProducto.ToString());
                    int idS = Convert.ToInt32(combo[ComboBoxProductos.SelectedIndex].IdSucursal.ToString());
                    int idC = Convert.ToInt32(combo[ComboBoxProductos.SelectedIndex].IdCategoria.ToString());
                    BuscarPro = buscar.BuscarProducto(id);
                    Sucursal = buscar.BuscarSucursal(idS);
                    Categorias = buscar.BuscarCategoria(idC);
                }
                catch 
                {

                    MessageBox.Show("Por favor revisa que el ID este correcto", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtProducto.Clear();
                    txtProducto.Focus();
                }


            }

            if (BuscarPro.Count != 0)
            {
                TxtSucursal.Text = Sucursal[0].Nombre.ToString();

                TxtCategoria.Text = Categorias[0].Nombre.ToString();
                TxtNombre.Text = BuscarPro[0].Nombre;
                TxtPrecioCompra.Text = "$" + BuscarPro[0].PrecioCompra.ToString();
                TxtPrecioVenta.Text = "$" + BuscarPro[0].PrecioVenta.ToString();
                TxtCantidad.Text = BuscarPro[0].Cantidad.ToString();
                MessageBox.Show("Se ha encontrado el dato solicitado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            else
            {
                txtProducto.Clear();
                txtProducto.Focus();
            }    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BuscarProducto_Load(object sender, EventArgs e)
        {
            combo = buscar.MostrarProductos();


            ComboBoxProductos.DataSource = combo;
            ComboBoxProductos.DisplayMember = "Nombre";
        }

        private void ComboBoxProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtProducto.Text = combo[ComboBoxProductos.SelectedIndex].IdProducto.ToString();
            BtnBuscar.Focus();
        }
    }
}
