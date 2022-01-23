using System.Text;
using For_Space_Lovers.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;

namespace For_Space_Lovers.Models;

public class ApodDataLayer
{
    private readonly HttpClient _client = new HttpClient();
    private readonly string _apiRequest = "https://api.nasa.gov/planetary/apod?api_key=";
    private readonly string _apiKey = ConnectionString.ApiKey;

    public async Task<ApodViewModel> GetAdopUrlAsync()
    {
        var responseBody =
            await _client.GetStringAsync(_apiRequest + _apiKey);
        var apodVm = JsonConvert.DeserializeObject<ApodViewModel>(responseBody);
        if (apodVm != null)
        {
            return apodVm;
        }

        throw new NullReferenceException("Can't get api");
    }
}