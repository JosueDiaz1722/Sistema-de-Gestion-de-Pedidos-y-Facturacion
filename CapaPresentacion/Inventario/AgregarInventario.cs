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
    public partial class AgregarInventario : Form
    {
        CNInventarios objDato = new CNInventarios();
        public AgregarInventario()
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

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            textBoxCodigo.Clear();
            textBoxDescripcion.Clear();
            MedidacomboBox.SelectedIndex = 0;
            textBoxCantidad.Clear();
            textBoxPUnitario.Clear();
            textBoxTotal.Clear();
            errorCantidad.Visible = false;
            errorPUni.Visible = false;
            btnRegistrar.Enabled = false;
        }

        private void ListaInventario()
        {
            
            InventariodataGridView.DataSource = objDato.ListaInventario();
            IndexTable();
            btnRegistrar.Enabled = false;
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

        private void AgregarInventario_Load(object sender, EventArgs e)
        {
            ListaInventario();
            listaUnidad();
        }

        private void textBoxCantidad_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBoxCantidad.Text, "^([1-9]{1}[\\d]{0,2}(\\,[\\d]{3})*(\\.[\\d]{0,2})?|[1-9]{1}[\\d]{0,}(\\.[\\d]{0,2})?|0(\\.[\\d]{0,2})?|(\\.[\\d]{1,2})?)$") || string.IsNullOrEmpty(textBoxCantidad.Text))
            {
                errorCantidad.Visible = false;
                btnRegistrar.Enabled = true;
            }
            else
            {
                errorCantidad.Visible = true;
                btnRegistrar.Enabled = false;

            }
        }

        private void textBoxPUnitario_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBoxPUnitario.Text, "^([1-9]{1}[\\d]{0,2}(\\,[\\d]{3})*(\\.[\\d]{0,2})?|[1-9]{1}[\\d]{0,}(\\.[\\d]{0,2})?|0(\\.[\\d]{0,2})?|(\\.[\\d]{1,2})?)$") || string.IsNullOrEmpty(textBoxPUnitario.Text))
            {
                errorPUni.Visible = false;
                btnRegistrar.Enabled = true;


            }
            else
            {
                errorPUni.Visible = true;
                btnRegistrar.Enabled = false;
            }
        }

        private void listaUnidad()
        {

            CNMedida objMedida = new CNMedida();
            MedidacomboBox.DataSource = objMedida.ListaMedida();
            MedidacomboBox.DisplayMember = "unidadMedida";
            MedidacomboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            MedidacomboBox.SelectedIndex = 0;

        }

        private void textBoxPUnitario_Leave(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textBoxCantidad.Text)|| string.IsNullOrEmpty(textBoxPUnitario.Text))
            {
                btnRegistrar.Enabled = false;
            }
            else
            {
                decimal total = decimal.Parse(textBoxCantidad.Text) * decimal.Parse(textBoxPUnitario.Text);
                decimal.Round(total, 2);
                textBoxTotal.Text = total.ToString("N2");
                btnRegistrar.Enabled = true;
            }
        }

        private void textBoxCantidad_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCantidad.Text) || string.IsNullOrEmpty(textBoxPUnitario.Text))
            {
                btnRegistrar.Enabled = false;
            }
            else
            {

                decimal total = decimal.Parse(textBoxCantidad.Text) * decimal.Parse(textBoxPUnitario.Text);
                decimal.Round(total, 2);
                textBoxTotal.Text = total.ToString("N2");
                btnRegistrar.Enabled = true;
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCodigo.Text)|| string.IsNullOrEmpty(textBoxDescripcion.Text)||string.IsNullOrEmpty(textBoxCantidad.Text)|| string.IsNullOrEmpty(textBoxPUnitario.Text))
            {
                MessageBox.Show("Por Favor Llenar Todos Los Campos");
            }
            else
            {
                objDato.CodigioInventario = textBoxCodigo.Text;
                objDato.Descripcion = textBoxDescripcion.Text;
                int n = MedidacomboBox.SelectedIndex+1;
                objDato.UnidadMedida = n;
                decimal cantidad = decimal.Parse(textBoxCantidad.Text);
                decimal.Round(cantidad, 2);
                objDato.Cantidad = cantidad;
                decimal precioU = decimal.Parse(textBoxPUnitario.Text);
                decimal.Round(precioU, 2);
                objDato.PrecioUni = precioU;
                decimal precioTo = decimal.Parse(textBoxTotal.Text);
                decimal.Round(precioTo, 2);
                objDato.PrecioTotal = precioTo;
                try
                {
                    objDato.insertarInventario();
                    ListaInventario();
                    MessageBox.Show("Producto Insertado Exitosamente");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Producto Ya Existe");
                    textBoxCodigo.Clear();
                    textBoxDescripcion.Clear();
                    MedidacomboBox.SelectedIndex = 0;
                    textBoxCantidad.Clear();
                    textBoxPUnitario.Clear();
                    textBoxTotal.Clear();
                    errorCantidad.Visible = false;
                    errorPUni.Visible = false;
                    btnRegistrar.Enabled = false;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListaInventario();
        }
    }
}
