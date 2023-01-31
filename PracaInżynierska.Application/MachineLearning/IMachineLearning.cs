using PracaInzynierska.Application.Dto;

namespace PracaInzynierska.Application.MachineLearning
{
    public interface IMachineLearning
    {
        public Task<int> NaiveBayesPredict(MLFinancialChangeDto mfc);
    }
}
