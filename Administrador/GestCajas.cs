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
    public partial class GestCajas : Form
    {
        public GestCajas()
        {
            InitializeComponent();
        }
        private void GestCajas_Load(object sender, EventArgs e)
        {
            var objBD = new EnlaceDB();
            List<ObjetoDB.Caja> listCajas = new List<ObjetoDB.Caja>();
            listCajas = null;
            listCajas = objBD.ConsultaCajas();
            if (listCajas.Count() == 0)
            {
                MessageBox.Show("No se encuentan cajas en la base de datos", "Datos pendientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                mainmenuADM1 mainmenuADM1 = new mainmenuADM1();
                mainmenuADM1.Show();
            }
            else
            {
                comboBox1.DataSource = listCajas;
                comboBox1.ValueMember = "IDCaja";
                comboBox1.DisplayMember = "IDCaja";
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            mainmenuADM1 mainmenuADM1 = new mainmenuADM1();
            mainmenuADM1.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            ObjetoDB.Caja seleccion = comboBox1.SelectedItem as ObjetoDB.Caja;

            bool comp = false;
            string op = "e";
            byte IDCaja = seleccion.IDCaja;
            bool disponible = checkBox1.Checked;


            DialogResult dr = MessageBox.Show("¿Desea actualizar esta caja?",
                     "Editar Caja", MessageBoxButtons.YesNo);
            switch (dr)
            {
                case DialogResult.Yes:

                    var objBD = new EnlaceDB();
                    comp = objBD.GestCajas(op, IDCaja, disponible);

                    this.Close();
                    mainmenuADM1 mainmenuADM1 = new mainmenuADM1();
                    mainmenuADM1.Show();

                    break;
                case DialogResult.No:

                    break;
            }

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ObjetoDB.Caja seleccion = comboBox1.SelectedItem as ObjetoDB.Caja;
            checkBox1.Checked = seleccion.Disponible;
        }
    }
}
