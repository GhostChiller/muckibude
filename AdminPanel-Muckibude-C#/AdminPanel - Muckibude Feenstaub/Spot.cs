using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AdminPanel___Muckibude_Feenstaub
{
    public partial class Spot : Form
    {
        int i = 0;
        double x = 0,z=1;
        public Spot()
        {
            InitializeComponent();


        }

    

        private void Spot_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
            this.Opacity = 0;
            panel1.Location = new Point(
            this.ClientSize.Width / 2 - panel1.Size.Width / 2,
            this.ClientSize.Height / 2 - panel1.Size.Height / 2 + 70);
            panel1.Anchor = AnchorStyles.None;

            

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            


            if (panel2.Location.X > 750)
            {
                timer3.Start();
                timer2.Stop();
            } else if (panel2.Location.X < 5 && panel2.Location.X > -10)
            {
                timer2.Start();
                timer3.Stop();
            }
            
            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            panel2.Location = new Point(panel2.Location.X + 6, panel2.Location.Y);

        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            panel2.Location = new Point(panel2.Location.X - 6, panel2.Location.Y);

        }


        public void labelname(string _writename)
        {
            label1.Text = "Vorgang wird verarbeitet: ";
            label1.Text += _writename;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Spot_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true; 
        }

        private void opacity_Tick(object sender, EventArgs e)
        {
            if (x <= 1) { 
                x += 0.02;
                this.Opacity = x;
            }

            i++;

            if (x >= 1 && i >= 150)
            {
                z -= 0.02;
                this.Opacity = z;
            }
            
            if (z <= 0.01)
            {
                this.Dispose();
                this.Close();
            }

        }

  
    }
}
