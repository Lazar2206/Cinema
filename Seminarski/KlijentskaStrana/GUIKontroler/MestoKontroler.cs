using Domen;
using Komunikacija;
using KlijentskaStrana.Session;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Logika;

namespace KlijentskaStrana.GUIKontroler
{
    public class MestoKontroler
    {
        private readonly FrmMesto forma;

        public MestoKontroler(FrmMesto forma)
        {
            this.forma = forma;
        }

        public void NapuniDGV()
        {
            List<Mesto> mesta = Kontroler.Instance.VratiMesta();
            forma.DgvMesta.DataSource = null;
            forma.DgvMesta.DataSource = mesta;
        }

        public void KreirajMesto(string nazivMesta)
        {
            if (string.IsNullOrWhiteSpace(nazivMesta))
            {
                MessageBox.Show("Morate uneti naziv mesta.");
                return;
            }

            Mesto novoMesto = new Mesto
            {
                NazivMesta = nazivMesta
            };

            Poruka zahtev = new Poruka
            {
                Object = novoMesto,
                Operacija = Operacija.KreirajMesto
            };

            var klijent = Session.Session.Instance.Klijent;
            klijent.PošaljiPoruku(zahtev);
            Poruka odgovor = klijent.PrimiPoruku();

            if (odgovor.Operacija == Operacija.Uspešno)
            {
                MessageBox.Show("Sistem je kreirao mesto.");
                forma.TxtNazivMesta.Text = string.Empty;
                NapuniDGV();
            }
            else
            {
                MessageBox.Show("Sistem ne može da kreira mesto.");
            }
        }
    }
}
