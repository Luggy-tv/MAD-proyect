using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace MAD3_ventanas
{
    public partial class ventas : Form
    {
        public List<ObjetoDB.ProductosEnVenta> productosEnVentasLista= null;
        public DataTable productosEnVentasTabla= null;
        public decimal subtotal             = 0;
        public decimal total                = 0;
        public decimal cantidadDescontada   = 0;
        public ventas()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            pagar pagar = new pagar();
            pagar.Show();
        }
        private void Regresar_Click(object sender, EventArgs e)
        {
            this.Close();
            mainmenuCAJ mainmenuCAJ = new mainmenuCAJ();
            mainmenuCAJ.Show();
        }
        private void consulta_Click(object sender, EventArgs e)
        {
            Rapida Rapida = new Rapida();
            Rapida.ShowDialog();

        }
        private void ventas_Load(object sender, EventArgs e)
        {
            var objBD = new EnlaceDB();
            List<ObjetoDB.Producto> listProductos = new List<ObjetoDB.Producto>();
            listProductos = null;
            listProductos = objBD.ConsultaProductos();
            if (listProductos.Count() == 0)
            {
                MessageBox.Show("No se encuentran producto en la base de datos, favor de agregar estos al sistema",
                   "Datos pendientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                mainmenuCAJ mainmenuCAJ = new mainmenuCAJ();
                mainmenuCAJ.Show();
            }
            else { 
                comboBox1.DataSource = listProductos;
                comboBox1.ValueMember = "IDProducto";
                comboBox1.DisplayMember = "Nombre";
                DateTime localDate = DateTime.Now;
                textBox4.Text = loginCaj.loggedUser.nombres+ loginCaj.loggedUser.apellidoPat+ loginCaj.loggedUser.apellidoMat;
                textBox6.Text = loginCaj.loggedUCaja.ToString();
                textBox5.Text = localDate.ToString();
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ObjetoDB.Producto seleccion = comboBox1.SelectedItem as ObjetoDB.Producto;
            var objBD = new EnlaceDB();
            List<ObjetoDB.UnidadDeMedida> listUnidadMedidas = new List<ObjetoDB.UnidadDeMedida>();
            listUnidadMedidas = null;
            listUnidadMedidas = objBD.ConsultaUnidadDeMedida();
            var prodUMFK = GetUnidadDeMedidaFromProducto(seleccion, listUnidadMedidas);
            textBox7.Text = prodUMFK.Nombre;
        }
        private ObjetoDB.UnidadDeMedida GetUnidadDeMedidaFromProducto(ObjetoDB.Producto _producto, List<ObjetoDB.UnidadDeMedida> _listUnidadMedidas)
        {
            ObjetoDB.UnidadDeMedida UM = new ObjetoDB.UnidadDeMedida();
            for (int i1 = 0; i1 < _listUnidadMedidas.Count; i1++)
            {
                if (_listUnidadMedidas[i1].IDUnidadDeMedida == _producto.UnidadMedidaFK)
                    UM = _listUnidadMedidas[i1];
            }
            return UM;
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            // If you want, you can allow decimal (float) numbers
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        private void button2_Click(object sender, EventArgs e)//BOTON INGRESAR
        {
            var seleccion = comboBox1.SelectedItem as ObjetoDB.Producto;
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
