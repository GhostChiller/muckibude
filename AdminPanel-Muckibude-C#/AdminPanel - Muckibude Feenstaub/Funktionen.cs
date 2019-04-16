using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
namespace AdminPanel___Muckibude_Feenstaub
{
    class Funktionen
    {

        public string vorname, nachname, geburtsdatum,anschrift,plzstadt;
        public string erstellerregkey;
        public string iban, bic, kundentyp;
        public string benutzername, passwort, email;
       

        



        //FERTIG
        public void LeseKontoDaten(string _RegKey)
        {
            string ReadResult = new WebClient().DownloadString("http://127.0.0.1/PHPC/index.php?args=lesen&registerkey=" + _RegKey);

            string[] Konto;
            string[] CutAnschriftplz;
            Konto = ReadResult.Split(':');

            vorname = Konto[0];
            nachname = Konto[1];
            geburtsdatum = Konto[2];
            iban = Konto[4];
            bic = Konto[5];
            kundentyp = Konto[6];
            CutAnschriftplz = Konto[7].Split(',');
            anschrift = CutAnschriftplz[0];
            plzstadt = CutAnschriftplz[1];
            benutzername = Konto[8];
            passwort = Konto[9];
            email = Konto[10];
            //regkey = Konto[6];

        }



        //FERTIG
        public void ErstelleKonto(string _regvorname, string _regnachname, string _reggeburtsdatum, string _regiban, string _regbic,string _regkundentyp,string _reganschrift)
        {
            string CreateResult = "";

            try { 
                 CreateResult = new WebClient().DownloadString("http://127.0.0.1/PHPC/index.php?args=schreiben&vorname="+_regvorname+"&name="+_regnachname+"&geburtsdatum="+_reggeburtsdatum+"&iban="+_regiban+"&bic=" + _regbic + "&anschrift=" + _reganschrift + "&kundentyp=" + _regkundentyp);
            }
            catch (Exception) { MessageBox.Show("Es feht eine Internetverbindung"); return; }
            switch (CreateResult)
            {
                case "Konto konnte nicht erstellt werden! (KUNDEN_PDATA)":

                    MessageBox.Show(CreateResult, "ERSTELLEN - ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    break;

                case "Konto konnte nicht vollstaendig hinzugefuegt werden (REGISTERKEYS)":

                    MessageBox.Show(CreateResult, "ERSTELLEN - ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                    break;

                case "Konto konnte nicht vollstaendig hinzugefuegt werden (KUNDEN)":

                    MessageBox.Show(CreateResult, "ERSTELLEN - ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                    break;




                default:

                    string[] msg;
                    msg = CreateResult.Split(':');

                    MessageBox.Show(msg[0] + Environment.NewLine + msg[1] + Environment.NewLine + msg[2], "ERSTELLEN - ERFOLGREICH", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    erstellerregkey = msg[3];
                    return;

        }

                
                
                
        }


        //FERTIG
        public void UpdateKonto(string _updvorname, string _updnachname, string _updgeburtstag, string _updiban, string _updbic, string _updanschrift,string _updkundentyp ,string _updkey)
        {
            if (_updkundentyp == "Kunde")
            { }
            else if (_updkundentyp == "Trainer") { }
            else if (_updkundentyp == "Angestellte/r") { }
            else { }
            string UpdateResult = new WebClient().DownloadString("http://127.0.0.1/PHPC/index.php?args=update&vorname=" + _updvorname + "&name=" + _updnachname + "&geburtsdatum=" + _updgeburtstag + "&iban=" + _updiban + "&bic=" + _updbic + "&anschrift=" + _updanschrift + "&kundentyp=" + _updkundentyp +"&registerkey=" + _updkey);

            switch (UpdateResult)
            {

                case "Das Konto wurde erfolgreich ueberarbeitet":

                    MessageBox.Show("Das Konto mit dem Registerschlüssel " + _updkey + Environment.NewLine +
                                    "wurde erfolgreich überarbeitet!", "UPDATE - Erfolgreich", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    break;

                default:
                    MessageBox.Show(UpdateResult, "UPDATE - ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
            }

        }


        //Konvertiere TimeStamp zu DateTime
        public DateTime ConvertTimeStampIntoDateTime(int _timestamp)
        {
            DateTime datetime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

            datetime = datetime.AddSeconds(_timestamp).ToLocalTime();
            return datetime;

        }


        //FERTIG
        public string DeaktiviereKonto(string _decregkey)
        {
            string decvalue = new WebClient().DownloadString("http://127.0.0.1/PHPC/index.php?args=deaktiviere&registerkey=" + _decregkey);

            switch(decvalue)
            {
                case "Konto konnte nicht deaktiviert werden! (KUNDEN)":

                    return decvalue;

                case "Konto wurde nicht vollständig deaktiviert! (REGISTERKEYS)":

                    return decvalue;

                default:

                    return "Konto wurde erfolgreich deaktiviert!";

            }

        }
        private int eLD = 0;

        public void seteLD(int _eLD)
        {
            eLD = _eLD;
        }
        public int returneLD()
        {
            return eLD;
        }

    }
}



