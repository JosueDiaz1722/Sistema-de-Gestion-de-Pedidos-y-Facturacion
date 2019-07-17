using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Ayuda
{
    public partial class ManualUsuario : Form
    {
        public ManualUsuario()
        {
            InitializeComponent();
        }

        private void ManualUsuario_Load(object sender, EventArgs e)
        {
            axAcroPDF1.LoadFile("F:\\ProyectosVS\\Solution1\\ManualUsuario.pdf");
            axAcroPDF1.Show();
        }
    }
}
