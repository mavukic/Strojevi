using Strojevi.Models;
using System.Collections.Generic;

namespace Strojevi.Interfaces
{
    public interface IStatus
    {
        IEnumerable<Status> GetAll();
    }
}
