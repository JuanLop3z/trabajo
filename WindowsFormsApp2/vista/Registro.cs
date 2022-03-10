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
    public partial class Registro : Form
    {
        public Registro()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (CrudEntities db = new CrudEntities())
            {
                byte[] tmpSource;
                byte[] tmpHash;
                usuarios listado = new usuarios();
                listado.nombre_usuario = textBox1.Text;
                tmpSource = ASCIIEncoding.ASCII.GetBytes(textBox2.Text);
                tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);    
                listado.pass = Convert.ToBase64String(tmpHash);
                listado.nombre_completo = textBox3.Text;
                listado.rol = textBox4.Text;




                db.usuarios.Add(listado);
                db.SaveChanges();
                this.Close();
                vista.Login lg = new vista.Login();
            }
            }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Registro_Load(object sender, EventArgs e)
        {

        }
    }
}
