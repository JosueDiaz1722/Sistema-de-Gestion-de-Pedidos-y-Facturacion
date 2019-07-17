using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion.Administracion
{
    public partial class EliminarDato : Form
    {
        CNDatos objdatos = new CNDatos();
        public EliminarDato()
        {
            InitializeComponent();
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            String Men = "¿Seguro que quiere cerrar esta ventana?";
            String Tit = "Cerrar Ventana";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(Men, Tit, buttons);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void EliminarDato_Load(object sender, EventArgs e)
        {
            
            tables();
        }

       
        private void tables()
        {
            CargodataGridView.DataSource = objdatos.Cargos();
            TipoGridView.DataSource = objdatos.Tipo();
            MedidaGridView.DataSource = objdatos.Medida();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CargodataGridView.SelectedRows.Count > 0)
            {

                textBoxIDCargo.Text = CargodataGridView.CurrentRow.Cells[0].Value.ToString();
                textBoxNomCargo.Text = CargodataGridView.CurrentRow.Cells[1].Value.ToString();
            }
            else
            {
                MessageBox.Show("Debe Seleccionar Una Fila");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (TipoGridView.SelectedRows.Count > 0)
            {

                textBoxIDTipo.Text = TipoGridView.CurrentRow.Cells[0].Value.ToString();
                textBoxNombreTipo.Text = TipoGridView.CurrentRow.Cells[1].Value.ToString();
            }
            else
            {
                MessageBox.Show("Debe Seleccionar Una Fila");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MedidaGridView.SelectedRows.Count > 0)
            {
                textBoxIDMedida.Text = MedidaGridView.CurrentRow.Cells[0].Value.ToString();
                textBoxNomMedida.Text = MedidaGridView.CurrentRow.Cells[1].Value.ToString();
            }
            else
            {
                MessageBox.Show("Debe Seleccionar Una Fila");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            objdatos.Nombre1 = textBoxNomCargo.Text;
            objdatos.IdDato = Convert.ToInt32(textBoxIDCargo.Text);
            objdatos.DeleteCargo();
            MessageBox.Show("Cargo Eliminado Exitosamente");
            textBoxNomCargo.Clear();
            textBoxIDCargo.Clear();
            tables();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            objdatos.Nombre1 = textBoxNombreTipo.Text;
            objdatos.IdDato = Convert.ToInt32(textBoxIDTipo.Text);
            objdatos.DeleteMedida();
            MessageBox.Show("Medida Eliminada Exitosamente");
            textBoxNombreTipo.Clear();
            textBoxIDTipo.Clear();
            tables();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            objdatos.Nombre1 = textBoxNombreTipo.Text;
            objdatos.IdDato = Convert.ToInt32(textBoxIDTipo.Text);
            objdatos.DeleteTipo();
            MessageBox.Show("Tipo Eliminado Exitosamente");
            textBoxNombreTipo.Clear();
            textBoxIDTipo.Clear();
            tables();
        }
    }
}
