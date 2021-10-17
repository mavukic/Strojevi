using Strojevi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Strojevi.Interfaces
{
    public interface IStroj
    {
        void Dodaj(Stroj stroj);
        IEnumerable<Stroj> Get(int id);
        void Delete(int id);
        void Update(int id, Stroj stroj);
        IEnumerable<Stroj> GetAll();
        IEnumerable<Kvar> GetKvarovi();
    }
}
