using MemoryGameMVC.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MemoryGameMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            var board = new HtmlBoardBuilder(_webHostEnvironment)
                .WithDimensions(4, 4)
                .Build();


            return View(board);
        }

        [HttpPost]
        public IActionResult ClickCard(string firstImage, string secondImage)
        {
            // Compare the image URLs to check if they match
            bool imagesMatch = firstImage == secondImage;

            // Return the result as JSON
            return Json(new { match = imagesMatch });
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