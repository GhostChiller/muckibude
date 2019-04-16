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
    public partial class KontoErstellen : UserControl
    {
        public KontoErstellen()
        {
            InitializeComponent();
        }

        private void colorName1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Funktionen funktionen = new Funktionen();

            if (textBox1.Text.Length == 0 || 
                textBox2.Text.Length == 0 || 
                textBox3.Text.Length == 0 || 
                textBox4.Text.Length == 0 ||
                textBox5.Text.Length == 0 ||
                textBox7.Text.Length == 0 ||
                textBox11.Text.Length == 0) {

                    MessageBox.Show("Bitte füllen Sie alle Textfelder aus!", "ERROR - Textfelder ausfüllen!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (comboBox1.Text != "Angestellte/r" && comboBox1.Text != "Boss" && comboBox1.Text != "Kunde" && comboBox1.Text != "Trainer")
                {
                    MessageBox.Show("Wählen Sie einer der Kundentypen aus!", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } else { 


                    string anschrift = textBox7.Text + ", " + textBox11.Text;

                    funktionen.ErstelleKonto(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text,comboBox1.Text,anschrift);

                    if (!(funktionen.erstellerregkey.Length == 0))
                    {
                        textBox6.Text = funktionen.erstellerregkey;
                    }
                }
            }


    }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text.Length == 8)
            {
                textBox3.MaxLength = 10;
                textBox3.Text = textBox3.Text.Substring(4, 4) + "-" + textBox3.Text.Substring(2, 2) + "-" + textBox3.Text.Substring(0, 2);

            }
            else
            {
                textBox3.MaxLength = 8;
            }
        }

        private void KontoErstellen_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void KontoErstellen_VisibleChanged(object sender, EventArgs e)
        {
           if (this.Visible)
           {
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
                textBox11.Clear();
                comboBox1.Text = "Kundentyp";
               

           } else
           {
                
           }
        }
    }
}
