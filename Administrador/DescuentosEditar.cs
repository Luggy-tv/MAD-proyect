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
    public partial class DescuentosEditar : Form
    {
        public DescuentosEditar()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)//cancelar
        {
            this.Close();
            mainmenuADM1 mainmenuADM1 = new mainmenuADM1();
            mainmenuADM1.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            bool comp = false;
            string op = "e";
            int IDProducto = Convert.ToInt32(textBox3.Text);
            string Nombre = textBox1.Text;
            byte porcentaje = byte.Parse(textBox2.Text);
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
        }//Actualizar
        private void button3_Click(object sender, EventArgs e)//eliminar
        {
            bool comp = false;
            string op = "d";
            int IDProducto = Convert.ToInt32(textBox3.Text);
            string Nombre = textBox1.Text;
            byte porcentaje = byte.Parse(textBox2.Text);
            DateTime FechaINI = dateTimePicker1.Value;
            DateTime FechaFIN = dateTimePicker2.Value;
            ObjetoDB.Producto producto = comboBox1.SelectedItem as ObjetoDB.Producto;

            DialogResult dr = MessageBox.Show("¿Desea eliminar este descuento?", "eliminar descuento", MessageBoxButtons.YesNo);
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
        private void DescuentosEditar_Load(object sender, EventArgs e)//Cargar
        {
            var objBD = new EnlaceDB();
            var listaDescuentos = new List<ObjetoDB.Descuento>();
            var listaProductos = new List<ObjetoDB.Producto>();
            listaDescuentos = null;
            listaProductos = null;

            listaProductos = objBD.ConsultaProductos();
            listaDescuentos = objBD.ConsultaDescuentos();

            if (listaDescuentos.Count() == 0 || listaProductos.Count() == 0)
            {
                MessageBox.Show("No se encuentran descuentos o productos en la base de datos, favor de agregar estos al sistema", "Datos pendientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                mainmenuADM1 mainmenuADM1 = new mainmenuADM1();
                mainmenuADM1.Show();
            }
            else
            {
                comboBox2.DataSource = listaDescuentos;
                comboBox2.ValueMember = "IDDescuento";
                comboBox2.DisplayMember = "Nombre";

                comboBox1.DataSource = listaProductos;
                comboBox1.ValueMember = "IDProducto";
                comboBox1.DisplayMember = "Nombre";
            }
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            var seleccion = comboBox2.SelectedItem as ObjetoDB.Descuento;

            textBox3.Text = seleccion.IDDescuento.ToString();
            textBox1.Text = seleccion.Nombre;
            textBox2.Text = seleccion.Porcentaje.ToString();
            dateTimePicker1.Value = seleccion.FechaINI;
            dateTimePicker2.Value = seleccion.FechaFIN;

            comboBox1.SelectedItem = seleccion.ProductoFK;

        }
    }
}
