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
    public partial class DatosTiendaVer : Form
    {
        public DatosTiendaVer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            mainmenuADM1 mainmenuADM1 = new mainmenuADM1();
            mainmenuADM1.Show();
        }
        private void DatosTiendaVer_Load(object sender, EventArgs e)
        {
            var objBD = new EnlaceDB();
            DataTable tablaDeDatos = new DataTable();
            tablaDeDatos = null;

            tablaDeDatos = objBD.ConsultaTablaDatosDeTienda();
            dataGridView1.DataSource = tablaDeDatos;

            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
