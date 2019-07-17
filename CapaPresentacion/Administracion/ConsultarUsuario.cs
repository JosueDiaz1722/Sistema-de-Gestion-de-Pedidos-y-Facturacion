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
    public partial class ConsultarUsuario : Form
    {
        public ConsultarUsuario()
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

        private void LoadComboBox()
        {

            comboBox1.Items.Add("Nombre Usuario");
            comboBox1.Items.Add("Correo Electrónico");
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.SelectedIndex = 0;
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

        private void ConsultarUsuario_Load(object sender, EventArgs e)
        {
            LoadComboBox();
            ListaUsuarios();
            ListaIndex();
        }

        private void BuscarUsuario(string id)
        {
            CNUsuario objDato = new CNUsuario();
            objDato.Usuario = id;
            UsuariodataGridView.DataSource = objDato.BuscarUsuario();
            ListaIndex();
        }

        private void BuscarCorreo(string id)
        {
            CNUsuario objDato = new CNUsuario();
            objDato.Correo = id;
            UsuariodataGridView.DataSource = objDato.BuscarUsuarioCorreo();
            ListaIndex();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textBox1.Text))
            {
                ListaUsuarios();
            }
            else
            {
                string criterio = comboBox1.Text;
                switch (criterio)
                {
                    case "Nombre Usuario":
                        BuscarUsuario(textBox1.Text);
                        break;
                    case "Correo Electrónico":
                        BuscarCorreo(textBox1.Text);
                        break;
                }
            }
        }
    }
}
