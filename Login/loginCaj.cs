using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MAD3_ventanas
{

    public partial class loginCaj : Form
    {

        string usuario;
        string contrasena;

        int numCaja;


        public loginCaj()
        {
            InitializeComponent();
        }

        private void Regresar_Click(object sender, EventArgs e)
        {
            this.Hide();
            prelogin prelogin = new prelogin();
            prelogin.Show();
        }

        private void Ingresar_Click(object sender, EventArgs e)
        {
            string IDusuario = textBox1.Text;
            string contraseña = textBox2.Text;
            int numCaja = comboBox1.SelectedIndex;

            if (usuario == "" || contrasena == "" /*|| numCaja == 0*/) 
            {
                MessageBox.Show("Llenar todos los campos");

            }

            else {
                this.Close();
                mainmenuCAJ mainmenuCAJ = new mainmenuCAJ();
                mainmenuCAJ.Show();
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void loginCaj_Load(object sender, EventArgs e)
        {

        }
    }
}
