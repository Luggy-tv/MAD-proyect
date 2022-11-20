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
    public partial class GestDptosEditar : Form
    {
        public GestDptosEditar()
        {
            InitializeComponent();
            
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
            string op = "e";
            short IDDepartamento = Convert.ToInt16(textBox2.Text);
            string nombreDept = textBox1.Text;
            bool reembolsable = checkBox1.Checked;

            if (nombreDept == "")
            {
                MessageBox.Show("Ingresar nombre del departamento", "Datos pendientes", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                DialogResult dr = MessageBox.Show("¿Desea editar este departamento?",
                         "Editar departamento", MessageBoxButtons.YesNo);
                switch (dr)
                {
                    case DialogResult.Yes:

                        var objBD = new EnlaceDB();
                        comp = objBD.GestDept(op, IDDepartamento, nombreDept, reembolsable);

                        this.Close();
                        mainmenuADM1 mainmenuADM1 = new mainmenuADM1();
                        mainmenuADM1.Show();

                        break;
                    case DialogResult.No:

                        break;
                }
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           ObjetoDB.Departamento seleccion = comboBox1.SelectedItem as ObjetoDB.Departamento;
            textBox1.Text = seleccion.nombreDept;
            textBox2.Text = seleccion.IDDepartamento.ToString();
            checkBox1.Checked = seleccion.Reembolsable;
        }
        public void GestDptosEditar_Load(object sender, EventArgs e)
        {
            var objBD = new EnlaceDB();

            List<ObjetoDB.Departamento> listDepartamentos = new List<ObjetoDB.Departamento>();
            listDepartamentos = null;

            listDepartamentos = objBD.ConsultaDepartamentos();

            if (listDepartamentos.Count() == 0)
            {
                MessageBox.Show("No se encuentran departamentos en la base de datos, favor de agregar estos al sistema", "Datos pendientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        }
        private void button3_Click(object sender, EventArgs e)
        {
            bool comp = false;
            string op = "d";
            short IDDepartamento = Convert.ToInt16(textBox2.Text);
            string nombreDept = textBox1.Text;
            bool reembolsable = checkBox1.Checked;

            DialogResult dr = MessageBox.Show("¿Desea eliminar este departamento?",
                        "Eliminar departamento", MessageBoxButtons.YesNo);
            switch (dr)
            {
                case DialogResult.Yes:

                    var objBD = new EnlaceDB();
                    comp = objBD.GestDept(op, IDDepartamento, nombreDept, reembolsable);

                    this.Close();
                    mainmenuADM1 mainmenuADM1 = new mainmenuADM1();
                    mainmenuADM1.Show();

                    break;
                case DialogResult.No:

                    break;
            }
            
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

    }
}
