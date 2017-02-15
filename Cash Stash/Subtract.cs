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
    public partial class Subtract : Form
    {
        public Subtract()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            double subtraction;
            double total = 0;
            bool flag = false;
            Foo:
            try
            {
                subtraction = Convert.ToDouble(textBox1.Text);
            }

            catch
            {
                MessageBox.Show("Please enter a number.");
                goto Foo;
            }

            StreamReader file = new StreamReader("C:/Users/Evan/Documents/amount.txt");
            while (flag == false)
            {
                try
                {
                    total = Convert.ToDouble(file.ReadLine());
                    flag = true;
                }
                catch
                {
                    MessageBox.Show("Please enter a number.");
                }
            }
            total = total - subtraction;
            file.Close();
            using (var sw = new StreamWriter("C:/Users/Evan/Documents/amount.txt"))
            {
                sw.WriteLine(total.ToString());
                MessageBox.Show("Your withdraw has been made.");
            }
            using (var logwriter = File.AppendText("C:/Users/Evan/Documents/logs.txt"))
            {
                logwriter.WriteLine("Log Entry:" + now);
                logwriter.WriteLine("User user has withdrew " + subtraction.ToString() + ".");
                logwriter.WriteLine("The total is now " + total.ToString() + ".");
                logwriter.WriteLine("*********************************");
                logwriter.WriteLine();
                logwriter.WriteLine();
                logwriter.WriteLine();
            }
            Form2 form2 = new Form2();
            form2.label2.Text = label2.Text;
            this.Hide();
            form2.Show();
        }
    }
}
