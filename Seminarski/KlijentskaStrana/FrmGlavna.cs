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

        }
    }
}
