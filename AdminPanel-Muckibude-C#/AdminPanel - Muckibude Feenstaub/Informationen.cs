using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace AdminPanel___Muckibude_Feenstaub
{
    public partial class Informationen : UserControl
    {

       


        public Informationen()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void Informationen_Load(object sender, EventArgs e)
        {
          
        }


        public void GetInfoLogin()
        {
            string text = "";


            try
            { 
                text = File.ReadAllText("user.dat");
            } catch (Exception ex) { MessageBox.Show(ex.Message + "INFORMATION");  return; }

            string[] newtxt = text.Split(':');

            text = new WebClient().DownloadString("http://127.0.0.1/PHPC/getlogininfo.php?user=" + newtxt[0] + "&gs=" + newtxt[1]);

          

            string[] txt = text.Split(':');


            string b = txt[0];
            string v = txt[1];

            Funktionen funktionen = new Funktionen();

            int ts = Convert.ToInt32(txt[6]);

            DateTime dt = funktionen.ConvertTimeStampIntoDateTime(ts);

            label5.Text = b;
            label8.Text = v;
            label9.Text = dt.ToString();
           


        }

        private void Informationen_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                GetInfoLogin();
            }
        }
    }
}
