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
    
    public partial class ConsultarDato : Form
    {
        CNDatos objdatos = new CNDatos();
        public ConsultarDato()
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
        private void ConsultarDato_Load(object sender, EventArgs e)
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
    }
}
