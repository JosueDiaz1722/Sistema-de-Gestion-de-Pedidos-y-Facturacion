using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
            btnRestaurar.Visible = false;
        }

        public Inicio(string a)
        {
            InitializeComponent();
            btnRestaurar.Visible = false;
            toolStripMenuItem1.Visible = false;
            toolStripMenuBajaCliente.Visible = false;
            ToolStripMenudarDeAltaACliente.Visible = false;
            toolStripMenuItemModifcar.Visible = false;
            toolStripMenuItemAnularFactura.Visible = false;
            ToolStripMenuItemEliminarInventario.Visible = false;
            ToolStripMenuItemModificarInventario.Visible = false;
            toolStripMenuItem16.Visible = false;
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            
        }
        private int tolerance = 12;
        private const int WM_NCHITTEST = 132;
        private const int HTBOTTOMRIGHT = 17;
        private Rectangle sizeGripRectangle;

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    base.WndProc(ref m);
                    var hitPoint = this.PointToClient(new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16));
                    if (sizeGripRectangle.Contains(hitPoint))
                        m.Result = new IntPtr(HTBOTTOMRIGHT);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            var region = new Region(new Rectangle(0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height));

            sizeGripRectangle = new Rectangle(this.ClientRectangle.Width - tolerance, this.ClientRectangle.Height - tolerance, tolerance, tolerance);

            region.Exclude(sizeGripRectangle);
            this.panelContenedor.Region = region;
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            SolidBrush blueBrush = new SolidBrush(Color.FromArgb(207, 200, 210));
            e.Graphics.FillRectangle(blueBrush, sizeGripRectangle);

            base.OnPaint(e);
            ControlPaint.DrawSizeGrip(e.Graphics, Color.Transparent, sizeGripRectangle);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            String Men = "¿Seguro que quiere cerrar la aplicación?";
            String Tit = "Cerrar Aplicación";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(Men, Tit, buttons);
            if(result == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {

            }
            
        }

        int lx, ly;
        int sw, sh;

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            btnRestaurar.Visible = false;
            btnMaximizar.Visible = true;
            this.Size = new Size(sw, sh);
            this.Location = new Point(lx, ly);
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            lx = this.Location.X;
            ly = this.Location.Y;
            sw = this.Size.Width;
            sh = this.Size.Height;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void toolStripMenuIConsultarCliente_Click(object sender, EventArgs e)
        {
            AbrirFormulario<ConsultarCliente>();
        }

        private void consultarPedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Pedido.ConsultarPedido>();
        }

        private void toolStripMenuConsultarFactura_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Factura.ConsultarFactura>();
        }

        private void ToolStripMenuItemconsultarFacturas_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Factura.ConsultarFacturas>();
        }

        private void consultarInventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Inventario.ConsultarInventario>();
        }

        private void toolStripMenuConsultarUsuario_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Administracion.ConsultarUsuario>();
        }

        private void toolStripMenuItemRegistrarProducto_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Producto.RegistrarProducto>();
        }

        private void toolStripMenuItemIngresarCliente_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Cliente.RegistrarCliente>();
        }

        private void ToolStripMenuItemregistrarPedido_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Pedido.TabPedidos>();
            //AbrirFormulario<Pedido.RegistrarPedido>();
        }

        private void toolStripMenuItemEmitirFactura_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Factura.EmitirFactura>();
        }

        private void ToolStripMenuItemConsultarPedido_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Pedido.ConsultarPedidos>();
        }

        private void ToolStripMenuItemagregarInventario_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Inventario.AgregarInventario>();
        }

        private void toolStripMenuItemCrearUsuario_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Administracion.CrearUsuario>();
        }

        private void toolStripMenuEliminarProducto_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Producto.EliminarProducto>();
        }

        private void toolStripMenuBajaCliente_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Cliente.DarBajaCliente>();
        }

        private void ToolStripMenudarDeAltaACliente_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Cliente.DarAltaCliente>();
        }

        private void ToolStripMenuItemanularPedido_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Pedido.AnularPedido>();
        }

        private void toolStripMenuItemAnularFactura_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Factura.AnularFactura>();
        }

        private void ToolStripMenuItemEliminarInventario_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Inventario.EliminarInventario>();
        }

        private void toolStripMenuItemDesactivarUsuario_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Administracion.EliminarUsuario>();
        }

        private void ToolStripMenuItemActivarUsuario_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Administracion.ActivarUsuario>();
        }

        private void toolStripMenuItemModificarProducto_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Producto.ModificarProducto>();
        }

        private void ToolStripMenuItemModificarPedido_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Pedido.ModificarPedido>();
        }

        private void toolStripMenuItemModificarFactura_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Factura.ModificarFactura>();
        }

        private void ToolStripMenuItemModificarInventario_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Inventario.ModificarInventario>();
        }

        private void toolStripMenuItemModificarUsuario_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Administracion.ModificarUsuario>();
        }

        private void ToolStripMenuItemDatosDelSistema_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Administracion.DatosSistema>();
            
        }

        private void ToolStripMenuItemInformacionDelSistema_Click(object sender, EventArgs e)
        {
            Ayuda.DatosSistema obj = new Ayuda.DatosSistema();
            obj.Show();
        }

        private void toolStripMenuItemManuelUsuario_Click(object sender, EventArgs e)
        {
            Ayuda.ManualUsuario obj = new Ayuda.ManualUsuario();
            obj.Show();
        }

        private void toolStripMenuItemModifcar_Click(object sender, EventArgs e)
        {
            AbrirFormulario < Cliente.ModificarCliente>();
        }

        private void btnConsultarProducto_Click(object sender, EventArgs e)
        {
            AbrirFormulario<ConsultarProducto>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String Men = "¿Seguro que quiere cerrar todas las ventanas?";
            String Tit = "Cerrar Ventanas";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(Men, Tit, buttons);
            if (result == DialogResult.Yes)
            {
                foreach (Form form in panelformularios.Controls.OfType<Form>().ToArray())
                {
                    form.Close();
                }
            }
            
                
        }

        private void consultarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Administracion.ConsultarUsuario>();
        }

        private void crearUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Administracion.CrearUsuario>();
        }

        private void desactivarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Administracion.EliminarUsuario>();
        }

        private void activarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Administracion.ActivarUsuario>();
        }

        private void modificarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Administracion.ModificarUsuario>();
        }

        private void modificarParametroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Administracion.DatosSistema>();
        }

        private void panelformularios_Paint(object sender, PaintEventArgs e)
        {

        }

        private void crearParametroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Administracion.CrearDatos>();
        }

        private void consultarParametroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Administracion.ConsultarDato>();
        }

        private void eliminarParametroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Administracion.EliminarDato>();
        }

        private void AbrirFormulario<MiForm>() where MiForm : Form, new()
        {
            Form formulario;
            formulario = panelformularios.Controls.OfType<MiForm>().FirstOrDefault();//Busca en la colecion el formulario
            //si el formulario/instancia no existe
            if (formulario == null)
            {
                formulario = new MiForm();
                formulario.TopLevel = false;
                formulario.FormBorderStyle = FormBorderStyle.None;
                formulario.Dock = DockStyle.Fill;
                panelformularios.Controls.Add(formulario);
                panelformularios.Tag = formulario;
                formulario.Show();
                formulario.BringToFront();
                
            }
             //si el formulario/instancia existe
            else
            {
                formulario.BringToFront();
                
            }
        }

        private void CerrarFormulario()
        {
            foreach (Form form in panelformularios.Controls.OfType<Form>())
            {
                form.Close();
            }
        }
       
    }
}
