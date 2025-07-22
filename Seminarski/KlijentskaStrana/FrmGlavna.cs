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
    public partial class FrmGlavna : Form
    {

        private Bioskop bioskop;
        private Klijent klijent;

        public FrmGlavna(Bioskop bioskop, Klijent klijent)
        {
            InitializeComponent();
            this.bioskop = bioskop;
            this.klijent = klijent;
        }

        private void gledalacToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FrmGledalac frm = new FrmGledalac(bioskop, klijent);
            frm.ShowDialog();

        }

        private void btnKreiraj_Click(object sender, EventArgs e)
        {

        }

        private void distributerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDistributer frm = new FrmDistributer(klijent, bioskop);
            frm.ShowDialog();
        }

        private void mestoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMesto frm = new FrmMesto(klijent);
            frm.ShowDialog();
        }

        private void filmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmFilm frm = new FrmFilm(klijent, bioskop);
            frm.ShowDialog();
        }

        private void računToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRačun frm = new FrmRačun(klijent, bioskop);
            frm.ShowDialog();
        }

        private void bioskopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBioskop frm = new FrmBioskop(klijent, bioskop);
            frm.ShowDialog();
        }
    }
}
