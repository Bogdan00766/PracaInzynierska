using Microsoft.ML.Data;

namespace PracaInzynierska.Application.MachineLearning.Models
{
    public class MLCategoryPrediciton
    {
        [ColumnName("PredictedLabel")]
        public float PredictedLabels { get; set; }

    }
}
