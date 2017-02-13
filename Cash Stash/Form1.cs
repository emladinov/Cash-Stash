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
using System.Xml;

namespace Cash_Stash
{

    public partial class Form1 : Form
    {
        //List<String> usernames = new List<String>();
        //List<String> passwords = new List<String>();
        bool flag = false;
        string line;
        string[] credentialsline = new string[3];
        public Form1()
        {
            
            
            InitializeComponent();
        }

        public string getuser(string username)
        {
            string user = username;
            return user;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //login
            /*   string username = textBox1.Text;
               string password = textBox2.Text;
               XmlWriter writer = XmlWriter.Create("C:/Users/Evan/Documents/Users.xml");
               writer.WriteStartElement("Users");
               writer.WriteStartElement("User");
               //writer.WriteStartElement("UserName");
               writer.WriteAttributeString("Username","testusername");
               writer.WriteAttributeString("Password", "testpassword");
               //writer.WriteStartElement("UserPassword");
               //writer.WriteElementString("UserName", "testusername");
               //writer.WriteElementString("UserPassword", "testpassword");
               //writer.WriteEndElement();
               writer.WriteEndDocument();
               writer.Close();
               */
            login();
        }

        public void button2_Click(object sender, EventArgs e)
        {
            //create account
            string[] credentials = new string[3];
            credentials[0] = textBox1.Text;
            credentials[1] = textBox2.Text;
            using (var reader = new StreamReader("C:/Users/Evan/Documents/credentials.txt"))
            {
                if (reader.ReadLine() == null)
                    credentials[2] = 1.ToString();
                else
                    credentials[2] = 0.ToString();
            }

            using (var file = new StreamReader("C:/Users/Evan/Documents/credentials.txt")) {
                while ((line = file.ReadLine()) != null)
                {
                    credentialsline = line.Split(';');
                    //MessageBox.Show(credentialsline[2]);
                    if (textBox1.Text == credentialsline[0])
                    {
                        MessageBox.Show("This usernmae is already in use. Choose another.");
                        return;
                    }


                }
            }
            StreamWriter sw = File.AppendText("C:/Users/Evan/Documents/credentials.txt");
            
            sw.Write(credentials[0]);
            sw.Write(";");
            sw.Write(credentials[1]);
            sw.Write(";");
            sw.Write(credentials[2]);
            sw.WriteLine(";");
            
            sw.Close();
            //MessageBox.Show("2");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(1);
        }

        public void login()
        {
            StreamReader file = new StreamReader("C:/Users/Evan/Documents/credentials.txt");
            while ((line = file.ReadLine()) != null)
            {
                credentialsline = line.Split(';');
                //MessageBox.Show(credentialsline[2]);
                if (textBox1.Text == credentialsline[0])
                    if (textBox2.Text == credentialsline[1])
                        flag = true;
                goto Foo;

            }
            //MessageBox.Show("1");
            Foo:
            file.Close();
            if (flag)
            {
                flag = false;
                //MessageBox.Show("good");

                Form2 form2 = new Form2();
                this.Hide();
                form2.textBox1.Text = credentialsline[0];
                form2.Show();
                
                return;
            }
            else
                MessageBox.Show("Invalid credentials. Try again.");

            return;
            

            
        }
    }
}
