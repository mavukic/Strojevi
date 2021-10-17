using Strojevi.Models;
using System.Collections.Generic;

namespace Strojevi.Interfaces
{
    public interface IPrioritet
    {
        IEnumerable<Prioritet> GetAll();
    }
}
