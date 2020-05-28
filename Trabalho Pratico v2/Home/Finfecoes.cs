﻿using System;
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

        private void button2_Click(object sender, EventArgs e)
        {
            i.Nome = textBox8.Text;
            i.Sintomas = textBox5.Text;

            bool sucess = i.Insert(i);
            if (sucess)
            {
                MessageBox.Show("Regiao adicionada com sucesso.");
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
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
