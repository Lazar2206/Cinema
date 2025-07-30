using Domen;
using Komunikacija;
using Logika;
using KlijentskaStrana.Session;
using System;
using System.Windows.Forms;

namespace KlijentskaStrana.GUIKontroler
{
    public class DistributerKontroler
    {
        private readonly FrmDistributer forma;
        private string poslednjiNaziv = "";

        public DistributerKontroler(FrmDistributer forma)
        {
            this.forma = forma;
        }

        public void KreirajDistributera()
        {
            string naziv = forma.TxtNaziv.Text;
            if (string.IsNullOrWhiteSpace(naziv))
            {
                MessageBox.Show("Unesite naziv distributera!");
                return;
            }

            var d = new Distributer { NazivDistributera = naziv };

            var uc = new UcDistributer
            {
                Distributer = d,
                Klijent = Session.Session.Instance.Klijent
            };

            uc.PopuniPolja();
            uc.DistributerAzuriran += (s, e) => OsveziTabelu();

            forma.Panel.Controls.Clear();
            forma.Panel.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
        }

        public void PretraziDistributere()
        {
            poslednjiNaziv = forma.TxtNaziv.Text;

            var kriterijum = new Distributer { NazivDistributera = poslednjiNaziv };
            var rezultat = Kontroler.Instance.VratiDistributere(kriterijum);

            forma.Dgv.DataSource = null;
            forma.Dgv.DataSource = rezultat;

            MessageBox.Show(rezultat.Count > 0 ? "Pronađeni distributeri." : "Nema rezultata.");
        }

        public void PrikaziDetalje()
        {
            if (forma.Dgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("Izaberite distributera.");
                return;
            }

            var izabrani = forma.Dgv.SelectedRows[0].DataBoundItem as Distributer;

            var uc = new UcDistributer
            {
                Distributer = izabrani,
                Klijent = Session.Session.Instance.Klijent
            };

            uc.PopuniPolja();
            uc.DistributerAzuriran += (s, e) => OsveziTabelu();

            forma.Panel.Controls.Clear();
            forma.Panel.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;

            MessageBox.Show("Sistem je našao distributera.");
        }

        public void OsveziTabelu()
        {
            var kriterijum = new Distributer { NazivDistributera = poslednjiNaziv };

            forma.Dgv.DataSource = null;
            forma.Dgv.DataSource = Kontroler.Instance.VratiDistributere(kriterijum);
        }
    }
}
