using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Domen;

namespace ServerskaStrana
{
    public class Server
    {
        private Socket socket; 
        private bool kraj;
        private List<ClientHandler> korisnici = new List<ClientHandler>();
     
        public void start()
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9000);
            socket.Bind(iPEndPoint);
            socket.Listen(10); 
        }
        public void Accept()
        {
            try
            {
                kraj = false;
                while (!kraj) 
                {
                    Debug.WriteLine("Čekam klijenta da se poveže");
                    Socket klijent = socket.Accept(); 
                    Debug.WriteLine("Uspešno povezivanje sa klijetom");
               

                    ClientHandler ch = new ClientHandler(klijent,korisnici);
                    korisnici.Add(ch);
                    Thread nit = new Thread(ch.HandleClient);
                    nit.Start();

                }
            }
            catch (Exception ex)
            {

                Debug.WriteLine("Server je prestao sa radom: " + ex.Message);
            }
        }

      
        public void Stop()
        {
            
            foreach (ClientHandler ch in korisnici)
            {
                ch.Logout();
            }
            korisnici = new List<ClientHandler>();
            kraj = true;
            socket.Close();

        }

    }
}
