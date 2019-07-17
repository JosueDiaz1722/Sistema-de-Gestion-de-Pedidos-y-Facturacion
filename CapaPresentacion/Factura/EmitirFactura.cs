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
    public partial class EmitirFactura : Form
    {
        private int f;
        DataTable ListaPedido = new DataTable();
        public EmitirFactura()
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

        private void EmitirFactura_Load(object sender, EventArgs e)
        {
            DateTime current = DateTime.Now;
            textBoxFecha.Text = current.ToString("dd/MM/yyyy");
            LoadCombobox();
            LoadMesas();
            btnEmitir.Enabled = false;
            
            numeroFactura();
            textBoxNumFactura.Text = f.ToString();
        }

        private void LoadCombobox()
        {
            comboBox1.Items.Add("Factura");
            comboBox1.Items.Add("Consumidor Final");
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.SelectedIndex = -1;

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

        private void ListaIndex2()
        {

            ProductodataGridView.Columns[0].HeaderText = "Código Producto";
            ProductodataGridView.Columns[1].HeaderText = "Nombre Producto";
            ProductodataGridView.Columns[2].HeaderText = "Cantidad";
            ProductodataGridView.Columns[3].HeaderText = "PVP";
            ProductodataGridView.Columns[3].HeaderText = "Total";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxNumeroPedido.Text))
            {
                limpiar();
            }
            else
            {
                limpiar();
                CNPedido objPedido = new CNPedido();
                objPedido.NumPedido = int.Parse(textBoxNumeroPedido.Text);
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");
                objPedido.Fecha1 = DateTime.Parse(textBoxFecha.Text);

                try
                {
                    DataTable Pedido = objPedido.BuscarPedidoFactura();
                    int n = int.Parse(Pedido.Rows[0][8].ToString());
                    comboBox2.SelectedIndex = n - 1;
                    textBoxSubTotal.Text = Pedido.Rows[0][3].ToString();
                    textBoxServicio.Text = Pedido.Rows[0][4].ToString();
                    textBoxIVA.Text = Pedido.Rows[0][5].ToString();
                    textBoxTotal.Text = Pedido.Rows[0][6].ToString();

                    CNCliente objCli = new CNCliente();
                    objCli.Id = Pedido.Rows[0][1].ToString();
                    DataTable Cliente = objCli.BuscarID();

                    textBoxRUC.Text = Cliente.Rows[0][1].ToString();
                    textBoxNombre.Text = Cliente.Rows[0][2].ToString();
                    textBoxApellido.Text = Cliente.Rows[0][3].ToString();
                    textBoxDireccion.Text = Cliente.Rows[0][4].ToString();
                    textBoxCorreo.Text = Cliente.Rows[0][5].ToString();
                    textBoxTelefono.Text = Cliente.Rows[0][6].ToString();


                    CNDetallePedido objDet = new CNDetallePedido();
                    objDet.NumPedido = int.Parse(textBoxNumeroPedido.Text);
                    objDet.Fecha = DateTime.Parse(textBoxFecha.Text);
                    ListaPedido = objDet.ListaDetallePedidos();
                    ProductodataGridView.DataSource = ListaPedido;
                    ListaIndex2();
                    
                    btnEmitir.Enabled = true;
                    comboBox1.SelectedIndex = 0;
                    comboBox1.Enabled = true;
                }
                catch
                {
                    MessageBox.Show("Pedido No Existo o No esta Cerrado el Pedido");
                }
                
            }
            

        }

        private void limpiar()
        {
            
            comboBox2.SelectedIndex = -1;
            textBoxSubTotal.Clear();
            textBoxServicio.Clear();
            textBoxIVA.Clear();
            textBoxTotal.Clear();
            textBoxRUC.Clear();
            textBoxNombre.Clear();
            textBoxApellido.Clear();
            textBoxDireccion.Clear();
            textBoxCorreo.Clear();
            textBoxTelefono.Clear();
            ProductodataGridView.DataSource = null;

        }

        private void numeroFactura()
        {
            CNDatos objDatos = new CNDatos();
            DataTable dato = objDatos.NumeroFactura();
            decimal a = decimal.Parse(dato.Rows[0][0].ToString());
            f = decimal.ToInt32(a);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if( comboBox1.SelectedIndex == 0)
            {

            }else{
                textBoxNumFactura.Text = "00000000000000";
            }
        }

        private void btnEmitir_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text.Equals("Factura"))
            {
                CNFactura objDato = new CNFactura();
                objDato.Numfactura = int.Parse(textBoxNumFactura.Text);
                objDato.Numpedido = int.Parse(textBoxNumeroPedido.Text);
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");
                objDato.Fecha = DateTime.Parse(textBoxFecha.Text);
                objDato.EmitirFactura();
                CNDatos objDatos = new CNDatos();
                f++;
                objDatos.Valor = f;
                objDatos.UpdateNumeroFactura();
                MessageBox.Show("Factura Emitida Exitosamente");
                this.Close();
                
            }
            else
            {
                CNFactura objDato = new CNFactura();
                objDato.Numfactura = int.Parse(textBoxNumFactura.Text);
                objDato.Numpedido = int.Parse(textBoxNumeroPedido.Text);
                objDato.Fecha = DateTime.Parse(textBoxFecha.Text);
                objDato.EmitirConsumidor();
                MessageBox.Show("Consumidor Final Emitido Exitosamente");
                this.Close();
            }
            
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == printDialog1.ShowDialog())
            {
                PrintPreviewDialog printPreview = new PrintPreviewDialog();
                printPreview.Document = imprimirPedido;

                // this is were you take the printersettings from the printDialog
                printPreview.Document.PrinterSettings = printDialog1.PrinterSettings;

                imprimirPedido.DefaultPageSettings.Landscape = true;
                printPreview.ShowDialog();
            }
        }

        private void imprimirPedido_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("FECHA\t SANGOLQUI\t" + textBoxFecha.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 140));
            e.Graphics.DrawString("NOMB\t " + textBoxNombre.Text + " " + textBoxApellido.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 160));
            e.Graphics.DrawString("CI.\t " + textBoxRUC.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 180));
            e.Graphics.DrawString("DIRREC\t " + textBoxDireccion.Text + "\tCOD\t" + textBoxRUC.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 200));
            e.Graphics.DrawString("TELF\t " + textBoxTelefono.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 220));
            e.Graphics.DrawString("CORREO\t " + textBoxCorreo.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 240));
            e.Graphics.DrawString("FACT\t " + textBoxNumFactura.Text + "\tMESA\t" + comboBox2.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 260));
            e.Graphics.DrawString("CANT.\tARTICULO\t V.UNT\tV.TOTAL", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 280));
            int n = 300;
            foreach (DataRow row in ListaPedido.Rows)
            {

                e.Graphics.DrawString(row["cantidad"].ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, n));
                e.Graphics.DrawString("\t" + row["nombreProducto"].ToString(), new Font("Arial", 8, FontStyle.Regular), Brushes.Black, new Point(25, n));
                e.Graphics.DrawString("\t\t\t " + row["PVP"].ToString() + "\t" + row["preciototal"].ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, n));
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
