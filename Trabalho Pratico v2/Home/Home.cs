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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Fpacientes fp = new Fpacientes();
            fp.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Fregioes fp = new Fregioes();
            fp.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Finfecoes fp = new Finfecoes();
            fp.Show();
        }
    }
}
