using Domen;
using KlijentskaStrana.Session;
using Komunikacija;
using Logika;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace KlijentskaStrana.GUIKontroler
{
    public class GledalacKontroler
    {
        private readonly FrmGledalac forma;
        private Gledalac gledalac;

        public GledalacKontroler(FrmGledalac forma)
        {
            this.forma = forma;
        }

        public void NapuniCmbMesta()
        {
            List<Mesto> mesta = Kontroler.Instance.VratiMesta();
            forma.CMBMesta.DataSource = mesta;
            forma.CMBMesta.DisplayMember = "NazivMesta";
            forma.CMBMesta.ValueMember = "IdMesto";
            forma.CMBMesta.SelectedIndex = -1;
        }

        public void OsveziGledaoce()
        {
            var lista = Kontroler.Instance.VratiGledaoce(new Gledalac());
            forma.DgvGledaoci.DataSource = null;
            forma.DgvGledaoci.DataSource = lista;
        }

        public void PretraziGledaoce()
        {
            string ime = forma.TxtIme.Text;
            int? idMesto = forma.CmbMesta.SelectedValue as int?;

            var kriterijum = new Gledalac
            {
                Ime = ime,
                IdMesto = idMesto ?? 0
            };

            var lista = Kontroler.Instance.VratiGledaoce(kriterijum);
            forma.DgvGledaoci.DataSource = null;
            forma.DgvGledaoci.DataSource = lista;
        }

        public void OtvoriFormuZaUnos()
        {
            UcGledalac uc = new UcGledalac(this); ;
            uc.PopuniPolja();
            uc.GledalacAzuriran += (s, e) => OsveziGledaoce();

            forma.Panel.Controls.Clear();
            forma.Panel.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
        }

        public void OtvoriDetalje()
        {
            if (forma.DgvGledaoci.SelectedRows.Count == 0)
            {
                MessageBox.Show("Izaberite gledaoca.");
                return;
            }

            var izabrani = forma.DGVGledaoci.SelectedRows[0].DataBoundItem;

            UcGledalac uc = new UcGledalac(this);
            uc.PopuniPoljaIzObjekta(izabrani);
            uc.GledalacAzuriran += (s, e) => OsveziGledaoce();

            forma.Panel.Controls.Clear();
            forma.Panel.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;

            MessageBox.Show("Sistem je našao gledaoca.");
        }
        public bool ZapamtiGledaoca(Gledalac g)
        {
            Poruka zahtev = new Poruka
            {
                Object = g,
                Operacija = Operacija.KreirajGledalac
            };

            Session.Session.Instance.Klijent.PošaljiPoruku(zahtev);
            Poruka odgovor = Session.Session.Instance.Klijent.PrimiPoruku();
            return odgovor.Operacija == Operacija.Uspešno;
        }

        public bool IzmeniGledaoca()
        {
            Poruka zahtev = new Poruka
            {
                Object = this.gledalac,
                Operacija = Operacija.PromeniGledaoca
            };

            Session.Session.Instance.Klijent.PošaljiPoruku(zahtev);
            Poruka odgovor = Session.Session.Instance.Klijent.PrimiPoruku();
            return odgovor.Operacija == Operacija.Uspešno;
        }

        public bool ObrisiGledaoca()
        {
            Poruka zahtev = new Poruka
            {
                Object = this.gledalac,
                Operacija = Operacija.ObrišiGledalac
            };

            Session.Session.Instance.Klijent.PošaljiPoruku(zahtev);
            Poruka odgovor = Session.Session.Instance.Klijent.PrimiPoruku();
            return odgovor.Operacija == Operacija.Uspešno;
        }
        public void PostaviGledaoca(Gledalac g)
        {
            this.gledalac = g;
        }
        public List<Mesto> VratiMesta()
        {
            return Kontroler.Instance.VratiMesta();
        }
    }
}
