

using DBBroker;
using Domen;
using Domen.DTO;
using SistemskeOperacije;
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
            SOBase operacija = new SOLogin(bioskop.KorisnickoIme, bioskop.Sifra);
            operacija.ExecuteTemplate();
            return ((SOLogin)operacija).Result;
         
        }
        public List<Mesto> VratiMesta(Gledalac kriterijum)
        {
            SOVratiSvaMesta so = new SOVratiSvaMesta();
            so.ExecuteTemplate();
            List<Mesto> svaMesta = so.Rezultat;
            return svaMesta;
        }
        public List<Mesto> VratiMesta()
        {
            SOVratiSvaMesta so = new SOVratiSvaMesta();
            so.ExecuteTemplate();
            List<Mesto> svaMesta = so.Rezultat;
            return svaMesta;
        }
        public void Logout(Bioskop prijavljeniBioskop)
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
            SOBase operacija= new SOKreirajGledalac(gledalac);
            operacija.ExecuteTemplate();
            return true;
        }

        public bool KreirajMesto(Mesto mesto)
        {
            var so = new SOKreirajMesto(mesto);
            so.ExecuteTemplate();

            return (so.Uspeh);
        }

        public List<Film> VratiFilmove()
        {
            SOVratiSveFilmove so = new SOVratiSveFilmove();
            so.ExecuteTemplate();
            List<Film> sviFilmovi = so.Rezultat;
            return sviFilmovi;
        }

        public bool KreirajFilm(Film film)
        {
            var so = new SOKreirajFilm(film);
            so.ExecuteTemplate();

            return so.Uspeh;
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

        public List<PrikazRacuna> VratiRacun(Racun racun)
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

        public bool ObrisiRacun(Racun obrisanRacun)
        {
            return broker.ObrisiRacun(obrisanRacun.IdRacun);
        }

        public bool ObrisiStavkuRacuna(StavkaRacuna obrisanaStavka)
        {
            if (broker.ObrisiStavkuRacuna(obrisanaStavka.IdRacun,obrisanaStavka.Rb))
            {
                broker.AzurirajUkupnuCenuRacuna(obrisanaStavka.IdRacun);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool KreirajBioskop(Bioskop bioskop)
        {
            var so = new SOKreirajBioskop(bioskop);
            so.ExecuteTemplate(); 
            return so.Uspeh;
        }
        public List<Bioskop> VratiSveBioskope()
        {
           var so = new SOVratiSveBioskope();
            so.ExecuteTemplate();
            List<Bioskop> bioskopi = so.Rezultat;
            return bioskopi;
        }

        public int VratiSledeciRbZaRacun(int idRacun)
        {
            return broker.VratiSledeciRB(idRacun);
        }
    }
}
