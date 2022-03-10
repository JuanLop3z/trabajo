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

namespace WindowsFormsApp2
{
    public partial class Home : Form
    {
        public int ide;
        public Home(int ide)
        {
            InitializeComponent();
            this.ide = ide;
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            obtenerDatos();
        }
        private void obtenerDatos()
        {
            using (CrudEntities db = new CrudEntities())
            {
                var listado = from b in db.datos
                              select new {b.id,b.producto,b.valor,b.fk_usuarios };
                dataGridView1.DataSource = listado.ToList();
                foreach (int valorTotal in listado.Select(d => d.valor))
                { 
                    textBox1.Text += valorTotal.ToString();
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int? id = null;
            vista.AddProducto formCrea = new vista.AddProducto(ide,id);
            formCrea.ShowDialog();
            obtenerDatos();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int? id = int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());
            if (id != null)
            {
                vista.AddProducto edit = new vista.AddProducto(ide,id);
                edit.ShowDialog();
                obtenerDatos();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int? id = int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());
            if (id != null)
            {
                using (CrudEntities db = new CrudEntities())
                {
                    datos listado = db.datos.Find(id);
                    db.datos.Remove(listado);
                    db.SaveChanges();
                }
                obtenerDatos();
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
