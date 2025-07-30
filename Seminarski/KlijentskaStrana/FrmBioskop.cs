using DBBroker;
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
    public partial class FrmBioskop : Form
    {
        
        private readonly BioskopKontroler kontroler;
        public FrmBioskop()
        {
            InitializeComponent();
            kontroler = new BioskopKontroler(this);
        }
        public TextBox TxtNaziv => txtNazivBioskopa;
        public TextBox TxtAdresa => txtAdresaBioskopa;
        public TextBox TxtKorisnickoIme => txtKorisničkoIme;
        public TextBox TxtSifra => txtŠifra;
        public DataGridView Dgv => dgvBioskopi;

        private void btnGlavna_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            kontroler.DodajBioskop();

        }
       
    }
}
