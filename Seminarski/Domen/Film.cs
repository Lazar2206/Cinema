using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public class Film
    {
        public int IdFilm { get; set; }
        public string Naslov { get; set; }
        public Žanr Zanr { get; set; }    
        public TimeSpan Pocetak { get; set; }
        public TimeSpan Kraj { get; set; }  
        public int TrajanjeMinuti { get; set; } 
    }

}
