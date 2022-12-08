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
    public partial class ConsultaNotADM : Form
    {
        public ObjetoDB.DatosDeTienda DatosDeTienda = new ObjetoDB.DatosDeTienda();
        public ObjetoDB.ReciboDeVenta reciboDeVenta = new ObjetoDB.ReciboDeVenta();
        public ObjetoDB.NotaCredito notaCredito = new ObjetoDB.NotaCredito();
        public ObjetoDB.Devolucion devolucion = new ObjetoDB.Devolucion();

        public ConsultaNotADM()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            mainmenuADM1 mainmenuADM1 = new mainmenuADM1();
            mainmenuADM1.Show();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            //IMPRESION EN PDF
            //IMPRESION EN PDF           
            printDocument1 = new PrintDocument();
            PrinterSettings ps = new PrinterSettings();
            printDocument1.PrinterSettings = ps;
            printDocument1.PrintPage += Imprimir;
            printDocument1.Print();

            this.Close();
            mainmenuADM1 mainmenuADM1 = new mainmenuADM1();
            mainmenuADM1.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
           

        private void ConsultaNotADM_Load(object sender, EventArgs e)
        {
            var objBD = new EnlaceDB();
            var listCajas = new List<ObjetoDB.Caja>();
            listCajas = null;
            listCajas = objBD.ConsultaCajasl();

            comboBox1.DataSource = listCajas;
            comboBox1.ValueMember = "IDCaja";
            comboBox1.DisplayMember = "IDCaja";

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
       
            var objBD = new EnlaceDB();

            if (textBox1.Text.Length != 0)
            {
                if (int.Parse(textBox1.Text) >= 2000000 || int.Parse(textBox1.Text) < 0)
                {
                    MessageBox.Show("Numero de nota ingresado no valido", "Error en nota", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                
                }
                else
                {
                    string op = "n";
                    int IDrecibo = int.Parse(textBox1.Text);
                    dataGridView1.DataSource = objBD.ConsultaNotaPorNumero(op, IDrecibo);
                    textBox1.Clear();
                }
            }
            else
            {
                MessageBox.Show("Favor de llenar el campo", "Datos faltantes", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
       
        }
        private void button2_Click(object sender, EventArgs e)
        {
            ObjetoDB.Caja seleccion = comboBox1.SelectedItem as ObjetoDB.Caja;
            var objBD = new EnlaceDB();

            string op = "D";
            DateTime date = dateTimePicker1.Value;
            byte dummyCaja = 1;
            dataGridView1.DataSource = objBD.ConsultaNotaPorFecha(op, dummyCaja, date);
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
