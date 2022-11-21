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

        }

        private void button2_Click(object sender, EventArgs e)//Busqueda por Codigo
        {

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
