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
            byte porcentaje=    byte.Parse(textBox2.Text);
            DateTime FechaINI = dateTimePicker1.Value;
            DateTime FechaFIN = dateTimePicker2.Value;
            ObjetoDB.Producto producto = comboBox1.SelectedItem as ObjetoDB.Producto;

            if (Nombre == "" || textBox2.Text == "")
            {
                MessageBox.Show("Llenar todos los campos", "Datos Faltantes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult dr = MessageBox.Show("¿Desea Agregar este descuento?", "Agregar descuento", MessageBoxButtons.YesNo);
                switch (dr)
                {
                    case DialogResult.Yes:

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
            }else
            {
                cantDesc = cantDesc + 1000000;
                textBox3.Text = cantDesc.ToString();

                comboBox1.DataSource = listProductos;
                comboBox1.ValueMember = "IDProducto";
                comboBox1.DisplayMember = "Nombre";
            }


        }
    }
}
