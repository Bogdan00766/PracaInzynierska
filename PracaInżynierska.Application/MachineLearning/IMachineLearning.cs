using PracaInzynierska.Application.Dto;
using PracaInzynierska.Application.MachineLearning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierska.Application.MachineLearning
{
    public interface IMachineLearning
    {
        public Task<int> NaiveBayesPredict(MLFinancialChangeDto mfc);
    }
}
