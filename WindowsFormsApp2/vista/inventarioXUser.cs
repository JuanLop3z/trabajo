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
    public partial class inventarioXUser : Form
    {
        public inventarioXUser()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (CrudEntities db = new CrudEntities())
            {
                String consulta = consultaUsu.Text;
                int numeroConsulta = int.Parse(consulta);


                var dato = db.datos.Where(D => D.fk_usuarios == numeroConsulta).Select(D => new {D.producto,D.valor,D.fk_usuarios });
                    dataGridView1.DataSource = dato.ToList();
            }
        }

        private void inventarioXUser_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
