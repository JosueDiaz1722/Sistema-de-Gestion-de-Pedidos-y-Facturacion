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
using System.Data.SqlClient;
using System.Data;

namespace CapaPresentacion.Pedido
{
    public partial class ConsultarPedido : Form
    {
        private int n = 0;
        DataTable ListaPedido = new DataTable();
        public ConsultarPedido()
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
        private void ConsultarPedido_Load(object sender, EventArgs e)
        {
            LoadComboBox();
            LoadMesas();
            btnImprimir.Enabled = false;

        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            limpiar();
            if (String.IsNullOrWhiteSpace(textBox1.Text))
            {
                
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

        private void LoadMesas()
        {
            CNDatos objDatos = new CNDatos();

            DataTable dato = objDatos.NumeroMesas();
            decimal n = decimal.Parse(dato.Rows[0][0].ToString());
            for (int i = 1; i <= n; i++)
            {
                comboBox2.Items.Add(i);
            }
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.SelectedIndex = -1;

        }

        private void BuscarNumeroPedido(string id)
        {
            n = 5;
            CNPedido objDato = new CNPedido();
            objDato.NumPedido = int.Parse(id);
            FechacomboBox3.DataSource = objDato.BuscarNumeroPedido();
            if (FechacomboBox3.SelectedIndex == -1)
            {
                MessageBox.Show("No Existe Pedido");
            }
            else
            {

                FechacomboBox3.DisplayMember = "Fecha";
                FechacomboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
                FechacomboBox3.SelectedIndex = 0;
                n = 7;
                NumeroPediocomboBox.Items.Add(id);
                NumeroPediocomboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                NumeroPediocomboBox.SelectedIndex = 0;
                

                NumeroPediocomboBox.Enabled = false;
                FechacomboBox3.Enabled = true;
                
            }
            
            
        }
        private void BuscarClientePedio(string id)
        {
            n = 11;
            CNPedido objDato = new CNPedido();
            objDato.IdCliente = id;
            NumeroPediocomboBox.DataSource = objDato.BuscarClientePedidoDistintos();
            if (NumeroPediocomboBox.SelectedIndex == -1)
            {
                MessageBox.Show("No Existe Cliente");
            }
            else
            {
                NumeroPediocomboBox.DisplayMember = "numPedido";
                NumeroPediocomboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                NumeroPediocomboBox.SelectedIndex = 0;

                listaFecha();
                NumeroPediocomboBox.Enabled = true;
                FechacomboBox3.Enabled = true;
                n = 3;

            }
            
        }

        private void cargarClienteNumero()
        {
            CNPedido objPedido = new CNPedido();
            
            objPedido.NumPedido = int.Parse(NumeroPediocomboBox.GetItemText(NumeroPediocomboBox.SelectedItem));
            DataTable Pedido = objPedido.BuscarNumeroPedido();
            int n = int.Parse(Pedido.Rows[0][8].ToString());
            comboBox2.SelectedIndex = n - 1;
            textBoxSubTotal.Text = Pedido.Rows[0][3].ToString();
            textBoxServicio.Text = Pedido.Rows[0][4].ToString();
            textBoxIVA.Text = Pedido.Rows[0][5].ToString();
            textBoxTotal.Text = Pedido.Rows[0][6].ToString();
            textBoxEstado.Text = Pedido.Rows[0][7].ToString();
            int index = FechacomboBox3.FindString(Pedido.Rows[0][2].ToString());
            FechacomboBox3.SelectedIndex = index;


            CNCliente objCli = new CNCliente();
            objCli.Id = Pedido.Rows[0][1].ToString();
            DataTable Cliente = objCli.BuscarID();
            textBoxID.Text = Cliente.Rows[0][0].ToString();
            textBoxRUC.Text = Cliente.Rows[0][1].ToString();
            textBoxNombre.Text = Cliente.Rows[0][2].ToString();
            textBoxApellido.Text = Cliente.Rows[0][3].ToString();
            textBoxDireccion.Text = Cliente.Rows[0][4].ToString();
            textBoxCorreo.Text = Cliente.Rows[0][5].ToString();
            textBoxTelefono.Text = Cliente.Rows[0][6].ToString();
            

            CNDetallePedido objDet = new CNDetallePedido();
            objDet.NumPedido = int.Parse(NumeroPediocomboBox.GetItemText(NumeroPediocomboBox.SelectedItem));
            objDet.Fecha = DateTime.Parse(FechacomboBox3.GetItemText(FechacomboBox3.SelectedItem));
            ListaPedido = objDet.ListaDetallePedidos();
            ProductodataGridView.DataSource = ListaPedido;
            ListaIndex2();

        }

        private void cargarClienteFecha()
        {
            CNPedido objPedido = new CNPedido();

            objPedido.NumPedido = int.Parse(NumeroPediocomboBox.GetItemText(NumeroPediocomboBox.SelectedItem));
            DataTable Pedido = objPedido.BuscarNumeroPedido();
            int n = int.Parse(Pedido.Rows[0][8].ToString());
            comboBox2.SelectedIndex = n - 1;
            textBoxSubTotal.Text = Pedido.Rows[0][3].ToString();
            textBoxServicio.Text = Pedido.Rows[0][4].ToString();
            textBoxIVA.Text = Pedido.Rows[0][5].ToString();
            textBoxTotal.Text = Pedido.Rows[0][6].ToString();
            textBoxEstado.Text = Pedido.Rows[0][7].ToString();

            CNCliente objCli = new CNCliente();
            objCli.Id = Pedido.Rows[0][1].ToString();
            DataTable Cliente = objCli.BuscarID();
            textBoxID.Text = Cliente.Rows[0][0].ToString();
            textBoxRUC.Text = Cliente.Rows[0][1].ToString();
            textBoxNombre.Text = Cliente.Rows[0][2].ToString();
            textBoxApellido.Text = Cliente.Rows[0][3].ToString();
            textBoxDireccion.Text = Cliente.Rows[0][4].ToString();
            textBoxCorreo.Text = Cliente.Rows[0][5].ToString();
            textBoxTelefono.Text = Cliente.Rows[0][6].ToString();


            CNDetallePedido objDet = new CNDetallePedido();
            objDet.NumPedido = int.Parse(NumeroPediocomboBox.GetItemText(NumeroPediocomboBox.SelectedItem));
            objDet.Fecha = DateTime.Parse(FechacomboBox3.Text);
            ListaPedido = objDet.ListaDetallePedidos();
            ProductodataGridView.DataSource = ListaPedido;
            ListaIndex2();

        }

        private void listaFecha()
        {
            limpiar();
            n = 11;
            CNPedido objDato = new CNPedido();
            objDato.NumPedido = int.Parse(NumeroPediocomboBox.Text);
            FechacomboBox3.DataSource = objDato.BuscarNumeroPedido();
            FechacomboBox3.DisplayMember = "Fecha";
            FechacomboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            FechacomboBox3.SelectedIndex = 0;
            n = 3;
        }

        private void NumeroPediocomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(n == 5)
            {
                cargarClienteNumero();
            }
            if(n==3)
            {
                listaFecha();
            }
            
        }

        private void FechacomboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (n == 7)
            {
                cargarClienteFecha();
            }
            if(n==3)
            {
                cargarClienteFecha();
            }
            btnImprimir.Enabled = true;
        }


        private void ListaIndex2()
        {

            ProductodataGridView.Columns[0].HeaderText = "Código Producto";
            ProductodataGridView.Columns[1].HeaderText = "Nombre Producto";
            ProductodataGridView.Columns[2].HeaderText = "Cantidad";
            ProductodataGridView.Columns[3].HeaderText = "PVP";
            ProductodataGridView.Columns[4].HeaderText = "Total";
            ProductodataGridView.Columns[4].DefaultCellStyle.Format = "0.00##";
            

        }

        private void limpiar()
        {
            textBoxSubTotal.Clear();
            textBoxServicio.Clear();
            textBoxIVA.Clear();
            textBoxTotal.Clear();
            textBoxEstado.Clear();
            textBoxID.Clear();
            textBoxRUC.Clear();
            textBoxNombre.Clear();
            textBoxApellido.Clear();
            textBoxDireccion.Clear();
            textBoxCorreo.Clear();
            textBoxTelefono.Clear();
            btnImprimir.Enabled = false;
            ProductodataGridView.DataSource = null;

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            /*printPreviewDialog1.Document = imprimirPedido;
            printPreviewDialog1.ShowDialog();
            printDialog1.Document = imprimirPedido;
            printDialog1.ShowDialog();*/
            PrintDialog printDialog = new PrintDialog();
            if (DialogResult.OK == printDialog.ShowDialog())
            {
                PrintPreviewDialog printPreview = new PrintPreviewDialog();
                printPreview.Document = imprimirPedido;

                // this is were you take the printersettings from the printDialog
                printPreview.Document.PrinterSettings = printDialog.PrinterSettings;

                imprimirPedido.DefaultPageSettings.Landscape = true;
                printPreview.ShowDialog();
            }
        }

        private void imprimirPedido_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("FECHA\t SANGOLQUI\t" + FechacomboBox3.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 140));
            e.Graphics.DrawString("NOMB\t " + textBoxNombre.Text+" "+textBoxApellido.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 160));
            e.Graphics.DrawString("CI.\t " + textBoxRUC.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 180));
            e.Graphics.DrawString("DIRREC\t " + textBoxDireccion.Text+"\tCOD\t"+textBoxRUC.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 200));
            e.Graphics.DrawString("TELF\t " + textBoxTelefono.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 220));
            e.Graphics.DrawString("CORREO\t " + textBoxCorreo.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 240));
            e.Graphics.DrawString("PEDIDO\t " + NumeroPediocomboBox.Text + "\tMESA\t" + comboBox2.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 260));
            e.Graphics.DrawString("CANT.\tARTICULO\t V.UNT\tV.TOTAL", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 280));
            int n = 300;
            foreach (DataRow row in ListaPedido.Rows)
            {
                
                e.Graphics.DrawString(row["cantidad"].ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, n));
                e.Graphics.DrawString("\t" + row["nombreProducto"].ToString(), new Font("Arial", 8, FontStyle.Regular), Brushes.Black, new Point(25, n));
                e.Graphics.DrawString("\t\t\t " + row["PVP"].ToString() + "\t" + ((Decimal)row["preciototal"]).ToString("0.00##"), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, n));
                n += 20;
  
            }
            if (n < 520)
            {
                e.Graphics.DrawString("\t\tSUB TOTAL\t$" + textBoxSubTotal.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 520));
                e.Graphics.DrawString("\t\tSERVICIO\t$" + textBoxServicio.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 540));
                e.Graphics.DrawString("\t\tIVA\t\t$" + textBoxIVA.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 560));
                e.Graphics.DrawString("\t\tTOTAL\t\t$" + textBoxTotal.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 580));
            }
            else
            {
                n += 20;
                e.Graphics.DrawString("\t\tSUB TOTAL\t$" + textBoxSubTotal.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, n));
                n += 20;
                e.Graphics.DrawString("\t\tSERVICIO\t$" + textBoxServicio.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, n));
                n += 20;
                e.Graphics.DrawString("\t\tIVA\t\t$" + textBoxIVA.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, n));
                n += 20;
                e.Graphics.DrawString("\t\tTOTAL\t\t$" + textBoxTotal.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, n));
            }
        }
    }
}
