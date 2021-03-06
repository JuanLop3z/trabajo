using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2.Modelo;
using System.Security.Cryptography;
using System.Text;

namespace WindowsFormsApp2.vista
{
    public partial class Login : Form
    {
        
        public Login()
        {
            InitializeComponent();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void loguear(String usuario, String password)
        {
            try
            {
                using (CrudEntities db = new CrudEntities())
                { 
                    byte[] tmpSource = ASCIIEncoding.ASCII.GetBytes(password);
                    byte[] tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);
                    String contrasena = Convert.ToBase64String(tmpHash);
                    var lista = db.usuarios.Where(C => C.nombre_usuario == usuario && C.pass == contrasena).Select(D => new {D.id, D.nombre_completo, D.rol });

                    if (lista.Count() == 1)
                    { 
                        foreach (var Datos in lista.ToList())
                        {
                            if (Datos.rol == "admin")
                            {
                                MessageBox.Show("Bienvenido " + Datos.nombre_completo);

                                vistaAdmin form1 = new vistaAdmin();
                                form1.Show();

                                this.Hide();
                            }
                            else if (Datos.rol == "user")
                            {
                                MessageBox.Show("Bienvenido " + Datos.nombre_completo);

                                Home form = new Home(Datos.id);
                                form.Show();

                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("No se le ah asignado rol al usuario");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Usuario o contraseña incorrectos");
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error = " + ex);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            String usuario = usuarioIngreso.Text;
            String password = usuarioContraseña.Text;
            loguear(usuario,password);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            vista.Registro registro = new vista.Registro();
            registro.Show();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            //cambiar colores al pasar sobre ellos
            aceptarBtn.BackColor = SystemColors.ScrollBar;
        }

        private void aceptarBtn_MouseLeave(object sender, EventArgs e)
        {
            //cambiar colores al salir del boton
            aceptarBtn.BackColor=SystemColors.Window;
        }

        private void button1_MouseEnter_1(object sender, EventArgs e)
        {
            //cambiar colores al pasar sobre ellos
            salirBtn.BackColor = SystemColors.ScrollBar;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            //cambiar colores al salir del boton
            salirBtn.BackColor = SystemColors.Window;
        }

        private void salirBtn_Click(object sender, EventArgs e)
        {
            //al presionar el boton finalizar programa
            this.Dispose();
        }

        private void usuarioIngreso_Click(object sender, EventArgs e)
        {
            //metodo para vaciar los contenedores de ingreso de datos

            if (usuarioIngreso.Text.Equals("Ingrese su nombre de usuario"))
            {

                usuarioIngreso.ResetText();
                usuarioIngreso.ForeColor = SystemColors.InfoText;

            }

            if (usuarioContraseña.Text.Equals(""))
            {

                usuarioContraseña.AppendText("************");
                usuarioContraseña.ForeColor = SystemColors.ScrollBar;

            }    
            }

        private void usuarioContraseña_TextChanged(object sender, EventArgs e)
        {

        }

        private void usuarioContraseña_Click(object sender, EventArgs e)
        {
            //metodo para vaciar los contenedores de ingreso de datos

            if (usuarioContraseña.Text.Equals("************"))
            {

                usuarioContraseña.ResetText();
                usuarioContraseña.ForeColor = SystemColors.InfoText;

            }

            if (usuarioIngreso.Text.Equals(""))
            {

                usuarioIngreso.AppendText("Ingrese su nombre de usuario");
                usuarioIngreso.ForeColor = SystemColors.ScrollBar;

            }
        }
    }
    }
