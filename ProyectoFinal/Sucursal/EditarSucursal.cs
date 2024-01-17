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
    public partial class EditarSucursal : Form
    {
        public EditarSucursal()
        {
            InitializeComponent();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            conexiones busSucursal = new conexiones();
            List<Sucursales> sucur = new List<Sucursales>();
            if (TxtIDSucursal.Text.Trim() == string.Empty) //REVISA QUE SE INGRESE ID
            {
                MessageBox.Show("Por Favor rellene los espacios en blanco", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtIDSucursal.Clear();
                TxtIDSucursal.Focus();
            }
            else
            {
                TxtIDSucursal.Enabled = false;
                TxtNombreS.Enabled = true;
                TxtDireccionS.Enabled = true;
                try
                {
                    int id = Convert.ToInt32(TxtIDSucursal.Text);
                    sucur = busSucursal.BuscarSucursal(id);

                }
                catch (Exception ex)
                {

                    MessageBox.Show("Hay un error " + ex.Message, "AVISO", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    TxtIDSucursal.Enabled = true;
                    TxtIDSucursal.Clear();
                    TxtIDSucursal.Focus();
                    TxtNombreS.Enabled = false;
                    TxtDireccionS.Enabled = false;
                }


            }
            if (sucur.Count != 0) //POR SI EL ID ESTA VACIO
            {
                TxtNombreS.Text = sucur[0].Nombre.ToString();
                TxtDireccionS.Text = sucur[0].Direccion.ToString();
            }
            else
            {
                
                TxtIDSucursal.Enabled = true;
                TxtIDSucursal.Clear();
                TxtIDSucursal.Focus();
                TxtNombreS.Enabled = false;
                TxtDireccionS.Enabled = false;

            }
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            conexiones editarSucu = new conexiones(); //REVISA SI POR ERROR SE BORRARON LOS DATOS ANTES DE REALIZAR LA ACTUALIZACION EN BD
            if (TxtIDSucursal.Text.Trim() == string.Empty || TxtNombreS.Text.Trim() == string.Empty || TxtDireccionS.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Por favor, complete todos los campos (Nombre y Dirección).", "Campos Vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                try
                {
                    int id = Convert.ToInt32(TxtIDSucursal.Text);
                    string nombre = TxtNombreS.Text.Trim();
                    string direccion = TxtDireccionS.Text.Trim();
                    editarSucu.EditarSucursal(nombre, direccion, id);
                    conexiones fun = new conexiones();
                    dataGridView1.DataSource = fun.MostrarSucursales();
                    MessageBox.Show("Los datos se han actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TxtDireccionS.Clear();
                    TxtIDSucursal.Clear();
                    TxtNombreS.Clear();
                    TxtIDSucursal.Enabled = true;
                    TxtIDSucursal.Focus();
                    TxtNombreS.Enabled = false;
                    TxtDireccionS.Enabled = false;
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Hay un error " + ex.Message, "AVISO", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                }



            }

        }

        private void Btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditarSucursal_Load(object sender, EventArgs e)
        {
            conexiones fun = new conexiones();
            dataGridView1.DataSource = fun.MostrarSucursales();
            TxtNombreS.Enabled = false;
            TxtDireccionS.Enabled = false;
        }


    }
}
