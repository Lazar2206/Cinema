using Domen;
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
    public partial class FrmGledalac : Form
    {
        private string poslednjeIme = "";
        private int? poslednjeIdMesto = null;
        private Bioskop bioskop;
        private Klijent klijent;

        public FrmGledalac(Bioskop bioskop, Klijent klijent)
        {
            InitializeComponent();
            this.bioskop = bioskop;
            this.klijent = klijent;
            NapuniCMB();
        }
        private void NapuniCMB()
        {
            cmbMesta.DataSource = Kontroler.Instance.VratiMesta();
            cmbMesta.DisplayMember = "NazivMesta";
            cmbMesta.ValueMember = "IdMesto";
            cmbMesta.SelectedIndex = -1;
        }


        private void OsveziGledaoce()
        {
            Gledalac kriterijum = new Gledalac
            {
                Ime = poslednjeIme,
                IdMesto = poslednjeIdMesto ?? 0
            };

            dgvGledaoci.DataSource = null;
            dgvGledaoci.DataSource = Kontroler.Instance.VratiGledaoce(kriterijum);
        }





        private void btnKreiraj_Click_1(object sender, EventArgs e)
        {
            Gledalac g = new Gledalac
            {
                Ime = txtIme.Text,
                Prezime = txtPrezime.Text,
                Mejl = txtMejl.Text,
                IdMesto = (int)cmbMesta.SelectedValue,
            };

            if (string.IsNullOrWhiteSpace(g.Ime) || string.IsNullOrWhiteSpace(g.Prezime) || string.IsNullOrWhiteSpace(g.Mejl))
            {
                MessageBox.Show("Sistem ne može da kreira gledaoca");
                return;
            }

            UcGledalac uc = new UcGledalac();
            uc.Gledalac = g;
            uc.Klijent = klijent;
            uc.PopuniPolja();


            pnlGledalac.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            pnlGledalac.Controls.Add(uc);
        }

        private void btnPretraži_Click_1(object sender, EventArgs e)
        {
            poslednjeIme = txtIme.Text;
            poslednjeIdMesto = cmbMesta.SelectedValue != null ? (int?)cmbMesta.SelectedValue : null;

            Gledalac gledalac = new Gledalac()
            {
                Ime = poslednjeIme,
                IdMesto = poslednjeIdMesto ?? 0
            };

            dgvGledaoci.DataSource = Kontroler.Instance.VratiGledaoce(gledalac);

            if (dgvGledaoci.Rows.Count == 0)
            {
                MessageBox.Show("Sistem ne može da nađe gledaoce po zadatim kriterijume");
            }
            else
            {
                MessageBox.Show("Sistem je našao gledaoce po zadatom kriterijumu");
            }
        }

        private void btnDetalji_Click_1(object sender, EventArgs e)
        {
            if (dgvGledaoci.SelectedRows.Count > 0)
            {
                UcGledalac uc = new UcGledalac();
                uc.Gledalac = (Gledalac)dgvGledaoci.SelectedRows[0].DataBoundItem;
                uc.Klijent = klijent;
                uc.PopuniPolja();

                // PRVO poveži događaj
                uc.GledalacAzuriran += (s, e2) => OsveziGledaoce();

                // ONDA ubaci u panel
                pnlGledalac.Controls.Clear();
                uc.Dock = DockStyle.Fill;
                pnlGledalac.Controls.Add(uc);

                MessageBox.Show("Sistem je našao gledaoca.");
            }
            else
            {
                MessageBox.Show("Sistem ne može da nađe gledaoca");
            }
        }

        private void btnGlavna_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
