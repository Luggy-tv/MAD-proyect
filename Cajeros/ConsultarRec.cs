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
    public partial class ConsultarRec : Form
    {
        public ConsultarRec()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            mainmenuCAJ mainmenu = new mainmenuCAJ();
            mainmenu.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var comp = false;
            var objBD = new EnlaceDB();

            if(textBox1.Text!="")
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
