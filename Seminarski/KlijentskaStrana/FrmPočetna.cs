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
    public partial class FrmPočetna : Form
    {
        public FrmPočetna()
        {
            InitializeComponent();
        }

        private void btnBioskop_Click(object sender, EventArgs e)
        {
            FrmLoginBioskop frm = new FrmLoginBioskop();
            frm.ShowDialog();
        }

        private void btnGledalac_Click(object sender, EventArgs e)
        {
            FrmLoginGledalac frm = new FrmLoginGledalac();
            frm.ShowDialog();
        }
    }
}
