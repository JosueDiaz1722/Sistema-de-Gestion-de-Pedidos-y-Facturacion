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

namespace CapaPresentacion.Inventario
{
    public partial class ModificarInventario : Form
    {
        CNInventarios objDato = new CNInventarios();
        public ModificarInventario()
        {
            InitializeComponent();
            
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
            btnModificar.Enabled = false;
            MedidacomboBox.Enabled = false;
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

        private void ListaInventario()
        {

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

        private void listaUnidad()
        {

            CNMedida objMedida = new CNMedida();
            MedidacomboBox.DataSource = objMedida.ListaMedida();
            MedidacomboBox.DisplayMember = "unidadMedida";
            MedidacomboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            MedidacomboBox.SelectedIndex = 0;

        }

        private void ModificarInventario_Load(object sender, EventArgs e)
        {
            ListaInventario();
            listaUnidad();
            btnModificar.Enabled = false;
            btnModificar.Enabled = false;
            textBoxCodigo.Enabled = false;
            textBoxDescripcion.Enabled = false;
            MedidacomboBox.Enabled = false;
            textBoxCantidad.Enabled = false;
            textBoxPUnitario.Enabled = false;
            btnLimpiar.Enabled = false;
        }

        private void textBoxCantidad_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBoxCantidad.Text, "^([1-9]{1}[\\d]{0,2}(\\,[\\d]{3})*(\\.[\\d]{0,2})?|[1-9]{1}[\\d]{0,}(\\.[\\d]{0,2})?|0(\\.[\\d]{0,2})?|(\\.[\\d]{1,2})?)$") || string.IsNullOrEmpty(textBoxCantidad.Text))
            {
                errorCantidad.Visible = false;
                btnModificar.Enabled = true;
            }
            else
            {
                errorCantidad.Visible = true;
                btnModificar.Enabled = false;

            }
        }

        private void textBoxPUnitario_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBoxPUnitario.Text, "^([1-9]{1}[\\d]{0,2}(\\,[\\d]{3})*(\\.[\\d]{0,2})?|[1-9]{1}[\\d]{0,}(\\.[\\d]{0,2})?|0(\\.[\\d]{0,2})?|(\\.[\\d]{1,2})?)$") || string.IsNullOrEmpty(textBoxPUnitario.Text))
            {
                errorPUni.Visible = false;
                btnModificar.Enabled = true;


            }
            else
            {
                errorPUni.Visible = true;
                btnModificar.Enabled = false;
            }
        }

        private void textBoxPUnitario_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCantidad.Text) || string.IsNullOrEmpty(textBoxPUnitario.Text))
            {
                btnModificar.Enabled = false;
            }
            else
            {
                decimal total = decimal.Parse(textBoxCantidad.Text) * decimal.Parse(textBoxPUnitario.Text);
                decimal.Round(total, 2);
                textBoxTotal.Text = total.ToString("N2");
                btnModificar.Enabled = true;
            }
        }

        private void textBoxCantidad_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCantidad.Text) || string.IsNullOrEmpty(textBoxPUnitario.Text))
            {
                btnModificar.Enabled = false;
            }
            else
            {

                decimal total = decimal.Parse(textBoxCantidad.Text) * decimal.Parse(textBoxPUnitario.Text);
                decimal.Round(total, 2);
                textBoxTotal.Text = total.ToString("N2");
                btnModificar.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListaInventario();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (InventariodataGridView.SelectedRows.Count > 0)
            {
                btnModificar.Enabled = true;
                textBoxCodigo.Enabled = true;
                textBoxDescripcion.Enabled = true;
                MedidacomboBox.Enabled = true;
                textBoxCantidad.Enabled = true;
                textBoxPUnitario.Enabled = true;
                btnLimpiar.Enabled = true;

                textBoxCodigo.Text = InventariodataGridView.CurrentRow.Cells[0].Value.ToString();
                textBoxDescripcion.Text = InventariodataGridView.CurrentRow.Cells[1].Value.ToString();

                CNMedida objMedida = new CNMedida();
                objMedida.Unidad = InventariodataGridView.CurrentRow.Cells[2].Value.ToString();
                DataTable dato = objMedida.BuscarIndex();
                MedidacomboBox.SelectedIndex = int.Parse(dato.Rows[0][0].ToString())-1;


                textBoxCantidad.Text = InventariodataGridView.CurrentRow.Cells[3].Value.ToString();
                textBoxPUnitario.Text = InventariodataGridView.CurrentRow.Cells[4].Value.ToString();
                textBoxTotal.Text = InventariodataGridView.CurrentRow.Cells[5].Value.ToString();
            }
            else
            {
                MessageBox.Show("Debe Seleccionar Una Fila");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCodigo.Text) || string.IsNullOrEmpty(textBoxDescripcion.Text) || string.IsNullOrEmpty(textBoxCantidad.Text) || string.IsNullOrEmpty(textBoxPUnitario.Text))
            {
                MessageBox.Show("Por Favor Llenar Todos Los Campos");
            }
            else
            {
                objDato.CodigioInventario = textBoxCodigo.Text;
                objDato.Descripcion = textBoxDescripcion.Text;
                int n = MedidacomboBox.SelectedIndex + 1;
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
                    objDato.modificarInventario();
                    ListaInventario();
                    MessageBox.Show("Producto Modificado Exitosamente");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: No Se Modifico El Producto");
                    textBoxCodigo.Clear();
                    textBoxDescripcion.Clear();
                    MedidacomboBox.SelectedIndex = 0;
                    textBoxCantidad.Clear();
                    textBoxPUnitario.Clear();
                    textBoxTotal.Clear();
                    errorCantidad.Visible = false;
                    errorPUni.Visible = false;
                    btnModificar.Enabled = false;
                }
            }
        }
    }
}
