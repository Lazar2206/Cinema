using Domen;
using Komunikacija;
using Logika;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerskaStrana
{
    public class ClientHandler
    {
        private Socket klijent;

        private JsnNetworkSerializer json;
        private Gledalac gledalac;
        private Mesto mesto;
        private Film film;
        private Distributer distributer;
        private Racun racun;
        private bool kraj;
        private Socket socket;
        public Bioskop prijavljeniBioskop { get; set; }
        private List<ClientHandler> prijavljeniKorisnici = new List<ClientHandler>();
        public ClientHandler(Socket socket, List<ClientHandler> prijavljeniKorisnici)
        {
            this.socket = socket;
            json = new JsnNetworkSerializer(socket);
            this.prijavljeniKorisnici = prijavljeniKorisnici;
        }
        public void PošaljiPoruku(Poruka poruka)
        {
            json.PosaljiPoruku(poruka);
        }
        public Poruka PrimiPoruku()
        {
            return json.PrimiPoruku<Poruka>();
        }
        public void HandleClient()
        {
            try
            {
                kraj = false;
                while (!kraj)
                {

                    
                    Poruka zahtev = PrimiPoruku();
                    Poruka odgovor = new Poruka()
                    {
                        Object = new object(),
                    };
                    

                    switch (zahtev.Operacija)
                    {
                        case Operacija.Login:
                            Bioskop bioskop1 = json.ReadType<Bioskop>(zahtev.Object);
                            Bioskop prijavljeni = Kontroler.Instance.Login(bioskop1);
                            if (prijavljeni != null)
                            {
                                odgovor.Operacija = Operacija.Uspešno;
                                odgovor.Object = prijavljeni; 
                                prijavljeniBioskop = prijavljeni;
                            }

                            PošaljiPoruku(odgovor);
                            break;
                        case Operacija.PromeniGledaoca:
                            gledalac = json.ReadType<Gledalac>(zahtev.Object);
                            if(Kontroler.Instance.PromeniGledaoca(gledalac))
                            {
                                odgovor.Operacija = Operacija.Uspešno;
                            }
                            else
                            {
                                odgovor.Operacija = Operacija.Neuspešno;
                            }
                            PošaljiPoruku(odgovor);
                            break;
                        case Operacija.KreirajGledalac:
                            gledalac = json.ReadType<Gledalac>(zahtev.Object);
                            if (Kontroler.Instance.KreirajGledalac(gledalac))
                            {
                                odgovor.Operacija = Operacija.Uspešno;
                            }
                            else
                            {
                                odgovor.Operacija = Operacija.Neuspešno;
                            }
                            PošaljiPoruku(odgovor);
                            break;
                        case Operacija.ObrišiGledalac:
                            gledalac = json.ReadType<Gledalac>(zahtev.Object);
                            if (Kontroler.Instance.ObrišiGledalac(gledalac))
                            {
                                odgovor.Operacija = Operacija.Uspešno;
                            }
                            else
                            {
                                odgovor.Operacija = Operacija.Neuspešno;
                            }
                            PošaljiPoruku(odgovor);
                            break;
                        case Operacija.KreirajMesto:
                            mesto= json.ReadType<Mesto>(zahtev.Object);
                            if (Kontroler.Instance.KreirajMesto(mesto))
                            {
                                odgovor.Operacija = Operacija.Uspešno;
                            }
                            else
                            {
                                odgovor.Operacija = Operacija.Neuspešno;
                            }
                            PošaljiPoruku(odgovor);
                            break;
                        case Operacija.KreirajFilm:
                            film = json.ReadType<Film>(zahtev.Object);
                            if (Kontroler.Instance.KreirajFilm(film))
                            {
                                odgovor.Operacija = Operacija.Uspešno;
                            }
                            else
                            {
                                odgovor.Operacija = Operacija.Neuspešno;
                            }
                            PošaljiPoruku(odgovor);
                            break;
                        case Operacija.PromeniDistributera:
                            distributer = json.ReadType<Distributer>(zahtev.Object);
                            if (Kontroler.Instance.PromeniDistributer(distributer))
                            {
                                odgovor.Operacija = Operacija.Uspešno;
                            }
                            else
                            {
                                odgovor.Operacija = Operacija.Neuspešno;
                            }
                            PošaljiPoruku(odgovor);
                            break;
                        case Operacija.KreirajDistributer:
                            distributer = json.ReadType<Distributer>(zahtev.Object);
                            if (Kontroler.Instance.KreirajDistributer(distributer))
                            {
                                odgovor.Operacija = Operacija.Uspešno;
                            }
                            else
                            {
                                odgovor.Operacija = Operacija.Neuspešno;
                            }
                            PošaljiPoruku(odgovor);
                            break;
                        case Operacija.ObrišiDistributer:
                            distributer = json.ReadType<Distributer>(zahtev.Object);
                            if (Kontroler.Instance.ObrišiDistributer(distributer))
                            {
                                odgovor.Operacija = Operacija.Uspešno;
                            }
                            else
                            {
                                odgovor.Operacija = Operacija.Neuspešno;
                            }
                            PošaljiPoruku(odgovor);
                            break;
                        case Operacija.DodajStavkuRacuna:
                            StavkaRacuna stavka = json.ReadType<StavkaRacuna>(zahtev.Object);
                            if (Kontroler.Instance.DodajStavkuRacuna(stavka))
                            {
                                odgovor.Operacija = Operacija.Uspešno;
                            }
                            else
                            {
                                odgovor.Operacija = Operacija.Neuspešno;
                            }
                            PošaljiPoruku(odgovor);
                            break;
                        case Operacija.PretražiRacun:
                            racun = json.ReadType<Racun>(zahtev.Object);
                            if (Kontroler.Instance.KreirajRacun(racun))
                            {
                                odgovor.Operacija = Operacija.Uspešno;
                            }
                            else
                            {
                                odgovor.Operacija = Operacija.Neuspešno;
                            }
                            PošaljiPoruku(odgovor);
                            break;
                        case Operacija.AzurirajUkupnuCenu:
                            var podaci = json.ReadType<Tuple<int, double>>(zahtev.Object);
                            if (Kontroler.Instance.AzurirajUkupnuCenu(podaci.Item1, podaci.Item2))
                            {
                                odgovor.Operacija = Operacija.Uspešno;
                            }
                            else
                            {
                                odgovor.Operacija = Operacija.Neuspešno;
                            }
                            PošaljiPoruku(odgovor);
                            break;
                        case Operacija.IzmeniStavkuRacuna:
                            StavkaRacuna izmenjenaStavka = json.ReadType<StavkaRacuna>(zahtev.Object);
                            if (Kontroler.Instance.IzmeniStavkuRacuna(izmenjenaStavka))
                            {
                                odgovor.Operacija = Operacija.Uspešno;
                            }
                            else
                            {
                                odgovor.Operacija = Operacija.Neuspešno;
                            }
                            PošaljiPoruku(odgovor);
                            break;
                        case Operacija.IzmeniRacun:
                            Racun izmenjenRacun = json.ReadType<Racun>(zahtev.Object);
                            if (Kontroler.Instance.IzmeniRacun(izmenjenRacun))
                            {
                                odgovor.Operacija = Operacija.Uspešno;
                            }
                            else
                            {
                                odgovor.Operacija = Operacija.Neuspešno;
                            }
                            PošaljiPoruku(odgovor);
                            break;
                        case Operacija.ObrisiRacun:
                            Racun obrisanRacun = json.ReadType<Racun>(zahtev.Object);
                            if (Kontroler.Instance.ObrisiRacun(obrisanRacun))
                            {
                                odgovor.Operacija = Operacija.Uspešno;
                            }
                            else
                            {
                                odgovor.Operacija = Operacija.Neuspešno;
                            }
                            PošaljiPoruku(odgovor);
                            break;
                        case Operacija.ObrisiStavkuRacuna:
                            StavkaRacuna obrisanaStavka = json.ReadType<StavkaRacuna>(zahtev.Object);
                            if (Kontroler.Instance.ObrisiStavkuRacuna(obrisanaStavka))
                            {
                                odgovor.Operacija = Operacija.Uspešno;
                            }
                            else
                            {
                                odgovor.Operacija = Operacija.Neuspešno;
                            }
                            PošaljiPoruku(odgovor);
                            break;
                        case Operacija.DodajBioskop:
                            Bioskop noviBioskop = json.ReadType<Bioskop>(zahtev.Object);
                            if (Kontroler.Instance.DodajBioskop(noviBioskop))
                            {
                                odgovor.Operacija = Operacija.Uspešno;
                            }
                            else
                            {
                                odgovor.Operacija = Operacija.Neuspešno;
                            }
                            PošaljiPoruku(odgovor);
                            break;
                       




                    }
                }
            }
            catch (Exception ex)
            {

                Debug.WriteLine(">>>CH je prestao sa radom: " + ex.Message);
            }
         
        }

     
    }
}
