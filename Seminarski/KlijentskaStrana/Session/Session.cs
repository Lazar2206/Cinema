using Domen;
using Domen.DTO;
using Microsoft.Build.Tasks.Deployment.Bootstrapper;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlijentskaStrana.Session
{
    public class Session
    {
        private static Session instance;
        private Session() { }

        public static Session Instance
        {
            get
            {
                if (instance == null)
                    instance = new Session();
                return instance;
            }
        }

        public Klijent Klijent { get; set; }
        public Bioskop CurrentBioskop { get; set; }
        public PrikazStavkeRacuna TrenutnaStavkaRacuna { get; set; }
        public Racun TrenutniRacun { get; set; }
    }
}
