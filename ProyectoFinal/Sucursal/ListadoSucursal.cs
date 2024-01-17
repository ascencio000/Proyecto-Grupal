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
    public partial class ListadoSucursal : Form
    {
        public ListadoSucursal()
        {
            InitializeComponent();
        }

        

        private void Btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ListadoSucursal_Load(object sender, EventArgs e)
        {
            conexiones Sucursal = new conexiones();
            dataGridView1.DataSource = Sucursal.MostrarSucursales();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conexiones Sucursal = new conexiones();
            dataGridView1.DataSource = Sucursal.MostrarSucursales();
        }
    }
}
