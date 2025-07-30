using KlijentskaStrana.GUIKontroler;
using System;
using System.Windows.Forms;

namespace KlijentskaStrana
{
    public partial class FrmLoginBioskop : Form
    {
        
        private LoginKontroler kontroler;
        public FrmLoginBioskop()
        {
            InitializeComponent();
            kontroler = new LoginKontroler();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            kontroler.Login(this);
       
        }
        
    }
}
