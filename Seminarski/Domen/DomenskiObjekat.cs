using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public interface DomenskiObjekat

    {
        string NazivTabele { get; }
        string UslovZaJednog();
        string UslovZaSelect { get; }
        string InsertKolone { get; }
        string InsertVrednosti { get; }
        string VrednostiZaUpdate { get; }
        string UslovZaUpdate { get; }
        DomenskiObjekat ReadRow(SqlDataReader reader);
    }
}
