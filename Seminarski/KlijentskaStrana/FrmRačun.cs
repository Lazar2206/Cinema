using Domen;
using Komunikacija;
using Logika;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KlijentskaStrana
{
    public partial class FrmRačun : Form
    {
        private Klijent klijent;
        private Bioskop bioskop;
        private double ukupnaCena = 0;
        private int idRacun = 0;
        public double UkupnaCena
        {
            get => ukupnaCena;
            set
            {
                ukupnaCena = value;
                txtUkupnaCena.Text = ukupnaCena.ToString("F2");
            }
        }
        public FrmRačun(Klijent klijent, Bioskop bioskop)
        {
            InitializeComponent();
            this.klijent = klijent;
            this.bioskop = bioskop;
            txtBioskop.Text = bioskop.NazivBioskopa;

            NapuniCMB();
        }

        private void NapuniCMB()
        {

            cmbGledalac.DataSource = Kontroler.Instance.VratiGledaoce();
            cmbGledalac.DisplayMember = "Prikaz";
            cmbGledalac.ValueMember = "IdGledalac";
            cmbGledalac.SelectedIndex = -1;

        }

        private void cmbBioskop_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {

        }

        private void OsvežiDGV()
        {
            dgvRacunStavke.DataSource = null;
            var stavke = Kontroler.Instance.VratiStavkeRacuna(idRacun);
            MessageBox.Show("Broj stavki: " + stavke.Count);
            dgvRacunStavke.DataSource = stavke;

        }

        private void btnKreirajRačun_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value.Date < DateTime.Today)
            {
                MessageBox.Show("Ne možete kreirati račun za datum u prošlosti!");
                return;
            }
            if (cmbGledalac.SelectedValue == null)
            {
                MessageBox.Show("Izaberite gledaoce!");
                return;
            }
            Racun r = new Racun
            {
                Datum = dateTimePicker1.Value.Date,
                UkupnaCena = 0,
                IdGledalac = (int)cmbGledalac.SelectedValue,
                IdBioskop = bioskop.IdBioskop
            };
            Poruka zahtev = new Poruka
            {
                Object = r,
                Operacija = Operacija.PretražiRacun
            };
            try
            {
                klijent.PošaljiPoruku(zahtev);
                Poruka odgovor = klijent.PrimiPoruku();

                if (odgovor.Operacija == Operacija.Uspešno)
                {
                    MessageBox.Show("Sistem je kreirao račun");
                    idRacun = Kontroler.Instance.VratiIdNajnovijegRacuna();
                    UcStavkaRacunacs uc = new UcStavkaRacunacs();
                    uc.Klijent = klijent;
                    uc.Bioskop = bioskop;
                    uc.IdRacun = idRacun;
                    uc.Dock = DockStyle.Fill;

                    pnlStavka.Controls.Clear();
                    pnlStavka.Controls.Add(uc);
                    uc.UcitajFilmove();
                    uc.StavkaDodata += (cena) =>
                    {
                        ukupnaCena += cena;
                        txtUkupnaCena.Text = ukupnaCena.ToString("F2");
                        OsvežiDGV();

                        // Ovo je jedino mesto gde treba ažurirati bazu
                        Poruka azuriraj = new Poruka
                        {
                            Operacija = Operacija.AzurirajUkupnuCenu,
                            Object = Tuple.Create(idRacun, ukupnaCena)
                        };
                        klijent.PošaljiPoruku(azuriraj);
                        Poruka odgovor = klijent.PrimiPoruku();
                        if (odgovor.Operacija != Operacija.Uspešno)
                        {
                            MessageBox.Show("Račun nije ažuriran u bazi!");
                        }
                    };
                }
                else
                {
                    MessageBox.Show("Sistem ne može da kreira račun");
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show("Greška u komunikaciji sa serverom: " + ex.Message);
            }
        }

        private void btnGlavna_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPretraži_Click(object sender, EventArgs e)
        {
            Racun r = new Racun
            {
                Datum = dateTimePicker1.Value.Date,
                IdGledalac = cmbGledalac.SelectedItem != null ? (int)cmbGledalac.SelectedValue : 0,
                IdBioskop = bioskop.IdBioskop
            };

            dgvRacuni.DataSource = null;
            dgvRacuni.DataSource = Kontroler.Instance.VratiRacun(r);
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            if (dgvRacuni.SelectedRows.Count > 0)
            {
                
                MessageBox.Show("Sistem je našao gledaoca.");
            }
            else
            {
                MessageBox.Show("Sistem ne može da nađe gledaoca");
            }
        }
    }
}
