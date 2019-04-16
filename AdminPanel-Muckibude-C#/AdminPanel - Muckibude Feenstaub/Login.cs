using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Net;
using System.IO;

namespace AdminPanel___Muckibude_Feenstaub
{
    public partial class Login : Form
    {

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();


        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] lg = { };
            string Loginvalue;
            Form1 form1 = new Form1();
            
            try { 
             Loginvalue = new WebClient().DownloadString("http://127.0.0.1/PHPC/login.php?user=" + textBox1.Text + "&pwd=" + textBox2.Text + "&gs="+ textBox4.Text);
            } catch (Exception) { MessageBox.Show("Login fehlgeschlagen", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }


            try
            {
                lg = Loginvalue.Split(':');
            } catch (Exception) { return; };

            switch (lg[0])
            {
                case "Erfolgreich eingeloggt!":

                    
                    int ts = Convert.ToInt32(lg[1]);
                    WriteInfoLogin(textBox1.Text,textBox4.Text);

                    MessageBox.Show("Erfolgreich eingeloggt","Erfolgreich!",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    this.Hide();
                    form1.ShowDialog();
                    break;

                default:
                    MessageBox.Show("Login fehlgeschlagen!","Fehlgeschlagen!",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    return;
                  
                

            }
            
        }
  

        private void SuccessAnimation_Tick(object sender, EventArgs e)
        {
            
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_Click(object sender, EventArgs e)
        {
            panel6.BackColor = Color.FromArgb(0, 192, 192);
            panel1.BackColor = Color.White;
            panel2.BackColor = Color.White;
            pictureBox4.Image = Image.FromFile("gallery/firewall (1).png");

            if (textBox4.Text == "Geheim-Schlüssel") {
                textBox4.Clear();
                textBox4.PasswordChar = '*';
            }
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = Image.FromFile("gallery/padlock (1).png");

            panel2.BackColor = Color.FromArgb(0, 192, 192);
            panel1.BackColor = Color.White;
            panel6.BackColor = Color.White;

            if (textBox2.Text == "Passwort")
            {

                textBox2.Clear();
                textBox2.PasswordChar = '*';
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            pictureBox2.Image = Image.FromFile("gallery/padlock.png");
            if (!(textBox2.Text.Length > 0))
            {
                panel1.BackColor = Color.White;
                panel2.BackColor = Color.White;
                panel6.BackColor = Color.White;
                textBox2.PasswordChar = textBox3.PasswordChar;
                textBox2.Text = "Passwort";
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            pictureBox4.Image = Image.FromFile("gallery/firewall.png");
            if (!(textBox4.Text.Length > 0))
            {
                panel1.BackColor = Color.White;
                panel2.BackColor = Color.White;
                panel6.BackColor = Color.White;
                textBox4.PasswordChar = textBox3.PasswordChar;
                textBox4.Text = "Geheim-Schlüssel";
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("gallery/user.png");
            if (!(textBox1.Text.Length > 0))
            {
                panel6.BackColor = Color.White;
                panel1.BackColor = Color.White;
                panel2.BackColor = Color.White;
                textBox1.Text = "Benutzername";
            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("gallery/user (1).png");

            panel1.BackColor = Color.FromArgb(0, 192, 192);
            panel2.BackColor = Color.White;
            panel6.BackColor = Color.White;


            if (textBox1.Text == "Benutzername")
            {
                textBox1.Clear();
            }
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            panel6.BackColor = Color.FromArgb(0, 192, 192);
            panel1.BackColor = Color.White;
            panel2.BackColor = Color.White;
            pictureBox4.Image = Image.FromFile("gallery/firewall (1).png");

            if (textBox4.Text == "Geheim-Schlüssel")
            {
                textBox4.Clear();
                textBox4.PasswordChar = '*';
            }
        }

        private void textBox4_AcceptsTabChanged(object sender, EventArgs e)
        {
           
        }

        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            File.Delete("user.dat");
            if (File.Exists("dRegkey.dat"))
            {
                File.Delete("dRegkey.dat");
            }
            Environment.Exit(0);
        }

        public void WriteInfoLogin(string b,string gs)
        {

            File.WriteAllText("user.dat", b + ":" + gs);
            
        }

        private void textBox1_AcceptsTabChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("gallery/user (1).png");

            panel1.BackColor = Color.FromArgb(0, 192, 192);
            panel2.BackColor = Color.White;
            panel6.BackColor = Color.White;

            if (textBox1.Text == "Benutzername")
            {
                textBox1.Clear();
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            pictureBox2.Image = Image.FromFile("gallery/padlock (1).png");

            panel2.BackColor = Color.FromArgb(0, 192, 192);
            panel1.BackColor = Color.White;
            panel6.BackColor = Color.White;

            if (textBox2.Text == "Passwort")
            {

                textBox2.Clear();
                textBox2.PasswordChar = '*';
            }
        }
    }
}
