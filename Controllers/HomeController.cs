using MemoryGame;
using MemoryGameMVC.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;

namespace MemoryGameMVC.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private Board gameBoard;
        private static Dictionary<string, Board> _gameBoards = new Dictionary<string, Board>();

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            string sessionId = HttpContext.Session.Id;
            if (!_gameBoards.ContainsKey(sessionId))
            {
                gameBoard = new Board();
                gameBoard.Shuffle();
                _gameBoards.Add(sessionId, gameBoard);
            }

            var currentGameBoard = _gameBoards[sessionId];
            return View(currentGameBoard);
        }

        public IActionResult FlipCard(int id)
        {
            var currentGameBoard = _gameBoards.Values.First();
            var match = currentGameBoard.FlipCard(id);
            return View("Index", currentGameBoard);
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