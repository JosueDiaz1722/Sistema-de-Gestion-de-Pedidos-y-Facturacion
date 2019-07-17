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

namespace CapaPresentacion
{
    public partial class ConsultarProducto : Form
    {
        
        public ConsultarProducto()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Productos_Load(object sender, EventArgs e)
        {
            ListaProducto();
            ListaIndex();
            LoadComboBox();
        }

        private void ListaProducto()
        {
            CNProductos objDato = new CNProductos();
            ProductodataGridView.DataSource = objDato.ListaProd();
        }

        private void LoadComboBox()
        {
            ProductocomboBox.Items.Add("Código Producto");
            ProductocomboBox.Items.Add("Tipo");
            ProductocomboBox.Items.Add("Nombre Producto");
            ProductocomboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            ProductocomboBox.SelectedIndex = 0;
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

        private void ListaIngrediente(string id)
        {
            CNIngredientes objIng = new CNIngredientes();
            objIng.CodigoProducto = id;
            IngredientedataGridView.DataSource = objIng.ListaIngredientes();
            ListaIndex2();

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

        private void button1_Click(object sender, EventArgs e)
        {
            if (ProductodataGridView.SelectedRows.Count > 0)
            {
                     ListaIngrediente(ProductodataGridView.CurrentRow.Cells[0].Value.ToString());
            }
            else
            {
                MessageBox.Show("Debe Seleccionar Una Fila");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textBox1.Text))
            {
                ListaProducto();
                CNIngredientes objIng = new CNIngredientes();
                objIng.CodigoProducto = "null";
                IngredientedataGridView.DataSource = objIng.ListaIngredientes();
                ListaIndex2();
            }
            else
            {
                string criterio = ProductocomboBox.Text;
                switch (criterio)
                {
                    case "Código Producto":
                        BuscarID(textBox1.Text);
                        break;
                    case "Tipo":
                        BuscarTipo(textBox1.Text);
                        break;
                    case "Nombre Producto":
                        BuscarNom(textBox1.Text);
                        break;
                }
                CNIngredientes objIng = new CNIngredientes();
                objIng.CodigoProducto = "null";
                IngredientedataGridView.DataSource = objIng.ListaIngredientes();
                ListaIndex2();
            }
        }

        private void BuscarID(string id)
        {

            CNProductos objDato = new CNProductos();
            objDato.codigoProd = id;
            ProductodataGridView.DataSource = objDato.BuscarIDProd();
            ListaIndex();
            
        }
        private void BuscarTipo(string id)
        {

            CNProductos objDato = new CNProductos();
            objDato.nomTipo = id;
            ProductodataGridView.DataSource = objDato.BuscarTipoProd();
            ListaIndex();
        }
        private void BuscarNom(string id)
        {

            CNProductos objDato = new CNProductos();
            objDato.nombreProd = id;
            ProductodataGridView.DataSource = objDato.BuscarNomProd();
            ListaIndex();
        }
    }
}
