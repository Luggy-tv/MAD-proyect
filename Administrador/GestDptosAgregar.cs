using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MAD3_ventanas;

namespace MAD3_ventanas.Administrador
{
    public partial class GestDptosAgregar : Form
    {
        //string nombreDept;

        public GestDptosAgregar()
        {
            InitializeComponent();
        }

        private void GestDptosAgregar_Load(object sender, EventArgs e)
        {
            var objBD = new EnlaceDB();
            int cantDep = objBD.GetCount("DPTO");

            cantDep = cantDep + 10000;
            textBox2.Text = cantDep.ToString();

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            this.Close();
            mainmenuADM1 mainmenuADM1 = new mainmenuADM1();
            mainmenuADM1.Show();
        }

        private void button2_Click(object sender, EventArgs e) //FALTA VALIDAR QUE NO ESTÉ VACÍO
        {
            //falta guardar info
            bool comp = false;
            string op = "i";
            Int16 IDDepartamento = 10000;
            string nombreDept = textBox1.Text;
            bool reembolsable = checkBox1.Checked;

            if (nombreDept == "")
            {
                MessageBox.Show("Ingresar nombre del departamento");

            }

            else
            { 
                DialogResult dr = MessageBox.Show("¿Desea guardar este departamento?",
                         "Agregar departamento", MessageBoxButtons.YesNo);
                switch (dr)
                {
                    case DialogResult.Yes:

                        var objBD = new EnlaceDB();
                        comp = objBD.GestDept( op, IDDepartamento,  nombreDept, reembolsable);

                    this.Close();
                    mainmenuADM1 mainmenuADM1 = new mainmenuADM1();
                    mainmenuADM1.Show();

                    break;
                    case DialogResult.No:

                        break;
                }
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
