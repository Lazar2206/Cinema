using KlijentskaStrana.GUIKontroler;
using System;
using System.Windows.Forms;


namespace KlijentskaStrana
{
    public partial class FrmDistributer : Form
    {
        private readonly DistributerKontroler distributerKontroler;
        
        public FrmDistributer(Klijent klijent)
        {
            InitializeComponent();
            distributerKontroler = new DistributerKontroler(this, klijent);
            distributerKontroler.OsveziTabelu();
        }
        public TextBox TxtNaziv => txtNazivDistributera;
        public DataGridView Dgv => dgvDistributeri;


        private void btnKreiraj_Click(object sender, EventArgs e)
        {
            distributerKontroler.KreirajDistributera();
        }

        private void btnPretraži_Click(object sender, EventArgs e)
        {
            distributerKontroler.PretraziDistributere();
        }

       


        private void btnGlavna_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAžuriraj_Click(object sender, EventArgs e)
        {
            distributerKontroler.IzmeniDistributera();
        }

        private void btnObriši_Click(object sender, EventArgs e)
        {
            distributerKontroler.ObrisiDistributera();
        }
    }
}
