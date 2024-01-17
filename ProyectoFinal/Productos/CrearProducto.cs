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
    public partial class CrearProducto : Form
    {
        conexiones CrearPro = new conexiones();
        List <Sucursales> Sucursal = new List <Sucursales>();
        List<Categoria> Categorias = new List<Categoria>();

        public CrearProducto()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (TxtNombre.Text.Trim() == string.Empty || TxtPrecioCompra.Text.Trim() == string.Empty || TxtPrecioVenta.Text.Trim() == string.Empty || TxtCantidad.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Por favor, asegúrate de revisar que todos los campos estén completos antes de continuar.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtNombre.Focus();

            }
            else
            {
                try
                {
                    int idS = Convert.ToInt32(Sucursal[ComboBoxSucursal.SelectedIndex].IdSucursal);
                    int idC = Convert.ToInt32(Categorias[ComboBoxCategoria.SelectedIndex].IdCategoria);
                    int Stock = Convert.ToInt32(Categorias[ComboBoxCategoria.SelectedIndex].Stock);
                    string nombre = TxtNombre.Text.Trim();
                    double precioC = Convert.ToDouble(TxtPrecioCompra.Text);
                    double precioV = Convert.ToDouble(TxtPrecioVenta.Text);
                    int cantidad = Convert.ToInt32(TxtCantidad.Text);
                    int newStock = Stock + cantidad;
                    CrearPro.CrearProcuto(idS, idC, nombre, precioC, precioV, cantidad);
                    CrearPro.EditarStock(newStock, idC); //AÑADIR TABLA DE STOCK
                    ///LIMPIAR TEXT///
                    TxtCantidad.Clear();
                    TxtNombre.Clear();
                    TxtPrecioCompra.Clear();
                    TxtPrecioVenta.Clear();
                    ComboBoxSucursal.SelectedIndex = 0;
                    ComboBoxCategoria.SelectedIndex = 0;
                    TxtNombre.Focus();

                }
                catch
                {

                    MessageBox.Show("Se ha producido un error. Por favor, revisa los campos e inténtalo de nuevo.", "AVISO", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    TxtPrecioCompra.Focus() ;
                }


            }


        }

        private void CrearProducto_Load(object sender, EventArgs e)
        {
            Sucursal = CrearPro.MostrarSucursales();
            Categorias = CrearPro.MostrarCategoria();

            ComboBoxCategoria.DataSource = Categorias;
            ComboBoxCategoria.DisplayMember = "Nombre";
            
            ComboBoxSucursal.DataSource = Sucursal;
            ComboBoxSucursal.DisplayMember = "Nombre";

            //TxtSucursal.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
