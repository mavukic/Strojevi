using Strojevi.Models;
using System.Collections.Generic;

namespace Strojevi.Interfaces
{
    public interface IKvar
    {
        void Dodaj(Kvar kvar);
        IEnumerable<Kvar> Get(int id);
        void Delete(int id);
        void Update(int id, Kvar kvar);
        IEnumerable<Kvar> GetAll();
    }
}
