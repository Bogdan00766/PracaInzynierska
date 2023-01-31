using Microsoft.ML.Data;

namespace PracaInzynierska.Application.MachineLearning.Models
{
    public class MLFinancialChange
    {
        [LoadColumn(0)]
        public string Name { get; set; }
        [LoadColumn(1)]
        public float Value { get; set; }
        [LoadColumn(2)]
        public float Label { get; set; }


    }
}
