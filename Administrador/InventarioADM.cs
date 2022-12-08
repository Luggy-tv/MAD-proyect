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
    public partial class InventarioADM : Form
    {
        public InventarioADM()
        {
            InitializeComponent();
        }

        private void InventarioADM_Load(object sender, EventArgs e)
        {
            var objBD = new EnlaceDB();
            int cantProd = objBD.GetCount("PROD");

            List<ObjetoDB.Departamento> listDepartamentos = new List<ObjetoDB.Departamento>();
          

            listDepartamentos = null;
            

            listDepartamentos = objBD.ConsultaDepartamentos();
           

            if (listDepartamentos.Count() == 0)
            {
                MessageBox.Show("No se encuentran departamentos o unidades de medida en la base de datos, favor de agregar estos al sistema", "Datos pendientes", MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.Close();
                mainmenuADM1 mainmenuADM1 = new mainmenuADM1();
                mainmenuADM1.Show();
            }
            else
            {
                comboBox1.DataSource = listDepartamentos;
                comboBox1.ValueMember = "IDDepartamento";
                comboBox1.DisplayMember = "nombreDept";

            }

            dataGridView1.DataSource = objBD.ConsultaInventario();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            mainmenuADM1 mainmenuADM1 = new mainmenuADM1();
            mainmenuADM1.Show();

         

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var seleccion = comboBox1.SelectedItem as ObjetoDB.Producto;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //comboBox1.Enabled = (comboBox2.SelectedIndex == 1);
           if (comboBox2.SelectedIndex == 1)
            {
                comboBox1.Enabled = true;
            }
           else
            {
                comboBox1.Enabled = false;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
