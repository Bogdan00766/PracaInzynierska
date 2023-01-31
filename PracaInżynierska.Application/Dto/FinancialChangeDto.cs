namespace PracaInzynierska.Application.Dto
{
    public class FinancialChangeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Value { get; set; }
        public string SentFrom { get; set; }
        public string SentTo { get; set; }
        public string CategoryName { get; set; }
        public string AssetTypeName { get; set; }
        public int ReductionId { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
