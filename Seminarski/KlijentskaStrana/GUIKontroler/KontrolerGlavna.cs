using System;
using System.Diagnostics;
using System.Windows.Forms;
using Komunikacija;


namespace KlijentskaStrana.GUIKontroler
{
    public class KontrolerGlavna
    {
        private Form glavnaForma;
    private Klijent klijent= Session.Session.Instance.Klijent;

        public KontrolerGlavna(Form glavnaForma)
        {
            this.glavnaForma = glavnaForma;
        }

        public void Logout()
        {
            var zahtev = new Poruka
            {
                Operacija = Operacija.Logout,
                Object = Session.Session.Instance.CurrentBioskop
            };

            klijent.PošaljiPoruku(zahtev);
            klijent.Logout();
            glavnaForma.Close();
        }
    }
}
