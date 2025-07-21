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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace KlijentskaStrana
{
    public partial class FrmDistributer : Form
    {
        private Bioskop bioskop;
        private Klijent klijent;
        private string poslednjeIme = "";
        public FrmDistributer(Klijent klijent, Bioskop bioskop)
        {
            InitializeComponent();
            this.bioskop = bioskop;
            this.klijent = klijent;
        }

        private void btnKreiraj_Click(object sender, EventArgs e)
        {
            Distributer d = new Distributer
            {
                NazivDistributera = txtNazivDistributera.Text,
            };


            if (string.IsNullOrWhiteSpace(d.NazivDistributera))
            {
                MessageBox.Show("Sistem ne može da kreira distributera");
                return;
            }

            UcDistributer uc = new UcDistributer();
            uc.Distributer = d;
            uc.Klijent = klijent;
            uc.DistributerAzuriran += (s, e2) => OsveziDistributere();
            uc.PopuniPolja();


            pnlDistributer.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            pnlDistributer.Controls.Add(uc);
        }

        private void btnPretraži_Click(object sender, EventArgs e)
        {
            poslednjeIme = txtNazivDistributera.Text;
         

            Distributer distributer = new Distributer()
            {
                NazivDistributera = poslednjeIme,
                
            };

            dgvDistributeri.DataSource = Kontroler.Instance.VratiDistributere(distributer);

            if (dgvDistributeri.Rows.Count == 0)
            {
                MessageBox.Show("Sistem ne može da nađe distributere po zadatim kriterijume");
            }
            else
            {
                MessageBox.Show("Sistem je našao distributere po zadatom kriterijumu");
            }
        }

        private void btnDetalji_Click(object sender, EventArgs e)
        {
            if (dgvDistributeri.SelectedRows.Count > 0)
            {
                UcDistributer uc = new UcDistributer();
                uc.Distributer = (Distributer)dgvDistributeri.SelectedRows[0].DataBoundItem;
                uc.Klijent = klijent;
                uc.PopuniPolja();

                // PRVO poveži događaj
                uc.DistributerAzuriran += (s, e2) => OsveziDistributere();

                // ONDA ubaci u panel
                pnlDistributer.Controls.Clear();
                uc.Dock = DockStyle.Fill;
                pnlDistributer.Controls.Add(uc);

                MessageBox.Show("Sistem je našao distributera.");
            }
            else
            {
                MessageBox.Show("Sistem ne može da nađe distributera");
            }
        }
        private void OsveziDistributere()
        {
            Distributer kriterijum = new Distributer
            {
                NazivDistributera = poslednjeIme,

            };

            dgvDistributeri.DataSource = null;
            dgvDistributeri.DataSource = Kontroler.Instance.VratiDistributere(kriterijum);
        }

        private void btnGlavna_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
