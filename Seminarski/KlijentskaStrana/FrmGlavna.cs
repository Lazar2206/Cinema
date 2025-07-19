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
    public partial class FrmGlavna : Form
    {
        private Bioskop bioskop;
        private Klijent klijent;

        public FrmGlavna(Bioskop bioskop, Klijent klijent)
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



        private void gledalacToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlGledalac.Controls.Clear();
            UcGledalac ucGledalac = new UcGledalac();
            ucGledalac.Dock = DockStyle.Fill;
            pnlGledalac.Controls.Add(ucGledalac);
        }

        private void btnPretraži_Click(object sender, EventArgs e)
        {
            Gledalac gledalac = new Gledalac()
            {
                KorisničkoIme = txtIme.Text,
                IdMesto = (int)cmbMesta.SelectedValue
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

        private void btnDetalji_Click(object sender, EventArgs e)
        {
            if (dgvGledaoci.SelectedRows.Count > 0)
            {
                UcGledalac uc = new UcGledalac();
                uc.Gledalac = (Gledalac)dgvGledaoci.SelectedRows[0].DataBoundItem;
                uc.Klijent = klijent;
                uc.PopuniPolja(); // <<< OVO JE KLJUČNO

                pnlGledalac.Controls.Clear();
                uc.Dock = DockStyle.Fill;
                pnlGledalac.Controls.Add(uc);

                MessageBox.Show("Sistem je našao gledaoca");
            }

        }
    }
}
