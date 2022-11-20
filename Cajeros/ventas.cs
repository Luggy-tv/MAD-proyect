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
    public partial class ventas : Form
    {
        public ventas()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

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
    }
}
