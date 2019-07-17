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
    public partial class EliminarProducto : Form
    {
        public EliminarProducto()
        {
            InitializeComponent();
        }

        private void EliminarProducto_Load(object sender, EventArgs e)
        {
            ListaProducto();
            LoadComboBox();
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textBox1.Text))
            {
                ListaProducto();
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (ProductodataGridView.SelectedRows.Count > 0)
            {

                String Men = "¿Seguro que quiere eliminar a este producto?";
                String Tit = "Eliminar";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(Men, Tit, buttons);
                if (result == DialogResult.Yes)
                {
                    CNProductos objDato = new CNProductos();
                    objDato.codigoProd = ProductodataGridView.CurrentRow.Cells[0].Value.ToString();
                    objDato.EliminarProd();
                    ListaProducto();
                    MessageBox.Show("Producto Eliminado Exitosamente");
                }

            }
            else
            {
                MessageBox.Show("Debe Seleccionar Una Fila");
            }
        }
    }
}
