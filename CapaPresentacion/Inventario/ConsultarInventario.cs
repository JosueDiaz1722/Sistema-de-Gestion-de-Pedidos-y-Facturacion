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

namespace CapaPresentacion.Inventario
{
    public partial class ConsultarInventario : Form
    {
        public ConsultarInventario()
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

        private void LoadComboBox()
        {
            InventariocomboBox.Items.Add("Código");
            InventariocomboBox.Items.Add("Descripción");
            InventariocomboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            InventariocomboBox.SelectedIndex = 0;
        }

        private void ListaInventario()
        {
            CNInventarios objDato = new CNInventarios();
            InventariodataGridView.DataSource = objDato.ListaInventario();
            IndexTable();
        }

        private void IndexTable()
        {
            InventariodataGridView.Columns[0].HeaderText = "Código";
            InventariodataGridView.Columns[1].HeaderText = "Descripción";
            InventariodataGridView.Columns[2].HeaderText = "Unidad de Medida";
            InventariodataGridView.Columns[3].HeaderText = "Cantidad";
            InventariodataGridView.Columns[4].HeaderText = "Precio Unitario";
            InventariodataGridView.Columns[5].HeaderText = "Total";
        }
        private void ConsultarInventario_Load(object sender, EventArgs e)
        {
            
            ListaInventario();
            LoadComboBox();
        }

        private void BuscarCod(string cod)
        {
            CNInventarios objDato = new CNInventarios();
            objDato.CodigioInventario = cod;
            InventariodataGridView.DataSource = objDato.BuscarIDInv();
            IndexTable();
        }

        private void BuscarDesc(string desc)
        {
            CNInventarios objDato = new CNInventarios();
            objDato.Descripcion = desc;
            InventariodataGridView.DataSource = objDato.BuscarDescripcionInv();
            IndexTable();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(InventariotextBox.Text))
            {
                ListaInventario();
            }
            else
            {
                string criterio = InventariocomboBox.Text;
                switch (criterio)
                {
                    case "Código":
                        BuscarCod(InventariotextBox.Text);
                        break;
                    case "Descripción":
                        BuscarDesc(InventariotextBox.Text);
                        break;
                }
            }
        }
    }
}
