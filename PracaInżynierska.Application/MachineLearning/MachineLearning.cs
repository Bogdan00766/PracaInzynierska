using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.VisualBasic;
using PracaInzynierska.Application.Dto;
using PracaInzynierska.Application.MachineLearning.Models;
using PracaInzynierska.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.ML.DataOperationsCatalog;
using static System.Net.Mime.MediaTypeNames;

namespace PracaInzynierska.Application.MachineLearning
{
    public class MachineLearning : IMachineLearning
    {
        private readonly string _modelPath = Path.Combine(AppContext.BaseDirectory, "svm.mdl");
    
        public async Task<int> NaiveBayesPredict(MLFinancialChangeDto dto)
        {
            MLFinancialChange mfc = new MLFinancialChange()
            {
                Name = dto.Name,
                Value = dto.Value
            };
            MLContext mlContext = new MLContext();

            DatabaseLoader loader = mlContext.Data.CreateDatabaseLoader<MLFinancialChange>();
            string connectionString = @"Server=51.137.50.51;Database=PracaInz;User Id=sa;Password=MSSQLBogdan!; Trusted_Connection=False; TrustServerCertificate=True";
            string sqlCommand = "SELECT Name, CAST(Value as REAL) as Value, CAST(CategoryId as REAL) as CategoryId FROM FinancialChange";
            
            DatabaseSource dbSource = new DatabaseSource(System.Data.SqlClient.SqlClientFactory.Instance, connectionString, sqlCommand);

            IDataView data = loader.Load(dbSource);
            

            string featuresColumnName = "Features";


            var DataPreparationPipeline = mlContext.Transforms.Conversion.MapValueToKey("Label")
                .Append(mlContext.Transforms.Text.FeaturizeText(featuresColumnName, "Name"))
                .Append(mlContext.Transforms.Concatenate(featuresColumnName, "Value"));


            var naiveBayesMultiClassTrainer = DataPreparationPipeline.Append(mlContext.MulticlassClassification.Trainers.NaiveBayes(labelColumnName: "Label", featureColumnName: featuresColumnName))
                .Append(mlContext.Transforms.Conversion.MapKeyToValue("PredictedLabel"));

            

            TrainTestData trainTestData = mlContext.Data.TrainTestSplit(data, testFraction: 0.5);



            var model = naiveBayesMultiClassTrainer.Fit(trainTestData.TrainSet);

            //var metrics = mlContext.MulticlassClassification.Evaluate(model.Transform(trainTestData.TestSet));

            //Console.WriteLine($"Confusion Matrix: {metrics.ConfusionMatrix.GetFormattedConfusionTable().ToString()}");
            //Console.WriteLine();
            //Console.WriteLine($"Macro Accurracy: {metrics.MacroAccuracy:P2}");
            //Console.WriteLine($"Micro Accurracy: {metrics.MicroAccuracy:P2}");
            //Console.WriteLine();
            //Console.WriteLine($"Log Loss: {metrics.LogLoss.ToString()}");
            //Console.WriteLine($"Log Loss Reduction: {metrics.LogLossReduction.ToString()}");
            //Console.WriteLine();
            //Console.WriteLine($"Top K Accuracy: {metrics.TopKAccuracy:P2}");
            //Console.WriteLine($"Top K Prediction Count: {metrics.TopKPredictionCount}");
            //Console.WriteLine();
            //Console.WriteLine("END");

            var predictor = mlContext.Model.CreatePredictionEngine<MLFinancialChange, MLCategoryPrediciton>(model);

            var predictedCategory = predictor.Predict(mfc);
            return Int32.Parse(predictedCategory.PredictedLabels.ToString());
        }
    
    
    }
}
