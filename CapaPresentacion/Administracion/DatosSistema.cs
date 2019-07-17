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
    public partial class DatosSistema : Form
    {
        CNDatos objdatos = new CNDatos();
        public DatosSistema()
        {
            InitializeComponent();

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            textBoxIva.Clear();
            textBoxServicio.Clear();
            textBoxFactura.Clear();
            textBoxPedido.Clear();
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

        private void DatosSistema_Load(object sender, EventArgs e)
        {
            datos();
            tables();
        }
        private void datos()
        {
            DataTable dato = objdatos.IVA();
            textBoxIva.Text = dato.Rows[0][0].ToString();
            dato = objdatos.NumeroFactura();
            textBoxFactura.Text = dato.Rows[0][0].ToString();
            dato = objdatos.Servicio();
            textBoxServicio.Text = dato.Rows[0][0].ToString();
            dato = objdatos.NumeroPedido();
            textBoxPedido.Text = dato.Rows[0][0].ToString();
            dato = objdatos.NumeroMesas();
            textBoxMesas.Text = dato.Rows[0][0].ToString();

        }
        private void tables()
        {
            CargodataGridView.DataSource = objdatos.Cargos();
            TipoGridView.DataSource = objdatos.Tipo();
            MedidaGridView.DataSource = objdatos.Medida();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            objdatos.Nombre1 = textBoxNomCargo.Text;
            objdatos.IdDato = Convert.ToInt32(textBoxIDCargo.Text);
            objdatos.UpdateCargo();
            MessageBox.Show("Cargo Modificado Exitosamente");
            textBoxNomCargo.Clear();
            textBoxIDCargo.Clear();
            tables();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            objdatos.Nombre1 = textBoxNombreTipo.Text;
            objdatos.IdDato = Convert.ToInt32(textBoxIDTipo.Text);
            objdatos.UpdateTipo();
            MessageBox.Show("Tipo Modificado Exitosamente");
            textBoxNombreTipo.Clear();
            textBoxIDTipo.Clear();
            tables();
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

        private void button6_Click(object sender, EventArgs e)
        {
            objdatos.Nombre1 = textBoxNombreTipo.Text;
            objdatos.IdDato = Convert.ToInt32(textBoxIDTipo.Text);
            objdatos.UpdateMedida();
            MessageBox.Show("Medida Modificado Exitosamente");
            textBoxNombreTipo.Clear();
            textBoxIDTipo.Clear();
            tables();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            objdatos.Valor = decimal.Parse(textBoxIva.Text);
            objdatos.Nombre1 = "IVA";
            objdatos.UpdateDato();
            objdatos.Valor = decimal.Parse(textBoxServicio.Text);
            objdatos.Nombre1 = "Servicio";
            objdatos.UpdateDato();
            objdatos.Valor = decimal.Parse(textBoxFactura.Text);
            objdatos.Nombre1 = "Factura";
            objdatos.UpdateDato();
            objdatos.Valor = decimal.Parse(textBoxPedido.Text);
            objdatos.Nombre1 = "Pedido";
            objdatos.UpdateDato();
            objdatos.Valor = decimal.Parse(textBoxMesas.Text);
            objdatos.Nombre1 = "Mesas";
            objdatos.UpdateDato();
            
            MessageBox.Show("Datos Modificados Exitosamente");
            datos();

        }
    }
}
