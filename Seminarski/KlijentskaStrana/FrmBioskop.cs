
using KlijentskaStrana.GUIKontroler;

using System;

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
