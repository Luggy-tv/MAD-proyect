﻿using System;
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
            var objBD = new EnlaceDB();
            bool reciboExist = false, productExistsInRecibo = false, productIsReembolsable = false ;

            var seleccion = comboBox1.SelectedItem as ObjetoDB.Producto;

            List<ObjetoDB.Producto_En_Recibo> ListaProductoEnRecibos = new List<ObjetoDB.Producto_En_Recibo>();
            ListaProductoEnRecibos = null;
            ListaProductoEnRecibos = objBD.ConsultaProductoEnRecibos();

            ObjetoDB.Producto_En_Recibo producto = new ObjetoDB.Producto_En_Recibo();
            producto = null;


            if (textBox2.Text.Length ==0  || int.Parse(textBox2.Text) <= 0|| int.Parse(textBox2.Text)>= 2000000|| textBox1.Text.Length == 0 || int.Parse(textBox1.Text) <= 0)
            {
                MessageBox.Show("Favor de llenar la informacion correspondiente",
                   "Datos pendientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                reciboExist = CheckIfReciboExists(ListaProductoEnRecibos, int.Parse(textBox1.Text));
                if (reciboExist)
                {
                    producto = GetProducto_En_ReciboFromList(ListaProductoEnRecibos, int.Parse(textBox1.Text));
                    productExistsInRecibo = CheckIfProductExistsInRecibo(producto, seleccion);
                }
                else
                {
                    MessageBox.Show("Recibo no existe en la base de datos, verificar los datos ingresados",
                  "Datos incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (productExistsInRecibo)
                {
                    
                    productIsReembolsable = CheckIfProductIsReembolsable(producto, seleccion);
                }
                else
                {
                    MessageBox.Show("Producto no existe en el recibo, verificar los datos ingresados",
                 "Datos incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (productIsReembolsable)
                {
                    MessageBox.Show("Carita feliz",
                ":)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Lamento decirle que el producto que esta seleccionando no es reembolsable",
                 "Producto no reembolsable", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


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
            List<ObjetoDB.Producto_En_Recibo> ListaProductoEnRecibos = new List<ObjetoDB.Producto_En_Recibo>();

            listProductos = null;
            ListaProductoEnRecibos = null;

            listProductos = objBD.ConsultaProductos();
            ListaProductoEnRecibos = objBD.ConsultaProductoEnRecibos();

            if (listProductos.Count() == 0)
            {
                MessageBox.Show("No se encuentran recibos en la base de datos, favor de realizar una venta",
                   "Datos pendientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ListaProductoEnRecibos.Clear();
                this.Close();
                mainmenuCAJ mainmenuCAJ = new mainmenuCAJ();
                mainmenuCAJ.Show();
            }
            else
            {
                ListaProductoEnRecibos.Clear();
                comboBox1.DataSource = listProductos;
                comboBox1.ValueMember = "IDProducto";
                comboBox1.DisplayMember = "Nombre";
            }
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
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
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private bool CheckIfReciboExists(List<ObjetoDB.Producto_En_Recibo> _ListaProductoEnRecibos, int _idRecibo)
        {
            bool flag = false;
            foreach(var item in _ListaProductoEnRecibos)
            {
                if (item.IDRecibo == _idRecibo)
                    flag = true;
            }

            return flag;
        }
        private bool CheckIfProductExistsInRecibo(ObjetoDB.Producto_En_Recibo producto_En_Recibo, ObjetoDB.Producto producto)
        {
            bool flag = false;
            if (producto_En_Recibo.ProductoFK == producto.IDProducto)
            {
                flag = true;
            }
            return flag;
        }
        private bool CheckIfProductIsReembolsable(ObjetoDB.Producto_En_Recibo producto_En_Recibo, ObjetoDB.Producto producto)
        {
            bool flag = false;
            if (producto_En_Recibo.ProductoFK == producto.IDProducto)
            {
                flag = producto_En_Recibo.Reembolsable;
            }
            return flag;
        }
        private ObjetoDB.Producto_En_Recibo GetProducto_En_ReciboFromList(List<ObjetoDB.Producto_En_Recibo> _ListaProductoEnRecibos, int _idRecibo)
        {
            ObjetoDB.Producto_En_Recibo prod =null;

            foreach (var item in _ListaProductoEnRecibos)
            {
                if (item.IDRecibo == _idRecibo)
                {
                    prod=item;
                }
            }

            return prod; 
        }
    }
}
