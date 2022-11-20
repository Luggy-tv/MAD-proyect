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
    public partial class mainmenuADM1 : Form
    {
        public mainmenuADM1()
        {
            InitializeComponent();
        }

        private void mainmenuADM1_Load(object sender, EventArgs e)
        {

        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            GestCajerosAgreg GestCajerosAgreg = new GestCajerosAgreg();
            GestCajerosAgreg.ShowDialog();
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            GestCajerosEditar GestCajerosEditar = new GestCajerosEditar();
            GestCajerosEditar.Show();
        }

        private void agregarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            GestProdAgregar GestProdAgregar = new GestProdAgregar();
            GestProdAgregar.Show();
        }

        private void editarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            GestProdEditar gestProdEditar = new GestProdEditar();
            gestProdEditar.Show();
        }

        private void agregarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Hide();
            GestDptosAgregar GestDptosAgregar = new GestDptosAgregar();
            GestDptosAgregar.Show();
        }

        private void editarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Hide();
            GestDptosEditar gestDptosEditar = new GestDptosEditar();
            gestDptosEditar.Show();
        }

        private void agregarToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            this.Hide();
            DescuentosAgreg DescuentosAgreg = new DescuentosAgreg();
            DescuentosAgreg.Show();
        }

        private void editarToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            this.Hide();
            DescuentosEditar descuentosEditar = new DescuentosEditar();
            descuentosEditar.Show();

        }

        private void cajasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            GestCajas gestCajas = new GestCajas();
            gestCajas.Show();
        }

        private void Salir_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void actualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            DatosTienda datosTienda = new DatosTienda();
            datosTienda.Show();

        }

        private void verToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            DatosTiendaVer datosTiendaVer = new DatosTiendaVer();
            datosTiendaVer.Show();
        }

        private void devolucionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Devoluciones devoluciones = new Devoluciones();
            devoluciones.Show();

        }

        private void porCajeroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            ReporteCajero reporteCajero = new ReporteCajero();
            reporteCajero.Show();

        }

        private void porVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            ReporteVentas reporteVentas = new ReporteVentas();
            reporteVentas.Show();
        }

        private void inventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            InventarioADM inventario = new InventarioADM();
            inventario.Show();

        }

        private void recibosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            ConsultaRecADM consultaRecADM = new ConsultaRecADM();
            consultaRecADM.Show();
        }

        private void notasDeCréditoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            ConsultaNotADM consultaNotADM = new ConsultaNotADM();
            consultaNotADM.Show();

        }
    }
}
