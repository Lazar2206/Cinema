
using KlijentskaStrana.GUIKontroler;
using System;
using System.Windows.Forms;

namespace KlijentskaStrana
{
    public partial class FrmMesto : Form
    {
        private MestoKontroler mestoKontroler;
        public FrmMesto()
        {
            InitializeComponent();
            mestoKontroler = new MestoKontroler(this);
            mestoKontroler.NapuniDGV();
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            mestoKontroler.KreirajMesto(txtNazivMesta.Text);

        }

        private void btnGlavna_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
