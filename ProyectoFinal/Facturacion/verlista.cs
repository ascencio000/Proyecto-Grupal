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
    public partial class verlista : Form
    {
        public verlista()
        {
            InitializeComponent();
        }

        private void Btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void verlista_Load(object sender, EventArgs e)
        {
            conexiones objeto2 = new conexiones();
            dataGridView1.DataSource = objeto2.mostrarfactu();
        }
    }
}
