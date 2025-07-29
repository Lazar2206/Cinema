using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.DTO
{
    public class PrikazRacuna
    {
  
            public int IdRacun { get; set; }
            public DateTime Datum { get; set; }
            public double UkupnaCena { get; set; }
            public string ImeGledaoca { get; set; }
            public string NazivBioskopa { get; set; }
            public int IdGledalac { get; set; }     
            public int IdBioskop { get; set; }

        public override string ToString()
            {
                return $"Račun #{IdRacun} - {ImeGledaoca}, {NazivBioskopa} - {Datum:d} - {UkupnaCena:C}";
            }
        
    }
}
