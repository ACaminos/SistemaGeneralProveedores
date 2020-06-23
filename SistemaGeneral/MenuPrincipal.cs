using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaGeneral
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void salirDelSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult opcion;
            opcion = MessageBox.Show("¿Desea salir del sistema?", "¡Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (opcion == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 F = new Form1();
            DialogResult opcion;
            opcion = MessageBox.Show("¿Desea cerrar la sesión?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (opcion == DialogResult.Yes)
            {
                this.Hide();
                F.Show();
            }
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clientes C = new Clientes();
            this.Hide();
            C.Show();
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Proveedores P = new Proveedores();
            this.Hide();
            P.Show();
        }
    }
}
