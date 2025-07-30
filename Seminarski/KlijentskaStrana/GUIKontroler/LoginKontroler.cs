using Domen;
using Komunikacija;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlijentskaStrana.GUIKontroler
{
    public class LoginKontroler
    {

        private Klijent klijent;
        Bioskop prijavljeniBioskop;
        public void Login( FrmLoginBioskop loginBioskop)
        {
            if (klijent == null)
            {
                klijent = new Klijent();
                if (!klijent.PoveziSe())//provera da li se povezao 
                {
                    klijent = null; //ako se nije povezao
                    MessageBox.Show("Neuspešno povezivanje");
                    return;
                }
            }
            Bioskop bioskop = new Bioskop()
            {
                KorisnickoIme = loginBioskop.TxtKorisničkoIme.Text,
                Sifra = loginBioskop.TxtLozinka.Text

            };
            //kreiranje zahteva
            Poruka zahtev = new Poruka();
            zahtev.Object = bioskop;
            zahtev.Operacija = Operacija.Login;
            //slanje zahteva
            klijent.PošaljiPoruku(zahtev);
            //primanje odgovora
            Poruka odgovor = klijent.PrimiPoruku();
            if (odgovor.Operacija.Equals(Operacija.Uspešno))
            {
                prijavljeniBioskop = klijent.ReadType<Bioskop>(odgovor.Object);
                bioskop.IdBioskop = prijavljeniBioskop.IdBioskop;
                bioskop.NazivBioskopa = prijavljeniBioskop.NazivBioskopa;
                bioskop.KorisnickoIme = prijavljeniBioskop.KorisnickoIme;

                MessageBox.Show("Dobrodošli, " + prijavljeniBioskop.NazivBioskopa + "!");

                FrmGlavna frm = new FrmGlavna();
                Session.Session.Instance.Klijent = klijent;
                Session.Session.Instance.CurrentBioskop = prijavljeniBioskop;
                loginBioskop.Visible = false;
                frm.ShowDialog();
            }
            else
            {
                //ako podaci nisu ispravni
                MessageBox.Show("Nepostojeci korisnik");
            }
        }
       
    }
}
