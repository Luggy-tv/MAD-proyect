﻿using System;
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
    public partial class ConsultaNot : Form
    {
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
        }

        private void ConsultaNot_Load(object sender, EventArgs e)
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
    }
}
