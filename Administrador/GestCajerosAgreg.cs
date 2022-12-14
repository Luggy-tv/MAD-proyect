using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

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
            cantUser = 10000 + cantUser;
            textBox10.Text = cantUser.ToString();
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
            
            bool val;
            bool val2;
            bool val3;
            bool val4;
            bool val5;
            bool val6;
            bool val7;
            bool val8;
            bool val9;
            bool val10;

            //CAMBIO EKIZ

            string regex = "^[a-zA-Z ]+$";
            string regex2 = "^[a-zA-Z0-9]+$";
            string regex3 = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";


            bool result1 = Regex.IsMatch(nombres, regex);
            bool result2 = Regex.IsMatch(apellidoPat, regex);
            bool result3 = Regex.IsMatch(apellidoMat, regex);
            bool result4 = Regex.IsMatch(CURP, regex2);
            bool result5 = Regex.IsMatch(numNomina, regex2);
            bool result6 = Regex.IsMatch(email, regex3);



            if (apellidoMat == "")
            {
              result3 = true;
              apellidoMat = "-";
            }
               

            //VALIDACIÓN NO VACÍOS
            if (nombres == "" || apellidoPat == "" || fechaNac == null || CURP == "" || numNomina == "" || email == "" || contraseña == "" || contraseñaVal == "")
            {
                MessageBox.Show("Llenar todos los campos", "Datos Faltantes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                val = false;
            }
            else
            {
                val = true;
            }

            //VALIDACIÓN CONTRASEÑAS IGUALES
            if (contraseña != contraseñaVal)
            {
                MessageBox.Show("Las contraseñas deben coincidir", "Accion inconcebible", MessageBoxButtons.OK, MessageBoxIcon.Error);
                val2 = false;
            }
            else
            {
                val2 = true;
            }

            //VALIDACIÓN MAYOR DE 18 AÑOS
            if (dateTimePicker1.Value > DateTime.Today.AddYears(-18))
            {
                MessageBox.Show("El usuario debe ser mayor de 18 años para regitrarse como empleado");
                val3 = false;
            }
            else
            {
                val3 = true;
            }

            //VALIDACION CARACTERES MIN Y MAX CONTRASEÑAS 
            if (contraseña.Length < 5 || contraseña.Length > 20)
            {
                MessageBox.Show("La contraseña debe tener una longitud de entre 5 y 20 caracteres");
                val4 = false;
            }
            else
            {
                val4 = true;
            }


            //VALIDACION CARACTERES MAX NOMBRES || SOLO LETRAS
            if (nombres.Length > 30 || result1 == false)
            {
                MessageBox.Show("El nombre debre tener un máximo de 30 caracteres unicamente alfabeticos");
                val5 = false;
            }
            else
            {
                val5 = true;
            }


            //VALIDACION CARACTERES MAX APPAT
            if (apellidoPat.Length > 30 || result2 == false)
            {
                MessageBox.Show("El apellido paterno debre tener un máximo de 30 caracteres unicamente alfabeticos");
                val6 = false;
            }
            else
            {
                val6 = true;
            }


            //VALIDACION CARACTERES MAX APMAT
            if (apellidoMat.Length > 30 || result3 == false)
            {
                MessageBox.Show("El apellido materno debre tener un máximo de 30 caracteres unicamente alfabeticos");
                val7 = false;
            }
            else
            {
                val7 = true;
            }


            //VALIDACION CARACTERES CURP
            if (CURP.Length != 18 || result4 == false)
            {
                MessageBox.Show("El CURP debe tener 18 caracteres alfanuméricos");
                val8 = false;
            }
            else
            {
                val8 = true;
            }

            //VALIDACION CARACTERES NUM NOMINA
            if (numNomina.Length != 16 || result5 == false)
            {
                MessageBox.Show("El número de nómina debe tener 16 caracteres alfanuméricos");
                val9 = false;
            }
            else
            {
                val9 = true;
            }

            //VALIDACION CARACTERES EMAIL !!! pendiente validar formato !!!
            if (email.Length > 30 || result6 == false)
            {
                MessageBox.Show("El formato del correo electrónico no es válido o excede el límite de 30 caracteres");
                val10 = false;
            }
            else
            {
                val10 = true;
            }



            if (val == true && val2 == true && val3 == true && val4 == true && val5 == true && val6 == true && val7 == true && val8 == true && val9 == true && val10 == true)
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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
