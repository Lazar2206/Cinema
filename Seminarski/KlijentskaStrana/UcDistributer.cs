using Domen;
using Komunikacija;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace KlijentskaStrana
{
    public partial class UcDistributer : UserControl
    {
        public event EventHandler DistributerAzuriran;
        public Distributer Distributer { get; set; }
        public Klijent Klijent { get; set; }
        public UcDistributer()
        {
            InitializeComponent();
        }

        private void btnZapamti_Click(object sender, EventArgs e)
        {
            Distributer d = new Distributer
            {
                NazivDistributera = txtNazivDistributera.Text,
            };
          
            Poruka zahtev = new Poruka
            {
                Object = d,
                Operacija = Operacija.KreirajDistributer,
            };
            Klijent.PošaljiPoruku(zahtev);
            Poruka odgovor = Klijent.PrimiPoruku();
            if (odgovor.Operacija == Operacija.Uspešno)
            {
                MessageBox.Show("Sistem je zapamtio distributera");
                txtNazivDistributera.Text = string.Empty;
              
                DistributerAzuriran?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                MessageBox.Show("Sistem ne može da zapamti gledaoca");
            }
        }
        public void PopuniPolja()
        {
            if (Distributer != null)
            {
                txtNazivDistributera.Text = Distributer.NazivDistributera;
            }
        }
        private void btnUredi_Click(object sender, EventArgs e)
        {
            Distributer d = new Distributer
            {
                 IdDistributer= Distributer.IdDistributer,
                NazivDistributera = txtNazivDistributera.Text,
            };
            Poruka zahtev = new Poruka
            {
                Object = d,
                Operacija = Operacija.PromeniDistributera,
            };
            Klijent.PošaljiPoruku(zahtev);
            Poruka odgovor = Klijent.PrimiPoruku();
            if (odgovor.Operacija == Operacija.Uspešno)
            {
                MessageBox.Show("Sistem je zapamtio distributera");
                DistributerAzuriran?.Invoke(this, EventArgs.Empty);
                txtNazivDistributera.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Sistem ne može da zapamti distributera");

            }
        }

        private void btnObriši_Click(object sender, EventArgs e)
        {
            Poruka zahtev = new Poruka
            {
                Object = Distributer,
                Operacija = Operacija.ObrišiDistributer,
            };
            Klijent.PošaljiPoruku(zahtev);
            Poruka odgovor = Klijent.PrimiPoruku();
            if (odgovor.Operacija == Operacija.Uspešno)
            {
                MessageBox.Show("Sistem je obrisao distributera");
                DistributerAzuriran?.Invoke(this, EventArgs.Empty);
                txtNazivDistributera.Text = string.Empty;
            }
            else
            {
                DistributerAzuriran?.Invoke(this, EventArgs.Empty);
                MessageBox.Show("Sistem ne može da obriše distributera");
            }
        }
    }
}
