using EuromillionsML.ML;
using Microsoft.ML;
using System;

namespace EuromillionsML.Trainers
{
    //https://docs.microsoft.com/en-us/dotnet/api/microsoft.ml.trainers.sdcaregressiontrainer?view=ml-dotnet
    public static class Sdca
    {
        public static void Predict()
        {
            MLContext mlContext = new MLContext(seed: 0);
            var model = Train(mlContext, Constants._trainDataPath);

            Evaluate(mlContext, model);

            TestSinglePrediction(mlContext, model);
        }

        private static ITransformer Train(MLContext mlContext, string trainDataPath)
        {
            //Loads the data.
            IDataView dataView = mlContext.Data.LoadFromTextFile<EuroDrawnData>(trainDataPath, hasHeader: true, separatorChar: ',');

            //Extracts and transforms the data.
            var pipelineBall1 = mlContext.Transforms.CopyColumns(outputColumnName: "Label", inputColumnName: "Ball1")
                      //indicar as colunas de feature
                      .Append(mlContext.Transforms.Concatenate("Features", "Date", "Ball2", "Ball3", "Ball4", "Ball5", "Star1", "Star2"))
                      //Choose a learning algorithm
                      .Append(mlContext.Regression.Trainers.Sdca())
                      .Append(mlContext.Transforms.CopyColumns(outputColumnName: "bola1", inputColumnName: "Score"));

            var pipelineBall2 = mlContext.Transforms.CopyColumns(outputColumnName: "Label", inputColumnName: "Ball2")
                      //indicar as colunas de feature
                      .Append(mlContext.Transforms.Concatenate("Features", "Date", "Ball1", "Ball3", "Ball4", "Ball5", "Star1", "Star2"))
                      //Choose a learning algorithm
                      .Append(mlContext.Regression.Trainers.Sdca())
                      .Append(mlContext.Transforms.CopyColumns(outputColumnName: "bola2", inputColumnName: "Score"));

            var pipelineBall3 = mlContext.Transforms.CopyColumns(outputColumnName: "Label", inputColumnName: "Ball3")
                      //indicar as colunas de feature
                      .Append(mlContext.Transforms.Concatenate("Features", "Date", "Ball1", "Ball2", "Ball4", "Ball5", "Star1", "Star2"))
                      //Choose a learning algorithm
                      .Append(mlContext.Regression.Trainers.Sdca())
                      .Append(mlContext.Transforms.CopyColumns(outputColumnName: "bola3", inputColumnName: "Score"));

            var pipelineBall4 = mlContext.Transforms.CopyColumns(outputColumnName: "Label", inputColumnName: "Ball4")
                      //indicar as colunas de feature
                      .Append(mlContext.Transforms.Concatenate("Features", "Date", "Ball1", "Ball2", "Ball3", "Ball5", "Star1", "Star2"))
                      //Choose a learning algorithm
                      .Append(mlContext.Regression.Trainers.Sdca())
                      .Append(mlContext.Transforms.CopyColumns(outputColumnName: "bola4", inputColumnName: "Score"));

            var pipelineBall5 = mlContext.Transforms.CopyColumns(outputColumnName: "Label", inputColumnName: "Ball5")
                      //indicar as colunas de feature
                      .Append(mlContext.Transforms.Concatenate("Features", "Date", "Ball1", "Ball2", "Ball3", "Ball4", "Star1", "Star2"))
                      //Choose a learning algorithm
                      .Append(mlContext.Regression.Trainers.Sdca())
                      .Append(mlContext.Transforms.CopyColumns(outputColumnName: "bola5", inputColumnName: "Score"));

            var pipelineStar1 = mlContext.Transforms.CopyColumns(outputColumnName: "Label", inputColumnName: "Star1")
                      //indicar as colunas de feature
                      .Append(mlContext.Transforms.Concatenate("Features", "Date", "Ball1", "Ball2", "Ball3", "Ball4", "Ball5", "Star2"))
                      //Choose a learning algorithm
                      .Append(mlContext.Regression.Trainers.Sdca())
                      .Append(mlContext.Transforms.CopyColumns(outputColumnName: "estrela1", inputColumnName: "Score"));

            var pipelineStar2 = mlContext.Transforms.CopyColumns(outputColumnName: "Label", inputColumnName: "Star2")
                      //indicar as colunas de feature
                      .Append(mlContext.Transforms.Concatenate("Features", "Date", "Ball1", "Ball2", "Ball3", "Ball4", "Ball5", "Star1"))
                      //Choose a learning algorithm
                      .Append(mlContext.Regression.Trainers.Sdca())
                      .Append(mlContext.Transforms.CopyColumns(outputColumnName: "estrela2", inputColumnName: "Score"));

            //Train the model
            var model = pipelineBall1
                        .Append(pipelineBall2)
                        .Append(pipelineBall3)
                        .Append(pipelineBall4)
                        .Append(pipelineBall5)
                        .Append(pipelineStar1)
                        .Append(pipelineStar2)
                        .Fit(dataView);

            return model;
        }

        private static void Evaluate(MLContext mlContext, ITransformer model)
        {
            IDataView dataView = mlContext.Data.LoadFromTextFile<EuroDrawnData>(Constants._testDataPath, hasHeader: true, separatorChar: ',');
            var predictions = model.Transform(dataView);

            var metrics = mlContext.Regression.Evaluate(predictions, "Label", "Score");

            //Console.WriteLine("Evaluate");
            //Console.WriteLine($"*************************************************");
            //Console.WriteLine($"*       Model quality metrics evaluation         ");
            //Console.WriteLine($"*------------------------------------------------");
            //Console.WriteLine($"*       RSquared Score:      {metrics.RSquared:0.##}");
            //Console.WriteLine($"*       Root Mean Squared Error:      {metrics.RootMeanSquaredError:#.##}");
        }

        private static void TestSinglePrediction(MLContext mlContext, ITransformer model)
        {
            var predictionFunction = mlContext.Model.CreatePredictionEngine<EuroDrawnData, EuroDrawnPrediction>(model);
            var euroDrawnSample = new EuroDrawnData()
            {
                Ball1 = 0,
                Ball2 = 0,
                Ball3 = 0,
                Ball4 = 0,
                Ball5 = 0,
                Star1 = 0,
                Star2 = 0,
                Date = Constants.dateToPredict
            };

            var prediction = predictionFunction.Predict(euroDrawnSample);
            Console.WriteLine($"****************Sdca Prediction****************");
            Console.WriteLine($"Predicted Ball1: {prediction.Ball1:0.####}");
            Console.WriteLine($"Predicted Ball2: {prediction.Ball2:0.####}");
            Console.WriteLine($"Predicted Ball3: {prediction.Ball3:0.####}");
            Console.WriteLine($"Predicted Ball4: {prediction.Ball4:0.####}");
            Console.WriteLine($"Predicted Ball5: {prediction.Ball5:0.####}");
            Console.WriteLine($"Predicted Star1: {prediction.Star1:0.####}");
            Console.WriteLine($"Predicted Star2: {prediction.Star2:0.####}");
            Console.WriteLine();
        }
    }
}
