using For_Space_Lovers.Models;
using Microsoft.AspNetCore.Mvc;

namespace For_Space_Lovers.Controllers
{
    public class EpicController : Controller
    {
        private readonly EpicDataLayer _epicDataLayer;

        public EpicController()
        {
            _epicDataLayer = new EpicDataLayer();
        }
        public async Task<IActionResult> IndexAsync()
        {
            var evm = await _epicDataLayer.GetEpicObjects();
            return View(evm);
        }
    }
}
