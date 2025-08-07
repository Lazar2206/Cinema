using KlijentskaStrana.GUIKontroler;
using System;
using System.Windows.Forms;


namespace KlijentskaStrana
{
    public partial class FrmGledalac : Form
    {
        private  GledalacKontroler gledalacKontroler;


        public FrmGledalac()
        {
            InitializeComponent();
            gledalacKontroler = new GledalacKontroler(this);
            gledalacKontroler.NapuniCmbMesta();
        }
        private void btnKreiraj_Click_1(object sender, EventArgs e)
        {
            gledalacKontroler.OtvoriFormuZaUnos();
            
        }

        private void btnPretraži_Click_1(object sender, EventArgs e)
        {
            gledalacKontroler.PretraziGledaoce();
        }

        private void btnDetalji_Click_1(object sender, EventArgs e)
        {
            gledalacKontroler.OtvoriDetalje();

        }
        public ComboBox CMBMesta => cmbMesta;
        public TextBox TXTIme => txtIme;
        public DataGridView DGVGledaoci => dgvGledaoci;
        public Panel Panel => pnlGledalac;

        private void btnGlavna_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
