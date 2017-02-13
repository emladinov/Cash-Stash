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
    public partial class User_Privileges : Form
    {
        public User_Privileges()
        {
            InitializeComponent();
            string[] credentialsline = new string[3];
            string line;
            StreamReader file = new StreamReader("C:/Users/Evan/Documents/credentials.txt");
            while ((line = file.ReadLine()) != null)
            {
                credentialsline = line.Split(';');
                //put text in list view
                textBox1.AppendText(credentialsline[0] + "\n");


            }
            file.Close();

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //User_Privileges privileges = new User_Privileges();
            string user;
            string line;
            string correctline = "";
            bool flag = false;
            string[] credentialsline = new string[3];
            user = textBox2.Text;

            using (StreamReader file = new StreamReader("C:/Users/Evan/Documents/credentials.txt"))
            {
                
                
                while ((line = file.ReadLine()) != null)
                {
                    credentialsline = line.Split(';');
                    
                    //put text in list view
                    if(textBox2.Text == credentialsline[0])
                    {
                        correctline = line;
                        flag = true;
                    }


                }

            }
            
            if (flag)
            {
                if(correctline == "")
                {
                    MessageBox.Show("Invalid Input. Try Again.");
                    return;
                }
                promoteaccess(correctline);
                flag = false;
            }
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string user;
            string line;
            string correctline = "";
            bool flag = false;
            string[] credentialsline = new string[3];
            user = textBox2.Text;

            using (StreamReader file = new StreamReader("C:/Users/Evan/Documents/credentials.txt"))
            {


                while ((line = file.ReadLine()) != null)
                {
                    credentialsline = line.Split(';');

                    //put text in list view
                    if (textBox2.Text == credentialsline[0])
                    {
                        correctline = line;
                        flag = true;
                    }


                }

            }

            if (flag)
            {
                if (correctline == "")
                {
                    MessageBox.Show("Invalid Input. Try Again.");
                    return;
                }
                limitaccess(correctline);
                flag = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            this.Hide();
            form2.Show();
        }

        private void promoteaccess(string line)
        {
            string[] file = File.ReadAllLines("C:/Users/Evan/Documents/credentials.txt");
            string[] credentialsline = new string[4];
            credentialsline = line.Split(';');
            credentialsline[2] = 1.ToString();
            for (int i = 0; file.Length > i; i++)
            {
                if (file[i] == line)
                {
                    //file[i].Replace(file[i], credentialsline[0] + ";" + credentialsline[1] + ";" + credentialsline[2] + ";");
                    file[Array.IndexOf(file, line)] = credentialsline[0] + ";" + credentialsline[1] + ";" + credentialsline[2] + ";";
                    File.WriteAllLines("C:/Users/Evan/Documents/credentials.txt", file);
                }
            }
                MessageBox.Show("The user has been promoted.");
            
        }

        private void limitaccess(string line)
        {
            string[] file = File.ReadAllLines("C:/Users/Evan/Documents/credentials.txt");
            string[] credentialsline = new string[4];
            credentialsline = line.Split(';');
            credentialsline[2] = 0.ToString();
            for (int i = 0; file.Length > i; i++)
            {
                if (file[i] == line)
                {
                    //file[i].Replace(file[i], credentialsline[0] + ";" + credentialsline[1] + ";" + credentialsline[2] + ";");
                    file[Array.IndexOf(file, line)] = credentialsline[0] + ";" + credentialsline[1] + ";" + credentialsline[2] + ";";
                    File.WriteAllLines("C:/Users/Evan/Documents/credentials.txt", file);
                }
            }
            MessageBox.Show("The user has been limited.");
        }
    }
}
