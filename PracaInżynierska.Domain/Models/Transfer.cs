namespace PracaInzynierska.Domain.Models
{
    public class Transfer : Entity
    {
        public string Name { get; set; }
        public string SentFrom { get; set; }
        public string SentTo { get; set; }
        public string AccountNumber { get; set; }
        //public int FinancialChangeId { get; set; }
        //public List<FinancialChange>? FinancialChanges { get; set; }
    }
}