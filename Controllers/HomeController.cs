using AppTest.DataAccess.Entities;
using AppTest.Interfaces;
using AppTest.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text;
using Newtonsoft.Json;

namespace AppTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFolderServices _folderService;

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

        private static async Task<string> ReadAsStringAsync(IFormFile file)
        {
            var result = new StringBuilder();
            using (var reader =  new StreamReader(file.OpenReadStream()))
            {
                while (reader.Peek() >= 0)
                    result.AppendLine(await reader.ReadLineAsync());
            }

            return result.ToString();
        }

        [HttpPost]
        public async Task<IActionResult> Import(IFormFile jsonFile)
        {
            if (!Path.GetFileName(jsonFile.FileName).EndsWith(".json"))
            {
                ViewBag.Error =  "Invalid file type";
            }
            else
            {
              var str = await ReadAsStringAsync(jsonFile);
              var folders = JsonConvert.DeserializeObject<IEnumerable<Folder>>(str);
              await _folderService.Import(folders);
            }

            return RedirectToAction("Index");
        }
    }
}