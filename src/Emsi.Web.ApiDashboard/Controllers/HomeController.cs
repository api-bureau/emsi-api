using Emsi.Api;
using Emsi.Web.ApiDashboard.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Emsi.Web.ApiDashboard.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly EmsiClient _client;

        public HomeController(ILogger<HomeController> logger, EmsiClient client)
        {
            _logger = logger;
            _client = client;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var status = await _client.Skills.GetStatusAsync();

            return View(status);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
