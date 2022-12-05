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
    public partial class ConsultaRecADM : Form
    {
        public ConsultaRecADM()
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var comp = false;
            var objBD = new EnlaceDB();

            if (textBox1.Text != "")
            {
                if (Int32.Parse(textBox1.Text) >= 9999999 || Int32.Parse(textBox1.Text) < 0)
                {
                    string op = "c";
                    int IDrecibo = Int32.Parse(textBox1.Text);
                    dataGridView1.DataSource = objBD.ConsultaRecibo(op, IDrecibo);
                }
            }

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
