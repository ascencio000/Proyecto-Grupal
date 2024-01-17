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
    public partial class EditarProducto : Form
    {
        public EditarProducto()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conexiones buscar = new conexiones();
            int id = 0;
            List<Productos> BuscarPro = new List<Productos>();
            if (txtProducto.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Por favor revisa que el ID este correcto", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtProducto.Focus();
            }

            else
            {
                txtProducto.Enabled = false;
                TxtCantidad.Enabled = true;
                TxtCategoria.Enabled = true;
                TxtNombre.Enabled = true;
                TxtPrecioCompra.Enabled = true;
                TxtPrecioVenta.Enabled = true;
                TxtSucursal.Enabled = true;

                try
                {
                    id = Convert.ToInt32(txtProducto.Text);
                    BuscarPro = buscar.BuscarProducto(id);
                }
                catch
                {

                    MessageBox.Show("Por favor revisa que el ID este correcto", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtProducto.Enabled = true;

                    txtProducto.Clear();
                    txtProducto.Focus();
                    TxtCantidad.Enabled = false;
                    TxtCategoria.Enabled = false; ;
                    TxtNombre.Enabled = false;
                    TxtPrecioCompra.Enabled = false;
                    TxtPrecioVenta.Enabled = false;
                    TxtSucursal.Enabled = false;
                }



            }

            if (BuscarPro.Count != 0)
            {
                TxtSucursal.Text = BuscarPro[0].IdSucursal.ToString();
                TxtCategoria.Text = BuscarPro[0].IdCategoria.ToString();
                TxtNombre.Text = BuscarPro[0].Nombre;
                TxtPrecioCompra.Text = BuscarPro[0].PrecioCompra.ToString();
                TxtPrecioVenta.Text = BuscarPro[0].PrecioVenta.ToString();
                TxtCantidad.Text = BuscarPro[0].Cantidad.ToString();
            }
            else
            {
                txtProducto.Enabled = true;
                txtProducto.Clear();
                txtProducto.Focus();
                TxtCantidad.Enabled = false;
                TxtCategoria.Enabled = false; ;
                TxtNombre.Enabled = false;
                TxtPrecioCompra.Enabled = false;
                TxtPrecioVenta.Enabled = false;
                TxtSucursal.Enabled = false;
            }
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {

            conexiones Editar = new conexiones();


            if (TxtNombre.Text.Trim() == string.Empty || txtProducto.Text.Trim() == string.Empty || TxtSucursal.Text == string.Empty || TxtCategoria.Text == string.Empty || TxtNombre.Text == string.Empty ||
                TxtPrecioCompra.Text == string.Empty || TxtPrecioVenta.Text == string.Empty || TxtCantidad.Text == string.Empty)
            {
                MessageBox.Show("Por Favor rellene los espacios en blanco", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    int idS = Convert.ToInt32(TxtSucursal.Text);
                    int idC = Convert.ToInt32(TxtCategoria.Text);
                    string nombre = TxtNombre.Text.Trim();
                    double precioC = Convert.ToDouble(TxtPrecioCompra.Text);
                    double precioV = Convert.ToDouble(TxtPrecioVenta.Text);
                    int cantidad = Convert.ToInt32(TxtCantidad.Text);
                    int id = Convert.ToInt32(txtProducto.Text);
                    Editar.EditarProductos(idS, idC, nombre, precioC, precioV, cantidad, id);
                    conexiones fun = new conexiones();
                    dataGridView1.DataSource = fun.MostrarProductos();
                    MessageBox.Show("Los datos se han actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtProducto.Clear();
                    TxtCantidad.Clear();
                    TxtCategoria.Clear();
                    TxtNombre.Clear();
                    TxtPrecioCompra.Clear();
                    TxtPrecioVenta.Clear();
                    TxtSucursal.Clear();
                    txtProducto.Focus();
                    txtProducto.Enabled = true;
                    TxtCantidad.Enabled = false;
                    TxtCategoria.Enabled = false; ;
                    TxtNombre.Enabled = false;
                    TxtPrecioCompra.Enabled = false;
                    TxtPrecioVenta.Enabled = false;
                    TxtSucursal.Enabled = false;
                }
                catch
                {


                    MessageBox.Show("Se ha producido un error. Por favor, revisa los campos e inténtalo de nuevo.", "AVISO", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    TxtCantidad.Enabled = false;
                    TxtCategoria.Enabled = false; ;
                    TxtNombre.Enabled = false;
                    TxtPrecioCompra.Enabled = false;
                    TxtPrecioVenta.Enabled = false;
                    TxtSucursal.Enabled = false;
                }

            }
        }

        private void EditarProducto_Load(object sender, EventArgs e)
        {
            conexiones fun = new conexiones();
            dataGridView1.DataSource = fun.MostrarProductos();
            TxtCantidad.Enabled = false;
            TxtCategoria.Enabled = false; ;
            TxtNombre.Enabled = false;
            TxtPrecioCompra.Enabled = false;
            TxtPrecioVenta.Enabled = false;
            TxtSucursal.Enabled = false;
        }

        private void Btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
