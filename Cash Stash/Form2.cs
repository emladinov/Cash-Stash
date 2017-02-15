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
        public static class Globals
        {
            public static int globalcounter = 0;
            public const string globaluser = "";
        }

       
        public string MyProperty { get; set; }
        public Form2()
        {
            InitializeComponent();
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
           
                //Brings name of user into this form.
                string labeltext;
                //string user = label2.Text;
                string usertext = label2.Text;
                Form1 form1 = new Form1();

                //MessageBox.Show("test");
                /*
                using (var file = new StreamReader("C:/Users/Evan/Documents/credentials.txt"))
                {
                    string[] credentialsline = new string[3];
                    string line;

                    while ((line = file.ReadLine()) != null)
                    {
                        credentialsline = line.Split(';');


                        if (user == credentialsline[0])
                        {
                            usertext = credentialsline[0];
                        }


                    }
                }
                */

                using (var file = new StreamReader("C:/Users/Evan/Documents/amount.txt"))
                {
                    //StreamReader file = new StreamReader("C:/Users/Evan/Documents/amount.txt");
                    labeltext = file.ReadLine();


                }
                label1.Text = "Hello " + label2.Text + ". The current balance is $" + labeltext;
                //label1.Text = "The current balance is $" + labeltext;
                
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Deposit
            if (credentialscheck(label2.Text))
            {
                Add add = new Add();
                this.Hide();
                add.Show();
                add.label2.Text = label2.Text;
            }
            else
                MessageBox.Show("You do not have access.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Withdraw
            if (credentialscheck(label2.Text))
            {
                Subtract subtract = new Subtract();
                this.Hide();
                subtract.Show();
                subtract.label2.Text = label2.Text;
            }
            else
                MessageBox.Show("You do not have access.");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Check Logs
            if (credentialscheck(label2.Text))
            {
                Logs logs = new Logs();
                this.Hide();
                logs.Show();
                logs.label2.Text = label2.Text;
            }
            else
                MessageBox.Show("You do not have access.");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Logout
            Form1 form1 = new Form1();
            this.Hide();
            form1.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Change User Privileges
            if (credentialscheck(label2.Text))
            {
                User_Privileges users = new User_Privileges();
                this.Hide();
                users.Show();
                users.label2.Text = label2.Text;
            }
            else
                MessageBox.Show("You do not have access.");
        }

        private bool credentialscheck(string username)
        {
            using (var file = new StreamReader("C:/Users/Evan/Documents/credentials.txt"))
            {
                string[] credentialsline = new string[4];
                string line;
                
                while ((line = file.ReadLine()) != null)
                {
                    credentialsline = line.Split(';');

                    
                    if (username == credentialsline[0])
                    {
                        if (credentialsline[2] == 1.ToString())
                            return true;
                        else
                            return false;
                    }


                }

            }
            return false;
        }
    }
}
