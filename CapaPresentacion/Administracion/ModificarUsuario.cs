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

namespace CapaPresentacion.Administracion
{
    public partial class ModificarUsuario : Form
    {
        CNUsuario objDato = new CNUsuario();
        public ModificarUsuario()
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

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            if (textBoxPass.UseSystemPasswordChar == true)
            {
                textBoxPass.UseSystemPasswordChar = false;
                btnMostrar.Text = "OCULTAR";
            }
            else
            {
                textBoxPass.UseSystemPasswordChar = true;
                btnMostrar.Text = "MOSTRAR";
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            textBoxNombre.Clear();
            textBoxPass.Clear();
            textBoxCorreo.Clear();
            comboBoxCargo.SelectedIndex = 0;
            textBoxNombre.Enabled = false;
            textBoxPass.Enabled = false;
            textBoxCorreo.Enabled = false;
            comboBoxCargo.Enabled = false;
            btnModificar.Enabled = false;

        }

        private void ListaUsuarios()
        {
            CNUsuario objDato = new CNUsuario();
            UsuariodataGridView.DataSource = objDato.ListaUsuarios();

        }

        private void ListaIndex()
        {
            UsuariodataGridView.Columns[0].HeaderText = "Nombre Usuario";
            UsuariodataGridView.Columns[1].HeaderText = "Correo Electrónico";
            UsuariodataGridView.Columns[2].HeaderText = "Cargo";
            UsuariodataGridView.Columns[3].HeaderText = "Estado";
        }


        private void listaCargo()
        {

            CNUsuario objMedida = new CNUsuario();
            comboBoxCargo.DataSource = objMedida.ListaCargo();
            comboBoxCargo.DisplayMember = "nombreCargo";
            comboBoxCargo.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCargo.SelectedIndex = 0;

        }

        private void ModificarUsuario_Load(object sender, EventArgs e)
        {
            textBoxPass.UseSystemPasswordChar = true;
            listaCargo();
            ListaUsuarios();
            ListaIndex();
            textBoxNombre.Enabled = false;
            textBoxPass.Enabled = false;
            textBoxCorreo.Enabled = false;
            comboBoxCargo.Enabled = false;
            btnModificar.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListaUsuarios();
        }

        private void textBoxCorreo_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCorreo.Text))
            {
                errorCorreo.Visible = false;
            }
            else
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

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxNombre.Text) || String.IsNullOrEmpty(textBoxPass.Text) || String.IsNullOrEmpty(textBoxCorreo.Text))
            {
                MessageBox.Show("Por Favor Llenar Todos Los Campos");
            }
            else
            {
                objDato.Usuario = textBoxNombre.Text;
                objDato.Pass = textBoxPass.Text;
                objDato.Correo = textBoxCorreo.Text;
                int n = comboBoxCargo.SelectedIndex + 1;
                objDato.Cargo = n;
                try
                {
                    objDato.ModificarUsuario();
                    ListaUsuarios();
                    MessageBox.Show("Usuario Modificado Exitosamente");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al Modificar Usuario");
                    textBoxNombre.Clear();
                    textBoxPass.Clear();
                    textBoxCorreo.Clear();
                    comboBoxCargo.SelectedIndex = 0;
                }
            }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (UsuariodataGridView.SelectedRows.Count > 0)
            {
                textBoxNombre.Enabled = true;
                textBoxPass.Enabled = true;
                textBoxCorreo.Enabled = true;
                comboBoxCargo.Enabled = true;
                btnLimpiar.Enabled = true;

                textBoxNombre.Text = UsuariodataGridView.CurrentRow.Cells[0].Value.ToString();
                CNUsuario objCargo = new CNUsuario();
                objCargo.Usuario = UsuariodataGridView.CurrentRow.Cells[0].Value.ToString();
                DataTable pass = objCargo.BuscarPass();
                textBoxPass.Text = pass.Rows[0][0].ToString();
                textBoxCorreo.Text =UsuariodataGridView.CurrentRow.Cells[1].Value.ToString();
                objCargo.Nombrecargo = UsuariodataGridView.CurrentRow.Cells[2].Value.ToString();
                DataTable dato = objCargo.BuscarIndex();
                comboBoxCargo.SelectedIndex = int.Parse(dato.Rows[0][0].ToString()) - 1;
            }
            else
            {
                MessageBox.Show("Debe Seleccionar Una Fila");
            }
        }
    }
}