using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;

namespace For_Space_Lovers.Models;

public class SpaceDataLayer
{
    private string _apiKey = "sj2qEOxBAIrQNMygJyPE1m6xw1Rqto0EPTIiO1ag";
    private readonly HttpClient _client = new HttpClient();

    public async Task<SpaceVievModel> GetAdopUrlAsync()
    {
        var responseBody =
            await _client.GetStringAsync(
                "https://api.nasa.gov/planetary/apod?api_key=sj2qEOxBAIrQNMygJyPE1m6xw1Rqto0EPTIiO1ag");
        var spaceVievModel = JsonConvert.DeserializeObject<SpaceVievModel>(responseBody);
        if (spaceVievModel != null)
        {
            return spaceVievModel;
        }

        throw new NullReferenceException("Can't get api");
    }
}