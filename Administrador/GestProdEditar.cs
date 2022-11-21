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
    public partial class GestProdEditar : Form
    {
        public GestProdEditar()
        {
            InitializeComponent();
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
            string op = "e";
            int IDProducto = Convert.ToInt32(textBox1.Text);
            string Nombre = textBox2.Text;
            string Descripcion = textBox3.Text;
            decimal Costo = decimal.Parse(textBox5.Text);
            decimal PrecioUnitario = decimal.Parse(textBox10.Text);
            decimal Existencias = decimal.Parse(textBox4.Text);
            decimal PuntoDeReorden = decimal.Parse(textBox6.Text);
            ObjetoDB.Departamento departamento = comboBox1.SelectedItem as ObjetoDB.Departamento;
            ObjetoDB.UnidadDeMedida unidadDeMedida = comboBox2.SelectedItem as ObjetoDB.UnidadDeMedida;

            DialogResult dr = MessageBox.Show("¿Desea editar este producto?","Editar producto", MessageBoxButtons.YesNo);
            switch (dr)
            {
                case DialogResult.Yes:

                    var objBD = new EnlaceDB();
                    comp = objBD.GestProd(op, IDProducto, Nombre, Descripcion, Costo, PrecioUnitario, Existencias, PuntoDeReorden, departamento.IDDepartamento, unidadDeMedida.IDUnidadDeMedida);

                    this.Close();
                    mainmenuADM1 mainmenuADM1 = new mainmenuADM1();
                    mainmenuADM1.Show();

                    break;
                case DialogResult.No:

                    break;
            }
        }
        private void button3_Click(object sender, EventArgs e)//Eliminar Producto
        {
            bool comp = false;
            string op = "d";
            int IDProducto = Convert.ToInt32(textBox1.Text);
            string Nombre = textBox2.Text;
            string Descripcion = textBox3.Text;
            decimal Costo = decimal.Parse(textBox5.Text);
            decimal PrecioUnitario = decimal.Parse(textBox10.Text);
            decimal Existencias = decimal.Parse(textBox4.Text);
            decimal PuntoDeReorden = decimal.Parse(textBox6.Text);
            ObjetoDB.Departamento departamento = comboBox1.SelectedItem as ObjetoDB.Departamento;
            ObjetoDB.UnidadDeMedida unidadDeMedida = comboBox2.SelectedItem as ObjetoDB.UnidadDeMedida;

            DialogResult dr = MessageBox.Show("¿Desea eliminar este producto? Recuerde que se eliminaran asimismo todos los descuentos que este producto tenga",
                        "Eliminar producto", MessageBoxButtons.YesNo);
            switch (dr)
            {
                case DialogResult.Yes:

                    var objBD = new EnlaceDB();
                    comp = objBD.GestProd(op, IDProducto, Nombre, Descripcion, Costo, PrecioUnitario, Existencias, PuntoDeReorden, departamento.IDDepartamento, unidadDeMedida.IDUnidadDeMedida);

                    this.Close();
                    mainmenuADM1 mainmenuADM1 = new mainmenuADM1();
                    mainmenuADM1.Show();

                    break;
                case DialogResult.No:

                    break;
            }
        }
        private void GestProdEditar_Load(object sender, EventArgs e)//Cargar ventana
        {
            var objBD = new EnlaceDB();

            List<ObjetoDB.Producto>          listProductos      = new List<ObjetoDB.Producto>();
            List<ObjetoDB.Departamento>     listDepartamentos   = new List<ObjetoDB.Departamento>();
            List<ObjetoDB.UnidadDeMedida>    listUnidadMedidas  = new List<ObjetoDB.UnidadDeMedida>();
            
            listProductos = null;
            listDepartamentos = null;
            listUnidadMedidas = null;

            listDepartamentos = objBD.ConsultaDepartamentos();
            listProductos = objBD.ConsultaProductos();
            listUnidadMedidas = objBD.ConsultaUnidadDeMedida();
            if (listDepartamentos.Count() == 0|| listProductos.Count()==0||listUnidadMedidas.Count()==0)
            {
                MessageBox.Show("No se encuentran departamentos, productos o unidad de medidas en la base de datos, favor de agregar estos al sistema", "Datos pendientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                mainmenuADM1 mainmenuADM1 = new mainmenuADM1();
                mainmenuADM1.Show();
            }
            else
            {
                comboBox3.DataSource = listProductos;
                comboBox3.ValueMember = "IDProducto";
                comboBox3.DisplayMember = "Nombre";

                comboBox1.DataSource = listDepartamentos;
                comboBox1.ValueMember = "IDDepartamento";
                comboBox1.DisplayMember = "nombreDept";

                comboBox2.DataSource = listUnidadMedidas;
                comboBox2.ValueMember = "IDUnidadDeMedida";
                comboBox2.DisplayMember = "Nombre";

            }

        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            ObjetoDB.Producto seleccion = comboBox3.SelectedItem as ObjetoDB.Producto;
            textBox1.Text = seleccion.IDProducto.ToString();
            textBox2.Text = seleccion.Nombre;
            textBox3.Text = seleccion.Descripcion;
            textBox5.Text = seleccion.Costo.ToString();
            textBox10.Text = seleccion.PrecioUnitario.ToString();
            textBox4.Text = seleccion.Existencias.ToString();
            textBox6.Text = seleccion.PuntoDeReorden.ToString();

            comboBox1.SelectedItem = seleccion.DepartamentoFK;
            comboBox2.SelectedItem = seleccion.UnidadMedidaFK;

        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

      
    }
}
