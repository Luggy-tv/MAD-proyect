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

    public partial class loginCaj : Form
    {
       public static ObjetoDB.Usuario   loggedUser;
       public static byte               loggedUCaja;
        public static DateTime          date;

        public static ObjetoDB.CurrentLogin currentLogin;
        public loginCaj()
        {
            InitializeComponent();
        }
        private void Regresar_Click(object sender, EventArgs e)
        {
            this.Hide();
            prelogin prelogin = new prelogin();
            prelogin.Show();
        }

        private void Ingresar_Click(object sender, EventArgs e)//INGRESAR
        {
            ObjetoDB.Caja seleccion = comboBox1.SelectedItem as ObjetoDB.Caja;

            var objBD = new EnlaceDB();
            var listUsuarios = new List<ObjetoDB.Usuario>();
            listUsuarios = null;
            listUsuarios = objBD.ConsultaUsuarios();
            string op = "i";
            string IDusuario = textBox1.Text;
            string contraseña = textBox2.Text;
            byte numCaja = seleccion.IDCaja;
            if (IDusuario == "" || contraseña == "")
            {
                MessageBox.Show("Llenar todos los campos");
            }
            else
            {
                bool userIsValid = false, passIsVal = false, login = false;

                userIsValid = userExists(IDusuario,listUsuarios);

                if (userIsValid)
                {
                    passIsVal = passIsValid(IDusuario, contraseña, listUsuarios);

                    if (userIsValid && passIsVal)
                    {
                        login = true;

                        if (login)
                        {

                            loggedUser = getUserFromString(IDusuario, listUsuarios);
                            loggedUCaja = numCaja;
                            date = dateTimePicker1.Value;

                            bool comp = objBD.GestLogin(op, loggedUser.IDUsuario, loggedUCaja, date);

                            this.Close();
                            mainmenuCAJ mainmenuCAJ = new mainmenuCAJ();
                            mainmenuCAJ.Show();

                        }
                    }
                    else
                    {
                        MessageBox.Show("La contraseña es incorrecta");
                    }
                }
                else {
                    MessageBox.Show("El usuario no existe");

                }
    
                 
            }

        }
        private void loginCaj_Load(object sender, EventArgs e)
        {
            var objBD = new EnlaceDB();
            var listUsuarios = new List<ObjetoDB.Usuario>();
            listUsuarios = null;
            listUsuarios = objBD.ConsultaUsuarios();

            var listCajas = new List<ObjetoDB.Caja>();
            listCajas = null;
            listCajas = objBD.ConsultaCajasl();

            comboBox1.DataSource = listCajas;
            comboBox1.ValueMember = "IDCaja";
            comboBox1.DisplayMember = "IDCaja";
        }
        private void textBox1_TextChanged(object sender, EventArgs e)//USUARIO
        {

        }
        private void textBox2_TextChanged(object sender, EventArgs e)//CONTRASEÑA
        {

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)//COMBOBOX
        {

        }
        public bool userExists(string nombreUsuario, List<ObjetoDB.Usuario> listaUsuarios)
        {
           
            bool exists = false;
            for (int i1 = 0; i1 < listaUsuarios.Count; i1++)
            {
                if (listaUsuarios[i1].IDUsuario == Convert.ToInt16(nombreUsuario))
                    exists = true;
            }
            return exists;
        }
        public bool passIsValid(string user,string pass, List<ObjetoDB.Usuario> listaUsuarios)
        {
            bool exists = false;
            for (int i1 = 0; i1 < listaUsuarios.Count; i1++)
            {
                if (listaUsuarios[i1].contraseña == pass && listaUsuarios[i1].IDUsuario== Convert.ToInt16(user))
                    exists = true;
            }
            return exists;
        }

        public ObjetoDB.Usuario getUserFromString(string user, List<ObjetoDB.Usuario> listaUsuarios)
        {
            var usuario = new ObjetoDB.Usuario();
            for (int i1 = 0; i1 < listaUsuarios.Count; i1++)
            {
                if (listaUsuarios[i1].IDUsuario == Convert.ToInt16(user))
                    usuario = listaUsuarios[i1];
            }
            return usuario;
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
