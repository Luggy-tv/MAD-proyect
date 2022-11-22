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
    public partial class pagar : Form
    {
        public pagar()
        {
            InitializeComponent();
        }
        private void pagar_Load(object sender, EventArgs e)
        {
            textBox5.Text = ventas.ptotalVenta.ToString();

            var objBD = new EnlaceDB();
            var listaDeOpcionesDePago = objBD.ConsultaOpcionDePago();

            comboBox1.DataSource = listaDeOpcionesDePago;
            comboBox1.ValueMember = "IDOpcionDePago";
            comboBox1.DisplayMember = "Nombre";

            comboBox2.DataSource = listaDeOpcionesDePago;
            comboBox2.ValueMember = "IDOpcionDePago";
            comboBox2.DisplayMember = "Nombre";

            comboBox3.DataSource = listaDeOpcionesDePago;
            comboBox3.ValueMember = "IDOpcionDePago";
            comboBox3.DisplayMember = "Nombre";

            comboBox4.DataSource = listaDeOpcionesDePago;
            comboBox4.ValueMember = "IDOpcionDePago";
            comboBox4.DisplayMember = "Nombre";
        }
       
        private void checkBox1_CheckStateChanged(object sender, EventArgs e) {
            comboBox2.Enabled = (checkBox1.CheckState == CheckState.Checked);
            textBox2.Enabled = (checkBox1.CheckState == CheckState.Checked);
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            comboBox3.Enabled = (checkBox2.CheckState == CheckState.Checked);
             textBox3.Enabled = (checkBox2.CheckState == CheckState.Checked);
        }
        private void checkBox_3CheckedChanged(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            decimal cant1 = 0;

            var objBD = new EnlaceDB();
            if(checkBox1.CheckState == CheckState.Checked)
            {

            }
        }
    }
}
