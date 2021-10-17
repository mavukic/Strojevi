using System.Collections.Generic;

namespace Strojevi.Models
{
    public class Stroj
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public ICollection<Kvar> Kvarovi {get;set;}
    }
}
