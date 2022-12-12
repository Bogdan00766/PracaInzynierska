using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierska.Application.MachineLearning.Models
{
    public class MLCategoryPrediciton
    {
        [ColumnName("PredictedLabel")]
        public float PredictedLabels { get; set; }

    }
}
