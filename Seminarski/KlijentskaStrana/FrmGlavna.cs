using Domen;
using KlijentskaStrana.GUIKontroler;
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

        public FrmGlavna()
        {
            InitializeComponent();
            

        }

        private void gledalacToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FrmGledalac frm = new FrmGledalac();
            frm.ShowDialog();

        }

        private void btnKreiraj_Click(object sender, EventArgs e)
        {

        }

        private void distributerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDistributer frm = new FrmDistributer(klijent);
            frm.ShowDialog();
        }

        private void mestoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMesto frm = new FrmMesto();
            frm.ShowDialog();
        }

        private void filmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmFilm frm = new FrmFilm();
            frm.ShowDialog();
        }

        private void računToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRačun frm = new FrmRačun();
            frm.ShowDialog();
        }

        private void bioskopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBioskop frm = new FrmBioskop();
            frm.ShowDialog();
        }

      
    }
}
