

using DBBroker;
using Domen;
using Domen.DTO;
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

        public Bioskop Login(Bioskop bioskop)
        {
            foreach (Bioskop k in broker.VratiSveBioskope())
            {
                if (k.KorisnickoIme == bioskop.KorisnickoIme && k.Sifra == bioskop.Sifra)
                {
                    prijavljeniBioskopi.Add(k);
                    return k; 
                }
            }
            return null;
        }
        public List<Mesto> VratiMesta(Gledalac kriterijum)
        {
            return broker.VratiMesta();
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

        public bool KreirajMesto(Mesto mesto)
        {
           return broker.KreirajMesto(mesto);
        }

        public List<Film> VratiFilmove()
        {
            return broker.VratiFilmove();
        }

        public bool KreirajFilm(Film film)
        {
            return broker.KreirajFilm(film);
        }

        public List<Distributer> VratiDistributere(Distributer kriterijum)
        {
          return broker.VratiDistributere(kriterijum);
        }

        public bool KreirajDistributer(Distributer distributer)
        {
            return broker.KreirajDistributera(distributer);
        }

        public bool ObrišiDistributer(Distributer distributer)
        {
            return broker.ObrisiDistributera(distributer);
        }

      

        public bool PromeniDistributer(Distributer distributer)
        {
            return broker.PromeniDistributera(distributer);
        }

        public List<Gledalac> VratiGledaoce()
        {
            return broker.VratiGledaoce();
        }

        public bool DodajStavkuRacuna(StavkaRacuna stavka)
        {
            return broker.DodajStavkuRacuna(stavka);
        }

        public int VratiIdNajnovijegRacuna()
        {
            return broker.VratiIdNajnovijegRacuna();
        }

        public List<PrikazStavkeRacuna> VratiStavkeRacuna(int idRacun)
        {
            return broker.VratiStavkeRacuna( idRacun);
        }

        public bool KreirajRacun(Racun racun)
        {
            return broker.KreirajRacun(racun);
        }

        public bool AzurirajUkupnuCenu(int item1, double item2)
        {
            return broker.AzurirajUkupnuCenu(item1, item2);
        }

        public List<Racun> VratiRacun(Racun racun)
        {
            return broker.VratiRacune(racun);
        }

        public bool IzmeniStavkuRacuna(StavkaRacuna izmenjenaStavka)
        {
            if (broker.IzmeniStavkuRacuna(izmenjenaStavka))
            {
                broker.AzurirajUkupnuCenuRacuna(izmenjenaStavka.IdRacun);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IzmeniRacun(Racun izmenjenRacun)
        {
            return broker.IzmeniRacun(izmenjenRacun);
        }
    }
}
