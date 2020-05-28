using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Home
{
    public partial class Dados : Form
    {
        public Dados()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        Classes.Infetados i = new Classes.Infetados();

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable db = i.GetByRegions();
            dataGridView1.DataSource = db;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
