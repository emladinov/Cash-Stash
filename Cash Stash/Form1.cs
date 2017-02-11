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

        public void credentials()
        {

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
            if (flag)
                MessageBox.Show("good");
            flag = false;
            file.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //create account
            string[] credentials = new string[3];
            credentials[0] = textBox1.Text;
            credentials[1] = textBox2.Text;
            StreamWriter sw = File.AppendText("C:/Users/Evan/Documents/credentials.txt");
            sw.Write(credentials[0]);
            sw.Write(";");
            sw.Write(credentials[1]);
            sw.WriteLine(";");
            sw.Close();
            MessageBox.Show("2");
        }
    }
}
