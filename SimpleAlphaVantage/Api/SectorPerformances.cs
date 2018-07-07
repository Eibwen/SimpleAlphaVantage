using System.Collections.Generic;
using System.Threading.Tasks;
using SimpleAlphaVantage.ResponseModels;
using SimpleAlphaVantage.Utilities;

namespace SimpleAlphaVantage.Api
{
    public class SectorPerformances : BaseEndpointParameters
    {
        public SectorPerformances(string apiKey, GenericApiClient apiClient = null)
            : base(apiKey, apiClient)
        {
        }

        public async Task<Sector> Sector()
        {
            var function = ApiFunction.SECTOR;

            return await ApiClient.SendGetAsync<Sector>(BuildUri(function), new Dictionary<string, string>
            {
            });
        }
    }
}