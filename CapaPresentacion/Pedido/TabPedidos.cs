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

namespace CapaPresentacion.Pedido
{
    public partial class TabPedidos : Form
    {
        private int n;
        public TabPedidos()
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

        private void TabPedidos_Load(object sender, EventArgs e)
        {
            numeroPedido();
            NuevoPedido();
        }

         

        private void AbrirFormulario<MiForm>(TabPage tpage) where MiForm : Form, new()
        {
            Form formulario;
            formulario = tpage.Controls.OfType<MiForm>().FirstOrDefault();//Busca en la colecion el formulario
            //si el formulario/instancia no existe
            if (formulario == null)
            {
                

                formulario = new MiForm();
                formulario.TopLevel = false;
                formulario.FormBorderStyle = FormBorderStyle.None;
                formulario.Dock = DockStyle.Fill;
                formulario.AutoScroll = true;
                tpage.Controls.Add(formulario);
                tpage.Tag = formulario;
                formulario.Show();
                formulario.BringToFront();

            }
            //si el formulario/instancia existe
            else
            {
                formulario.BringToFront();

            }
        }

        private void NuevoPedido(TabPage tpage,int n)
        {
            RegistrarPedido formulario = new RegistrarPedido(n);
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            formulario.AutoScroll = true;
            tpage.Controls.Add(formulario);
            tpage.Tag = formulario;
            formulario.Show();
            formulario.BringToFront();
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            NuevoPedido();
        }

        private void NuevoPedido()
        {
            TabPage tpage = new TabPage("Pedido #"+n);
            
            NuevoPedido(tpage, n);
            tabControl1.TabPages.Add(tpage);
            tabControl1.SelectedIndex = (tabControl1.SelectedIndex + 1 < tabControl1.TabCount) ?
                             tabControl1.SelectedIndex + 1 : tabControl1.SelectedIndex;
            n++;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            String Men = "¿Seguro que quiere eliminar este pedido?";
            String Tit = "Cerrar Pedido";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(Men, Tit, buttons);
            if (result == DialogResult.Yes)
            {
            int a = tabControl1.SelectedIndex;
            tabControl1.TabPages.Remove(tabControl1.SelectedTab);
            tabControl1.SelectedIndex = (a - 1 < tabControl1.TabCount) ?
                             a - 1 : tabControl1.SelectedIndex;
            n--;
            }

        }

        private void numeroPedido()
        {
            CNDatos objDatos = new CNDatos();
            DataTable dato = objDatos.NumeroPedido();
            decimal a = decimal.Parse(dato.Rows[0][0].ToString());
            n= decimal.ToInt32(a);
        }

        public void close()
        {
            cerrar();
        }

        private void cerrar()
        {
            tabControl1.TabPages.Remove(tabControl1.SelectedTab);
        }
    }
}
