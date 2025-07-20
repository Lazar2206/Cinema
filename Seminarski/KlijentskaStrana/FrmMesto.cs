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
    public partial class FrmMesto : Form
    {
        Klijent klijent = new Klijent();
        private string poslednjeIme = "";
        private int? poslednjeIdMesto = null;
        public FrmMesto(Klijent klijent)
        {
            InitializeComponent();
            this.klijent = klijent;
            NapuniDGV();
        }

        private void NapuniDGV()
        {
            dgvMesta.DataSource = null;
            dgvMesta.DataSource = Kontroler.Instance.VratiMesta();
        }



        private void btnDodaj_Click(object sender, EventArgs e)
        {
            Mesto mesto = new Mesto
            {
                NazivMesta = txtNazivMesta.Text
            };
            if (string.IsNullOrWhiteSpace(mesto.NazivMesta))
            {
                MessageBox.Show("Sistem ne može da kreira gledaoca");
                return;
            }
            else
            {
                Poruka zahtev = new Poruka
                {
                    Object = mesto,
                    Operacija = Operacija.KreirajMesto,
                };
                klijent.PošaljiPoruku(zahtev);
                Poruka odgovor = klijent.PrimiPoruku();
                if (odgovor.Operacija == Operacija.Uspešno)
                {
                    MessageBox.Show("Sistem je kreirao mesto");
                    txtNazivMesta.Text = string.Empty;
                    OsveziGledaoce();
                }
                else
                {
                    MessageBox.Show("Sistem ne može da kreira mesto");
                }
            }

        }
        private void OsveziGledaoce()
        {

            dgvMesta.DataSource = null;
            dgvMesta.DataSource = Kontroler.Instance.VratiMesta();
        }

        private void btnGlavna_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
