

using DBBroker;
using Domen;
using System.ComponentModel;

namespace Logika
{
    public class Kontroler
    {
        private static Kontroler instance;
        private Broker broker = new Broker();
        private BindingList<Bioskop> prijavljeniBioskopi = new BindingList<Bioskop>();
        public static Kontroler Instance//telefon do šefa
        {
            get
            {
                if (instance == null)
                {
                    instance = new Kontroler();
                }
                return instance;
            }
        }

        public bool Login(Bioskop bioskop)
        {
            foreach (Bioskop k in broker.VratiSveBioskope())
            {
                if (k.KorisnickoIme == bioskop.KorisnickoIme && k.Sifra == bioskop.Sifra)
                {
                    prijavljeniBioskopi.Add(k);
                    return true;
                }
            }
            return false;
        }
        public List<Mesto> VratiMesta()
        {
            return broker.VratiMesta();
        }
        public void Logout()
        {
            
        }

        public List<Gledalac> VratiGledaoce(Gledalac gledalac)
        {
            return broker.VratiGledaoce(gledalac);
        }

        public bool PromeniGledaoca(Gledalac gledalac)
        {
            return broker.PromeniGledaoca(gledalac);
        }

        public bool ObrišiGledalac(Gledalac gledalac)
        {
            return broker.ObrišiGledalac(gledalac);
        }

        public bool KreirajGledalac(Gledalac gledalac)
        {
            return broker.KreirajGledalac(gledalac);
        }
    }
}
