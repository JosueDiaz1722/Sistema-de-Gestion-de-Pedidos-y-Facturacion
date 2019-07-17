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
    public partial class RegistrarCliente : Form
    {
        CNCliente objDato = new CNCliente();
        public RegistrarCliente()
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
            textBoxID.Clear();
            textBoxNombre.Clear();
            textBoxApellido.Clear();
            textBoxArticuloDireccion.Clear();
            textBoxCorreo.Clear();
            textBoxTelefono.Clear();
            errorCorreo.Visible = false;
            errorTelefono.Visible = false;
            btnRegistrar.Enabled = false;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(textBoxID.Text) || String.IsNullOrEmpty(textBoxNombre.Text)|| String.IsNullOrEmpty(textBoxApellido.Text)|| 
                String.IsNullOrEmpty(textBoxArticuloDireccion.Text)|| String.IsNullOrEmpty(textBoxCorreo.Text)|| String.IsNullOrEmpty(textBoxTelefono.Text)||
                String.IsNullOrWhiteSpace(textBoxID.Text) || String.IsNullOrWhiteSpace(textBoxNombre.Text) || String.IsNullOrWhiteSpace(textBoxApellido.Text) ||
                String.IsNullOrWhiteSpace(textBoxArticuloDireccion.Text) || String.IsNullOrWhiteSpace(textBoxCorreo.Text) || String.IsNullOrWhiteSpace(textBoxTelefono.Text))
            {
                MessageBox.Show("Por Favor Llenar Todos Los Campos");
            }
            else
            {
                objDato.Id = textBoxID.Text;
                objDato.Nombre = textBoxNombre.Text;
                objDato.Apellido = textBoxApellido.Text;
                objDato.Direccion = textBoxArticuloDireccion.Text;
                objDato.Correo = textBoxCorreo.Text;
                objDato.Telefono = textBoxTelefono.Text;
                objDato.Tipoid = TipoIdcomboBox.Text;
                try
                {
                    objDato.InsertarCliente();
                    ListaCliente();
                    MessageBox.Show("Cliente Insertado Exitosamente");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Cliente Ya Existe");
                    textBoxID.Clear();
                    textBoxNombre.Clear();
                    textBoxApellido.Clear();
                    textBoxArticuloDireccion.Clear();
                    textBoxCorreo.Clear();
                    textBoxTelefono.Clear();
                }
            }
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

        private void RegistrarCliente_Load(object sender, EventArgs e)
        {
            ListaCliente();
            LoadCombobox();
            btnRegistrar.Enabled = false;
            errorID.Visible = false;
        }



        public static bool ValidateId(string cedula)
        {
            long isNumeric;
            const int tamanoLongitudCedula = 10;
            const int numeroProvincias = 24;
            const int tercerDigito = 6;
            var total = 0;
            int[] coeficientes = { 2, 1, 2, 1, 2, 1, 2, 1, 2 };
            if (long.TryParse(cedula, out isNumeric) && cedula.Length.Equals(tamanoLongitudCedula))
            {
                var Provincia = Convert.ToInt32(string.Concat(cedula[0] + string.Empty, cedula[1] + string.Empty));
                var digitoTres = Convert.ToInt32(cedula[2] + string.Empty);
                if ((Provincia > 0 && Provincia <= numeroProvincias) && digitoTres < tercerDigito)
                {
                    var digitoVerificadorRecibido = Convert.ToInt32(cedula[9] + string.Empty);
                    for (var i = 0; i < coeficientes.Length; i++)
                    {
                        var valor = Convert.ToInt32(coeficientes[i] + string.Empty) * Convert.ToInt32(cedula[i] + string.Empty);

                        total = valor >= 10 ? total + (valor - 9) : total + valor;
                    }
                    var digitoVerificadorobtenido = total >= 10 ? (total % 10) != 0 ? 10 - (total % 10) : (total % 10) : total;
                    return digitoVerificadorRecibido == digitoVerificadorobtenido;
                }
                return false;
            }
            return false;
        }

        private bool ValidarRuc(string RUC)
        {
            long isNumeric;
            const int tamanioRUC = 13;
            const string establecimiento = "001";
            if(long.TryParse(RUC, out isNumeric)&& RUC.Length.Equals(tamanioRUC))
            {
                var numeroProvincia = Convert.ToInt32(string.Concat(RUC[0] + string.Empty, RUC[1] + string.Empty));
                var personaNatrual = Convert.ToInt32(RUC[2] + String.Empty);
                if((numeroProvincia>=1 && numeroProvincia<=24)&&(personaNatrual >=0 && personaNatrual < 6))
                {
                    return RUC.Substring(10, 3) == establecimiento && ValidateId(RUC.Substring(0, 10));
                }
                return false;
            }
            return false;
        }

        private void textBoxID_Leave(object sender, EventArgs e)
        {
           
        }

        private void LoadCombobox()
        {
            TipoIdcomboBox.Items.Add("Cédula");
            TipoIdcomboBox.Items.Add("RUC");
            TipoIdcomboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            TipoIdcomboBox.SelectedIndex = 0;
        }

        private void textBoxTelefono_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBoxTelefono.Text, "[^0-9]"))
            {
                errorTelefono.Visible = true;
                btnRegistrar.Enabled = false;
            }
            else
            {
                errorTelefono.Visible = false;
                btnRegistrar.Enabled = true;
            }
        }

        private void textBoxCorreo_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBoxCorreo.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
            {
                errorCorreo.Visible = false;
                btnRegistrar.Enabled = true;
            }
            else
            {
                errorCorreo.Visible = true;
                btnRegistrar.Enabled = false;

            }
        }

        private void textBoxCorreo_Leave(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListaCliente();
        }

        private void textBoxID_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxID.Text))
            {
                errorID.Visible = false;
            }
            else
            {
                if (TipoIdcomboBox.SelectedItem.Equals("Cédula"))
                {
                    if (ValidateId(textBoxID.Text) == false)
                    {
                        errorID.Text = "Cédula Invalida";
                        errorID.Visible = true;
                        btnRegistrar.Enabled = false;

                    }
                    else
                    {
                        btnRegistrar.Enabled = true;
                        errorID.Visible = false;
                    }

                }
                else
                {
                    if (ValidarRuc(textBoxID.Text) == false)
                    {

                        errorID.Text = "RUC Invalido";
                        errorID.Visible = true;
                        btnRegistrar.Enabled = false;
                    }
                    else
                    {
                        btnRegistrar.Enabled = true;
                        errorID.Visible = false;
                    }
                }
            }
            
        }
    }
}
