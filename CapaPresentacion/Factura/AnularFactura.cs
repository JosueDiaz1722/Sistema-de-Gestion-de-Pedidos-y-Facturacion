using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion.Factura
{
    public partial class AnularFactura : Form
    {
        public AnularFactura()
        {
            InitializeComponent();
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");
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
            comboBox1.Items.Add("No. Factura");
            comboBox1.Items.Add("Identificación Cliente");
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.SelectedIndex = 0;
        }

        private void ListaFactura()
        {
            CNFactura objDato = new CNFactura();
            FacturasdataGridView.DataSource = objDato.ListaFactura();
            IndexTable();
        }

        private void IndexTable()
        {
            FacturasdataGridView.Columns[0].HeaderText = "No. Factura";
            FacturasdataGridView.Columns[2].HeaderText = "Identificación Cliente";
            FacturasdataGridView.Columns[1].HeaderText = "Fecha";
            FacturasdataGridView.Columns[3].HeaderText = "Nombres Cliente";
            FacturasdataGridView.Columns[4].HeaderText = "Apellidos Cliente";
            FacturasdataGridView.Columns[5].HeaderText = "Total";
            FacturasdataGridView.Columns[6].HeaderText = "Estado";
        }
        private void AnularFactura_Load(object sender, EventArgs e)
        {
            LoadComboBox();
            ListaFactura();
            IndexTable();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textBox1.Text))
            {
                ListaFactura();
            }
            else
            {
                string criterio = comboBox1.Text;
                switch (criterio)
                {
                    case "No. Factura":
                        BuscarNumeroPedido(textBox1.Text);
                        break;
                    case "Identificación Cliente":
                        BuscarClientePedio(textBox1.Text);
                        break;
                }
            }
        }

        private void BuscarNumeroPedido(string id)
        {

            CNFactura objDato = new CNFactura();
            objDato.Numfactura = int.Parse(id);
            FacturasdataGridView.DataSource = objDato.BuscarNumeroFactura();
            IndexTable();

        }
        private void BuscarClientePedio(string id)
        {

            CNFactura objDato = new CNFactura();
            objDato.IdCliente = id;
            FacturasdataGridView.DataSource = objDato.BuscarClienteFactura();
            IndexTable();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (FacturasdataGridView.SelectedRows.Count > 0)
            {
                if (FacturasdataGridView.CurrentRow.Cells[6].Value.ToString().Equals("ANULADO"))
                {
                    MessageBox.Show("La Factura Ya Esta Anulada");
                }
                else
                {
                    String Men = "¿Seguro que quiere anular a esta Factura?";
                    String Tit = "Anular Factura";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result = MessageBox.Show(Men, Tit, buttons);
                    if (result == DialogResult.Yes)
                    {
                        CNFactura objDato = new CNFactura();
                        objDato.Numfactura = int.Parse(FacturasdataGridView.CurrentRow.Cells[0].Value.ToString());

                        objDato.AnularFactura();
                        ListaFactura();
                        MessageBox.Show("Factuar Anulada Exitosamente");
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe Seleccionar Una Fila");
            }
        }
    }
}
