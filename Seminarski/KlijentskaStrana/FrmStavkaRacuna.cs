using KlijentskaStrana.Forme;
using KlijentskaStrana.GUIKontroler;

using System;

using System.Windows.Forms;

namespace KlijentskaStrana
{
    public partial class FrmStavkaRacuna : Form
    {
        private readonly StavkaRacunaKontroler kontroler;

        
        public FrmStavkaRacuna(RacunKontroler racunKontroler)
        {
            InitializeComponent();
            kontroler = new StavkaRacunaKontroler(this,racunKontroler);
            
            
            
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            kontroler.DodajStavku();
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            kontroler.ObrisiStavku();
        }

        private void btnIzmeniStavku_Click(object sender, EventArgs e)
        {
            kontroler.IzmeniStavku();
        }

       

        public TextBox TxtOpis => txtOpis;
        public TextBox TxtCena => txtCena;
        public ComboBox CmbFilm => cmbFilm;
        public Button BtnDodaj => btnDodaj;
        public Button BtnIzmeni => btnIzmeniStavku;
        public Button BtnObrisi => btnObrisi;
    }
}
