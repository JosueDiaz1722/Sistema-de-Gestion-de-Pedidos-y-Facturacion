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

namespace CapaPresentacion.Producto
{
    public partial class ModificarProducto : Form
    {
        DataTable Listaingredientes = new DataTable();
        public ModificarProducto()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click_1(object sender, EventArgs e)
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

        private void btnLimpiar_Click_1(object sender, EventArgs e)
        {
            textBoxArticuloProducto.Clear();
            textBoxCodigoProducto.Clear();
            textBoxPBrutoProducto.Clear();
            textBoxPVPProducto.Clear();
            textBoxDescripcion.Clear();
            Listaingredientes.Rows.Clear();
            textBoxCantidad.Clear();
            textBoxCodigoIngrediente.Clear();
            btnAgregar.Enabled = false;
            btnRegistrar.Enabled = false;
            errorPUni.Visible = false;
            errorPBruto.Visible = false;
            errorCantidad.Visible = false;
            btnBuscarProducto.Enabled = false;
            IngredientedataGridView.DataSource = Listaingredientes;
        }

        private void ModificarProducto_Load(object sender, EventArgs e)
        {
            listaTipo();
            ListaProducto();
            listaUnidad();
            dataTableIndex();
            btnRegistrar.Enabled = false;
            btnAgregar.Enabled = false;
            btnBuscarProducto.Enabled = false;
            textBoxArticuloProducto.Enabled = false;
            textBoxCodigoProducto.Enabled = false;
            textBoxPBrutoProducto.Enabled = false;
            textBoxPVPProducto.Enabled = false;
            textBoxDescripcion.Enabled = false;
            Listaingredientes.Rows.Clear();
            textBoxCantidad.Enabled = false;
            textBoxCodigoIngrediente.Enabled = false;
            errorPUni.Visible = false;
            errorPBruto.Visible = false;
            errorCantidad.Visible = false;
            btnBuscarProducto.Enabled = false;
        }

        private void listaTipo()
        {

            CNProductos objProd = new CNProductos();
            TipoComboBox.DataSource = objProd.ListaTipo();
            TipoComboBox.DisplayMember = "nombreTipo";
            TipoComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            TipoComboBox.SelectedIndex = 0;

        }

        private void ListaProducto()
        {
            CNProductos objDato = new CNProductos();
            ProductodataGridView.DataSource = objDato.ListaProd();
        }

        private void ListaIndex()
        {

            ProductodataGridView.Columns[0].HeaderText = "Código Producto";
            ProductodataGridView.Columns[1].HeaderText = "Tipo";
            ProductodataGridView.Columns[2].HeaderText = "Nombre Producto";
            ProductodataGridView.Columns[3].HeaderText = "PVP";
            ProductodataGridView.Columns[4].HeaderText = "Precio Bruto";
        }

        private void ListaIndex2()
        {

            IngredientedataGridView.Columns[0].HeaderText = "Código Ingrediente";
            IngredientedataGridView.Columns[1].HeaderText = "Descripción";
            IngredientedataGridView.Columns[2].HeaderText = "Unidad de Medida";
            IngredientedataGridView.Columns[3].HeaderText = "Cantidad";
        }

        private void dataTableIndex()
        {
            Listaingredientes.Columns.Add("Código Ingrediente");
            Listaingredientes.Columns.Add("Descripción");
            Listaingredientes.Columns.Add("Unidad de Medida");
            Listaingredientes.Columns.Add("Cantidad");
        }

        private void textBoxCantidad_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBoxCantidad.Text, "^([1-9]{1}[\\d]{0,2}(\\,[\\d]{3})*(\\.[\\d]{0,2})?|[1-9]{1}[\\d]{0,}(\\.[\\d]{0,2})?|0(\\.[\\d]{0,2})?|(\\.[\\d]{1,2})?)$"))
            {
                errorCantidad.Visible = false;

            }
            else
            {
                errorCantidad.Visible = true;

            }
        }

        private void textBoxPUnitario_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBoxPVPProducto.Text, "^([1-9]{1}[\\d]{0,2}(\\,[\\d]{3})*(\\.[\\d]{0,2})?|[1-9]{1}[\\d]{0,}(\\.[\\d]{0,2})?|0(\\.[\\d]{0,2})?|(\\.[\\d]{1,2})?)$"))
            {
                errorPUni.Visible = false;
            }
            else
            {
                errorPUni.Visible = true;
                btnAgregar.Enabled = false;
            }
        }

        private void textBoxPBruto_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBoxPBrutoProducto.Text, "^([1-9]{1}[\\d]{0,2}(\\,[\\d]{3})*(\\.[\\d]{0,2})?|[1-9]{1}[\\d]{0,}(\\.[\\d]{0,2})?|0(\\.[\\d]{0,2})?|(\\.[\\d]{1,2})?)$"))
            {
                errorPBruto.Visible = false;
            }
            else
            {
                errorPBruto.Visible = true;
            }
        }

        private void textBoxPBrutoProducto_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCodigoProducto.Text) || string.IsNullOrEmpty(textBoxArticuloProducto.Text) || string.IsNullOrEmpty(textBoxPVPProducto.Text) || string.IsNullOrEmpty(textBoxPBrutoProducto.Text))
            {
                MessageBox.Show("Por Favor Llenar Todos los Campos de Producto\nPara Agregar Ingredientes");
                btnBuscarProducto.Enabled = false;
            }
            else
            {
                btnBuscarProducto.Enabled = true;
            }
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textBoxCodigoIngrediente.Text))
            {
                MessageBox.Show("Por Favor Ingrese el Código del Ingrediente");
            }
            else
            {
                BuscarCod(textBoxCodigoIngrediente.Text);

            }
        }

        private void BuscarCod(string cod)
        {
            CNInventarios objDato = new CNInventarios();
            objDato.CodigioInventario = cod;
            try
            {
                DataTable ingrediente = objDato.BuscarIDInv();
                textBoxDescripcion.Text = ingrediente.Rows[0][1].ToString();
            }
            catch
            {
                MessageBox.Show("No Existe el Ingrediente Ingresado");
                btnAgregar.Enabled = false;
                MedidacomboBox.SelectedIndex = 0;
                textBoxCodigoIngrediente.Clear();
                textBoxDescripcion.Clear();
                textBoxCantidad.Clear();
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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCantidad.Text))
            {
                MessageBox.Show("Por Favor Llenar Todos los Campos de Ingrediente");
            }
            else
            {
                /*CNIngredientes objDato = new CNIngredientes();
                objDato.CodigoProducto = textBoxCodigoProducto.Text;
                Listaingredientes = objDato.ListaIngredientes();*/

                Listaingredientes.Columns[0].ColumnName = "Código Ingrediente";
                Listaingredientes.Columns[1].ColumnName = "Descripción";
                Listaingredientes.Columns[2].ColumnName = "Unidad de Medida";
                Listaingredientes.Columns[3].ColumnName = "Cantidad";

                DataRow dr;
                dr = Listaingredientes.NewRow();
                dr["Código Ingrediente"] = textBoxCodigoIngrediente.Text;
                dr["Descripción"] = textBoxDescripcion.Text;
                dr["Unidad de Medida"] = MedidacomboBox.Text;
                dr["Cantidad"] = decimal.Parse(textBoxCantidad.Text);
                Listaingredientes.Rows.Add(dr);
                IngredientedataGridView.DataSource = Listaingredientes;
                btnAgregar.Enabled = false;
                MedidacomboBox.SelectedIndex = 0;
                textBoxCodigoIngrediente.Clear();
                textBoxDescripcion.Clear();
                textBoxCantidad.Clear();
                btnRegistrar.Enabled = true;
            }

        }

        private void textBoxCantidad_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCantidad.Text) || string.IsNullOrEmpty(textBoxCodigoIngrediente.Text) || string.IsNullOrEmpty(textBoxDescripcion.Text)
                || string.IsNullOrEmpty(textBoxPBrutoProducto.Text) || string.IsNullOrEmpty(textBoxPVPProducto.Text) || string.IsNullOrEmpty(textBoxArticuloProducto.Text)
                || string.IsNullOrEmpty(textBoxCodigoProducto.Text))
            {
                MessageBox.Show("Por Favor Llenar Todos los Campos");
            }
            else
            {
                btnAgregar.Enabled = true;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            ListaProducto();
        }


        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxPBrutoProducto.Text) || string.IsNullOrEmpty(textBoxPVPProducto.Text) || string.IsNullOrEmpty(textBoxArticuloProducto.Text)
                || string.IsNullOrEmpty(textBoxCodigoProducto.Text))
            {
                MessageBox.Show("Por Favor Llenar Todos los Campos");
            }
            else
            {
                CNProductos objDato = new CNProductos();
                objDato.codigoProd = textBoxCodigoProducto.Text;
                objDato.nombreProd = textBoxArticuloProducto.Text;
                int n = TipoComboBox.SelectedIndex + 1;
                objDato.Tipo = n;
                decimal pvp = decimal.Parse(textBoxPVPProducto.Text);
                decimal.Round(pvp, 2);
                objDato.PrecioUni = pvp;
                decimal precioB = decimal.Parse(textBoxPBrutoProducto.Text);
                decimal.Round(precioB, 2);
                objDato.PrecioB = precioB;

                try
                {
                    objDato.modificarProducto();
                    try
                    {
                        foreach (DataRow row in Listaingredientes.Rows)
                        {

                            CNIngredientes objIng = new CNIngredientes();
                            objIng.CodigoProducto = textBoxCodigoProducto.Text;
                            objIng.CodigoIngrediente = row["Código Ingrediente"].ToString();
                            objIng.Descripcion = row["Descripción"].ToString();
                            CNMedida objMedida = new CNMedida();
                            objMedida.Unidad = row["Unidad de Medida"].ToString();
                            DataTable dato = objMedida.BuscarIndex();
                            objIng.Medida = int.Parse(dato.Rows[0][0].ToString());
                            objIng.Cantidad = decimal.Parse(row["Cantidad"].ToString());
                            objIng.modificarIngrediente();
                        }
                        ListaProducto();
                        MessageBox.Show("Producto Modificado Exitosamente");
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                        objDato.EliminarProd();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }



            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (IngredientedataGridView.SelectedRows.Count > 0)
            {

                String Men = "¿Seguro que quiere quitar este ingrediente?";
                String Tit = "Quitar Ingrediente";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(Men, Tit, buttons);
                CNIngredientes objDato = new CNIngredientes();
                objDato.CodigoProducto = textBoxCodigoProducto.Text;
                objDato.CodigoIngrediente = IngredientedataGridView.CurrentRow.Cells[0].Value.ToString();
                objDato.eliminarIngrediente();
                int rowIndex = IngredientedataGridView.SelectedRows[0].Index;
                IngredientedataGridView.Rows.RemoveAt(rowIndex);
                
            }
            else
            {
                MessageBox.Show("Debe Seleccionar Una Fila");
            }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (ProductodataGridView.SelectedRows.Count > 0)
            {
                btnRegistrar.Enabled = true;
                btnAgregar.Enabled = true;
                btnBuscarProducto.Enabled = true;
                textBoxArticuloProducto.Enabled = true;
                textBoxCodigoProducto.Enabled = true;
                textBoxPBrutoProducto.Enabled = true;
                textBoxPVPProducto.Enabled = true;
                textBoxDescripcion.Enabled = true;
                textBoxCantidad.Enabled = true;
                textBoxCodigoIngrediente.Enabled = true;
                btnBuscarProducto.Enabled = true;

                textBoxCodigoProducto.Text = ProductodataGridView.CurrentRow.Cells[0].Value.ToString();

                CNProductos objDato = new CNProductos();
                objDato.nomTipo = ProductodataGridView.CurrentRow.Cells[1].Value.ToString();
                DataTable dato = objDato.buscarTipo();
                TipoComboBox.SelectedIndex = int.Parse(dato.Rows[0][0].ToString()) - 1;
                
                textBoxArticuloProducto.Text = ProductodataGridView.CurrentRow.Cells[2].Value.ToString();
                textBoxPVPProducto.Text = ProductodataGridView.CurrentRow.Cells[3].Value.ToString();
                textBoxPBrutoProducto.Text = ProductodataGridView.CurrentRow.Cells[4].Value.ToString();

                CNIngredientes objIng = new CNIngredientes();
                objIng.CodigoProducto = ProductodataGridView.CurrentRow.Cells[0].Value.ToString();
                IngredientedataGridView.DataSource = objIng.ListaIngredientes();
            }
            else
            {
                MessageBox.Show("Debe Seleccionar Una Fila");
            }
        }
    }
}
