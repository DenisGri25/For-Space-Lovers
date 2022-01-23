using For_Space_Lovers.Models;
using Microsoft.AspNetCore.Mvc;

namespace For_Space_Lovers.Controllers
{
    public class ApodController : Controller
    {
        private readonly ApodDataLayer _apodDataLayer;

        public ApodController()
        {
            _apodDataLayer = new ApodDataLayer();
        }
        public async Task<IActionResult> Index()
        {
            var avm = await _apodDataLayer.GetAdopUrlAsync();
            return View(avm);
        }
    }
}
