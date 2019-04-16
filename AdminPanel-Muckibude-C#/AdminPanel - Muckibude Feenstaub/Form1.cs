using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.IO;
using System.Net;

namespace AdminPanel___Muckibude_Feenstaub
{
    public partial class Form1 : Form
    {

        public int m = 0;

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();


 
        Login login = new Login();
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            label3.ForeColor = Color.FromArgb(0, 192, 192);
            label4.ForeColor = Color.FromArgb(0, 192, 192);
            label5.ForeColor = Color.FromArgb(0, 192, 192);
            label6.ForeColor = Color.FromArgb(0, 192, 192);

            Spot spot = new Spot();
            spot.labelname("Homescreen");
            spot.Show();
            m = 3;
            CheckUserControl.Start();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        //BEARBEITUN
        private void timer1_Tick(object sender, EventArgs e)
        {


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Select();
            pictureBox1.Focus();

            string text = "";


            try
            {
                text = File.ReadAllText("user.dat");
            }
            catch (Exception) { return; }
            string[] newtxt;
            newtxt = text.Split(':');

            text = new WebClient().DownloadString("http://127.0.0.1/PHPC/getlogininfo.php?user=" + newtxt[0] + "&gs=" + newtxt[1]);


            string[] txt = text.Split(':');

            int kundentyp = Convert.ToInt32(txt[3]);

            File.WriteAllText("kundentyp.dat", kundentyp.ToString());


            if (kundentyp == 4)
            {
                pictureBox5.Visible = true;
                label5.Visible = true;
            } else {
                pictureBox5.Visible = false;
                label5.Visible = false;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Spot spot = new Spot();
            spot.labelname("Konto bearbeiten");
            spot.Show();
            m = 2;

            label5.ForeColor = Color.FromArgb(0, 192, 192);
            label4.ForeColor = Color.FromArgb(0, 192, 192);
            label3.ForeColor = Color.Red;
            label6.ForeColor = Color.FromArgb(0, 192, 192);
            CheckUserControl.Start();




        }

        private void kontoBearbeiten1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Einstellungsfenster einstellungsfenster = new Einstellungsfenster();
            
            einstellungsfenster.ShowDialog();
     
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Spot spot = new Spot();
            spot.labelname("Konto erstellen");
            spot.Show();
            label3.ForeColor = Color.FromArgb(0, 192, 192);
            label5.ForeColor = Color.FromArgb(0, 192, 192);
            label4.ForeColor = Color.Red;
            label6.ForeColor = Color.FromArgb(0, 192, 192);
            m = 1;
            CheckUserControl.Start();
            

        }




        private void CheckUserControl_Tick(object sender, EventArgs e)
        {
            if (m == 1)
            {
                panel2.Location = new Point(1071, 0);
                this.Size = new Size(1106, this.Height);
                pictureBox4.Location = new Point(967, 12);
                kontoBearbeiten1.Visible = false;
                kontoErstellen1.Visible = true;
                homescreen1.Visible = false;
                angestellteverwalten1.Visible = false;
            }

            if (m == 2)
            {
                panel2.Location = new Point(1316, 0);
                pictureBox4.Location = new Point(1212, 12);
                this.Size = new Size(1351, this.Height);
                kontoBearbeiten1.Visible = true;
                kontoErstellen1.Visible = false;
                homescreen1.Visible = false;
                angestellteverwalten1.Visible = false;
            }

            if (m == 3)
            {
                panel2.Location = new Point(1071, 0);
                pictureBox4.Location = new Point(967, 12);
                this.Size = new Size(1106, this.Height);
                kontoBearbeiten1.Visible = false;
                kontoErstellen1.Visible = false;
                homescreen1.Visible = true;
                angestellteverwalten1.Visible = false;
            }

            if (m == 4)
            {
                panel2.Location = new Point(1071, 0);
                pictureBox4.Location = new Point(967, 12);
                this.Size = new Size(1106, this.Height);
                kontoBearbeiten1.Visible = false;
                kontoErstellen1.Visible = false;
                homescreen1.Visible = false;
                angestellteverwalten1.Visible = true;
            }
            CheckUserControl.Stop();
        }

        private void CheckFormularClosed_Tick(object sender, EventArgs e)
        {

        }

        private void homescreen1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Spot spot = new Spot();
            spot.labelname("Konto bearbeiten");
            spot.Show();
            m = 2;
            label5.ForeColor = Color.FromArgb(0, 192, 192);
            label4.ForeColor = Color.FromArgb(0, 192, 192);
            label3.ForeColor = Color.Red;
            label6.ForeColor = Color.FromArgb(0, 192, 192);
            CheckUserControl.Start();

        }

        private void label4_Click(object sender, EventArgs e)
        {
            Spot spot = new Spot();
            spot.labelname("Konto erstellen");
            spot.Show();
            label3.ForeColor = Color.FromArgb(0, 192, 192);
            label5.ForeColor = Color.FromArgb(0, 192, 192);
            label4.ForeColor = Color.Red;
            label6.ForeColor = Color.FromArgb(0, 192, 192);
            m = 1;
            CheckUserControl.Start();


        }

        private void label6_Click(object sender, EventArgs e)
        {
            if (File.Exists("dRegkey.dat"))
            {
                string dregkey = File.ReadAllText("dRegkey.dat");

                string value = new WebClient().DownloadString("http://127.0.0.1/PHPC/deleteregkey.php?registerkey=" + dregkey);

                if (value == "Erfolgreich deaktiviert") { File.Delete("dRegkey.dat");  MessageBox.Show("Konto mit dem Registerschlüssel " + dregkey + Environment.NewLine + "wurde erfolgreich deaktiviert!", "Erfoglreich deaktiviert!", MessageBoxButtons.OK, MessageBoxIcon.Information); kontoBearbeiten1.refresh(); return; }
                else { MessageBox.Show("Konto konnte nicht deaktiviert werden!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }
            }
            else { MessageBox.Show("Dies funktioniert nur, wenn Sie ein Konto bearbeiten!", "ERROR blyat", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
        }

            private void label5_Click(object sender, EventArgs e)
        {
            Spot spot = new Spot();
            spot.labelname("Angestellte verwalten");
            spot.Show();
            label3.ForeColor = Color.FromArgb(0, 192, 192);
            label4.ForeColor = Color.FromArgb(0, 192, 192);
            label5.ForeColor = Color.Red;
            label6.ForeColor = Color.FromArgb(0, 192, 192);
            m = 4;
            CheckUserControl.Start();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Spot spot = new Spot();
            spot.labelname("Angestellte verwalten");
            spot.Show();
            label3.ForeColor = Color.FromArgb(0, 192, 192);
            label4.ForeColor = Color.FromArgb(0, 192, 192);
            label5.ForeColor = Color.Red;
            label6.ForeColor = Color.FromArgb(0, 192, 192);
            m = 4;
            CheckUserControl.Start();

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (File.Exists("dRegkey.dat"))
            {
                string dregkey = File.ReadAllText("dRegkey.dat");

                string value = new WebClient().DownloadString("http://127.0.0.1/PHPC/deleteregkey.php?registerkey=" + dregkey);

                if (value == "Erfolgreich deaktiviert") { MessageBox.Show("Konto mit dem Registerschlüssel " + dregkey + Environment.NewLine + "wurde erfolgreich deaktiviert!", "Erfoglreich deaktiviert!", MessageBoxButtons.OK, MessageBoxIcon.Information); kontoBearbeiten1.refresh(); return; }
                else { MessageBox.Show("Konto konnte nicht deaktiviert werden!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }
            } else { MessageBox.Show("Dies funktioniert nur, wenn Sie ein Konto bearbeiten!", "ERROR blyat", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
              
            }
        }
    }


