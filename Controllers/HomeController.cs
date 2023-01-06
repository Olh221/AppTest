using AppTest.Interfaces;
using AppTest.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.IO;

namespace AppTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFolderServices _folderService;
        private object _context;

        public HomeController(ILogger<HomeController> logger, IFolderServices folderServices)
        {
            _logger = logger;
            _folderService = folderServices;
        }

        public async Task<IActionResult> Index(int? Id)
        {
            ViewBag.TopDirectories = await _folderService.Get(Id);
            return View();
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