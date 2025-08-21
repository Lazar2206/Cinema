using Domen;
using Logika;
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
        private BindingList<Bioskop> korisnici = new BindingList<Bioskop>();
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
            Thread nit1 = new Thread(NapuniDGV);
            nit1.Start();
            btnZaustavi.Enabled = true;

        }

        private void NapuniDGV()
        {
            kraj = false;
            while (!kraj)
            {
                Thread.Sleep(4000);
                Invoke(new Action(() =>
                {
                    var noviPodaci = Kontroler.Instance.VratiPrijavljeneKorisnike();
                    korisnici.Clear();
                    foreach (var k in noviPodaci)
                    {
                        korisnici.Add(k);
                    }
                    dgvKorisnici.DataSource = null;
                    dgvKorisnici.DataSource = korisnici;
                    dgvKorisnici.Columns[5].Visible = false;
                    dgvKorisnici.Columns[6].Visible = false;
                    dgvKorisnici.Columns[7].Visible = false;
                    dgvKorisnici.Columns[8].Visible = false;
                    dgvKorisnici.Columns[9].Visible = false;
                    dgvKorisnici.Columns[10].Visible = false;
                }));
            }
        }

        private void btnZaustavi_Click(object sender, EventArgs e)
        {
            kraj = true;
            dgvKorisnici.DataSource = null;
            server.Stop();
            btnZaustavi.Enabled = false;
            btnPokreni.Enabled = true;
            server = null;
        }
    }
}
