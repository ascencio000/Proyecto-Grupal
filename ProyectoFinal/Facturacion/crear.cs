using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal.Facturacion
{
    public partial class crear : Form
    {

        
        public crear()
        {
            InitializeComponent();
        }
        int[] cantidades_bd;
        //List<Productos> productos = new List<Productos>();
        List<Facturando> listafactura = new List<Facturando>();
        int i = 0;
        int h = 0;
        // boton crear facturas
        // el cual nos sirve para actualizar el inventario también
        private void Btn_Crear_Click(object sender, EventArgs e)
        {
            
            conexiones guardandofa = new conexiones();


            try
            {
                if (listafactura.Count != 0)
                {
                    Btn_limpiar.Enabled = true;
                    double sumatotales = 0;
                    sumatotales = Convert.ToDouble(Txt_total.Text);
                    for (i = 0; i < listafactura.Count; i++)
                    {
                        int idvendedor = 0, idproducto = 0, cantidad = 0;
                        int idfactura = 0;
                        double precio = 0;
                        DateTime fecha;
                        idvendedor = listafactura[i].idvendedor;
                        fecha = listafactura[i].fecha;
                        idproducto = listafactura[i].idproducto;
                        cantidad = listafactura[i].cantidad;
                        precio = listafactura[i].precio;
                        guardandofa.insertando(idvendedor, sumatotales, fecha, idfactura, idproducto, cantidad, precio);
                        conexiones objeto3 = new conexiones();
                        // llamo a estos metodos para poder ir actualizando luego de
                        // que se vaya insertando cada producto en la tabla
                        // Es decir que actualiza producto por producto 
                        // primero en la columna cantidad Producto y luego en stock Categoria
                        objeto3.actualizartabla();
                        objeto3.actualizartabla2();

                    }


                }
                else
                {
                    MessageBox.Show("No Se Han Seleccionado Productos","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }

               


            }
            catch (Exception ex)
            {
                throw new Exception("Hay un error en los datos ingresados" + ex.Message);
            }


        }

        // boton salir
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        // listas para que tengan mayor alcance
        conexiones objproducto = new conexiones();
        List<Productos> lista = new List<Productos>();
        List<Vendedor> lista1 = new List<Vendedor>();
        private void crear_Load(object sender, EventArgs e)
        {
            lista = objproducto.MostrarProductos();
            combo_producto.DataSource = lista;
            combo_producto.DisplayMember = "nombre";
            lista1 = objproducto.MostrarVendedores();
            combo_vendedor.DataSource = lista1;
            combo_vendedor.DisplayMember = "nombre";
            conexiones objeto = new conexiones();
            List<Productos> verificando = new List<Productos>();
            verificando = objeto.MostrarProductos();

            cantidades_bd = new int[verificando.Count];
            for (int i = 0; i < verificando.Count; i++)
            {
                cantidades_bd[i] = verificando[i].Cantidad;
            }
        }



        // boton para ir agregando cada producto
        private void Btn_agregar_Click(object sender, EventArgs e)
        {

            int cantidad1 = 0;
            double precio1 = 0, iva = 0, total1 = 0, subtotal = 0;
            if (txt_cantidad.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Por favor rellena los campos vacios", "Aviso");
                txt_cantidad.Clear();
                txt_cantidad.Focus();
            }
            else if ((Convert.ToInt32(txt_cantidad.Text) <= 0))
            {
                MessageBox.Show("Por favor, ingresa una cantidad válida", "Aviso");
                txt_cantidad.Clear();
                txt_cantidad.Focus();

            }else
            {
                try
                {
                    cantidad1 = Convert.ToInt32(txt_cantidad.Text);
                    precio1 = Convert.ToDouble(txt_precio.Text);
                    DataGridViewRow fila = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                    fila.Cells[0].Value = combo_producto.Text;
                    fila.Cells[1].Value = precio1;
                    fila.Cells[2].Value = cantidad1;
                    fila.Cells[3].Value = (precio1 * cantidad1);
                    dataGridView1.Rows.Add(fila);

                    subtotal = Convert.ToDouble(Txt_subtotal.Text);
                    iva = Convert.ToDouble(Txt_IVA.Text);
                    total1 = Convert.ToDouble(Txt_total.Text);
                    subtotal = subtotal + (precio1 * cantidad1);
                    iva = subtotal * 0.13;
                    total1 = subtotal + iva;
                    Math.Round(subtotal, 2);
                    Math.Round(iva, 2);
                    Math.Round(total1, 2);
                    Txt_total.Text = total1.ToString();
                    Txt_subtotal.Text = subtotal.ToString();
                    Txt_IVA.Text = iva.ToString();


                    conexiones guardandofa = new conexiones();

                    try
                    {
                        int[] cantidades = new int[combo_producto.SelectedIndex];
                        int idvendedor = 0;
                        double total = 0;
                        DateTime fecha;
                        int idproducto = 0;
                        int cantidad = 0;
                        double precio = 0;
                        int verificar = 0;

                        conexiones objeto = new conexiones();
                        List<Productos> verificando = new List<Productos>();
                        verificando = objeto.MostrarProductos();
                        verificar = Convert.ToInt32(verificando[combo_producto.SelectedIndex].Cantidad.ToString());
                        idvendedor = (Convert.ToInt32(combo_vendedor.SelectedIndex)) + 1;
                        precio = Convert.ToDouble(txt_precio.Text);
                        cantidad = Convert.ToInt32(txt_cantidad.Text);
                        //OJO CON ESE TOTAL
                        total = Convert.ToDouble(Txt_total.Text);
                        fecha = Convert.ToDateTime(dateTimePicker1.Value.ToString());
                        idproducto = (Convert.ToInt32(combo_producto.SelectedIndex)) + 1;

                        if (cantidad > cantidades_bd[combo_producto.SelectedIndex])
                        {
                            dataGridView1.Rows.Clear();
                            txt_cantidad.Clear();
                            Txt_subtotal.Text = 0.ToString();
                            Txt_total.Text = 0.ToString();
                            Txt_IVA.Text = 0.ToString();
                            conexiones objeto2 = new conexiones();
                            List<Productos> verificando2 = new List<Productos>();
                            verificando2 = objeto2.MostrarProductos();

                            cantidades_bd = new int[verificando2.Count];
                            for (int i = 0; i < verificando2.Count; i++)
                            {
                                cantidades_bd[i] = verificando2[i].Cantidad;
                            }
                            MessageBox.Show("La cantidad ingresada es mayor que nuestro inventario", "Aviso");


                        }
                        else
                        {
                            cantidades_bd[combo_producto.SelectedIndex] -= cantidad;
                            Facturando listatemp = new Facturando { idvendedor = idvendedor, total = total, fecha = fecha, idproducto = idproducto, cantidad = cantidad, precio = precio };
                            listafactura.Add(listatemp);
                            i++;
                            h++;

                        }



                    }

                    catch
                    {

                        MessageBox.Show("Se ha producido un error. Por favor, revisa los campos e inténtalo de nuevo.", "AVISO", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    }
                }
                catch (Exception)
                {

                    MessageBox.Show("Se ha producido un error. Por favor, revisa los campos e inténtalo de nuevo.", "AVISO", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                }

            }







        }

        // al seleccionar un item del combobox, lo convertimos en string para mostrar 
        // su precio en un textbox
        private void combo_producto_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_precio.Text = lista[combo_producto.SelectedIndex].PrecioVenta.ToString();
        }


        // boton limpiar 
        private void Btn_limpiar_Click(object sender, EventArgs e)
        {
            listafactura.RemoveAt(h - 1);
            h--;
            dataGridView1.Rows.Clear();
            txt_cantidad.Clear();
            Txt_subtotal.Text = 0.ToString();
            Txt_total.Text = 0.ToString();
            Txt_IVA.Text = 0.ToString();


        }


        private void Btn_actualizar_Click_1(object sender, EventArgs e)
        {


        }
    }




}
