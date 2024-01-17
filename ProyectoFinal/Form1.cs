using ProyectoFinal.Facturacion;
using ProyectoFinal.Sucursal;
using ProyectoFinal.Vendedores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        #region BOTONOS PRODUCTO
        private void listadoToolStripMenuItem_Click(object sender, EventArgs e) //Btn PARA MOSTRAR TODOS LOS PRODUCTOS
        {
            ListadoProducto ListaPro = new ListadoProducto();
            

           
                ListaPro.MdiParent = this;
                ListaPro.Show();
              

            
                
            

            Console.WriteLine(Application.OpenForms.Count);
        }

        private void buscarPorIDToolStripMenuItem_Click(object sender, EventArgs e)//Btn PARA BUSCAR PRODUCTO POR ID
        {
            BuscarProducto BusProdu = new BuscarProducto();
           
                BusProdu.MdiParent = this;
                BusProdu.Show();
                
            
           
            
        }

        private void crearToolStripMenuItem_Click(object sender, EventArgs e) //Btn PARA CREAR UN PRODUCTO NUEVO
        {
            CrearProducto CrearProdu = new CrearProducto();
            CrearProdu.MdiParent = this;
            CrearProdu.Show();
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)//Btn PARA ACTUALIZAR UN PRODUCTO
        {
            EditarProducto editarPr = new EditarProducto();
            editarPr.MdiParent = this;
            editarPr.Show();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e) //Btn PARA ELIMINAR UN PRODUCTO POR MEDIO DEL ID   
        {
            EliminarProducto eliminarPro = new EliminarProducto();
            eliminarPro.MdiParent = this;
            eliminarPro.Show();
        }

        #endregion

        #region BOTONOS CATEGORIA
        private void listadoToolStripMenuItem2_Click(object sender, EventArgs e) //Btn PARA MOSTRAR LAS CATEGORIAS
        {
            ListadoCategoria LisCate = new ListadoCategoria();
            LisCate.MdiParent = this;
            LisCate.Show();
        }

        private void buscarPorIDToolStripMenuItem2_Click(object sender, EventArgs e) // Btn PARA BUSCAR UNA CATEGORIA POR ID
        {
            BuscarCategoria BusCategoria = new BuscarCategoria();
            BusCategoria.MdiParent = this;
            BusCategoria.Show();
        }

        private void crearToolStripMenuItem2_Click(object sender, EventArgs e) //Btn PARA CREAR UNA CATEGORIA
        {
            CrearCategoria CrCategoria = new CrearCategoria();
            CrCategoria.MdiParent = this;
            CrCategoria.Show();
        }

        private void editarToolStripMenuItem2_Click(object sender, EventArgs e) //Btn PARA EDITAR UNA CATEGORIA POR ID
        {
            EditarCategoria editar = new EditarCategoria();
            editar.MdiParent = this;
            editar.Show();
        }

        private void eliminarToolStripMenuItem2_Click(object sender, EventArgs e) //Btn PARA ELIMINAR UNA CATEGORIA
        {
            EliminarCategoria delete = new EliminarCategoria();
            delete.MdiParent = this;
            delete.Show();
        }

        #endregion

        #region BOTONOS VENDEDORES
        private void listadoToolStripMenuItem3_Click(object sender, EventArgs e) //Btn PARA MOSTRAR A LOS VENDEDORES
        {
            ListadoVendedor venderdor = new ListadoVendedor();
            venderdor.MdiParent = this;
            venderdor.Show();
        }

        private void buscarPorIDToolStripMenuItem3_Click(object sender, EventArgs e) // Btn PARA BUSCAR A UN VENDEDOR POR ID
        {
            BuscarVendedor buscarVendedor = new BuscarVendedor();
            buscarVendedor.MdiParent = this;
            buscarVendedor.Show();
        }

        private void crearToolStripMenuItem3_Click(object sender, EventArgs e) //Btn PARA CREAR A UN VENDEDOR
        {
            CrearVendedor crear = new CrearVendedor();
            crear.MdiParent = this;
            crear.Show();
        }

        private void editarToolStripMenuItem3_Click(object sender, EventArgs e) //Btn PARA EDITAR A UN VENDEDOR POR EL ID
        {
            EditarVendedor editar = new EditarVendedor();
            editar.MdiParent = this;
            editar.Show();
        }
        private void eliminarToolStripMenuItem3_Click(object sender, EventArgs e) //Btn PARA ELIMINAR UN VENDEDOR
        {
            EliminarVendedor delete = new EliminarVendedor();
            delete.MdiParent = this;
            delete.Show();
        }

        #endregion

        #region BOTONES SUCURSALES
        private void listadoToolStripMenuItem1_Click(object sender, EventArgs e) //BTN PARA MOSTRAR LAS SUCURSALES
        {
            ListadoSucursal sucursal = new ListadoSucursal();
            sucursal.MdiParent = this;
            sucursal.Show();
        }

        private void buscarPorIDToolStripMenuItem1_Click(object sender, EventArgs e) //Btn PARA BUSCAR UNA SUCURSAL
        {
            BuscarSucursal buscarSu = new BuscarSucursal();
            buscarSu.MdiParent = this;
            buscarSu.Show();
        }

        private void crearToolStripMenuItem1_Click(object sender, EventArgs e) //Btn PARA CREAR UNA SUCURSAL
        {
            CrearSucursal crear = new CrearSucursal();
            crear.MdiParent = this;
            crear.Show();
        }

        private void editarToolStripMenuItem1_Click(object sender, EventArgs e) //Btn PARA EDITAR UNA SUCURSAL 
        {
            EditarSucursal editar = new EditarSucursal();
            editar.MdiParent = this;
            editar.Show();
        }
        private void eliminarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            EliminarSucursal delete = new EliminarSucursal();
            delete.MdiParent = this;
            delete.Show();

        }


        #endregion

       
        
        private void Form1_Load(object sender, EventArgs e)
        {
        }

       

        private void crearToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            crear creando = new crear();
            creando.MdiParent = this;
            creando.Show();
        }

        

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void verFacturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            verlista form = new verlista();
            form.MdiParent = this;
            form.Show();
        }

        private void buscarPorIDToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            BuscarID formu = new BuscarID();
            formu.MdiParent = this;
            formu.Show();
        }
    }
}
