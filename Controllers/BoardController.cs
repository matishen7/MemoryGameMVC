using MemoryGame;
using MemoryGameMVC.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MemoryGameMVC.Controllers
{
    public class BoardController : Controller
    {
        private readonly ILogger<BoardController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public BoardController(ILogger<BoardController> logger, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;

        }

        public IActionResult Index()
        {
            return View("_TableBoard");
        }
    }
}