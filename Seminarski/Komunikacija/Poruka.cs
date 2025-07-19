namespace Komunikacija
{
    public class Poruka
    {
        public object Object { get; set; }
        public List<string> PrijavljeniKorisnici { get; set; }
        public Operacija Operacija { get; set; }
    }
}
