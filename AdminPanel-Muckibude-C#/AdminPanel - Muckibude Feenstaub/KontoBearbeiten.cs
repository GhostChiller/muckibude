using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Net;
using System.IO;
namespace AdminPanel___Muckibude_Feenstaub
{
    public partial class KontoBearbeiten : UserControl
    {
        
        

        public int i = 0;
        int kundentyp = 0;


        public KontoBearbeiten()
        {
            InitializeComponent();
        }

        private void KontoErstellen_Load(object sender, EventArgs e)
        {
            SchalteElemente(1);
        }

        private void KontoErstellen_VisibleChanged(object sender, EventArgs e)
        {
            
            if (this.Visible)
            {
                GetAllRegKeys();
                try
                {
                    kundentyp = Convert.ToInt32(File.ReadAllText("kundentyp.dat"));

                } catch (Exception) { MessageBox.Show("ERROR"); }
            }
            else
            {

                textBox1.Text = "Nach Registerkey suchen..";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Clear();
                textBox9.Clear();
                textBox10.Clear();
                textBox11.Clear();
                comboBox1.Text = "Kundentyp";
                listBox1.Items.Clear();


            }
        }


        public void GetAllRegKeys()
        {
            string GetKeys = "";

            try { 
                  GetKeys = new WebClient().DownloadString("http://127.0.0.1/PHPC/index.php?args=lesen&registerkey=ALL");
            } catch (Exception ex) { MessageBox.Show(ex.Message); return; }
                string[] AllRegKeys;

            AllRegKeys = GetKeys.Split(':');

            for (int p = 0; AllRegKeys[p].Length != 0; p++)
            {
                listBox1.Items.Add(AllRegKeys[p]);
            }


        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            Funktionen funktionen = new Funktionen();
            
            if (listBox1.SelectedItem != null) { 
                funktionen.LeseKontoDaten(listBox1.SelectedItem.ToString());
                textBox2.Text = funktionen.vorname;
                textBox3.Text = funktionen.nachname;
                textBox4.Text = funktionen.geburtsdatum;
                textBox6.Text = funktionen.iban;
                textBox7.Text = funktionen.bic;
                comboBox1.Text = funktionen.kundentyp;
                textBox5.Text = funktionen.anschrift;
                textBox11.Text = funktionen.plzstadt;
                textBox8.Text = funktionen.benutzername;
                textBox9.Text = funktionen.passwort;
                textBox10.Text = funktionen.email;

                textBox1.Text = listBox1.SelectedItem.ToString();
                textBox1.ForeColor = Color.Green;
                deactivateregkey();
            }
            
            /*
            if (funktionen.premium == 1)
            {
                checkBox1.Checked = true;
            }
            else
            {
                checkBox1.Checked = false;

            } */

        }

        private void listBox1_Enter(object sender, EventArgs e)
        {

        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            Funktionen funktionen = new Funktionen();
            if (e.KeyCode == Keys.Enter) {

                if (listBox1.SelectedItem != null)
                {
                    funktionen.LeseKontoDaten(listBox1.SelectedItem.ToString());
                    textBox2.Text = funktionen.vorname;
                    textBox3.Text = funktionen.nachname;
                    textBox4.Text = funktionen.geburtsdatum;
                    textBox6.Text = funktionen.iban;
                    textBox7.Text = funktionen.bic;
                    comboBox1.Text = funktionen.kundentyp;
                    textBox5.Text = funktionen.anschrift;
                    textBox11.Text = funktionen.plzstadt;
                    textBox8.Text = funktionen.benutzername;
                    textBox9.Text = funktionen.passwort;
                    textBox10.Text = funktionen.email;

                    textBox1.Text = listBox1.SelectedItem.ToString();
                    textBox1.ForeColor = Color.Green;
                    deactivateregkey();
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 13)
            {
                if (listBox1.Items.Contains(textBox1.Text))
                {
                    listBox1.Items.Clear();
                    listBox1.Items.Add(textBox1.Text);
                    textBox1.ForeColor = Color.Green;
                    
                }
                else
                {
                    listBox1.Items.Clear();
                    listBox1.Items.Add("Existiert nicht!");
                    textBox1.ForeColor = Color.Red;
                    
                }
                i++;
            }
           if (i == 1) 
            {
                if (textBox1.Text.Length != 13)
                {
                    textBox1.ForeColor = Color.FromArgb(0, 192, 192);
                    i = 0;
                    listBox1.Items.Clear();
                    GetAllRegKeys();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox6.Clear();
                    textBox7.Clear();
                    textBox8.Clear();
                    textBox9.Clear();
                    textBox10.Clear();
                    textBox11.Clear();
                    comboBox1.Text = "Kundentyp";
                    SchalteElemente(1);
                    button1.Text = "Bearbeiten";
                }
            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Nach Registerkey suchen..") {
                textBox1.MaxLength = 13;
                textBox1.Clear();
            }
        }

        public void SchalteElemente(int i)
        {
            if (i == 0)
            {
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                textBox6.Enabled = true;
                textBox7.Enabled = true;
                comboBox1.Enabled = true;
                textBox5.Enabled = true;
                textBox11.Enabled = true;

                textBox2.ReadOnly = false;
                textBox3.ReadOnly = false;
                textBox4.ReadOnly = false;
                textBox6.ReadOnly = false;
                textBox7.ReadOnly = false;
                textBox5.ReadOnly = false;
                textBox11.ReadOnly = false;

                if (kundentyp == 4)
                {
                    textBox8.Enabled = true;
                    textBox9.Enabled = true;
                    textBox10.Enabled = true;

                    textBox8.ReadOnly = false;
                    textBox9.ReadOnly = false;
                    textBox10.ReadOnly = false;
                }
                else
                {
                    textBox8.Enabled = false;
                    textBox9.Enabled = false;
                    textBox10.Enabled = false;

                    textBox8.ReadOnly = true;
                    textBox9.ReadOnly = true;  
                    textBox10.ReadOnly = true;
                }
            }
            else if (i == 1)
            {
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                textBox6.Enabled = false;
                textBox7.Enabled = false;
                textBox8.Enabled = false;
                textBox9.Enabled = false;
                textBox10.Enabled = false;
                comboBox1.Enabled = false;
                textBox5.Enabled = false;
                textBox11.Enabled = false;

                textBox2.ReadOnly = true;
                textBox3.ReadOnly = true;
                textBox4.ReadOnly = true;
                textBox6.ReadOnly = true;
                textBox7.ReadOnly = true;
                textBox8.ReadOnly = true;
                textBox9.ReadOnly = true;
                textBox10.ReadOnly = true;
                textBox8.Enabled = false;
                textBox9.Enabled = false;
                textBox10.Enabled = false;
                textBox5.ReadOnly = true;
                textBox11.ReadOnly = true;

                textBox8.ReadOnly = true;
                textBox9.ReadOnly = true;
                textBox10.ReadOnly = true;
            
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            
            if (textBox1.Text == "")
            {
                textBox1.Text = "Nach Registerkey suchen..";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Funktionen funktionen = new Funktionen();

            if (!(textBox1.Text.Length == 0 || textBox2.Text.Length == 0 || textBox3.Text.Length == 0|| textBox4.Text.Length == 0 || textBox6.Text.Length == 0 || textBox7.Text.Length == 0)) { 

                if (button1.Text == "Bearbeiten")
                {
                    button1.Text = "Speichern";
                    SchalteElemente(0);

                }
                else
                {
                    string anschrift = textBox5.Text + ", " + textBox11.Text;
                    funktionen.UpdateKonto(textBox2.Text, textBox3.Text, textBox4.Text, textBox6.Text, textBox7.Text, anschrift,comboBox1.Text,textBox1.Text);
                    button1.Text = "Bearbeiten";
                    SchalteElemente(1);
                }
            }
            else
            {
                MessageBox.Show("Bitte wählen Sie als erstes ein Registerkey aus!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

      

        private void CheckSTRG_Tick(object sender, EventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control)
            {
                textBox1.Clear();
                textBox1.Text = "Nach Registerkey suchen..";
            }
        }



  

        public void deactivateregkey()
        {
           if (textBox1.Text != "Nach Registerkey suchen.." && textBox1.Text.Length == 13) {
                

                File.WriteAllText("dRegkey.dat", textBox1.Text);
                if (File.Exists("dRegkeyLOG.dat"))
                {
                    string alreadydRegkeys = File.ReadAllText("dRegkeyLOG.dat");
                    File.WriteAllText("dRegkeyLOG.dat", alreadydRegkeys + Environment.NewLine + textBox1.Text);
                } else
                {
                    File.WriteAllText("dRegkeyLOG.dat", textBox1.Text);
                }

            } else { MessageBox.Show("Bitte wählen Sie einen Registrierschlüssel aus!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text.Length == 8)
            {
                textBox4.MaxLength = 10;
                textBox4.Text = textBox4.Text.Substring(4, 4) + "-" + textBox4.Text.Substring(2, 2) + "-" + textBox4.Text.Substring(0, 2);

            }
            else
            {
                textBox4.MaxLength = 8;
            }
        }

        public void refresh()
        {
            textBox1.Text = "Nach Registerkey suchen..";
            listBox1.Items.Clear();
            GetAllRegKeys();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            comboBox1.Text = "Kundentyp";
            SchalteElemente(1);
            button1.Text = "Bearbeiten";
        }
    }
   
  }
    

