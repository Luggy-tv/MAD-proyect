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
            int IDProducto ;
            string Nombre = textBox2.Text;
            string Descripcion = textBox3.Text;

            decimal Costo ;
            decimal PrecioUnitario ;
            decimal Existencias ;
            decimal PuntoDeReorden ;


            ObjetoDB.Producto producto = comboBox3.SelectedItem as ObjetoDB.Producto;

            IDProducto = producto.IDProducto;

            ObjetoDB.Departamento departamento = comboBox1.SelectedItem as ObjetoDB.Departamento;
            ObjetoDB.UnidadDeMedida unidadDeMedida = comboBox2.SelectedItem as ObjetoDB.UnidadDeMedida;

            bool val1;
            bool val2;
            bool val3;
            bool val4;

            //VALIDACIÓN NO VACÍOS
            if (Nombre == "" || Descripcion == "" || textBox5.Text == "" || textBox10.Text == "" || textBox4.Text == "" || textBox6.Text == "")
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
                Costo =             decimal.Parse(textBox5.Text);
                PrecioUnitario =    decimal.Parse(textBox10.Text);
                Existencias =       decimal.Parse(textBox4.Text);
                PuntoDeReorden =    decimal.Parse(textBox6.Text);

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
                    DialogResult dr = MessageBox.Show("¿Desea editar estos datos?",
                    "Editar productos", MessageBoxButtons.YesNo);
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

            dataGridView1.DataSource = ConvertToDatatable(seleccion);

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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private DataTable ConvertToDatatable(ObjetoDB.Producto producto)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("IDProducto");
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Descripcion");
            dt.Columns.Add("Departamento");
            dt.Columns.Add("Unidad de medida");
            dt.Columns.Add("Costo");
            dt.Columns.Add("Precio unitario");
            dt.Columns.Add("Existencias");
            dt.Columns.Add("Punto de reorden");
          
          

           
                var row = dt.NewRow();

                row["IDProducto"] = producto.IDProducto;
                row["Nombre"] = producto.Nombre;
                row["Descripcion"] = producto.Descripcion;
                row["Departamento"] = producto.DepartamentoFK;
                row["Unidad de medida"] = producto.UnidadMedidaFK;
                row["Costo"] = producto.Costo;
                row["Precio unitario"] = producto.PrecioUnitario;
                row["Existencias"] = producto.Existencias;
                row["Punto de reorden"] = producto.PuntoDeReorden;
               

                dt.Rows.Add(row);

            return dt;
        }

    }    
}        
         