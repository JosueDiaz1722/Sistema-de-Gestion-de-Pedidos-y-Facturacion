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

namespace CapaPresentacion.Cliente
{
    public partial class DarBajaCliente : Form
    {
        public DarBajaCliente()
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

        private void DarBajaCliente_Load(object sender, EventArgs e)
        {
            ListaCliente();
            LoadComboBox();
        }

        private void LoadComboBox()
        {
            ClientecomboBox.Items.Add("RUC/Cédula");
            ClientecomboBox.Items.Add("Nombres");
            ClientecomboBox.Items.Add("Apellidos");
            ClientecomboBox.Items.Add("Dirección");
            ClientecomboBox.Items.Add("Correo Electronico");
            ClientecomboBox.Items.Add("Teléfono");
            ClientecomboBox.Items.Add("Estado");
            ClientecomboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            ClientecomboBox.SelectedIndex = 0;
        }

        private void ListaCliente()
        {
            CNCliente objDato = new CNCliente();
            ClientedataGridView.DataSource = objDato.ListaClientesCompleta();
            ClientedataGridView.Columns[0].HeaderText = "Tipo ID";
            ClientedataGridView.Columns[1].HeaderText = "RUC/Cédula";
            ClientedataGridView.Columns[2].HeaderText = "Nombres";
            ClientedataGridView.Columns[3].HeaderText = "Apellidos";
            ClientedataGridView.Columns[4].HeaderText = "Dirección";
            ClientedataGridView.Columns[5].HeaderText = "Correo Electronico";
            ClientedataGridView.Columns[6].HeaderText = "Teléfono";
            ClientedataGridView.Columns[7].HeaderText = "Estado";
        }

        private void BuscarId(string id)
        {
            CNCliente objDato = new CNCliente();
            objDato.Id = id;
            ClientedataGridView.DataSource = objDato.BuscarID();
            ClientedataGridView.Columns[0].HeaderText = "Tipo ID";
            ClientedataGridView.Columns[1].HeaderText = "RUC/Cédula";
            ClientedataGridView.Columns[2].HeaderText = "Nombres";
            ClientedataGridView.Columns[3].HeaderText = "Apellidos";
            ClientedataGridView.Columns[4].HeaderText = "Dirección";
            ClientedataGridView.Columns[5].HeaderText = "Correo Electronico";
            ClientedataGridView.Columns[6].HeaderText = "Teléfono";
            ClientedataGridView.Columns[7].HeaderText = "Estado";
        }

        private void BuscarNom(string busca)
        {
            CNCliente objDato = new CNCliente();
            objDato.Nombre = busca;
            ClientedataGridView.DataSource = objDato.BuscarNombre();
            ClientedataGridView.Columns[0].HeaderText = "Tipo ID";
            ClientedataGridView.Columns[1].HeaderText = "RUC/Cédula";
            ClientedataGridView.Columns[2].HeaderText = "Nombres";
            ClientedataGridView.Columns[3].HeaderText = "Apellidos";
            ClientedataGridView.Columns[4].HeaderText = "Dirección";
            ClientedataGridView.Columns[5].HeaderText = "Correo Electronico";
            ClientedataGridView.Columns[6].HeaderText = "Teléfono";
            ClientedataGridView.Columns[7].HeaderText = "Estado";
        }

        private void BuscarApl(string busca)
        {
            CNCliente objDato = new CNCliente();
            objDato.Apellido = busca;
            ClientedataGridView.DataSource = objDato.BuscarApellido();
            ClientedataGridView.Columns[0].HeaderText = "Tipo ID";
            ClientedataGridView.Columns[1].HeaderText = "RUC/Cédula";
            ClientedataGridView.Columns[2].HeaderText = "Nombres";
            ClientedataGridView.Columns[3].HeaderText = "Apellidos";
            ClientedataGridView.Columns[4].HeaderText = "Dirección";
            ClientedataGridView.Columns[5].HeaderText = "Correo Electronico";
            ClientedataGridView.Columns[6].HeaderText = "Teléfono";
            ClientedataGridView.Columns[7].HeaderText = "Estado";
        }

        private void BuscarDir(string busca)
        {
            CNCliente objDato = new CNCliente();
            objDato.Direccion = busca;
            ClientedataGridView.DataSource = objDato.BuscarDir();
            ClientedataGridView.Columns[0].HeaderText = "Tipo ID";
            ClientedataGridView.Columns[1].HeaderText = "RUC/Cédula";
            ClientedataGridView.Columns[2].HeaderText = "Nombres";
            ClientedataGridView.Columns[3].HeaderText = "Apellidos";
            ClientedataGridView.Columns[4].HeaderText = "Dirección";
            ClientedataGridView.Columns[5].HeaderText = "Correo Electronico";
            ClientedataGridView.Columns[6].HeaderText = "Teléfono";
            ClientedataGridView.Columns[7].HeaderText = "Estado";
        }

        private void BuscarCor(string busca)
        {
            CNCliente objDato = new CNCliente();
            objDato.Correo = busca;
            ClientedataGridView.DataSource = objDato.BuscarCor();
            ClientedataGridView.Columns[0].HeaderText = "Tipo ID";
            ClientedataGridView.Columns[1].HeaderText = "RUC/Cédula";
            ClientedataGridView.Columns[2].HeaderText = "Nombres";
            ClientedataGridView.Columns[3].HeaderText = "Apellidos";
            ClientedataGridView.Columns[4].HeaderText = "Dirección";
            ClientedataGridView.Columns[5].HeaderText = "Correo Electronico";
            ClientedataGridView.Columns[6].HeaderText = "Teléfono";
            ClientedataGridView.Columns[7].HeaderText = "Estado";
        }

        private void BuscarTel(string busca)
        {
            CNCliente objDato = new CNCliente();
            objDato.Telefono = busca;
            ClientedataGridView.DataSource = objDato.BuscarTel();
            ClientedataGridView.Columns[0].HeaderText = "Tipo ID";
            ClientedataGridView.Columns[1].HeaderText = "RUC/Cédula";
            ClientedataGridView.Columns[2].HeaderText = "Nombres";
            ClientedataGridView.Columns[3].HeaderText = "Apellidos";
            ClientedataGridView.Columns[4].HeaderText = "Dirección";
            ClientedataGridView.Columns[5].HeaderText = "Correo Electronico";
            ClientedataGridView.Columns[6].HeaderText = "Teléfono";
            ClientedataGridView.Columns[7].HeaderText = "Estado";
        }

        private void BuscarEst(string busca)
        {
            CNCliente objDato = new CNCliente();
            objDato.Estado = busca;
            ClientedataGridView.DataSource = objDato.BuscarEst();
            ClientedataGridView.Columns[0].HeaderText = "Tipo ID";
            ClientedataGridView.Columns[1].HeaderText = "RUC/Cédula";
            ClientedataGridView.Columns[2].HeaderText = "Nombres";
            ClientedataGridView.Columns[3].HeaderText = "Apellidos";
            ClientedataGridView.Columns[4].HeaderText = "Dirección";
            ClientedataGridView.Columns[5].HeaderText = "Correo Electronico";
            ClientedataGridView.Columns[6].HeaderText = "Teléfono";
            ClientedataGridView.Columns[7].HeaderText = "Estado";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textBox1.Text))
            {
                ListaCliente();
            }
            else
            {
                string criterio = ClientecomboBox.Text;
                switch (criterio)
                {
                    case "RUC/Cédula":
                        BuscarId(textBox1.Text);
                        break;
                    case "Nombres":
                        BuscarNom(textBox1.Text);
                        break;
                    case "Apellidos":
                        BuscarApl(textBox1.Text);
                        break;
                    case "Dirección":
                        BuscarDir(textBox1.Text);
                        break;
                    case "Correo Electronico":
                        BuscarCor(textBox1.Text);
                        break;
                    case "Teléfono":
                        BuscarTel(textBox1.Text);
                        break;
                    case "Estado":
                        BuscarEst(textBox1.Text);
                        break;
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(ClientedataGridView.SelectedRows.Count > 0)
            {
                if (ClientedataGridView.CurrentRow.Cells[7].Value.ToString().Equals("INACTIVO"))
                {
                    MessageBox.Show("El Cliente Ya Esta Inactivo");
                }
                else
                {
                    String Men = "¿Seguro que quiere de dar de baja a este cliente?";
                    String Tit = "Dar De Baja";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result = MessageBox.Show(Men, Tit, buttons);
                    if (result == DialogResult.Yes)
                    {
                        CNCliente objDato = new CNCliente();
                        objDato.Id = ClientedataGridView.CurrentRow.Cells[1].Value.ToString();
                        objDato.DarBaja();
                        ListaCliente();
                        MessageBox.Show("Cliente Dado De Baja Exitosamente");
                    }
                    
                }
               
            }
            else
            {
                MessageBox.Show("Debe Seleccionar Una Fila");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ClientedataGridView.SelectedRows.Count > 0)
            {
               
                    String Men = "¿Seguro que quiere eliminar a este cliente?";
                    String Tit = "Eliminar";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result = MessageBox.Show(Men, Tit, buttons);
                    if (result == DialogResult.Yes)
                    {
                        CNCliente objDato = new CNCliente();
                        objDato.Id = ClientedataGridView.CurrentRow.Cells[1].Value.ToString();
                        objDato.Eliminar();
                        ListaCliente();
                        MessageBox.Show("Cliente Eliminado Exitosamente");
                    }

            }
            else
            {
                MessageBox.Show("Debe Seleccionar Una Fila");
            }
        }
    }
}
