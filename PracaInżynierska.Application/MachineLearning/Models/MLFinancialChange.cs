using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        //public float CategoryId { get; set; }
        //[LoadColumn(3)]


    }
}
