namespace Domen
{
    public class Mesto
    {
        public int IdMesto { get; set; }
        public string NazivMesta { get; set; }

        public override string ToString()
        {
            return NazivMesta;
        }
    }
}
