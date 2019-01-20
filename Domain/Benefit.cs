namespace Domain
{
    public class Benefit : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual Employee Employee { get; set; }
    }
}