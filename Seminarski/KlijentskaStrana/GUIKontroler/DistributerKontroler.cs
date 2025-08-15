using Komunikacija;
using Logika;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace KlijentskaStrana.GUIKontroler
{
    public class DistributerKontroler
    {
        private readonly FrmDistributer forma;
        private readonly Klijent klijent;
        private string poslednjiNaziv = "";
        private Distributer izabrani;

        public DistributerKontroler(FrmDistributer forma, Klijent klijent)
        {
            this.forma = forma;
            this.klijent = klijent;
            this.klijent = Session.Session.Instance.Klijent;
        }

        public void KreirajDistributera()
        {
            string naziv = forma.TxtNaziv.Text.Trim();
            if (string.IsNullOrWhiteSpace(naziv))
            {
                MessageBox.Show("Unesite naziv distributera!");
                return;
            }

            var d = new Distributer { NazivDistributera = naziv };

            var zahtev = new Poruka
            {
                Object = d,
                Operacija = Operacija.KreirajDistributer
            };

            klijent.PošaljiPoruku(zahtev);
            var odgovor = klijent.PrimiPoruku();

            if (odgovor.Operacija == Operacija.Uspešno)
            {
                MessageBox.Show("Sistem je zapamtio distributera");
                forma.TxtNaziv.Clear();
                OsveziTabelu();
            }
            else
            {
                MessageBox.Show("Sistem ne može da zapamti distributera");
            }
        }

        public void PretraziDistributere()
        {
            if (string.IsNullOrWhiteSpace(forma.TxtNaziv.Text))
            {
                MessageBox.Show("Sistem ne može da nađe distributera");
                return;
            }
            poslednjiNaziv = forma.TxtNaziv.Text;
            var kriterijum = new Distributer { NazivDistributera = poslednjiNaziv };
            var rezultat = Kontroler.Instance.PretražiDistributere(kriterijum);

            forma.Dgv.DataSource = null;
            forma.Dgv.DataSource = rezultat;
            forma.Dgv.Columns[2].Visible = false;
            forma.Dgv.Columns[3].Visible = false;
            forma.Dgv.Columns[4].Visible = false;
            forma.Dgv.Columns[5].Visible = false;
            forma.Dgv.Columns[6].Visible = false;
            forma.Dgv.Columns[7].Visible = false;
            forma.Dgv.Columns[8].Visible = false;
            forma.Dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            forma.Dgv.AllowUserToAddRows = false;
        }

        public void PopuniFormuIzabranim()
        {
            if (forma.Dgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("Izaberite distributera iz tabele.");
                return;
            }

            izabrani = forma.Dgv.SelectedRows[0].DataBoundItem as Distributer;
            if (izabrani != null)
            {
                forma.TxtNaziv.Text = izabrani.NazivDistributera;
            }
        }

        public void IzmeniDistributera()
        {
            if (forma.Dgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("Izaberite distributera iz tabele.");
                return;
            }

            var izabrani = forma.Dgv.SelectedRows[0].DataBoundItem as Distributer;
            if (izabrani == null) return;

            izabrani.NazivDistributera = forma.TxtNaziv.Text.Trim();

            var zahtev = new Poruka
            {
                Object = izabrani,
                Operacija = Operacija.PromeniDistributera
            };

            klijent.PošaljiPoruku(zahtev);
            var odgovor = klijent.PrimiPoruku();

            if (odgovor.Operacija == Operacija.Uspešno)
            {
                MessageBox.Show("Sistem je izmenio distributera");
                OsveziTabelu();
            }
            else
            {
                MessageBox.Show("Sistem ne može da izmeni distributera");
            }
        }

        public void ObrisiDistributera()
        {
            if (forma.Dgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("Izaberite distributera iz tabele.");
                return;
            }

            var izabrani = forma.Dgv.SelectedRows[0].DataBoundItem as Distributer;
            if (izabrani == null) return;

            var zahtev = new Poruka
            {
                Object = izabrani,
                Operacija = Operacija.ObrišiDistributer
            };

            klijent.PošaljiPoruku(zahtev);
            var odgovor = klijent.PrimiPoruku();

            if (odgovor.Operacija == Operacija.Uspešno)
            {
                MessageBox.Show("Sistem je obrisao distributera");
                forma.TxtNaziv.Clear();
                OsveziTabelu();
            }
            else
            {
                MessageBox.Show("Sistem ne može da obriše distributera");
            }
        }

        public void OsveziTabelu()
        {
            var kriterijum = new Distributer { NazivDistributera = poslednjiNaziv };
            forma.Dgv.DataSource = null;
            forma.Dgv.DataSource = Kontroler.Instance.VratiDistributere(kriterijum);
            forma.Dgv.Columns[2].Visible = false;
            forma.Dgv.Columns[3].Visible = false;
            forma.Dgv.Columns[4].Visible = false;
            forma.Dgv.Columns[5].Visible = false;
            forma.Dgv.Columns[6].Visible = false;
            forma.Dgv.Columns[7].Visible = false;
            forma.Dgv.Columns[8].Visible = false;
            forma.Dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            forma.Dgv.AllowUserToAddRows = false;
            
        }
    }
}

