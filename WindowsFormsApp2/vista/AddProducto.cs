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

namespace WindowsFormsApp2.vista
{
    public partial class AddProducto : Form
    {
        public int? id;
        public int ide;
        datos listado = null;

        public AddProducto(int ide,int? id = null)
        {
            InitializeComponent();
            this.ide = ide;
            this.id = id;
            if (id != null)
                cargarDatosFormulario();
        }
        private void cargarDatosFormulario()
        {
            using (CrudEntities db = new CrudEntities())
            {
                listado = db.datos.Find(id);
                textBox1.Text = listado.producto;
                textBox2.Text = listado.valor.ToString();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (CrudEntities db = new CrudEntities())
            {

                if (id == null)
                {
                    listado = new datos();
                }
                listado.producto = textBox1.Text;
                listado.valor = int.Parse(textBox2.Text);
                listado.fk_usuarios = ide;
                if (id == null) {
                    db.datos.Add(listado);
                }
                else
                {
                    db.Entry(listado).State = System.Data.Entity.EntityState.Modified;
                }

                db.SaveChanges();
                this.Close(); 
                

            }
        }
    }
}
