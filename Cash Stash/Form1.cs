﻿using System;
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
        bool flag = false;
        string line;
        string[] credentialsline = new string[4];
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public void login()
        {
            StreamReader file = new StreamReader("C:/Users/Evan/Documents/credentials.txt");
            //This while loop searches through each line of the text document for the correct username.
            //It then checks to see if the password matches.
            while ((line = file.ReadLine()) != null)
            {
                credentialsline = line.Split(';');
                if (textBox1.Text == credentialsline[0])
                    if (textBox2.Text == credentialsline[1])
                    {
                        //If username and password match.
                        flag = true;
                        goto Foo;
                    }

            }
            Foo:
            file.Close();
            //If match was found.
            if (flag)
            {
                flag = false;

                Form2 form2 = new Form2();
                form2.label2.Text = credentialsline[0];
                this.Hide();
                form2.Show();

                return;
            }
            else
                MessageBox.Show("Invalid credentials. Try again.");

            return;



        }

        public bool existinguser(string[] credentials)
        {
            //Checks to see if username is already being used.
            //If so, the account can not be created.
            using (var file = new StreamReader("C:/Users/Evan/Documents/credentials.txt"))
            {
                //Check each line and see if any of the usernames match up with user input.
                while ((line = file.ReadLine()) != null)
                {
                    credentialsline = line.Split(';');
                    if (textBox1.Text == credentialsline[0])
                    {
                        MessageBox.Show("This username is already in use. Choose another.");
                        return false;
                    }


                }
            }
            return true;
        }

        public void createuser(string[] credentials)
        {
            //Creates new user in next empty line of text file.
            StreamWriter sw = File.AppendText("C:/Users/Evan/Documents/credentials.txt");

            sw.Write(credentials[0]);
            sw.Write(";");
            sw.Write(credentials[1]);
            sw.Write(";");
            sw.Write(credentials[2]);
            sw.WriteLine(";");

            sw.Close();
            MessageBox.Show("Account has been created");
        }

        public string nousers(string[] credentials)
        {
            //check to see if any users exist; if not give this one admin privileges
            using (var reader = new StreamReader("C:/Users/Evan/Documents/credentials.txt"))
            {
                if (reader.ReadLine() == null)
                    credentials[2] = 1.ToString();
                else
                    credentials[2] = 0.ToString();
            }

            return credentials[2];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Login
            login();
        }

        public void button2_Click(object sender, EventArgs e)
        {
            //create account
            /* credentials[0] = username
             * credentials[1] = password
             * credentials[2] - access level
             * */
            string[] credentials = new string[3];
            credentials[0] = textBox1.Text;
            credentials[1] = textBox2.Text;

            credentials[2] = nousers(credentials);

            if (!existinguser(credentials))
                return;
            createuser(credentials);
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //End Program
            System.Environment.Exit(1);
        }

        
    }
}
