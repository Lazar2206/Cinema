
using KlijentskaStrana.GUIKontroler;

using System;

using System.Windows.Forms;

namespace KlijentskaStrana
{
    public partial class FrmRačun : Form
    {
        private RacunKontroler racunKontroler;
      
        public FrmRačun()
        {
            InitializeComponent();
            racunKontroler = new RacunKontroler(this);
        }

        private void cmbBioskop_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            racunKontroler.DodajStavku();
        }

        private void btnKreirajRačun_Click(object sender, EventArgs e)
        {
            racunKontroler.KreirajRacun();
        }

        private void btnGlavna_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPretraži_Click(object sender, EventArgs e)
        {
            racunKontroler.PretraziRacune();
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            racunKontroler.IzmeniRacun();
        }

        private void btnDetalji_Click(object sender, EventArgs e)
        {
            racunKontroler.PrikaziDetalje();

        }

        private void btnObriši_Click(object sender, EventArgs e)
        {
            racunKontroler.ObrisiRacun();
        }
       
        public ComboBox CmbGledalac => cmbGledalac;
        public DateTimePicker DtpDatum => dateTimePicker1;
        public TextBox TxtBioskop => txtBioskop;
        public TextBox TxtUkupnaCena => txtUkupnaCena;
        public Panel PnlStavka => pnlStavka;
        public DataGridView DgvRacuni => dgvRacuni;
        public DataGridView DgvRacunStavke => dgvRacunStavke;
    }
}
