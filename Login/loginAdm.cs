using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MAD3_ventanas.Administrador;

namespace MAD3_ventanas
{
    public partial class login : Form
    {
        
        public login()
        {
            InitializeComponent();
        }

        private void Regresar_Click(object sender, EventArgs e)
        {
            this.Hide();
            prelogin prelogin = new prelogin();
            prelogin.Show();
        }

        //private void Ingresar_Click(object sender, EventArgs e)
        //{
        //    this.Hide();
        //    mainmenuADM1 mainmenuADM = new mainmenuADM1();
        //    mainmenuADM.Show();
        //}

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string IDusuario = textBox1.Text;
            string contraseña = textBox2.Text;

            if (IDusuario == "" || contraseña == "")
            {
                MessageBox.Show("Llenar todos los campos");

            }

            else
            {
                this.Close();
                mainmenuADM1 mainmenuADM1 = new mainmenuADM1();
                mainmenuADM1.Show();

            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}
