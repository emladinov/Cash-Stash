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


        private double inputcheck()
        {
            //checks to make sure the input is a number.
            double input = 0.0;

            try
            {
                input = Convert.ToDouble(textBox1.Text);
            }

            catch
            {
                MessageBox.Show("Please enter a number.");
                input = -1;
            }

            return (input);
        }

        private double getcurrenttotal(double total, double subtraction)
        {
            //Reads the current total from the file 'amount.txt' and puts the value in 'total'
            StreamReader file = new StreamReader("C:/Users/Evan/Documents/amount.txt");

            try
            {
                total = Convert.ToDouble(file.ReadLine());

            }
            catch
            {
                MessageBox.Show("Please enter a number.");
            }

            total = total - subtraction;
            file.Close();

            return total;
        }

        private void writetologs(double total, double subtraction)
        {
            DateTime now = DateTime.Now;
            //Records transaction in logs file.
            using (var logwriter = File.AppendText("C:/Users/Evan/Documents/logs.txt"))
            {
                logwriter.WriteLine("Log Entry:" + now);
                logwriter.WriteLine("User " + label2.Text + " has withdrew " + subtraction.ToString() + ".");
                logwriter.WriteLine("The total is now " + total.ToString() + ".");
                logwriter.WriteLine("*********************************");
                logwriter.WriteLine();
                logwriter.WriteLine();
                logwriter.WriteLine();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            double subtraction;
            double total = 0;


            subtraction = inputcheck();
            if (subtraction == -1)
            {
                return;
            }
            total = getcurrenttotal(total, subtraction);

            //Write new total to 'amount.txt'
            using (var sw = new StreamWriter("C:/Users/Evan/Documents/amount.txt"))
            {
                sw.WriteLine(total.ToString());
                MessageBox.Show("Your withdraw has been made.");
            }

            writetologs(total, subtraction);

            //Go back to main page.
            Form2 form2 = new Form2();
            form2.label2.Text = label2.Text;
            this.Hide();
            form2.Show();
        }
    }
}
