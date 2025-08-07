using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.DTO
{
    public class PrikazStavkeRacuna
    {
        public int Rb { get; set; }
        public string Opis { get; set; }
        public double Cena { get; set; }
        public string NaslovFilma { get; set; }
        public int IdFilm { get; set; }
        public int IdRacun { get; set; }
    }
}
