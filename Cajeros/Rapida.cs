using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MAD3_ventanas
{
    public partial class Rapida : Form
    {
        public Rapida()
        {
            InitializeComponent();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Rapida_Load(object sender, EventArgs e)
        {
            var objBD = new EnlaceDB();
            List<ObjetoDB.Producto> listProductos = new List<ObjetoDB.Producto>();
            listProductos = null;
            listProductos = objBD.ConsultaProductos();

            comboBox1.DataSource = listProductos;
            comboBox1.ValueMember = "IDProducto";
            comboBox1.DisplayMember = "Nombre";
        }

        private void button1_Click(object sender, EventArgs e)//Busqueda Por Nombre
        {
            var seleccion = comboBox1.SelectedItem as ObjetoDB.Producto;
            string op = "N";
            int idProd = 0;
            string nombre = seleccion.Nombre;
            var objBD = new EnlaceDB();
            var tabla = objBD.ConsultaRapidaPrecio(op,idProd,nombre);

            dataGridView1.DataSource = tabla;
        }

        private void button2_Click(object sender, EventArgs e)//Busqueda por Codigo
        {
            var seleccion = comboBox1.SelectedItem as ObjetoDB.Producto;
            string op = "C";
            int idProd = Int32.Parse(textBox1.Text);
            string nombre = "";
            var objBD = new EnlaceDB();
            var tabla = objBD.ConsultaRapidaPrecio(op, idProd, nombre);

            dataGridView1.DataSource = tabla;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

    }
}
