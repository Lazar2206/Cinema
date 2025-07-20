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
        private bool kraj;
        public Bioskop prijavljeniBioskop { get; set; }
        public ClientHandler(Socket klijent)
        {
            this.klijent = klijent;

            json = new JsnNetworkSerializer(klijent);

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
                    //obrada zahteva

                    switch (zahtev.Operacija)
                    {
                        case Operacija.Login:
                            Bioskop bioskop1 = json.ReadType<Bioskop>(zahtev.Object);
                            if (Kontroler.Instance.Login(bioskop1))
                            {
                                odgovor.Operacija = Operacija.Uspešno;
                                prijavljeniBioskop = bioskop1;
                            }
                            else
                            {
                                odgovor.Operacija = Operacija.Neuspešno;
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
                            

                            //case Operacija.Register:
                            //    Korisnik korisnik2 = json.ReadType<Korisnik>(zahtev.Object);
                            //    Kontroler.Instance.DodajKorisnika(korisnik2);
                            //    odgovor.Operacija = Operacija.Uspesno;
                            //    //slanje odgovora
                            //    PošaljiPoruku(odgovor);
                            //    break;
                            //case Operacija.ScheduleTrip:
                            //    PrijavljenaPutovanja prijava1 = json.ReadType<PrijavljenaPutovanja>(zahtev.Object);
                            //    Kontroler.Instance.PrijaviPutovanje(prijava1);
                            //    odgovor.Operacija = Operacija.Uspesno;
                            //    //slanje odgovora
                            //    PošaljiPoruku(odgovor);
                            //    break;
                            //case Operacija.DeleteTrip:
                            //    PrijavljenaPutovanja prijava2 = json.ReadType<PrijavljenaPutovanja>(zahtev.Object);
                            //    Kontroler.Instance.DeleteTrip(prijava2);
                            //    odgovor.Operacija = Operacija.Uspesno;
                            //    //slanje odgovora
                            //    PošaljiPoruku(odgovor);
                            //    break;
                            //case Operacija.ChangeTrip:
                            //    PrijavljenaPutovanja prijava3 = json.ReadType<PrijavljenaPutovanja>(zahtev.Object);
                            //    Kontroler.Instance.AzurirajPutovanje(prijava3);
                            //    odgovor.Operacija = Operacija.Uspesno;
                            //    //slanje odgovora
                            //    PošaljiPoruku(odgovor);
                            //    break;
                            //case Operacija.Logout:
                            //    Logout();
                            //    break;



                    }
                }
            }
            catch (Exception ex)
            {

                Debug.WriteLine(">>>CH je prestao sa radom: " + ex.Message);
            }
            //primanje zahteva


            //obrada zahteva

            //slanje odgovora
            //
        }

        internal void Logout()
        {
            kraj = true;
            Kontroler.Instance.Logout();
            klijent.Close();
        }
    }
}
