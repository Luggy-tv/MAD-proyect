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
    public partial class GestCajerosEditar : Form
    {
        public GestCajerosEditar()
        {
            InitializeComponent();
        }
        private void GestCajerosEditar_Load(object sender, EventArgs e)
        {
            var objBD = new EnlaceDB();

            List<ObjetoDB.Usuario> listUsuarios = new List<ObjetoDB.Usuario>();
            listUsuarios = null;

            listUsuarios = objBD.ConsultaUsuarios();

            if (listUsuarios.Count() == 0)
            {
                MessageBox.Show("No se encuentran usuarios en la base de datos, favor de agregar estos al sistema", "Datos pendientes", MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.Close();
                mainmenuADM1 mainmenuADM1 = new mainmenuADM1();
                mainmenuADM1.Show();
            }
            else
            {
                comboBox1.DataSource = listUsuarios;
                comboBox1.ValueMember = "IDUsuario";
                comboBox1.DisplayMember = "nombres" + "apellidoPat"+ "apellidoMat";
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            mainmenuADM1 mainmenuADM1 = new mainmenuADM1();
            mainmenuADM1.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            bool val = false;
            bool val2 = false;

            bool comp = false;
            string op = "e";
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

            if (apellidoMat == "")
                apellidoMat = "-";

                if (nombres == "" || apellidoPat == "" || fechaNac == null || CURP == "" || numNomina == "" || email == "" || contraseña == "")
            // if (string.IsNullOrEmpty(textBox1.Text) )
            {
                MessageBox.Show("Favor de llenar todos los campos", "Datos pendientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                DialogResult dr = MessageBox.Show("¿Desea editar estos datos?", "Editar Usuario", MessageBoxButtons.YesNo);
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
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ObjetoDB.Usuario seleccion = comboBox1.SelectedItem as ObjetoDB.Usuario;
            textBox1.Text = seleccion.nombres;
            textBox8.Text = seleccion.apellidoPat;
            textBox4.Text = seleccion.apellidoMat;
            dateTimePicker1.Value = seleccion.fechNac;
            textBox6.Text = seleccion.CURP;
            textBox2.Text = seleccion.numNomina;
            textBox5.Text = seleccion.email;
            textBox10.Text = seleccion.IDUsuario.ToString();
            textBox7.Text = seleccion.contraseña;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            ObjetoDB.Usuario seleccion = comboBox1.SelectedItem as ObjetoDB.Usuario;
            bool comp = false;
            string op = "d";
            Int16 IDUsuario = Convert.ToInt16(textBox10.Text);
            string contraseña = textBox7.Text;
            string contraseñaVal = textBox3.Text;
            string nombres = textBox1.Text;
            string apellidoPat = textBox8.Text;
            string apellidoMat = textBox4.Text;
            string CURP = textBox6.Text;
            DateTime fechaNac = dateTimePicker1.Value;
            string numNomina = textBox2.Text;
            string email = textBox5.Text;
            bool esAdmin = seleccion.esAdmin;

            if (seleccion.esAdmin) {

                MessageBox.Show("No se puede eliminar a un administrador del sistema", "Accion inconcebible", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else {
                DialogResult dr = MessageBox.Show("¿Desea eliminar estos datos?",
                            "Eliminar Cajero", MessageBoxButtons.YesNo);
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
        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

    }
}
