using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;

namespace AdminPanel___Muckibude_Feenstaub
{
    public partial class Angestellteverwalten : UserControl
    {
        int id;
        string kundentyp,gs;

        public Angestellteverwalten()
        {
            InitializeComponent();
        }

        private void Showalllogin()
        {
            listBox1.Items.Clear();
            string value = new WebClient().DownloadString("http://127.0.0.1/PHPC/showalllogin.php");

            string[] users = value.Split(':');


            for (int x = 0; users[x].Length != 0; x++)
            {
                listBox1.Items.Add(users[x]);
            }
        }

        private void Angestellteverwalten_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                Showalllogin();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 0 && textBox2.Text.Length != 0 && textBox3.Text.Length != 0 && textBox4.Text.Length != 0) {
               
               if (button1.Text == "Erstellen" && (comboBox1.Text == "Boss" || comboBox1.Text == "Angestellte/r"))
                {
                    string LoginErstellen = new WebClient().DownloadString("http://127.0.0.1/PHPC/registerlogin.php?benutzername=" +textBox4.Text +"&passwort=" + textBox3.Text + "&vorname=" + textBox1.Text + "&nachname=" + textBox2.Text + "&kundentyp=" + comboBox1.Text);

                    if (!(LoginErstellen == "Accountname existiert bereits"))
                    {
                        textBox5.Text = LoginErstellen;
                        MessageBox.Show("Login-Konto für " + textBox1.Text + " " + textBox2.Text + Environment.NewLine + "wurde erfolgreich erstellt!", "Erfolgreich!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Showalllogin();
                        return;
                    } else { MessageBox.Show("Benutzername existiert bereits", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }


                } else { if (button1.Text == "Erstellen") {MessageBox.Show("Bitte wählen Sie einer der Kundentypen aus!","Error",MessageBoxButtons.OK,MessageBoxIcon.Error); return; } }
             
            } else { MessageBox.Show("Füllen Sie alle Textfelder aus!", "Du Hund", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }

            if (textBox1.Text.Length != 0 && textBox2.Text.Length != 0 && textBox3.Text.Length != 0 && textBox4.Text.Length != 0) {

                if (button1.Text == "Speichern" && (comboBox1.Text == "Boss" || comboBox1.Text == "Angestellte/r"))
                {

                    string LoginUpdate = new WebClient().DownloadString("http://127.0.0.1/PHPC/updatelogininfo.php?username=" + textBox4.Text + "&password=" + textBox3.Text + "&vorname=" + textBox1.Text + "&nachname=" + textBox2.Text + "&kundentyp=" + comboBox1.Text + "&id=" + id);

                    if (LoginUpdate == "Erfolgreich")
                    {
                        MessageBox.Show("Login-Konto von " + textBox1.Text + " " + textBox2.Text + Environment.NewLine + "wurde erfolgreich überarbeitet!", "Erfolgreich!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Showalllogin();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Konto konnte nicht überarbeitet werden", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;
                    }
                }  else { MessageBox.Show("Bitte wählen Sie einer der Kundentypen aus!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            }

            else { MessageBox.Show("Füllen Sie alle Textfelder aus!", "Du Hund", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }
        }

        private void Angestellteverwalten_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
                if (button2.Text == "Bearbeiten")
                {
                    button1.Text = "Speichern";
                    label5.Text = "LOGIN-KONTO BEARBEITEN";
                    button2.Text = "Erstellen";
                }
                else {
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    comboBox1.Text = "Kundentyp";
                    label5.Text = "LOGIN-KONTO ERSTELLEN";
                    button2.Text = "Bearbeiten";
                    button1.Text = "Erstellen";
                }
         
        }

        private void GetEmployeeAccInfo()
        {
            string value = new WebClient().DownloadString("http://127.0.0.1/PHPC/getlogininfo.php?user=" + listBox1.SelectedItem.ToString());

            string[] infodaten = value.Split(':');

            textBox4.Text = infodaten[0];
            textBox3.Text = infodaten[4];
            textBox2.Text = infodaten[2];
            textBox1.Text = infodaten[1];
            id = Convert.ToInt32(infodaten[5]);
            kundentyp = infodaten[7];
            comboBox1.Text = kundentyp;
            gs = infodaten[8];
            textBox5.Text = gs;
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox3.PasswordChar = textBox1.PasswordChar;
            }
            else
            {
                textBox3.PasswordChar = '*';
            }
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (button2.Text == "Erstellen")
            {
                GetEmployeeAccInfo();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
