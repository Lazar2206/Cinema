using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerskaStrana
{
    public partial class FrmServer : Form
    {
        private Server server;
        private bool kraj;
        public FrmServer()
        {
            InitializeComponent();
        }

        private void btnPokreni_Click(object sender, EventArgs e)
        {
            server = new Server();
            server.start();
            Thread nit = new Thread(server.Accept);
            nit.Start();
            btnPokreni.Enabled = false;
           
        }

     
    }
}
