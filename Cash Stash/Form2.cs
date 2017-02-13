using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Cash_Stash
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string labeltext;
            string user = textBox1.Text;
            Form1 form1 = new Form1();
            using (var file = new StreamReader("C:/Users/Evan/Documents/amount.txt"))
            {
                //StreamReader file = new StreamReader("C:/Users/Evan/Documents/amount.txt");
                labeltext = file.ReadLine();
                label1.Text = "Hello " + user + "! The current balance is $" + labeltext;
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Add add = new Add();
            this.Hide();
            add.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Subtract subtract = new Subtract();
            this.Hide();
            subtract.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Logs logs = new Logs();
            this.Hide();
            logs.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Hide();
            form1.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            User_Privileges users = new User_Privileges();
            this.Hide();
            users.Show();
        }
    }
}
