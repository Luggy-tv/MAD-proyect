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
    public partial class DescuentosAgreg : Form
    {
        public DescuentosAgreg()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)//Cancelar
        {
            
            this.Close();
            mainmenuADM1 mainmenuADM1 = new mainmenuADM1();
            mainmenuADM1.Show();
        }

        private void button2_Click(object sender, EventArgs e)//Ingresar
        {
            bool comp = false;
            string op = "i";
            int IDProducto =    Convert.ToInt32(textBox3.Text);
            string Nombre =     textBox1.Text;
            //byte porcentaje=    byte.Parse(textBox2.Text);
            DateTime FechaINI = dateTimePicker1.Value;
            DateTime FechaFIN = dateTimePicker2.Value;
            ObjetoDB.Producto producto = comboBox1.SelectedItem as ObjetoDB.Producto;

            bool val1;
            bool val2;
            bool val3;
            bool val4;

            //VALIDAR QUE NO HAYA CAMPOS VACÍOS
            if (Nombre == "" || textBox2.Text == "")
            {
                MessageBox.Show("Llenar todos los campos", "Datos Faltantes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                val1 = false;
            }
            else
            {
                val1 = true;
            }

            //MÁXIMO 20 CARACTERES
            if(Nombre.Length > 20)
            {
                MessageBox.Show("El nombre excede el límite de 20 caracteres", "Límite de caracteres");
                val2 = false;
            }
            else
            {
                val2 = true;
            }

            //VALIDACIÓN FECHA DE INICIO < FECHA DE FIN
            if (dateTimePicker1.Value >= dateTimePicker2.Value)
            {
                MessageBox.Show("La fecha de inicio no puede ser mayor o igual a la fecha de fin");
                val3 = false;
            }
            else
            {
                val3 = true;
            }

            
            
            int min = 1;
            int max = 100;

            //VALIDACION DESCUENTRO ENTRE 1 AL 100
            if(int.Parse(textBox2.Text)< min || int.Parse(textBox2.Text) > max)
            {
                MessageBox.Show("El porcentaje del descuento debe estar entre 1 y 100");
                val4 = false;
            }
            else
            {
               
                val4 = true;
            }

            if(val1 == true && val2 == true && val3 == true && val4 == true)
            {
                DialogResult dr = MessageBox.Show("¿Desea Agregar este descuento?", "Agregar descuento", MessageBoxButtons.YesNo);
                switch (dr)
                {
                    case DialogResult.Yes:

                        byte porcentaje = byte.Parse(textBox2.Text);

                        var objBD = new EnlaceDB();
                        comp = objBD.GestDescuento(op, IDProducto, Nombre, porcentaje, FechaINI, FechaFIN, producto.IDProducto);

                        this.Close();
                        mainmenuADM1 mainmenuADM1 = new mainmenuADM1();
                        mainmenuADM1.Show();

                        break;
                    case DialogResult.No:

                        break;
                }
            }


        }

        private void DescuentosAgreg_Load(object sender, EventArgs e)
        {
            var objBD = new EnlaceDB();
            int cantDesc = objBD.GetCount("DESC");
            var listProductos = new List<ObjetoDB.Producto>();
            listProductos = null;
            listProductos = objBD.ConsultaProductos();



            if (listProductos.Count() == 0)
            {
                MessageBox.Show("No se encuentran productos en la base de datos, favor de agregar estos al sistema.", "Datos pendientes", MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.Close();
                mainmenuADM1 mainmenuADM1 = new mainmenuADM1();
                mainmenuADM1.Show();
            }
            
            else
            {
                cantDesc = cantDesc + 1000000;
                textBox3.Text = cantDesc.ToString();

                comboBox1.DataSource = listProductos;
                comboBox1.ValueMember = "IDProducto";
                comboBox1.DisplayMember = "Nombre";
            }

        }

        //SOLO NUMEROS
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verify that the pressed key isn't CTRL or any non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            // If you want, you can allow decimal (float) numbers
            //if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            //{
            //    e.Handled = true;
            //}
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
