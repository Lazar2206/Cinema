using Domen;
using Domen.DTO;
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
        private Racun selektovaniRacun;
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
            dgvRacunStavke.DataSource = stavke;

            
            ukupnaCena = stavke.Sum(s => s.Cena);
            txtUkupnaCena.Text = ukupnaCena.ToString("F2");
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
                    uc.StavkaDodata += (razlikaUCeni) =>
                    {
                        ukupnaCena += razlikaUCeni;
                        txtUkupnaCena.Text = ukupnaCena.ToString("F2");
                        OsvežiDGV();

                        Poruka azuriraj = new Poruka
                        {
                            Operacija = Operacija.AzurirajUkupnuCenu,
                            Object = Tuple.Create(idRacun, ukupnaCena)
                        };

                        klijent.PošaljiPoruku(azuriraj);
                        Poruka odgovor = klijent.PrimiPoruku();

                        if (odgovor.Operacija != Operacija.Uspešno)
                        {
                            MessageBox.Show("Greška prilikom ažuriranja ukupne cene u bazi.");
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
            dgvRacuni.Columns["IdGledalac"].Visible = false;
            dgvRacuni.Columns["IdBioskop"].Visible = false;
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            Racun r = new Racun
            {
                IdRacun = selektovaniRacun.IdRacun,
                Datum = dateTimePicker1.Value,
                IdGledalac = (int)cmbGledalac.SelectedValue,
                IdBioskop = bioskop.IdBioskop,
                UkupnaCena = txtUkupnaCena.Text != "" ? double.Parse(txtUkupnaCena.Text) : 0
            };

            Poruka zahtev = new Poruka
            {
                Operacija = Operacija.IzmeniRacun,
                Object = r
            };

            klijent.PošaljiPoruku(zahtev);
            Poruka odgovor = klijent.PrimiPoruku();

            if (odgovor.Operacija == Operacija.Uspešno)
            {
                MessageBox.Show("Račun uspešno izmenjen.");
            }
            else
            {
                MessageBox.Show("Greška pri izmeni računa.");
            }
        }

        private void btnDetalji_Click(object sender, EventArgs e)
        {
            if (dgvRacuni.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selektujte račun iz tabele.");
                return;
            }

            PrikazRacuna prikaz = (PrikazRacuna)dgvRacuni.SelectedRows[0].DataBoundItem;

            selektovaniRacun = new Racun
            {
                IdRacun = prikaz.IdRacun,
                IdGledalac = prikaz.IdGledalac,
                IdBioskop = prikaz.IdBioskop,
                UkupnaCena = prikaz.UkupnaCena,
                Datum = prikaz.Datum
            };

           
            foreach (var item in cmbGledalac.Items)
            {
                Gledalac g = (Gledalac)item;
                if (g.IdGledalac == selektovaniRacun.IdGledalac)
                {
                    cmbGledalac.SelectedItem = g;
                    break;
                }
            }

            
            dateTimePicker1.Value = selektovaniRacun.Datum;
            txtUkupnaCena.Text = selektovaniRacun.UkupnaCena.ToString("F2");

          
            txtBioskop.Text = bioskop.NazivBioskopa;

            
            idRacun = selektovaniRacun.IdRacun;


            if (dgvRacunStavke.SelectedRows.Count > 0)
            {
                var stavka = (PrikazStavkeRacuna)dgvRacunStavke.SelectedRows[0].DataBoundItem;
                UcStavkaRacunacs uc = new UcStavkaRacunacs();
                uc.Klijent = klijent;
                uc.Bioskop = bioskop;
                uc.IdRacun = selektovaniRacun.IdRacun;
                uc.StavkaDodata += (razlikaUCeni) =>
                {
                  

                    OsvežiDGV(); 
                    Poruka azuriraj = new Poruka
                    {
                        Operacija = Operacija.AzurirajUkupnuCenu,
                        Object = Tuple.Create(idRacun, ukupnaCena)
                    };

                    klijent.PošaljiPoruku(azuriraj);
                    Poruka odgovor = klijent.PrimiPoruku();

                    if (odgovor.Operacija != Operacija.Uspešno)
                    {
                        MessageBox.Show("Greška prilikom ažuriranja ukupne cene u bazi.");
                    }
                };
                uc.StavkaPromenjena += () =>
                {
                    OsvežiDGV();
                    OsvežiTabeluRacuna();
                };
                uc.UcitajFilmove();
                uc.PostaviStavku(stavka); 
                pnlStavka.Controls.Clear();
                pnlStavka.Controls.Add(uc);
            }
            OsvežiDGV();
            
        }

        private void btnObriši_Click(object sender, EventArgs e)
        {
            if (dgvRacuni.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selektujte račun koji želite da obrišete.");
                return;
            }

            selektovaniRacun = (Racun)dgvRacuni.SelectedRows[0].DataBoundItem;

            Poruka zahtev = new Poruka
            {
                Operacija = Operacija.ObrisiRacun,
                Object = new Racun { IdRacun = selektovaniRacun.IdRacun } 
            };

            klijent.PošaljiPoruku(zahtev);
            Poruka odgovor = klijent.PrimiPoruku();

            if (odgovor.Operacija == Operacija.Uspešno)
            {
                MessageBox.Show("Račun uspešno obrisan.");

                
                dgvRacuni.DataSource = null;
                dgvRacuni.DataSource = Kontroler.Instance.VratiRacun(new Racun() { IdBioskop = bioskop.IdBioskop });

                
                txtUkupnaCena.Clear();
                dateTimePicker1.Value = DateTime.Today;
                cmbGledalac.SelectedIndex = -1;
                dgvRacunStavke.DataSource = null;
                pnlStavka.Controls.Clear();
            }
            else
            {
                MessageBox.Show("Greška pri brisanju računa.");
            }
        }
        private void OsvežiTabeluRacuna()
        {
            dgvRacuni.DataSource = null;
            dgvRacuni.DataSource = Kontroler.Instance.VratiRacun(new Racun
            {
                IdBioskop = bioskop.IdBioskop
            });
            dgvRacuni.Columns["IdGledalac"].Visible = false;
            dgvRacuni.Columns["IdBioskop"].Visible = false;
        }
    }
}
