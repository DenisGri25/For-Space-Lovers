using For_Space_Lovers.Models;
using Microsoft.AspNetCore.Mvc;

namespace For_Space_Lovers.Controllers
{
    public class SpaceController : Controller
    {
        private SpaceDataLayer _spaceDataLayer;

        public SpaceController()
        {
            _spaceDataLayer = new SpaceDataLayer();
        }
        public async Task<IActionResult> Index()
        {
            var svm = await _spaceDataLayer.GetAdopUrlAsync();
            return View(svm);
        }
    }
}
