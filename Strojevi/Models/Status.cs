namespace Strojevi.Models
{
    public class Status
    {
        public int Id { get; set;}
        public string Naziv { get; set;}
        public virtual Kvar kvar { get; set; }
    }
}
