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
    public partial class BuscarID : Form
    {
        public BuscarID()
        {
            InitializeComponent();
        }

        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            int id = 0;
            id = Convert.ToInt32(Txt_id.Text);
            conexiones facturando = new conexiones();

            List<detalle> listadodetalle = new List<detalle>();
            listadodetalle = facturando.mostrardetalle(id);

            factura lfactura = new factura();
            lfactura = facturando.mostrarfactura(id);

            List<listaid> listandoid = new List<listaid>();

            for (int i = 0; i < listadodetalle.Count; i++)
            {
                listaid listtemp = new listaid();
                listtemp.iddetalle = listadodetalle[i].iddetalle;
                listtemp.idvendedor = lfactura.idvendedor;
                listtemp.total = lfactura.total;
                listtemp.idproducto = listadodetalle[i].idproducto;
                listtemp.cantidad = listadodetalle[i].cantidad;
                listandoid.Add(listtemp);
            }

            dataGridView1.DataSource = listandoid;


        }
    }
}
