

using DBBroker;
using Domen;
using Domen.DTO;
using SistemskeOperacije;

using SistemskeOperacije.SistemskeOperacije;
using System.ComponentModel;

namespace Logika
{
    public class Kontroler
    {
        private static Kontroler instance;
        private Broker broker = new Broker();
        private BindingList<Bioskop> prijavljeniBioskopi = new BindingList<Bioskop>();
        public static Kontroler Instance
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
            SOBase operacija = new SOLogin(bioskop.KorisnickoIme, bioskop.Sifra, prijavljeniBioskopi);
            operacija.ExecuteTemplate();
            Bioskop ulogovani = ((SOLogin)operacija).Result;


            return ulogovani;

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
            SOLogout operacija = new SOLogout(prijavljeniBioskop, prijavljeniBioskopi);
            operacija.ExecuteTemplate();
        }

        public List<Gledalac> VratiGledaoce(Gledalac gledalac)
        {
            var so = new SOPretražiGledaoce(gledalac);
            so.ExecuteTemplate();
            return so.Rezultat;
        
        }
        public bool PromeniGledaoca(Gledalac g)
        {
            var so = new SOPromeniGledaoca(g);
            so.ExecuteTemplate();
            return so.Uspeh;
        }

        public bool ObrišiGledalac(Gledalac gledalac)
        {
            var so = new SOObrisiGledaoca(gledalac);
            so.ExecuteTemplate();
            return so.Uspeh;
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
            var so = new SOVratiDistributere(kriterijum);
            so.ExecuteTemplate();
            List<Distributer> distributeri = so.Rezultat;
            return distributeri;
        }
        public List<Distributer> VratiSveDistributere()
        {
            var so= new SOVratiSveDistributere();
            so.ExecuteTemplate();
            List<Distributer> distributeri = so.Rezultat;
            return distributeri;
        }

        public bool KreirajDistributer(Distributer distributer)
        {

            var so = new SOKreirajDistributera(distributer);
            so.ExecuteTemplate();

            return so.Uspeh;
        }

        public bool ObrišiDistributer(Distributer distributer)
        {
            var so = new SOObrisiDistributera(distributer);
            so.ExecuteTemplate();
            return so.Uspeh;
        }

      

        public bool PromeniDistributer(Distributer distributer)
        {
            var so = new SOPromeniDistributera(distributer);
            so.ExecuteTemplate();
            return so.Uspeh;
        }



        public bool DodajStavkuRacuna(StavkaRacuna novaStavka)
        {
            var so = new SODodajStavkuRacuna(novaStavka);
            so.ExecuteTemplate();
            return so.Uspeh;
        }

        public int VratiIdNajnovijegRacuna()
        {
            var so = new SOVratiIdNajnovijegRacuna();
            so.ExecuteTemplate();
            return so.Id;
        }

        public List<PrikazStavkeRacuna> VratiStavkeRacuna(int idRacun)
        {
            SOVratiStavkeRacuna so = new SOVratiStavkeRacuna(idRacun);
            so.ExecuteTemplate();
            List<PrikazStavkeRacuna> sveStavke = so.Rezultat;
            return sveStavke;
        }

        public bool KreirajRacun(Racun racun)
        {
            var so = new SOKreirajRacun(racun);
            so.ExecuteTemplate();
            return so.Uspeh;
        }

        public bool AzurirajUkupnuCenu(int idRacun, double novaCena)
        {
            Racun r = new Racun
            {
                IdRacun = idRacun,
                UkupnaCena = novaCena
            };

            var so = new SOAzurirajCenu(r);
            so.ExecuteTemplate();
            return so.Uspeh;
        }

        public List<PrikazRacuna> VratiRacun(Racun racun)
        {
            var so = new SOPretraziRacune(racun);
            so.ExecuteTemplate();
            List<PrikazRacuna> racuni = so.Rezultat;
            return racuni;
        }

        public bool IzmeniStavkuRacuna(StavkaRacuna izmenjenaStavka)
        {
            var so = new SOPromeniStavkuRacuna(izmenjenaStavka);
            so.ExecuteTemplate(); 

            return so.Uspeh;
        }

        public bool IzmeniRacun(Racun racun)
        {
            var so = new SOPromeniRacun(racun);
            so.ExecuteTemplate();
            return so.Uspeh;
        }

        public bool ObrisiRacun(Racun obrisanRacun)
        {
            var so = new SOObrisiRacun(obrisanRacun);
            so.ExecuteTemplate();
            return so.Uspeh;
        }

        public bool ObrisiStavkuRacuna(StavkaRacuna obrisanaStavka)
        {
            var so = new SOObrisiStavkuRacuna(obrisanaStavka);
            so.ExecuteTemplate();

            return so.Uspeh;
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
           var so= new SOVratiSledeciRB(idRacun);
            so.ExecuteTemplate();
            return so.RB;
        }

        public object PretražiDistributere(Distributer kriterijum)
        {
            var so = new SOPretražiDistributera(kriterijum);
            so.ExecuteTemplate();
            return so.Rezultat;
        }

        public List<Gledalac> VratiSveGledaoce()
        {
            SOVratiSveGledaoce so = new SOVratiSveGledaoce();
            so.ExecuteTemplate();
            List<Gledalac> sviGledaoci = so.Rezultat;
            return sviGledaoci;
        }

        public BindingList<Bioskop> VratiPrijavljeneKorisnike()
        {
            return new BindingList<Bioskop>(prijavljeniBioskopi);
        }
    }
}
