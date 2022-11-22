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
        public List<ObjetoDB.ProductosEnVenta> productosEnVentasLista= new List<ObjetoDB.ProductosEnVenta>();
        public DataTable productosEnVentasTabla= null;
        public decimal subtotal             = 0;
        public decimal total                = 0;
        public decimal cantidadDescontada   = 0;
        public int cantidadDeProductos      = 0;

        public ventas()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            pagar pagar = new pagar();
            pagar.ShowDialog();
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
            if (textBox2.Text == "" || decimal.Parse(textBox2.Text)<=0|| decimal.Parse(textBox2.Text)>seleccion.Existencias)
            {
                MessageBox.Show("Favor de agregar la cantidad de producto correcta", "Accion Imposible", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else {
                decimal cant = decimal.Parse(textBox2.Text);
                if (seleccion.Existencias <= 0)
                {
                    MessageBox.Show("No se puede agregar producto ya que no tiene existencias", "Accion Imposible", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {

                    subtotal = subtotal + cant * seleccion.Costo;
                    cantidadDescontada = cantidadDescontada +  cant * CheckDescuentoForProd(seleccion);
                    total = subtotal - cantidadDescontada;

                    productosEnVentasLista.Add(new ObjetoDB.ProductosEnVenta
                    {
                        IDProducto = seleccion.IDProducto
                    ,
                        Nombre = seleccion.Nombre
                    ,
                        Existencias = seleccion.Existencias
                    ,
                        Costo = seleccion.Costo
                    ,
                        CantProd = cant
                    ,
                        PrecioProds = cant * seleccion.Costo
                    ,   
                        descuento= cant*CheckDescuentoForProd(seleccion)
                    });

                    seleccion.Existencias = seleccion.Existencias - cant;

                    dataGridView1.DataSource = ConvertToDatatable(productosEnVentasLista);

                    textBox3.Text = subtotal.ToString();
                    textBox1.Text = cantidadDescontada.ToString();
                    textBox8.Text = total.ToString();
                    
                    cantidadDeProductos++;

                    textBox2.Clear();
                }
            }
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
        private DataTable ConvertToDatatable(List<ObjetoDB.ProductosEnVenta> list)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("IDProducto  ");
            dt.Columns.Add("Nombre      ");
            dt.Columns.Add("Existencias ");
            dt.Columns.Add("Costo       ");
            dt.Columns.Add("CantProd    ");
            dt.Columns.Add("Precio productos");
            dt.Columns.Add("Descuento Aplicado");

            foreach (var item in list)
            {
                var row = dt.NewRow();

                row["IDProducto  "] = item.IDProducto;
                row["Nombre      "] = item.Nombre;
                row["Existencias "] = item.Costo;
                row["Costo       "] = item.Nombre;
                row["CantProd    "] = item.CantProd;
                row["Precio productos"] = item.PrecioProds;
                row["Descuento Aplicado"] = item.descuento;

                dt.Rows.Add(row);
            }

            return dt;
        }
        private decimal CheckDescuentoForProd(ObjetoDB.Producto producto)
        {
            decimal descuente = 0;
            List<ObjetoDB.Descuento> listaDescuentos = null;
            var objBD = new EnlaceDB();
            listaDescuentos = objBD.ConsultaDescuentos();
            DateTime localDate = DateTime.Now;

            foreach ( var item in listaDescuentos)
            {
                if(item.ProductoFK == producto.IDProducto)
                {
                    if (localDate > item.FechaINI && localDate < item.FechaFIN)
                    {
                        decimal porcentaje = (decimal)(item.Porcentaje * 0.01);
                        descuente = producto.Costo * porcentaje;
                    }
                }
            }
            
            return descuente;
        }
    }
}
