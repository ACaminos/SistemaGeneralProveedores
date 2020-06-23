using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using Microsoft.VisualBasic;

namespace SistemaGeneral
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        MenuPrincipal MP = new MenuPrincipal();
        public SqlConnection Conectar()
        {
            SqlConnection connection = new SqlConnection("data source=" + System.Convert.ToString(LeerHostDb()) + "; initial catalog=Northwind; integrated security=true");
            return connection;
        }
        public string LeerHostDb()
        {
            if (File.Exists(@"C:\Connections\hostDb.txt") == true)
            {
                StreamReader SR = File.OpenText(@"C:\Connections\hostDb.txt");
                string Line = SR.ReadLine();
                SR.Close();
                return Line;
            }

            return default;
        }

        public void iniciarSesion()
        {

            SqlCommand cmd = new SqlCommand("SELECT Usuario, Clave FROM NuevoUsuario WHERE Usuario='" + tUsuario.Text + "'AND Clave='" + tClave.Text + "'", Conectar());
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);

            if (dt.Rows.Count == 1)
            {
                this.Hide();
                MessageBox.Show("Autentificación exitosa", "Acceso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MP.Show();
            }
            else
            {
                MessageBox.Show("Acceso Denegado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void IniciarSesion_Click(object sender, EventArgs e)
        {
            string errores = "";
            string enter = Constants.vbCrLf;
            if (tUsuario.Text.Trim().Length < 3)
                errores += "Ingrese un Usuario." + enter;
            if (tClave.Text.Length < 6)
                errores += "Ingrese la Contraseña." + enter;
            if (errores.Length > 0)
            {
                MessageBox.Show("Hubo errores, Por Favor Verifique y Corrija Antes de Intentar de Nuevo:" + enter + enter + errores, "Errores", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
                iniciarSesion();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult opcion;
            opcion = MessageBox.Show("¿Desea salir del sistema?", "¡Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);

            if (opcion == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
