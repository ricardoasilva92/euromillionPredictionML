using EuromillionsML.Trainers;
using System.Threading.Tasks;

namespace EuromillionsML
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
			var euroService = new EuromillionsService();

			////fetch and map to EuromillionDrawns
			EuromillionDrawns allDrawns = await euroService.GetAllResults();

			//write to csv
			CsvHelper.EuromillionDrawnsToCsv(allDrawns.drawns, "..\\..\\..\\Data\\drawns.csv");

            //https://docs.microsoft.com/en-us/dotnet/machine-learning/tutorials/sentiment-analysis
            FastTree.Predict();
            FastTreeTweedie.Predict();
            FastForest.Predict();
            Gam.Predict();
            //OnlineGradientDescent.Predict(); //missing normalization?
            Sdca.Predict();
            LbfgsPoisson.Predict();
        }
    }
}
