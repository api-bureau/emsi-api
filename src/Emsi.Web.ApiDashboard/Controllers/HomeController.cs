using Emsi.Api;
using Emsi.Web.ApiDashboard.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Emsi.Web.ApiDashboard.Controllers;

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
        var viewModel = new HomeViewModel("Emsi API Dashboard")
        {
            Meta = (await _client.Skills.GetMetaAsync()).Data,
            Status = (await _client.Skills.GetStatusAsync()).Data,
            IsAlert = true,
            Message = "Maintance on 15th August 2021 10:00-20:00",
            Type = AlertType.Danger
        };

        return View(viewModel);
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
