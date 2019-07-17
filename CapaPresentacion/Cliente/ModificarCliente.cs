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
    public partial class ModificarCliente : Form
    {
        public ModificarCliente()
        {
            InitializeComponent();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            textBoxID.Clear();
            textBoxNombre.Clear();
            textBoxApellido.Clear();
            textBoxArticuloDireccion.Clear();
            textBoxCorreo.Clear();
            textBoxTelefono.Clear();
            btnModificar.Enabled = false;
            TipoIdcomboBox.Enabled = false;
            textBoxID.Enabled = false;
            textBoxNombre.Enabled = false;
            textBoxApellido.Enabled = false;
            textBoxArticuloDireccion.Enabled = false;
            textBoxCorreo.Enabled = false;
            textBoxTelefono.Enabled = false;
            errorCorreo.Visible = false;
            errorTelefono.Visible = false;
            btnModificar.Enabled = false;

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

        private void ModificarCliente_Load(object sender, EventArgs e)
        {
            ListaCliente();
            LoadCombobox();
            btnModificar.Enabled = false;
            TipoIdcomboBox.Enabled = false;
            textBoxID.Enabled = false;
            textBoxNombre.Enabled = false;
            textBoxApellido.Enabled = false;
            textBoxArticuloDireccion.Enabled = false;
            textBoxCorreo.Enabled = false;
            textBoxTelefono.Enabled = false;
        }

        private void LoadCombobox()
        {
            TipoIdcomboBox.Items.Add("Cédula");
            TipoIdcomboBox.Items.Add("RUC");
            TipoIdcomboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            TipoIdcomboBox.SelectedIndex = 0;
          
        }

        private void ListaCliente()
        {
            CNCliente objDato = new CNCliente();
            ClientedataGridView.DataSource = objDato.ListaClientes();
            ClientedataGridView.Columns[0].HeaderText = "Tipo ID";
            ClientedataGridView.Columns[1].HeaderText = "RUC/Cédula";
            ClientedataGridView.Columns[2].HeaderText = "Nombres";
            ClientedataGridView.Columns[3].HeaderText = "Apellidos";
            ClientedataGridView.Columns[4].HeaderText = "Dirección";
            ClientedataGridView.Columns[5].HeaderText = "Correo Electronico";
            ClientedataGridView.Columns[6].HeaderText = "Teléfono";
            ClientedataGridView.Columns[7].HeaderText = "Estado";
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (ClientedataGridView.SelectedRows.Count > 0)
            {
                btnModificar.Enabled = true;
                textBoxID.Enabled = true;
                textBoxNombre.Enabled = true;
                textBoxApellido.Enabled = true;
                textBoxArticuloDireccion.Enabled = true;
                textBoxCorreo.Enabled = true;
                textBoxTelefono.Enabled = true;
                if (ClientedataGridView.CurrentRow.Cells[0].Value.ToString().Equals("Cédula"))
                {
                    TipoIdcomboBox.SelectedIndex = 0;
                }
                else
                {
                    TipoIdcomboBox.SelectedIndex = 1;
                }
                textBoxID.Text = ClientedataGridView.CurrentRow.Cells[1].Value.ToString();
                textBoxNombre.Text = ClientedataGridView.CurrentRow.Cells[2].Value.ToString();
                textBoxApellido.Text = ClientedataGridView.CurrentRow.Cells[3].Value.ToString();
                textBoxArticuloDireccion.Text = ClientedataGridView.CurrentRow.Cells[4].Value.ToString(); 
                textBoxCorreo.Text = ClientedataGridView.CurrentRow.Cells[5].Value.ToString(); 
                textBoxTelefono.Text = ClientedataGridView.CurrentRow.Cells[6].Value.ToString();
                

            }
            else
            {
                MessageBox.Show("Debe Seleccionar Una Fila");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListaCliente();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxID.Text) || String.IsNullOrEmpty(textBoxNombre.Text) || String.IsNullOrEmpty(textBoxApellido.Text) ||
                String.IsNullOrEmpty(textBoxArticuloDireccion.Text) || String.IsNullOrEmpty(textBoxCorreo.Text) || String.IsNullOrEmpty(textBoxTelefono.Text) ||
                String.IsNullOrWhiteSpace(textBoxID.Text) || String.IsNullOrWhiteSpace(textBoxNombre.Text) || String.IsNullOrWhiteSpace(textBoxApellido.Text) ||
                String.IsNullOrWhiteSpace(textBoxArticuloDireccion.Text) || String.IsNullOrWhiteSpace(textBoxCorreo.Text) || String.IsNullOrWhiteSpace(textBoxTelefono.Text))
            {
                MessageBox.Show("Por Favor Llenar Todos Los Campos");
            }
            else
            {
                CNCliente objDato = new CNCliente();
                objDato.Id = textBoxID.Text;
                objDato.Nombre = textBoxNombre.Text;
                objDato.Apellido = textBoxApellido.Text;
                objDato.Direccion = textBoxArticuloDireccion.Text;
                objDato.Correo = textBoxCorreo.Text;
                objDato.Telefono = textBoxTelefono.Text;
                objDato.Tipoid = TipoIdcomboBox.Text;
                try
                {
                    objDato.ModificarCliente();
                    ListaCliente();
                    MessageBox.Show("Cliente Modificado Exitosamente");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error en Modificación");
                    
                }
            }
        }

        private void textBoxCorreo_Leave(object sender, EventArgs e)
        {
            
        }

        private void textBoxTelefono_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBoxTelefono.Text, "[^0-9]"))
            {
                errorTelefono.Visible = true;
                btnModificar.Enabled = false;
            }
            else
            {
                errorTelefono.Visible = false;
                btnModificar.Enabled = true;
            }
        }

        private void textBoxCorreo_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBoxCorreo.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
            {
                errorCorreo.Visible = false;
                btnModificar.Enabled = true;
            }
            else
            {
                errorCorreo.Visible = true;
                btnModificar.Enabled = false;

            }
        }
    }
}
