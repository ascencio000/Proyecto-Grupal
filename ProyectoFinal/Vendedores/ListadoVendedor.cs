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
    public partial class ListadoVendedor : Form
    {
        public ListadoVendedor()
        {
            InitializeComponent();
        }

       
        private void Btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ListadoVendedor_Load(object sender, EventArgs e)
        {
            conexiones vendedores = new conexiones();
            dataGridView1.DataSource = vendedores.MostrarVendedores();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conexiones vendedores = new conexiones();
            dataGridView1.DataSource = vendedores.MostrarVendedores();
        }
    
    }
}
