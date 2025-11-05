using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankAccountApp
{
    public partial class Form1 : Form
    {
        List<BankAccountApp> AllAccount = new List<BankAccountApp>();
        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
                return;

            BankAccountApp bankAccount = new BankAccountApp(textBox1.Text);

            AllAccount.Add(bankAccount);
            RefreshGrid();
            MessageBox.Show("Account Create Successfully");

        }

        public void RefreshGrid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = AllAccount;
            textBox1.Text = "";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select an Account");
                return;
            }
            BankAccountApp SelectAccount = dataGridView1.SelectedRows[0].DataBoundItem as BankAccountApp;
            SelectAccount.Balance += numericUpDown1.Value;
            RefreshGrid();
            numericUpDown1.Value = 0;   
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select an Account");
                return;
            }
            BankAccountApp SelectAccount = dataGridView1.SelectedRows[0].DataBoundItem as BankAccountApp;
            if (numericUpDown1.Value > SelectAccount.Balance)
            {
                MessageBox.Show("Insufficient balance!");
                return; 
            }
            SelectAccount.Balance -= numericUpDown1.Value;
            RefreshGrid();
            numericUpDown1.Value = 0;
        }
    }
}
