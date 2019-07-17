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

namespace CapaPresentacion.Pedido
{
    public partial class RegistrarPedido : Form
    {
        DataTable ListaPedido = new DataTable();
        private decimal IVA;
        private decimal Servicio;

        public decimal IVA1 { get => IVA; set => IVA = value; }
        public decimal Servicio1 { get => Servicio; set => Servicio = value; }

        public RegistrarPedido(int n)
        {
            InitializeComponent();
            textBoxPedido.Text = n.ToString();
        }


        private void RegistrarPedido_Load(object sender, EventArgs e)
        {
            DateTime current = DateTime.Now;
            TipoComboBox.Enabled = false;
            textBoxFecha.Text = current.ToString("dd/MM/yyyy");
            LoadMesas();
            LoadCombobox();
            btnBuscarCliente.Enabled = false;
            listaTipo();
            errorCantidad.Visible = false;
            dataTableIndex();
            btnCerrarPedido.Enabled = false;
            DatosSistema();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {

        }

        private void textBoxID_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxRUC.Text))
            {
                errorID.Visible = false;
            }
            else
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(textBoxRUC.Text, "[^0-9]"))
                {
                    errorID.Visible = true;
                    btnBuscarCliente.Enabled = false;
                }
                else
                {
                    errorID.Visible = false;
                    btnBuscarCliente.Enabled = true;
                }
            }

        }

        private void listaTipo()
        {

            CNProductos objProd = new CNProductos();
            TipoComboBox.DataSource = objProd.ListaTipo();
            TipoComboBox.DisplayMember = "nombreTipo";
            TipoComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            TipoComboBox.SelectedIndex = 0;

        }

        private void listaProductos(string tipo)
        {

            CNProductos objProd = new CNProductos();
            objProd.nomTipo = tipo;
            DataTable dato = objProd.BuscarTipoProd();  
            comboBox2.DataSource = dato;
            comboBox2.DisplayMember = "nombreProducto";
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.SelectedIndex = -1;
            
        }

        private void LoadMesas()
        {
            CNDatos objDatos = new CNDatos();

            DataTable dato = objDatos.NumeroMesas();
            decimal n = decimal.Parse(dato.Rows[0][0].ToString());
            for (int i=1; i <= n; i++)
            {
                comboBox1.Items.Add(i);
            }
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.SelectedIndex = 0;

        }
        private void LoadCombobox()
        {
            TipoIdcomboBox.Items.Add("Cédula");
            TipoIdcomboBox.Items.Add("RUC");
            TipoIdcomboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            TipoIdcomboBox.SelectedIndex = -1;

        }

        private void BuscarId(string id)
        {
            CNCliente objDato = new CNCliente();
            objDato.Id = id;
            try
            {
                DataTable dato = objDato.BuscarID();
                if (dato.Rows[0][7].ToString().Equals("ACTIVO"))
                {
                    if (dato.Rows[0][0].ToString().Equals("Cédula"))
                    {
                        TipoIdcomboBox.SelectedIndex = 0;
                    }
                    else
                    {
                        TipoIdcomboBox.SelectedIndex = 1;
                    }
                    textBoxNombre.Text = dato.Rows[0][2].ToString();
                    textBoxApellido.Text = dato.Rows[0][3].ToString();
                    textBoxDireccion.Text = dato.Rows[0][4].ToString();
                    textBoxCorreo.Text = dato.Rows[0][5].ToString();
                    textBoxTelefono.Text = dato.Rows[0][6].ToString();
                    TipoComboBox.Enabled = true;
                    comboBox2.Enabled = true;
                    
                }
                else
                {
                    MessageBox.Show("El Cliente Esta Inactivo");
                }
            }
            catch
            {
                MessageBox.Show("El Cliente No Existe Por Favor Registre al Cliente");
            }
            
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ((TabControl)((TabPage)this.Parent).Parent).TabPages.Remove((TabPage)this.Parent);
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxRUC.Text))
            {
                MessageBox.Show("El Campo de Cédula/RUC Esta Vacio");
            }
            else
            {
                BuscarId(textBoxRUC.Text);
            }
        }

        private void TipoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            listaProductos(TipoComboBox.Text);
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCantidad.Text))
            {
                MessageBox.Show("Por Favor Ingresar Cantidad");
            }
            else
            {
                BuscarProducto(comboBox2.Text);
            }
        }
        private void dataTableIndex()
        {
            ListaPedido.Columns.Add("Código Producto");
            ListaPedido.Columns.Add("Nombre Producto");
            ListaPedido.Columns.Add("Cantidad");
            ListaPedido.Columns.Add("Precio Unitario");
            ListaPedido.Columns.Add("Precio Total");
        }
        private void BuscarProducto(string cod)
        {
            CNProductos objDato = new CNProductos();
            objDato.nombreProd = cod;
            try
            {
                ProductodataGridView.DataSource = ListaPedido;
                DataTable producto = objDato.BuscarNomProd();
                if (ListaPedido.Rows.Count <= 0 || ListaPedido == null)
                {
                    DataRow dr;
                    dr = ListaPedido.NewRow();
                    dr["Código Producto"] = producto.Rows[0][0].ToString();
                    dr["Nombre Producto"] = producto.Rows[0][2].ToString();
                    dr["Cantidad"] = textBoxCantidad.Text;
                    dr["Precio Unitario"] = producto.Rows[0][3].ToString();
                    dr["Precio Total"] = decimal.Parse(textBoxCantidad.Text) * decimal.Parse(producto.Rows[0][3].ToString());
                    ListaPedido.Rows.Add(dr);
                    ProductodataGridView.DataSource = ListaPedido;
                    Calculos();
                    btnAgregarProducto.Enabled = false;
                    TipoComboBox.SelectedIndex = 0;
                    comboBox2.SelectedIndex = 0;
                    textBoxCantidad.Clear();
                    btnCerrarPedido.Enabled = true;
                }
                else
                {
                    for (int i = 0; i < ListaPedido.Rows.Count; i++)
                    {
                        if (ListaPedido.Rows[i][1].ToString().Equals(comboBox2.Text))
                        {
                            String Men = "Producto Ya Existe\n¿Seguro que quiere cambiar la cantidad de este producto?";
                            String Tit = "Producto Existe";
                            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                            DialogResult result = MessageBox.Show(Men, Tit, buttons);
                            if (result == DialogResult.Yes)
                            {
                                
                                ListaPedido.Rows[i][2] = textBoxCantidad.Text;
                                ListaPedido.Rows[i][4] = decimal.Parse(ListaPedido.Rows[i][2].ToString()) * decimal.Parse(ListaPedido.Rows[i][3].ToString());
                                ProductodataGridView.DataSource = ListaPedido;
                                Calculos();
                                btnAgregarProducto.Enabled = false;
                                TipoComboBox.SelectedIndex = 0;
                                comboBox2.SelectedIndex = 0;
                                textBoxCantidad.Clear();
                                btnCerrarPedido.Enabled = true;
                                return;
                            } 
                        }   
                    }
                    
                    DataRow dr;
                    dr = ListaPedido.NewRow();
                    dr["Código Producto"] = producto.Rows[0][0].ToString();
                    dr["Nombre Producto"] = producto.Rows[0][2].ToString();
                    dr["Cantidad"] = textBoxCantidad.Text;
                    dr["Precio Unitario"] = producto.Rows[0][3].ToString();
                    dr["Precio Total"] = decimal.Parse(textBoxCantidad.Text) * decimal.Parse(producto.Rows[0][3].ToString());
                    ListaPedido.Rows.Add(dr);
                    ProductodataGridView.DataSource = ListaPedido;
                    Calculos();
                    btnAgregarProducto.Enabled = false;
                    TipoComboBox.SelectedIndex = 0;
                    comboBox2.SelectedIndex = 0;
                    textBoxCantidad.Clear();
                    btnCerrarPedido.Enabled = true;
                }
            }
            catch
            {
                

            }

        }

        private void DatosSistema()
        {
            CNDatos objDato = new CNDatos();
            DataTable dato = objDato.Servicio();
            Servicio = decimal.Parse(dato.Rows[0][0].ToString());
            dato = objDato.IVA();
            IVA = decimal.Parse(dato.Rows[0][0].ToString());
        }

        private void Calculos()
        {
            decimal subTotal=0;
            for (int i = 0; i < ListaPedido.Rows.Count; i++)
            {
                subTotal += decimal.Parse(ListaPedido.Rows[i][4].ToString());
            }
            decimal ServicioPedido = (subTotal * Servicio);
            Math.Round(ServicioPedido, 2);
            textBoxServicio.Text = ServicioPedido.ToString("0.00");
            decimal IvaPedido = subTotal * IVA;
            Math.Round(IvaPedido, 2);
            textBoxIVA.Text = IvaPedido.ToString("0.00");
            textBoxSubTotal.Text = subTotal.ToString();
            decimal total = subTotal + IvaPedido + ServicioPedido;
            Math.Round(total, 2);
            textBoxTotal.Text = total.ToString("0.00");
            
        }
        private void textBoxCantidad_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCantidad.Text))
            {
                errorCantidad.Visible = false;
            }
            else
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(textBoxCantidad.Text, "[^0-9]"))
                {
                    errorCantidad.Visible = true;
                    btnAgregarProducto.Enabled = false;
                }
                else
                {
                    errorCantidad.Visible = false;
                    btnAgregarProducto.Enabled = true;
                }
            }
        }

        private void btnQuitarProducto_Click(object sender, EventArgs e)
        {
            if (ProductodataGridView.SelectedRows.Count > 0)
            {

                String Men = "¿Seguro que quiere quitar este producto?";
                String Tit = "Quitar Ingrediente";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(Men, Tit, buttons);
                int rowIndex = ProductodataGridView.SelectedRows[0].Index;
                ProductodataGridView.Rows.RemoveAt(rowIndex);
                Calculos();
            }
            else
            {
                MessageBox.Show("Debe Seleccionar Una Fila");
            }
        }

        private void btnCerrarPedido_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxRUC.Text) || string.IsNullOrEmpty(textBoxNombre.Text) || string.IsNullOrEmpty(textBoxApellido.Text)
                || string.IsNullOrEmpty(textBoxCorreo.Text) || string.IsNullOrEmpty(textBoxTelefono.Text) || string.IsNullOrEmpty(textBoxDireccion.Text))
            {
                MessageBox.Show("Por Favor Llenar Todos los Campos");
            }
            else
            {
                CNPedido objDato = new CNPedido();
                objDato.NumPedido = int.Parse(textBoxPedido.Text);
                objDato.IdCliente = textBoxRUC.Text;
                MessageBox.Show(textBoxFecha.Text);
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");
                objDato.Fecha1 = DateTime.Parse(textBoxFecha.Text);
                objDato.Subtotal = decimal.Parse(textBoxSubTotal.Text);
                objDato.Servicio = decimal.Parse(textBoxServicio.Text);
                objDato.Iva1 = decimal.Parse(textBoxIVA.Text);
                objDato.Total = decimal.Parse(textBoxTotal.Text);
                objDato.Mesa = int.Parse(comboBox1.Text);

                try
                {
                    objDato.RegistarPedido();
                    try
                    {
                        foreach (DataRow row in ListaPedido.Rows)
                        {

                            CNDetallePedido objIng = new CNDetallePedido();
                            objIng.NumPedido = int.Parse(textBoxPedido.Text);
                            objIng.IdProducto = row["Código Producto"].ToString();
                            objIng.Cantidad1 = int.Parse(row["Cantidad"].ToString());
                            objIng.Preciototal = decimal.Parse(row["Precio Total"].ToString());
                            objIng.Fecha = DateTime.Parse(textBoxFecha.Text);
                            objIng.RegistarDetallePedido();
                        }
                        MessageBox.Show("Pedido Registrado Exitosamente");
                        CNDatos objdatos = new CNDatos();
                        objdatos.Valor = decimal.Parse(textBoxPedido.Text)+1;
                        objdatos.UpdateNumeroPedido();


                        ((TabControl)((TabPage)this.Parent).Parent).TabPages.Remove((TabPage)this.Parent);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                        objDato.EliminarPedido();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    
                }



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
            e.Graphics.DrawString("PEDIDO\t " + textBoxPedido.Text + "\tMESA\t" + comboBox1.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 260));
            e.Graphics.DrawString("CANT.\tARTICULO\t V.UNT\tV.TOTAL", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 280));
            int n = 300;
            foreach (DataRow row in ListaPedido.Rows)
            {

                e.Graphics.DrawString(row["Cantidad"].ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, n));
                e.Graphics.DrawString("\t" + row["Nombre Producto"].ToString(), new Font("Arial", 8, FontStyle.Regular), Brushes.Black, new Point(25, n));
                e.Graphics.DrawString("\t\t\t " + row["Precio Unitario"].ToString() + "\t" + row["Precio Total"].ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, n));
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
