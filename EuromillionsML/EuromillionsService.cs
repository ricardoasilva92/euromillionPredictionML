namespace EuromillionsML
{
	using System.Net.Http;
	using System.Text.Json;
	using System.Threading.Tasks;

	public class EuromillionsService
    {
        private readonly string AllResultsUrl = "https://nunofcguerreiro.com/api-euromillions-json?result=all";
        private HttpClient client;

        public EuromillionsService()
        {
            this.client = new HttpClient();
        }

        public async Task<EuromillionDrawns> GetAllResults()
        {
            var jsonString = await this.client.GetStringAsync(AllResultsUrl);
            var euromillionDrawnsDto = JsonSerializer.Deserialize<EuromillionDrawnsDto>(jsonString);
            
            return EuromillionServiceHelper.EuromillionDrawnsConverter(euromillionDrawnsDto);
        }
    }
}
