namespace PracaInzynierska.Domain.Models
{
    public class FinancialChange : Entity
    {
        public string Name { get; set; }
        public float Value { get; set; }
        public Transfer? Transfer { get; set; }
        public string SentFrom { get; set; }
        public string SentTo { get; set; }
        public Category Category { get; set; }
        public AssetType AssetType { get; set; }
        public User Owner { get; set; }
        public FinancialChange? Reduction { get; set; }
    }
}