using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Strojevi.Models
{
    public class Kvar
    {
        public int Id { get; set; }
        public string Opis { get; set; }  
        public DateTime VrijemePocetka {  get; set; }
        public DateTime VrijemeZavrsetka {  get; set; }

        
        public virtual string ImeStroja {  get; set; }

        public virtual string status { get; set; }
        public virtual string prioritet { get; set; }

    }
}
