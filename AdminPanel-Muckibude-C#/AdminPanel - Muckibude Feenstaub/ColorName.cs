using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AdminPanel___Muckibude_Feenstaub
{
    public partial class ColorName : UserControl
    {

        public int x = 255, x1 = 255, x2 = 255;

        public ColorName()
        {
            InitializeComponent();
        }

        private void ColorName_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (x != 255)
            {
                x = x + 5;
                label1.ForeColor = Color.FromArgb(x, x1, x2);
            }

            if (x == 255 && x1 != 255)
            {
                x1 = x1 + 5;
                label1.ForeColor = Color.FromArgb(x, x1, x2);
            }
            if (x1 == 255 && x2 != 255)
            {
                x2 = x2 + 5;
                label1.ForeColor = Color.FromArgb(x, x1, x2);
            }


            if (label1.ForeColor == Color.FromArgb(255, 255, 255))
            {

                timer2.Start();

                timer1.Stop();

            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            x2 = x2 - 5;
            x1 = x1 - 5;

            label1.ForeColor = Color.FromArgb(x, x1, x2);

            if (x1 <= 0 || x2 <= 0 || x <= 0)
            {
                timer2.Stop();
                timer1.Start();
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
