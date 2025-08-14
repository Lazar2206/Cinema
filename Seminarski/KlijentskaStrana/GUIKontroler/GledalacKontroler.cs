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

        public void KreirajGledaoca()
        {
            Gledalac novi = new Gledalac
            {
                Ime = forma.TXTIme.Text.Trim(),
                Prezime = forma.TxtPrezime.Text.Trim(),
                Mejl = forma.TxtMejl.Text.Trim(),
                IdMesto = (int)forma.CMBMesta.SelectedValue
            };

            Poruka zahtev = new Poruka
            {
                Object = novi,
                Operacija = Operacija.KreirajGledalac
            };

            Session.Session.Instance.Klijent.PošaljiPoruku(zahtev);
            var odgovor = Session.Session.Instance.Klijent.PrimiPoruku();

            if (odgovor.Operacija == Operacija.Uspešno)
            {
                MessageBox.Show("Sistem je zapamtio gledaoca.");
                OsveziGledaoce();
                OcistiPolja();
            }
            else
            {
                MessageBox.Show("Sistem ne može da zapamti gledaoca.");
            }
        }

        public void IzmeniGledaoca()
        {
            if (forma.DGVGledaoci.SelectedRows.Count == 0)
            {
                MessageBox.Show("Izaberite gledaoca za izmenu.");
                return;
            }

            var izabrani = forma.DGVGledaoci.SelectedRows[0].DataBoundItem as Gledalac;
            if (izabrani == null) return;

            izabrani.Ime = forma.TXTIme.Text.Trim();
            izabrani.Prezime = forma.TxtPrezime.Text.Trim();
            izabrani.Mejl = forma.TxtMejl.Text.Trim();
            izabrani.IdMesto = (int)forma.CMBMesta.SelectedValue;

            Poruka zahtev = new Poruka
            {
                Object = izabrani,
                Operacija = Operacija.PromeniGledaoca
            };

            Session.Session.Instance.Klijent.PošaljiPoruku(zahtev);
            var odgovor = Session.Session.Instance.Klijent.PrimiPoruku();

            if (odgovor.Operacija == Operacija.Uspešno)
            {
                MessageBox.Show("Sistem je izmenio gledaoca.");
                OsveziGledaoce();
            }
            else
            {
                MessageBox.Show("Sistem ne može da izmeni gledaoca.");
            }
        }

        public void ObrisiGledaoca()
        {
            if (forma.DGVGledaoci.SelectedRows.Count == 0)
            {
                MessageBox.Show("Izaberite gledaoca za brisanje.");
                return;
            }

            var izabrani = forma.DGVGledaoci.SelectedRows[0].DataBoundItem as Gledalac;
            if (izabrani == null) return;

            Poruka zahtev = new Poruka
            {
                Object = izabrani,              
                Operacija = Operacija.ObrišiGledalac
            };

            Session.Session.Instance.Klijent.PošaljiPoruku(zahtev);
            var odgovor = Session.Session.Instance.Klijent.PrimiPoruku();

            
            string serverPoruka = odgovor.Object as string ?? odgovor.Obavestenje as string ?? "Sistem ne može da obriše gledaoca";
            MessageBox.Show(serverPoruka);

            if (odgovor.Operacija == Operacija.Uspešno)
            {
                OsveziGledaoce();
                OcistiPolja();
            }
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
            forma.DgvGledaoci.Columns[5].Visible = false;
            forma.DgvGledaoci.Columns[6].Visible = false;
            forma.DgvGledaoci.Columns[7].Visible = false;
            forma.DgvGledaoci.Columns[8].Visible = false;
            forma.DgvGledaoci.Columns[9].Visible = false;
            forma.DgvGledaoci.Columns[10].Visible = false;
            forma.DgvGledaoci.Columns[11].Visible = false;
            forma.DgvGledaoci.Columns[12].Visible = false;
            forma.DgvGledaoci.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            forma.DgvGledaoci.AllowUserToAddRows = false;

        }

        private void OcistiPolja()
        {
            forma.TXTIme.Clear();
            forma.TxtPrezime.Clear();
            forma.TxtMejl.Clear();
            forma.CMBMesta.SelectedIndex = -1;
        }

    }
}
