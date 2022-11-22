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
    public partial class GestProdAgregar : Form
    {
        public GestProdAgregar()
        {
            InitializeComponent();
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void GestProdAgregar_Load(object sender, EventArgs e)
        {
           
            var objBD = new EnlaceDB();
            int cantProd = objBD.GetCount("PROD");

            List <ObjetoDB.Departamento> listDepartamentos = new List<ObjetoDB.Departamento>();
            List<ObjetoDB.UnidadDeMedida> listUnidadMedidas = new List<ObjetoDB.UnidadDeMedida>();

            listDepartamentos = null;
            listUnidadMedidas = null;

            listDepartamentos = objBD.ConsultaDepartamentos();
            listUnidadMedidas = objBD.ConsultaUnidadDeMedida();

            if (listDepartamentos.Count() == 0 || listUnidadMedidas.Count() == 0)
            {
                MessageBox.Show("No se encuentran departamentos o unidades de medida en la base de datos, favor de agregar estos al sistema", "Datos pendientes", MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.Close();
                mainmenuADM1 mainmenuADM1 = new mainmenuADM1();
                mainmenuADM1.Show();
            }
            else
            {
                cantProd = cantProd + 1000000;
                textBox1.Text = cantProd.ToString();

                comboBox1.DataSource = listDepartamentos;
                comboBox1.ValueMember = "IDDepartamento";
                comboBox1.DisplayMember = "nombreDept";

                comboBox2.DataSource = listUnidadMedidas;
                comboBox2.ValueMember = "IDUnidadDeMedida";
                comboBox2.DisplayMember = "Nombre";
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

            bool comp = false;
            string op = "i";
            short IDProducto = 10000;
            string Nombre = textBox2.Text;
            string Descripcion = textBox3.Text;

            decimal Costo = 0;
            decimal PrecioUnitario = 0;
            int Existencias = 0;
            int PuntoDeReorden = 0;


            ObjetoDB.Departamento departamento = comboBox1.SelectedItem as ObjetoDB.Departamento;
            ObjetoDB.UnidadDeMedida unidadDeMedida = comboBox2.SelectedItem as ObjetoDB.UnidadDeMedida;

            bool val1;
            bool val2;
            bool val3;
            bool val4;

            //VALIDACIÓN NO VACÍOS
            if (Nombre == "" || Descripcion == "" || textBox5.Text == "" || textBox10.Text == "" || textBox4.Text == "" || textBox6.Text == "" )
            {
                MessageBox.Show("Llenar todos los campos", "Datos Faltantes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                val1 = false;
            }
            else
            {
                val1 = true;
            }


            if (Nombre.Length > 30)
            {
                MessageBox.Show("El nombre del producto excede el límite de 30 caracteres", "Exceso de caracteres", MessageBoxButtons.OK, MessageBoxIcon.Error);
                val2 = false;
            }
            else
            {
                val2 = true;
            }


            if (Descripcion.Length > 50)
            {
                MessageBox.Show("La descripción del producto excede el límite de 50 caracteres", "Exceso de caracteres", MessageBoxButtons.OK, MessageBoxIcon.Error);
                val3 = false;
            }
            else
            {
                val3 = true;
            }

       


            if (val1 == true && val2 == true && val3 == true)
            {
                Costo = decimal.Parse(textBox5.Text);
                PrecioUnitario = decimal.Parse(textBox10.Text);
                Existencias = int.Parse(textBox4.Text);
                PuntoDeReorden = int.Parse(textBox6.Text);

                if (Costo < PrecioUnitario)
                {
                    MessageBox.Show("El precio unitario no puede ser mayor al costo", "Datos no válidos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    val4 = false;
                }
                else
                {
                    val4 = true;
                }

                if (val4 == true)
                {
                         DialogResult dr = MessageBox.Show("¿Desea agregar estos datos?",
                         "Agregar productos", MessageBoxButtons.YesNo);
                  switch (dr)
                  {
                    case DialogResult.Yes:
    

                        var objBD = new EnlaceDB();
                        comp = objBD.GestProd(op, IDProducto, Nombre, Descripcion, Costo, PrecioUnitario, Existencias, PuntoDeReorden, departamento.IDDepartamento, unidadDeMedida.IDUnidadDeMedida);
                      
                        this.Close();
                        mainmenuADM1 mainmenu = new mainmenuADM1();
                        mainmenu.Show();

                        break;
                    case DialogResult.No:

                        break;
                  }
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verify that the pressed key isn't CTRL or any non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // If you want, you can allow decimal (float) numbers
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verify that the pressed key isn't CTRL or any non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // If you want, you can allow decimal (float) numbers
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verify that the pressed key isn't CTRL or any non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // If you want, you can allow decimal (float) numbers
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verify that the pressed key isn't CTRL or any non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // If you want, you can allow decimal (float) numbers
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }


    }
}
