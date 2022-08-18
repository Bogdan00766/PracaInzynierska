namespace PracaInżynierska.Domain.Models
{
    public class Transfer : Entity
    {
        public string Name { get; set; }
        public string SentFrom { get; set; }
        public string SentTo { get; set; }
        public string AccountNumber { get; set; }
        public FinancialChange FinancialChange { get; set; }
    }
}