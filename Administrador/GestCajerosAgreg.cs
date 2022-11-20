using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MAD3_ventanas.Administrador
{
    public partial class GestCajerosAgreg : Form
    {
        public GestCajerosAgreg()
        {
            InitializeComponent();
        }

        private void GestCajerosAgreg_Load(object sender, EventArgs e)
        {
            var objBD = new EnlaceDB();
            int cantUser = objBD.GetCount("USER");
            cantUser = 10001 + cantUser;
            textBox10.Text =cantUser.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            mainmenuADM1 mainmenu = new mainmenuADM1();
            mainmenu.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool comp = false;
            string op = "I";
            Int16 IDUsuario = 10000;
            string contraseña = textBox7.Text;
            string contraseñaVal = textBox3.Text;
            string nombres = textBox1.Text;
            string apellidoPat = textBox8.Text;
            string apellidoMat = textBox4.Text;
            string CURP = textBox6.Text;
            DateTime fechaNac = dateTimePicker1.Value;
            string numNomina = textBox2.Text;
            string email = textBox5.Text;
            bool esAdmin = false;
            bool val = false;
            bool val2 = false;

            if (apellidoMat == "")
                apellidoMat = "-";

   
                if (nombres == "" || apellidoPat == "" || fechaNac == null || CURP == "" || numNomina == "" || email == "" || contraseña == "" || contraseñaVal == "")
            {
                MessageBox.Show("Llenar todos los campos", "Datos Faltantes", MessageBoxButtons.OK, MessageBoxIcon.Error);

                val = false;
            } 

                else 
            { 
                val = true; 
            }

                if (contraseña != contraseñaVal)
            {
                MessageBox.Show("Las contraseñas deben coincidir", "Accion inconcebible", MessageBoxButtons.OK, MessageBoxIcon.Error);

                val2 = false;
            }

                else 
            { 
                val2 = true; 
            }



            if (val == true && val2 == true)
            {          
                DialogResult dr = MessageBox.Show("¿Desea agregar estos datos?",
                         "Agregar cajeros", MessageBoxButtons.YesNo);
                switch (dr)
                {
                    case DialogResult.Yes:

                        var objBD = new EnlaceDB();
                        comp = objBD.GestUsuarios(op, IDUsuario, contraseña, nombres, apellidoPat, apellidoMat, CURP, fechaNac, numNomina, email, esAdmin);

                    this.Close();
                    mainmenuADM1 mainmenu = new mainmenuADM1();
                    mainmenu.Show();

                    break;
                    case DialogResult.No:

                        break;
                }
            }          

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
