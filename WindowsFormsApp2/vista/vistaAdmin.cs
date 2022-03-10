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
    public partial class vistaAdmin : Form
    {
        public int ide;
        public vistaAdmin()
        {
            InitializeComponent();//sonnar
            this.ide = ide;
        }
        private void obtenerDatos()
        {
            using (CrudEntities db = new CrudEntities())
            {
                var listado = from a in db.usuarios
                              select new { a.id, a.nombre_usuario, a.nombre_completo, a.rol };
                dataGridView1.DataSource = listado.ToList();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void vistaAdmin_Load(object sender, EventArgs e)
        {
            obtenerDatos();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            inventarioXUser from =new inventarioXUser();
            from.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (CrudEntities db = new CrudEntities())
            {
                var listado = from a in db.usuarios
                              select new {a.id};
                Home home = new Home(ide);
                home.Show();
            }
            
        }
    }
}
