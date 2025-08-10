using KlijentskaStrana.Forme;
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
    public partial class FrmStavkaRacuna : Form
    {
        private readonly StavkaRacunaKontroler kontroler;
        
        public FrmStavkaRacuna()
        {
            InitializeComponent();
            kontroler = new StavkaRacunaKontroler(this);
            this.Load += FrmStavkaRacuna_Load;
            
            
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

        private void FrmStavkaRacuna_Load(object sender, EventArgs e)
        {
            kontroler.UcitajFilmove();

            var stavka = Session.Session.Instance.TrenutnaStavkaRacuna;
            if (stavka != null)
            {
                txtCena.Text = stavka.Cena.ToString();
                txtOpis.Text = stavka.Opis;
                cmbFilm.SelectedValue = stavka.IdFilm;
            }
        }

        public TextBox TxtOpis => txtOpis;
        public TextBox TxtCena => txtCena;
        public ComboBox CmbFilm => cmbFilm;
        public Button BtnDodaj => btnDodaj;
        public Button BtnIzmeni => btnIzmeniStavku;
        public Button BtnObrisi => btnObrisi;
    }
}
