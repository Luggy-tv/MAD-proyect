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
            
            textBox5.Text = "$"+ventas.ptotalVenta.ToString();

            var objBD = new EnlaceDB();
            var listaDeOpcionesDePago1 = objBD.ConsultaOpcionDePago();
            var listaDeOpcionesDePago2 = objBD.ConsultaOpcionDePago();
            var listaDeOpcionesDePago3 = objBD.ConsultaOpcionDePago();
            var listaDeOpcionesDePago4 = objBD.ConsultaOpcionDePago();

            comboBox1.DataSource = listaDeOpcionesDePago1;
            comboBox1.ValueMember = "IDOpcionDePago";
            comboBox1.DisplayMember = "Nombre";

            comboBox2.DataSource = listaDeOpcionesDePago2;
            comboBox2.ValueMember = "IDOpcionDePago";
            comboBox2.DisplayMember = "Nombre";

            comboBox3.DataSource = listaDeOpcionesDePago3;
            comboBox3.ValueMember = "IDOpcionDePago";
            comboBox3.DisplayMember = "Nombre";

            comboBox4.DataSource = listaDeOpcionesDePago4;
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
            comboBox4.Enabled = (checkBox3.CheckState == CheckState.Checked);
             textBox4.Enabled = (checkBox3.CheckState == CheckState.Checked);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }//Regresar
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            // If you want, you can allow decimal (float) numbers
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }//Validacion de solo numeros en cantidad a pagar 
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            // If you want, you can allow decimal (float) numbers
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }//Validacion de solo numeros en cantidad a pagar
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            // If you want, you can allow decimal (float) numbers
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }//Validacion de solo numeros en cantidad a pagar
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            // If you want, you can allow decimal (float) numbers
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }//Validacion de solo numeros en cantidad a pagar
        private void button1_Click(object sender, EventArgs e)
        {
            ObjetoDB.ReciboDeVenta reciboDeVenta = new ObjetoDB.ReciboDeVenta();

            bool comp=false;

            decimal cant1 = 0;
            decimal cant2 = 0;
            decimal cant3 = 0;
            decimal cant4 = 0;

            var seleccion   = comboBox1.SelectedItem as ObjetoDB.OpcionDePago;
            var seleccion2  = comboBox2.SelectedItem as ObjetoDB.OpcionDePago;
            var seleccion3  = comboBox3.SelectedItem as ObjetoDB.OpcionDePago;
            var seleccion4  = comboBox4.SelectedItem as ObjetoDB.OpcionDePago;


            List<ObjetoDB.DetallePago> listaDPagos = new List<ObjetoDB.DetallePago>();

            if (textBox1.Text != "") {
                
                cant1 = decimal.Parse(textBox1.Text);
                listaDPagos.Add(new ObjetoDB.DetallePago
                {
                    FKOpPago = seleccion.IDOpcionDePago,
                    Cantidad = cant1

                }) ;
                
                if (checkBox1.CheckState == CheckState.Checked)
                {
                    if (textBox2.Text.Length != 0)
                    {
                        cant2 = decimal.Parse(textBox2.Text);
                        listaDPagos.Add(new ObjetoDB.DetallePago
                        {
                            FKOpPago = seleccion2.IDOpcionDePago,
                            Cantidad = cant2
                        });
                    }
                }
                if (checkBox2.CheckState == CheckState.Checked)
                {
                    if (textBox3.Text.Length != 0)
                    {
                        cant3 = decimal.Parse(textBox3.Text);
                        listaDPagos.Add(new ObjetoDB.DetallePago
                        {
                            FKOpPago = seleccion3.IDOpcionDePago,
                            Cantidad = cant3
                        });
                    }
                }
                if (checkBox3.CheckState == CheckState.Checked)
                {
                    if (textBox4.Text.Length != 0)
                    {
                        cant4 = decimal.Parse(textBox4.Text);
                        listaDPagos.Add(new ObjetoDB.DetallePago
                        {
                            FKOpPago = seleccion4.IDOpcionDePago,
                            Cantidad = cant4
                        });
                    }
                }

                decimal pagoTot = cant1 + cant2 + cant3 + cant4;

                if(pagoTot>= ventas.ptotalVenta)
                {
                    DialogResult dr = MessageBox.Show("¿Desea emitir recibo?",
                         "Emitir recibo", MessageBoxButtons.YesNo);
                    switch (dr)
                    {
                        case DialogResult.Yes:

                            var objBD = new EnlaceDB();
                            var ops = "i";
                            
                            reciboDeVenta = objBD.ConsultaReciboDeVenta(ops, reciboDeVenta.IDRecibo, ventas.ptotalVenta, ventas.subtotalVenta).First<ObjetoDB.ReciboDeVenta>();
                            
                            foreach(var items in listaDPagos)//Aqui es para pasar la lista de opciones de pago actuales a la base_De_Datos_Uno_Por_uno. la_lista_de_productos_es_listaDPagos
                            {
                                string op = "i";
                                comp = objBD.GestDetallePago(op,reciboDeVenta.IDRecibo,items.FKOpPago,items.Cantidad);
                            }
                            
                            foreach(var item in ventas.productosEnVentasLista) //Aqui es para pasar la lista de productos actuales a la base_De_Datos_Uno_Por_uno. la_lista_de_productos_es_productosEnVentasLista
                            {
                                string op = "i";
                                comp = objBD.GestDetalleProd(op, reciboDeVenta.IDRecibo, item.IDProducto, item.CantProd);
                            }

                            var opc = "i";
                            var idventa = 0;

                            
                            DateTime horaDeVenta = loginCaj.currentLogin.fecha;
                            TimeSpan ts = new TimeSpan(DateTime.Now.Hour,DateTime.Now.Minute,DateTime.Now.Second);
                            horaDeVenta = horaDeVenta.Date + ts;

                            comp = objBD.GestVenta(opc, idventa, loginCaj.currentLogin.IDCajero_Caja, reciboDeVenta.IDRecibo, horaDeVenta);

                            if (comp)
                            {
                                MessageBox.Show("Compra realizada cambio de :$ " + (pagoTot- ventas.ptotalVenta).ToString(), "Gracias por comprar", MessageBoxButtons.OK, MessageBoxIcon.Information);



                                this.Close();
                            }

                            break;
                        case DialogResult.No:

                            break;
                    }

                }
                else
                {
                    MessageBox.Show("Pago insuficiente", "Error de venta", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    
                }

            }
            else
            {
                MessageBox.Show("Favor de llenar los campos", "Accion Imposible", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
           
        }//pagar
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
