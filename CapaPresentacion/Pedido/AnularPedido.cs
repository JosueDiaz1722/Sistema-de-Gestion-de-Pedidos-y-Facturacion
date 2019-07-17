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

namespace CapaPresentacion.Pedido
{
    public partial class AnularPedido : Form
    {
        public AnularPedido()
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
            comboBox1.Items.Add("No. Pedido");
            comboBox1.Items.Add("Identificación Cliente");
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.SelectedIndex = 0;
        }

        private void ListaPedidos()
        {
            CNPedido objDato = new CNPedido();
            PedidodataGridView.DataSource = objDato.ListaPedidos();
            IndexTable();
        }

        private void IndexTable()
        {
            PedidodataGridView.Columns[0].HeaderText = "No. Pedido";
            PedidodataGridView.Columns[1].HeaderText = "Identificación Cliente";
            PedidodataGridView.Columns[2].HeaderText = "Fecha";
            PedidodataGridView.Columns[3].HeaderText = "Mesa";
            PedidodataGridView.Columns[4].HeaderText = "Subtotal";
            PedidodataGridView.Columns[5].HeaderText = "Iva";
            PedidodataGridView.Columns[6].HeaderText = "Servicio";
            PedidodataGridView.Columns[7].HeaderText = "Total";
            PedidodataGridView.Columns[8].HeaderText = "Estado";
        }
        private void AnularPedido_Load(object sender, EventArgs e)
        {
            LoadComboBox();
            ListaPedidos();
            IndexTable();

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textBox1.Text))
            {
                ListaPedidos();
            }
            else
            {
                string criterio = comboBox1.Text;
                switch (criterio)
                {
                    case "No. Pedido":
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

            CNPedido objDato = new CNPedido();
            objDato.NumPedido = int.Parse(id);
            PedidodataGridView.DataSource = objDato.BuscarNumeroPedido();
            IndexTable();

        }
        private void BuscarClientePedio(string id)
        {

            CNPedido objDato = new CNPedido();
            objDato.IdCliente = id;
            PedidodataGridView.DataSource = objDato.BuscarClientePedido();
            IndexTable();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (PedidodataGridView.SelectedRows.Count > 0)
            {
                if (PedidodataGridView.CurrentRow.Cells[8].Value.ToString().Equals("FACTURADO"))
                {
                    MessageBox.Show("No Se Puede Anular Un Pedido Facturado");
                }
                else
                {
                    String Men = "¿Seguro que quiere anular a este pedido?";
                    String Tit = "Anular Pedido";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result = MessageBox.Show(Men, Tit, buttons);
                    if (result == DialogResult.Yes)
                    {
                        CNPedido objDato = new CNPedido();
                        objDato.NumPedido = int.Parse(PedidodataGridView.CurrentRow.Cells[0].Value.ToString());
                        objDato.Fecha1 = DateTime.Parse(PedidodataGridView.CurrentRow.Cells[2].Value.ToString());
                        objDato.AnularPedido();
                        ListaPedidos();
                        MessageBox.Show("Pedido Anulado Exitosamente");
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
