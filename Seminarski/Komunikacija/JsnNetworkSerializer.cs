using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Komunikacija
{
    public class JsnNetworkSerializer
    {
        private Socket socket;
        private NetworkStream stream;
        private StreamReader reader;
        private StreamWriter writer;
        public JsnNetworkSerializer(Socket socket)
        {
            this.socket = socket;
            this.stream = new NetworkStream(socket);
            this.reader = new StreamReader(stream);
            this.writer = new StreamWriter(stream)
            {
                AutoFlush = true
            };
        }
        public void PosaljiPoruku(Object poruka)
        {
            writer.WriteLine(JsonSerializer.Serialize(poruka));
        }
        public T PrimiPoruku<T>()
        {
            string poruka = reader.ReadLine();
            return JsonSerializer.Deserialize<T>(poruka);
        }
        public T ReadType<T>(Object podaci)
        {

            return JsonSerializer.Deserialize<T>((JsonElement)podaci);
        }
    }
}
