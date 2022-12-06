using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace MAD3_ventanas.Administrador
{
    public partial class Devoluciones : Form
    {
        public ObjetoDB.DatosDeTienda DatosDeTienda = new ObjetoDB.DatosDeTienda();
        public ObjetoDB.ReciboDeVenta reciboDeVenta = new ObjetoDB.ReciboDeVenta();
        public ObjetoDB.NotaCredito notaCredito = new ObjetoDB.NotaCredito();
        public ObjetoDB.Devolucion devolucion = new ObjetoDB.Devolucion();



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

            DateTime localdate;
            localdate = DateTime.Now;
            string op = "s";
            decimal dummy = 10;
            int dummy2 = 10;

            var objBD = new EnlaceDB();

            var seleccion = comboBox1.SelectedItem as ObjetoDB.Producto;

            List<ObjetoDB.Producto_En_Recibo> ListaProductoEnRecibos = new List<ObjetoDB.Producto_En_Recibo>();
            ListaProductoEnRecibos = null;
            ListaProductoEnRecibos = objBD.ConsultaProductoEnRecibos();

            List<ObjetoDB.NotaCred_Devol> ListanotaCred_Devols = new List<ObjetoDB.NotaCred_Devol>();
            
            ObjetoDB.Producto_En_Recibo productoEnRecibo = new ObjetoDB.Producto_En_Recibo();
           
            ObjetoDB.NotaCred_Devol notaCred_Devol = new ObjetoDB.NotaCred_Devol();

            ListanotaCred_Devols = null;

            notaCredito = null;
            reciboDeVenta = null;
            productoEnRecibo = null;
            devolucion = null;
            notaCred_Devol = null;

            

            if (textBox2.Text.Length ==0  || int.Parse(textBox2.Text) <= 0|| int.Parse(textBox2.Text)>= 2000000|| textBox1.Text.Length == 0 || decimal.Parse(textBox1.Text) <= 0)
            {
                MessageBox.Show("Favor de llenar la informacion correspondiente",
                   "Datos pendientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (CheckIfReciboExists(ListaProductoEnRecibos, int.Parse(textBox2.Text)))
                {
                        
                    if (CheckIfProductExistsInRecibo(ListaProductoEnRecibos,int.Parse(textBox2.Text), seleccion))
                    {
                        productoEnRecibo = GetProducto_En_ReciboFromList(ListaProductoEnRecibos, int.Parse(textBox2.Text), seleccion);
                        if (CheckIfProductIsReembolsable(productoEnRecibo, seleccion))
                        {
                            //Aqui se estará llenando de manera incorrecta esta lista, es solo para llenarla de las notas de credito exstentes
                            //Esta lista contendrá, ID_NotaCreditoDevol, IDReciboDeCompra, CodigoDeProducto, Fecha
                            ListanotaCred_Devols = objBD.ConsultaNotaCreditoYDevolucion(op, dummy2, productoEnRecibo.IDRecibo, productoEnRecibo.ProductoFK,localdate);

                            if(!CheckIfNotaCredAlreadyExists(ListanotaCred_Devols, productoEnRecibo.IDRecibo, productoEnRecibo.ProductoFK)) { 
                                
                                if (CheckIfProductAmmountIsCorrect(productoEnRecibo, decimal.Parse(textBox1.Text)))
                                {
                                    DialogResult dr = MessageBox.Show("¿Desea emitir nota de credito? Recuerde que solo se puede hacer una vez por producto del recibo seleccionado", "Emitir Nota de Credito", MessageBoxButtons.YesNo);
                                    switch (dr)
                                    {
                                        case DialogResult.Yes:

                                            reciboDeVenta = objBD.ConsultaReciboDeVenta(op, productoEnRecibo.IDRecibo, dummy, dummy).First();
                                            op = "i";
                                            notaCredito = objBD.ConsultaNotaCredito(op, reciboDeVenta.IDRecibo, reciboDeVenta.Total, reciboDeVenta.Subtotal).First();

                                            devolucion = objBD.ConsultaDevolucion(op, seleccion.IDProducto, decimal.Parse(textBox1.Text), checkBox1.Checked).First();

                                            notaCred_Devol = objBD.ConsultaNotaCreditoYDevolucion(op, dummy2, notaCredito.IDNotaCredito, devolucion.IDDevolucion, localdate).First();

                                            MessageBox.Show("Nota de Credito generada imprimiendo acontinuacion", "Nota de credito creada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                            //IMPRESIÓN DE LA NOTA DE CRÉDITO
                                            printDocument1 = new PrintDocument();
                                            PrinterSettings ps = new PrinterSettings();
                                            printDocument1.PrinterSettings = ps;
                                            printDocument1.PrintPage += Imprimir;
                                            printDocument1.Print();

                                            this.Close();
                                            mainmenuADM1 mainmenuADM1 = new mainmenuADM1();
                                            mainmenuADM1.Show();

                                            break;

                                        case DialogResult.No:
                                            break;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("La cantidad de producto especificada no es la existente en el recibo, favor de verificar o llamar a seguridad",
                                    "Datos incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Se encuentra actualmente ya una nota de credito de este producto y esta compra, favor de verificar la informacion ingresada",
                                    "Producto no reembolsable", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Lamento decirle que el producto que esta seleccionando no es reembolsable",
                         "Producto no reembolsable", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Producto no existe en el recibo, verificar los datos ingresados",
                     "Datos incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Recibo no existe en la base de datos, verificar los datos ingresados",
                  "Datos incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
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

            if (ListaProductoEnRecibos.Count() == 0)
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
        private bool CheckIfProductExistsInRecibo(List<ObjetoDB.Producto_En_Recibo> _ListaProductoEnRecibos, int _idRecibo, ObjetoDB.Producto producto)
        {
            bool flag = false;
            foreach (var item in _ListaProductoEnRecibos)
            {
                if (item.IDRecibo == _idRecibo)
                {
                    if (item.ProductoFK == producto.IDProducto)
                    {
                        flag = true;
                    }
                }
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
        private ObjetoDB.Producto_En_Recibo GetProducto_En_ReciboFromList(List<ObjetoDB.Producto_En_Recibo> _ListaProductoEnRecibos, int _idRecibo, ObjetoDB.Producto producto)
        {
            ObjetoDB.Producto_En_Recibo prod =null;

            foreach (var item in _ListaProductoEnRecibos)
            {
                if (item.IDRecibo == _idRecibo && item.ProductoFK == producto.IDProducto)
                {
                    prod=item;
                }
            }

            return prod; 
        }
        private bool CheckIfProductAmmountIsCorrect(ObjetoDB.Producto_En_Recibo producto_En_Recibo, decimal _cantidadProducto)
        {
            bool flag = false;
            if(producto_En_Recibo.CantProd>= _cantidadProducto)
            {
                flag = true;
            }
            return flag;
        }
        private bool CheckIfNotaCredAlreadyExists(List<ObjetoDB.NotaCred_Devol> _listaNotaCreds, int _IDRecibo, int _IDProducto)
        {
            bool flag = false;
            foreach(var item in _listaNotaCreds)
            {
                if (item.NotaCreditoFK == _IDRecibo && item.DevolucionFK== _IDProducto)
                {
                    flag = true;
                }
            }
            return flag;
        }

        private void Imprimir(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            var objBD = new EnlaceDB();
            DatosDeTienda = objBD.ConsultaDatosDeTienda().First<ObjetoDB.DatosDeTienda>();
            var seleccion = comboBox1.SelectedItem as ObjetoDB.Producto;

            var total = seleccion.Costo * devolucion.Cantidad;

           

            DateTime localdate;
            localdate = DateTime.Now;

            Font font = new Font("Lucida Console", 10);
            int ancho = 600;
            int y = 20;

                       
            e.Graphics.DrawString("                      ---Nota de Crédito---                   ", font, Brushes.Gray, new RectangleF(0, y += 20, ancho, 20));
            e.Graphics.DrawString("" + DatosDeTienda.NombreTienda, font, Brushes.Gray, new RectangleF(0, y += 20, ancho, 20));
            e.Graphics.DrawString("Sucursal " + DatosDeTienda.Sucursal, font, Brushes.Gray, new RectangleF(0, y += 20, ancho, 20));
            e.Graphics.DrawString("RFC " + DatosDeTienda.RFC, font, Brushes.Gray, new RectangleF(0, y += 20, ancho, 20));
            e.Graphics.DrawString("" + DatosDeTienda.Domicilio, font, Brushes.Gray, new RectangleF(0, y += 20, ancho, 20));
            e.Graphics.DrawString("C.P. " + DatosDeTienda.CodigoPostal, font, Brushes.Gray, new RectangleF(0, y += 20, ancho, 20));
            e.Graphics.DrawString("Teléfono " + DatosDeTienda.numTel, font, Brushes.Gray, new RectangleF(0, y += 20, ancho, 20));

            e.Graphics.DrawString("--------------------------------------------------------------------", font, Brushes.Gray, new RectangleF(0, y += 20, ancho, 20));
            //Datos de venta    notaCredito
            e.Graphics.DrawString("Recibo relacionado: #" + reciboDeVenta.IDRecibo, font, Brushes.Gray, new RectangleF(0, y += 20, ancho, 20));
            e.Graphics.DrawString("Fecha y hora de emisión: " + localdate, font, Brushes.Gray, new RectangleF(0, y += 20, ancho, 20));
            e.Graphics.DrawString("Nota de crédito #" + notaCredito.IDNotaCredito, font, Brushes.Gray, new RectangleF(0, y += 20, ancho, 20));

            e.Graphics.DrawString("--------------------------------------------------------------------", font, Brushes.Gray, new RectangleF(0, y += 20, ancho, 20));
            //Datos de producto devuelto
            e.Graphics.DrawString("Concepto", font, Brushes.Gray, new RectangleF(0, y + 20, ancho, 20));
            e.Graphics.DrawString("Precio U", font, Brushes.Gray, new RectangleF(300, y + 20, ancho, 20));
            e.Graphics.DrawString("Cant", font, Brushes.Gray, new RectangleF(400, y + 20, ancho, 20));
            e.Graphics.DrawString("Monto", font, Brushes.Gray, new RectangleF(500, y + 20, ancho, 20));
            e.Graphics.DrawString(" ", font, Brushes.Gray, new RectangleF(0, y += 20, ancho, 20));


            //e.Graphics.DrawString("" + seleccion.Nombre + " " + "$" + String.Format("{0:0.00}", seleccion.Costo) + " " + String.Format("{0:0.00}", devolucion.Cantidad) + " " + "$" + String.Format("{0:0.00}", total), font, Brushes.Gray, new RectangleF(0, y += 20, ancho, 20));

            e.Graphics.DrawString("" + seleccion.Nombre, font, Brushes.Gray, new RectangleF(0, y + 20, ancho, 20));
            e.Graphics.DrawString(" " + "$" + String.Format("{0:0.00}", seleccion.Costo), font, Brushes.Gray, new RectangleF(300, y + 20, ancho, 20));
            e.Graphics.DrawString("" + String.Format("{0:0.00}", devolucion.Cantidad), font, Brushes.Gray, new RectangleF(400, y + 20, ancho, 20));
            e.Graphics.DrawString("$" + String.Format("{0:0.00}", total), font, Brushes.Gray, new RectangleF(500, y + 20, ancho, 20));

            e.Graphics.DrawString(" ", font, Brushes.Gray, new RectangleF(0, y += 20, ancho, 20));
            e.Graphics.DrawString("-------------------------------------------------------------------", font, Brushes.Gray, new RectangleF(0, y += 20, ancho, 20));
            e.Graphics.DrawString("Contacto:", font, Brushes.Gray, new RectangleF(0, y += 20, ancho, 20));
            e.Graphics.DrawString("" + DatosDeTienda.email, font, Brushes.Gray, new RectangleF(0, y += 20, ancho, 20));




        }
    }
}
