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
    public partial class DatosTienda : Form
    {
        public DatosTienda()
        {
            InitializeComponent();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void DatosTienda_Load(object sender, EventArgs e)
        {
            var objBD = new EnlaceDB();
            DataTable tablaDeDatos = new DataTable();
            List<ObjetoDB.DatosDeTienda> listaDeDatos = new List<ObjetoDB.DatosDeTienda>();
            tablaDeDatos = null;

            tablaDeDatos = objBD.ConsultaTablaDatosDeTienda();
            dataGridView1.DataSource = tablaDeDatos;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            this.Close();
            mainmenuADM1 mainmenuADM1 = new mainmenuADM1();
            mainmenuADM1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string op = "e";
            string nomtien = textBox1.Text;
            string rfc = textBox2.Text;
            string dom = textBox3.Text;
            string cp = textBox4.Text;
            string email = textBox5.Text;
            string numtel = textBox9.Text;
            var objBD = new EnlaceDB();

            bool val1;
            bool val2;
            bool val3;
            bool val4;
            bool val5;
            bool val6;
            bool val7;

            string regex = "^[a-zA-Z0-9]+$";
            string regex2 = "^[0-9]+$";
            string regex3 = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            bool result = Regex.IsMatch(rfc, regex);
            bool result2 = Regex.IsMatch(cp, regex2);
            bool result3 = Regex.IsMatch(email, regex3);
            bool result4 = Regex.IsMatch(numtel, regex2);


            //VALIDACION NO VACÍOS
            bool completo;
            if (nomtien == "" || textBox8.Text == "" || rfc == null || dom == "" || cp == "" || email == "" || email == "" || numtel == "")
            {
                MessageBox.Show("Favor de rellenar todos los campos", "Datos pendientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                val1 = false;
            }
            else
            {
                val1 = true;
            }

            //VALIDACION RFC
            if (rfc.Length > 12 || rfc.Length < 12|| result == false)
            {
                MessageBox.Show("El RFC de la empresa debe contener 12 caracteres alfanuméricos");
                val2 = false;
            }
            else
            {
                val2 = true;
            }

            //VALIDACION CP
            if (cp.Length > 5 || cp.Length < 5 || result2 == false)
            {
                MessageBox.Show("El código postal de la empresa debe contener 5 caracteres numéricos");
                val3 = false;
            }
            else
            {
                val3 = true;
            }

            //VALIDACION MAIL
            if (email.Length > 40 || result3 == false)
            {
                MessageBox.Show("El formato de correo electrónico no es válido o excede el límite de 40 caracteres");
                val4 = false;
            }
            else
            {
                val4 = true;
            }

            //VALIDACION NUM TELEFÓNICO
            if (numtel.Length < 7 || numtel.Length > 10 || result4 == false)
            {
                MessageBox.Show("La longitud del numero del teléfono no es válida");
                val5 = false;
            }
            else
            {
                val5 = true;
            }

           //VALIDACION LONGITUD NOMBRE
           if (nomtien.Length > 30)
            {
                MessageBox.Show("El nombre de la tienda supera el máximo de 30 caracteres");
                val6 = false;
            }
           else
            {
                val6 = true;
            }

            //VALIDACION LONGITUD DIRECCIÓN
            if (nomtien.Length > 100)
            {
                MessageBox.Show("La dirección de la tienda supera el máximo de 100 caracteres");
                val7 = false;
            }
            else
            {
                val7 = true;
            }


            if (val1 == true && val2 == true && val3 == true && val4 == true && val5 == true && val6 == true && val7 == true)
            {
                byte suc = byte.Parse(textBox8.Text);

                DialogResult dr = MessageBox.Show("¿Desea agregar estos datos?", "Agregar cajeros", MessageBoxButtons.YesNo);
                switch (dr)
                {
                    case DialogResult.Yes:
                        completo = objBD.GestTienda(op, nomtien, suc, rfc, dom, cp, email, numtel);
                        //falta guardar info
                        this.Close();
                        mainmenuADM1 mainmenuADM1 = new mainmenuADM1();
                        mainmenuADM1.Show();
                        break;
                    case DialogResult.No:

                        break;
                }
            }
           

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
