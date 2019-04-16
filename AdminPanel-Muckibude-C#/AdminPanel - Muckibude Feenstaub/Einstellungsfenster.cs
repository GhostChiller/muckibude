using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
namespace AdminPanel___Muckibude_Feenstaub
{
    public partial class Einstellungsfenster : Form
    {
        public Einstellungsfenster()
        {
            InitializeComponent();
        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Top = button1.Top;

            panel2.Height = button1.Height;
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            Form1 form1 = new Form1();
            panel2.Top = button3.Top;
            panel2.Height = button3.Height;

            Process.Start("AdminPanel - Muckibude Feenstaub.exe");
            Environment.Exit(0);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel2.Top = button2.Top;

            panel2.Height = button2.Height;
        }

        private void Einstellungsfenster_Load(object sender, EventArgs e)
        {
            panel2.Top = button2.Top;

            panel2.Height = button2.Height;
            button2.Focus();
            button2.Select();
            this.CenterToParent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
