using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MAD3_ventanas.Administrador;

namespace MAD3_ventanas
{
    public partial class login : Form
    {
        
        public login()
        {
            InitializeComponent();
        }

        private void Regresar_Click(object sender, EventArgs e)
        {
            this.Hide();
            prelogin prelogin = new prelogin();
            prelogin.Show();
        }

        //private void Ingresar_Click(object sender, EventArgs e)
        //{
        //    this.Hide();
        //    mainmenuADM1 mainmenuADM = new mainmenuADM1();
        //    mainmenuADM.Show();
        //}

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var objBD = new EnlaceDB();
            var listUsuarios = new List<ObjetoDB.Usuario>();
            listUsuarios = null;
            listUsuarios = objBD.ConsultaUsuarios();

            string IDusuario = textBox1.Text;
            string contraseña = textBox2.Text;
            bool esAdmin;

            if (IDusuario == "" || contraseña == "")
            {
                MessageBox.Show("Llenar todos los campos");
            }

            else
            {
                bool userIsValid = false, passIsVal = false, admIsVal = false, login = false;

                userIsValid = userExists(IDusuario, listUsuarios);

                if (userIsValid)
                {
                    admIsVal = admIsValid(IDusuario, listUsuarios);
                }

                if (userIsValid && admIsVal)
                {
                    passIsVal = passIsValid(IDusuario, contraseña, listUsuarios);
                    //login = true;
                     if (userIsValid && passIsVal && admIsVal)
                     {
                             login = true;
                     }

                     else
                     {
                              MessageBox.Show("La contraseña es incorrecta");
                     }
                }
                else
                {
                    MessageBox.Show("Este usuario no es administrador");
                }



               





                if (login)
                {
                    //loggedUser = getUserFromString(IDusuario, listUsuarios);

                    this.Close();
                    mainmenuADM1 mainmenuADM1 = new mainmenuADM1();
                    mainmenuADM1.Show();

                }
            }

            //string IDusuario = textBox1.Text;
            //string contraseña = textBox2.Text;

            //if (IDusuario == "" || contraseña == "")
            //{
            //    MessageBox.Show("Llenar todos los campos");

            //}

            //else
            //{
            //    this.Close();
            //    mainmenuADM1 mainmenuADM1 = new mainmenuADM1();
            //    mainmenuADM1.Show();

            //}

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
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
        public bool passIsValid(string user, string pass, List<ObjetoDB.Usuario> listaUsuarios)
        {
            bool exists = false;
            for (int i1 = 0; i1 < listaUsuarios.Count; i1++)
            {
                if (listaUsuarios[i1].contraseña == pass && listaUsuarios[i1].IDUsuario == Convert.ToInt16(user))
                    exists = true;
            }
            return exists;
        }

        public bool admIsValid(string user, List<ObjetoDB.Usuario> listaUsuarios)
        {
            bool exists = false;
            for (int i1 = 0; i1 < listaUsuarios.Count; i1++)
            {
                if (listaUsuarios[i1].esAdmin && listaUsuarios[i1].IDUsuario == Convert.ToInt16(user))
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
