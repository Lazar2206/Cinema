using KlijentskaStrana.GUIKontroler;
using System;
using System.Windows.Forms;

namespace KlijentskaStrana
{
    public partial class FrmFilm : Form
    {
        private FilmKontroler filmKontroler;
        public FrmFilm()
        {
            InitializeComponent();
            filmKontroler = new FilmKontroler(this);
        }
        
      
        private void btnDodaj_Click(object sender, EventArgs e)
        {
            filmKontroler.DodajFilm();
        }
     
        private void btnGlavna_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
