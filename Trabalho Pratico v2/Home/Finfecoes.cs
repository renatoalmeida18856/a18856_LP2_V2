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
    public partial class Finfecoes : Form
    {
        public Finfecoes()
        {
            InitializeComponent();
        }

        Classes.Infecoes i = new Classes.Infecoes();
        Classes.Infetados inf = new Classes.Infetados();


        private void button2_Click(object sender, EventArgs e)
        {
            i.Nome = textBox8.Text;
            i.Sintomas = textBox5.Text;

            bool sucess = i.Insert(i);
            if (sucess)
            {
                MessageBox.Show("Infeção adicionada com sucesso.");
            }
            else
            {
                MessageBox.Show("Ocorreu um erro por favor tente novamente!");
            }

            DataTable db = i.Select();
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

        private void Finfecoes_Load(object sender, EventArgs e)
        {
            DataTable db = i.Select();
            dataGridView2.DataSource = db;
            button1.Hide();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
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
            label3.Text = inf.GetInfectedInfections(id).ToString();
            label4.Text = inf.GetRecoversInfections(id).ToString();
            label5.Text = inf.GetDeathsInfections(id).ToString();
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            i.Nome = textBox8.Text;
            i.Sintomas = textBox5.Text;
            i.Id = Int32.Parse(textBox9.Text);


            bool sucess = i.Update(i);
            if (sucess)
            {
                MessageBox.Show("Regiao editada com sucesso.");
            }
            else
            {
                MessageBox.Show("Ocorreu um erro por favor tente novamente!");
            }

            DataTable db = i.Select();
            dataGridView2.DataSource = db;
        }
    }
}
