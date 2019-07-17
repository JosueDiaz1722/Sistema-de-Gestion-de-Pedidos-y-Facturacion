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
    
    public partial class CrearDatos : Form
    {
        CNDatos objdatos = new CNDatos();
        public CrearDatos()
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
        private void CrearDatos_Load(object sender, EventArgs e)
        {
            tables();
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
            objdatos.AddCargo();
            MessageBox.Show("Cargo Creado Exitosamente");
            textBoxNomCargo.Clear();
            
            tables();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            objdatos.Nombre1 = textBoxNombreTipo.Text;
            objdatos.AddTipo();
            MessageBox.Show("Tipo Creado Exitosamente");
            textBoxNombreTipo.Clear();
            
            tables();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            objdatos.Nombre1 = textBoxNomMedida.Text;
            objdatos.AddMedida();
            MessageBox.Show("Medida Creado Exitosamente");
            textBoxNomMedida.Clear();
            
            tables();
        }
    }
}
