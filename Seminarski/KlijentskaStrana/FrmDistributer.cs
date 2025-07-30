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
            distributerKontroler = new DistributerKontroler(this);
            distributerKontroler.OsveziTabelu();
        }
        public TextBox TxtNaziv => txtNazivDistributera;
        public DataGridView Dgv => dgvDistributeri;
        public Panel Panel => pnlDistributer;

        private void btnKreiraj_Click(object sender, EventArgs e)
        {
            distributerKontroler.KreirajDistributera();
        }

        private void btnPretraži_Click(object sender, EventArgs e)
        {
            distributerKontroler.PretraziDistributere();
        }

        private void btnDetalji_Click(object sender, EventArgs e)
        {
            distributerKontroler.PrikaziDetalje();
        }
       

        private void btnGlavna_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
