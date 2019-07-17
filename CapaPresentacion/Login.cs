using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using CapaNegocio;
using System.Data.SqlClient;

namespace CapaPresentacion
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void txtuser_Enter(object sender, EventArgs e)
        {
            if (txtuser.Text == "USUARIO")
            {
                txtuser.Text = "";
                txtuser.ForeColor = Color.LightGray; 
            }
        }

        private void txtuser_Leave(object sender, EventArgs e)
        {
            if (txtuser.Text == "")
            {
                txtuser.Text = "USUARIO";
                txtuser.ForeColor = Color.LightGray;
            }
        }

        private void txtpass_Leave(object sender, EventArgs e)
        {
            if (txtpass.Text == "")
            {
                txtpass.Text = "CONTRASEÑA";
                txtpass.ForeColor = Color.LightGray;
                txtpass.UseSystemPasswordChar = false;

            }
        }

        private void txtpass_Enter(object sender, EventArgs e)
        {
            if (txtpass.Text == "CONTRASEÑA")
            {
                txtpass.Text = "";
                txtpass.ForeColor = Color.LightGray;
                txtpass.UseSystemPasswordChar = true;

            }
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            String Men = "¿Seguro que quiere cerrar la aplicación?";
            String Tit = "Cerrar Aplicación";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(Men, Tit, buttons);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {

            }
        }

        private void btnminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            CNUsuario objUsuario = new CNUsuario();
            SqlDataReader Loguear;
            string usuario = txtuser.Text;
            objUsuario.Usuario = txtuser.Text;
            objUsuario.Pass = txtpass.Text;
            if (objUsuario.Usuario == txtuser.Text)
            {
                if(objUsuario.Pass == txtpass.Text)
                {
                    Loguear = objUsuario.IniciarSesion();
                    if (Loguear.Read() == true)
                    {
                        CNUsuario objDato = new CNUsuario();
                        
                        objDato.Usuario = usuario;
                        DataTable dato = objDato.BuscarUsuario();
                        if (dato.Rows[0][2].ToString().Equals("Administrador"))
                        {
                            this.Hide();
                            Inicio ObjFP = new Inicio();
                            ObjFP.Show();
                        }
                        else
                        {
                            this.Hide();
                            Inicio ObjFP = new Inicio("a");
                            ObjFP.Show();
                        }
           
                        
                    }
                    else
                    {
                        MessageBox.Show("Usuario o Contraseña Invalida");
                        txtuser.Text = "USUARIO";
                        txtuser.ForeColor = Color.LightGray;
                        txtpass.Text = "CONTRASEÑA";
                        txtpass.ForeColor = Color.LightGray;
                        txtpass.UseSystemPasswordChar = false;
                    }
                }else
                    MessageBox.Show(objUsuario.Pass);

            }
            else
                MessageBox.Show(objUsuario.Usuario);
            
        }
    }
}
