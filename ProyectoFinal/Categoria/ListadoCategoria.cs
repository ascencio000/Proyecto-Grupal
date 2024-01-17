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
    public partial class ListadoCategoria : Form
    {
        public ListadoCategoria()
        {
            InitializeComponent();
        }


        private void Btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ListadoCategoria_Load(object sender, EventArgs e)
        {
            conexiones ListCate = new conexiones();
            dataGridView1.DataSource = ListCate.MostrarCategoria();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conexiones ListCate = new conexiones();
            dataGridView1.DataSource = ListCate.MostrarCategoria();
        }
    }
}