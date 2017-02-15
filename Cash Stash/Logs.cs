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
    public partial class Logs : Form
    {
        public Logs()
        {
            InitializeComponent();
            var logstring = File.ReadAllText("C:/Users/Evan/Documents/logs.txt");
            textBox1.Text = logstring;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.label2.Text = label2.Text;
            this.Hide();
            form2.Show();
        }
    }
}
