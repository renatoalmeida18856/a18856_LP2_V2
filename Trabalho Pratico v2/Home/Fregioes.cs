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
    public partial class Fregioes : Form
    {
        public Fregioes()
        {
            InitializeComponent();
        }

        Classes.Regioes r = new Classes.Regioes();
        Classes.Infetados inf = new Classes.Infetados();

        private void Fregioes_Load(object sender, EventArgs e)
        {
            DataTable db = r.Select();
            dataGridView2.DataSource = db;

            button1.Hide();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            r.Nome = textBox8.Text;
            r.Populacao = Int32.Parse(textBox5.Text);

            bool sucess = r.Insert(r);
            if (sucess)
            {
                MessageBox.Show("Regiao adicionada com sucesso.");
            }
            else
            {
                MessageBox.Show("Ocorreu um erro por favor tente novamente!");
            }

            DataTable db = r.Select();
            dataGridView2.DataSource = db;
        }
       

        private void button5_Click(object sender, EventArgs e)
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

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Finfecoes fp = new Finfecoes();
            fp.Show();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Fregioes_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void dataGridView2_RowHeaderMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            button2.Hide();
            button1.Show();


            // Obter os dados para poder editar e obter informaçao
            int rowIndex = e.RowIndex;

            textBox8.Text = dataGridView2.Rows[rowIndex].Cells[1].Value.ToString();
            textBox5.Text = dataGridView2.Rows[rowIndex].Cells[2].Value.ToString();
            textBox9.Text = dataGridView2.Rows[rowIndex].Cells[0].Value.ToString();

            int id = Int32.Parse(dataGridView2.Rows[rowIndex].Cells[0].Value.ToString());

            //ao click de cada regiao
            label3.Text = inf.GetInfected(id).ToString();
            label4.Text = inf.GetRecovers(id).ToString();
            label5.Text = inf.GetDeaths(id).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            r.Nome = textBox8.Text;
            r.Populacao = Int32.Parse(textBox5.Text);
            r.Id = Int32.Parse(textBox9.Text);


            bool sucess = r.Update(r);
            if (sucess)
            {
                MessageBox.Show("Regiao editada com sucesso.");
            }
            else
            {
                MessageBox.Show("Ocorreu um erro por favor tente novamente!");
            }

            DataTable db = r.Select();
            dataGridView2.DataSource = db;
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
