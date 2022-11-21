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
            EnlaceDB objBD = new EnlaceDB();
            bool comp = false;
            string op = "i";
            short IDProducto = 10000;
            string Nombre = textBox2.Text;
            string Descripcion = textBox3.Text;
            decimal Costo = int.Parse(textBox5.Text);
            decimal PrecioUnitario = int.Parse(textBox10.Text);
            int Existencias = int.Parse(textBox4.Text);
            int PuntoDeReorden = int.Parse(textBox6.Text);
            ObjetoDB.Departamento departamento = comboBox1.SelectedItem as ObjetoDB.Departamento;
            ObjetoDB.UnidadDeMedida unidadDeMedida = comboBox2.SelectedItem as ObjetoDB.UnidadDeMedida;

            comp = objBD.GestProd(op, IDProducto, Nombre, Descripcion, Costo, PrecioUnitario, Existencias, PuntoDeReorden, departamento.IDDepartamento, unidadDeMedida.IDUnidadDeMedida);
            
            this.Close();
            mainmenuADM1 mainmenuADM1 = new mainmenuADM1();
            mainmenuADM1.Show();
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
    }
}
