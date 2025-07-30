using DBBroker;
using Repozitorijumi.GeneričkiRepozitorijumi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public abstract class SOBase
    {
        protected readonly GeneričkiRepozitorijum generičkiRepozitorijum;

        public SOBase()
        {
            generičkiRepozitorijum = new GeneričkiRepozitorijum();
        }

        public void ExecuteTemplate()
        {
            try
            {
                generičkiRepozitorijum.PoveziSe();
                generičkiRepozitorijum.BeginTransakcija();
                Execute();
                generičkiRepozitorijum.Commit();
            }
            catch (Exception)
            {
                generičkiRepozitorijum.Rollback();
                throw;
            }
            finally
            {
                generičkiRepozitorijum.ZatvoriKonekciju();
            }
        }

        protected abstract void Execute();
    }

}
