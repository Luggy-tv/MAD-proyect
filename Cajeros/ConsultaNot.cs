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

namespace MAD3_ventanas
{
    public partial class ConsultaNot : Form
    {
        public ObjetoDB.DatosDeTienda DatosDeTienda = new ObjetoDB.DatosDeTienda();
        public ObjetoDB.ReciboDeVenta reciboDeVenta = new ObjetoDB.ReciboDeVenta();
        public ObjetoDB.NotaCredito notaCredito = new ObjetoDB.NotaCredito();
        public ObjetoDB.Devolucion devolucion = new ObjetoDB.Devolucion();

        public ConsultaNot()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            mainmenuCAJ mainmenu = new mainmenuCAJ();
            mainmenu.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //IMPRESION EN PDF
            printDocument1 = new PrintDocument();
            PrinterSettings ps = new PrinterSettings();
            printDocument1.PrinterSettings = ps;
            printDocument1.PrintPage += Imprimir;
            printDocument1.Print();

            this.Close();
            mainmenuCAJ mainmenuCAJ = new mainmenuCAJ();
            mainmenuCAJ.Show();

        }

        private void ConsultaNot_Load(object sender, EventArgs e)
        {

        }

        private void Imprimir(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            var objBD = new EnlaceDB();
            DatosDeTienda = objBD.ConsultaDatosDeTienda().First<ObjetoDB.DatosDeTienda>();
            var seleccion = comboBox1.SelectedItem as ObjetoDB.Producto;

            //var total = seleccion.Costo * devolucion.Cantidad;



            DateTime localdate;
            localdate = DateTime.Now;

            Font font = new Font("Lucida Console", 10);
            int ancho = 600;
            int y = 20;


            e.Graphics.DrawString("            ---Recibo de Venta---           ", font, Brushes.Gray, new RectangleF(0, y += 20, ancho, 20));
            e.Graphics.DrawString("" + DatosDeTienda.NombreTienda, font, Brushes.Gray, new RectangleF(0, y += 20, ancho, 20));
            e.Graphics.DrawString("Sucursal " + DatosDeTienda.Sucursal, font, Brushes.Gray, new RectangleF(0, y += 20, ancho, 20));
            e.Graphics.DrawString("RFC " + DatosDeTienda.RFC, font, Brushes.Gray, new RectangleF(0, y += 20, ancho, 20));
            e.Graphics.DrawString("" + DatosDeTienda.Domicilio, font, Brushes.Gray, new RectangleF(0, y += 20, ancho, 20));
            e.Graphics.DrawString("C.P. " + DatosDeTienda.CodigoPostal, font, Brushes.Gray, new RectangleF(0, y += 20, ancho, 20));
            e.Graphics.DrawString("Teléfono " + DatosDeTienda.numTel, font, Brushes.Gray, new RectangleF(0, y += 20, ancho, 20));

        }
    }
}
