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
    public partial class Add : Form
    {
        public Add()
        {
            InitializeComponent();
        }

        private double inputcheck()
        {
            //Checks to make sure the input is a number.
            //If its not, the input variable is set to -1 which makes th button click function return
            //before setting the total amount in the amount.txt file.
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

        private double getcurrenttotal(double total, double addition)
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
            //Adds inputted number to the current total to make new total.
            total = addition + total;
            file.Close();

            return total;
        }

        private void writetologs(double total, double addition)
        {
            DateTime now = DateTime.Now;
            //Records data in logs file.
            using (var logwriter = File.AppendText("C:/Users/Evan/Documents/logs.txt"))
            {
                logwriter.WriteLine("Log Entry:" + now);
                logwriter.WriteLine("User " + label2.Text + " has deposited " + addition.ToString() + ".");
                logwriter.WriteLine("The total is now " + total.ToString() + ".");
                logwriter.WriteLine("*********************************");
                logwriter.WriteLine();
                logwriter.WriteLine();
                logwriter.WriteLine();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            double total = 0;
            double addition = 0;
            
            addition = inputcheck();
            //If inputcheck is false, return.
            if (addition == -1)
            {
                return;
            }
            total = getcurrenttotal(total, addition);
            
            //Rewrite total value over previous value.
            using (var sw = new StreamWriter("C:/Users/Evan/Documents/amount.txt"))
            {
                sw.WriteLine(total.ToString());
                MessageBox.Show("Your deposit has been made");
            }
            writetologs(total, addition);

            //Go back to main page.
            Form2 form2 = new Form2();
            form2.label2.Text = label2.Text;
            this.Hide();
            form2.Show();
            
        }
    }
}
