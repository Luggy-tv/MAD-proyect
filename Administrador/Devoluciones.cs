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
    public partial class Devoluciones : Form
    {
        public Devoluciones()
        {
            InitializeComponent();
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }
        private void button1_Click(object sender, EventArgs e)
        {
        }//EMITIR NOTA DE CREDITO
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            mainmenuADM1 mainmenuADM1 = new mainmenuADM1();
            mainmenuADM1.Show();
        }//REGRESAR MAIN MENU
        private void Devoluciones_Load(object sender, EventArgs e)
        {
            var objBD = new EnlaceDB();

            List<ObjetoDB.Producto> listProductos = new List<ObjetoDB.Producto>();
            listProductos = null;
            listProductos = objBD.ConsultaProductos();

            List

            if (listProductos.Count() == 0)
            {
                MessageBox.Show("No se encuentran recibos en la base de datos, favor de realizar una venta",
                   "Datos pendientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                mainmenuCAJ mainmenuCAJ = new mainmenuCAJ();
                mainmenuCAJ.Show();
            }
            else
            {
                comboBox1.DataSource = listProductos;
                comboBox1.ValueMember = "IDProducto";
                comboBox1.DisplayMember = "Nombre";
            }
        }

       

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
