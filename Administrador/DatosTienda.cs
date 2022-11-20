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
    public partial class DatosTienda : Form
    {
        public DatosTienda()
        {
            InitializeComponent();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void DatosTienda_Load(object sender, EventArgs e)
        {
            var objBD = new EnlaceDB();
            DataTable tablaDeDatos = new DataTable();
            List<ObjetoDB.DatosDeTienda> listaDeDatos = new List<ObjetoDB.DatosDeTienda>();
            tablaDeDatos = null;

            tablaDeDatos = objBD.ConsultaTablaDatosDeTienda();
            dataGridView1.DataSource = tablaDeDatos;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            this.Close();
            mainmenuADM1 mainmenuADM1 = new mainmenuADM1();
            mainmenuADM1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string op = "e";
            string nomtien = textBox1.Text;
            string rfc = textBox2.Text;
            string dom = textBox3.Text;
            string cp = textBox4.Text;
            string email = textBox5.Text;
            string numtel = textBox9.Text;
            var objBD = new EnlaceDB();

            bool completo;
            if (nomtien == "" || textBox8.Text == "" || rfc == null || dom == "" || cp == "" || email == "" || email == "" || numtel == "")
            {
                MessageBox.Show("Favor de rellenar todos los campos", "Datos pendientes", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else {
                byte suc = byte.Parse(textBox8.Text);

                DialogResult dr = MessageBox.Show("¿Desea agregar estos datos?", "Agregar cajeros", MessageBoxButtons.YesNo);
                switch (dr)
                {
                    case DialogResult.Yes:
                        completo = objBD.GestTienda(op, nomtien, suc, rfc, dom, cp, email, numtel);
                        //falta guardar info
                        this.Close();
                        mainmenuADM1 mainmenuADM1 = new mainmenuADM1();
                        mainmenuADM1.Show();
                        break;
                    case DialogResult.No:

                        break;
                }
            }
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
