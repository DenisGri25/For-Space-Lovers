using For_Space_Lovers.Utility;
using Newtonsoft.Json;

namespace For_Space_Lovers.Models;

public class EpicDataLayer
{
    private readonly HttpClient _client = new HttpClient();
    private readonly string _apiRequest = "https://api.nasa.gov/EPIC/api/natural/images?api_key=";
    private readonly string _apiKey = ConnectionString.ApiKey;

    public async Task<IEnumerable<EpicViewModel>> GetEpicObjects()
    {
        var responseBody = await _client.GetStringAsync(_apiRequest + _apiKey);
        var epicVm = JsonConvert.DeserializeObject<IEnumerable<EpicViewModel>>(responseBody);
        if (epicVm != null)
        {
            foreach (var obj in epicVm)
            {
                if (obj.Date.GetValueOrDefault().Month >= 10)
                {
                    obj.Image = obj.Image?.Insert(0,
                        "https://epic.gsfc.nasa.gov/archive/natural/" +
                        $"{obj.Date.GetValueOrDefault().Year}/{obj.Date.GetValueOrDefault().Month}/{obj.Date.GetValueOrDefault().Day}/png/");
                }
                else
                {
                    obj.Image = obj.Image?.Insert(0,
                        "https://epic.gsfc.nasa.gov/archive/natural/" +
                        $"{obj.Date.GetValueOrDefault().Year}/0{obj.Date.GetValueOrDefault().Month}/{obj.Date.GetValueOrDefault().Day}/png/");
                }
                
                obj.Image = obj.Image?.Insert(obj.Image.Length, ".png");
            }

            return epicVm;
        }

        throw new NullReferenceException("Can't get api");
    }
}