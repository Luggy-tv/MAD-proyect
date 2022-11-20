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
    public partial class mainmenuCAJ : Form
    {
        public mainmenuCAJ()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            ventas ventas = new ventas();
            ventas.Show();
        }

        private void recibosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            ConsultarRec ConsultarRec = new ConsultarRec();
            ConsultarRec.Show();
        }

        private void notasDeCréditoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            ConsultaNot ConsultaNot = new ConsultaNot();
            ConsultaNot.Show();
        }

        private void inventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Inventario Inventario = new Inventario();
            Inventario.Show();

        }

        private void mainmenuCAJ_Load(object sender, EventArgs e)
        {

        }
    }
}
