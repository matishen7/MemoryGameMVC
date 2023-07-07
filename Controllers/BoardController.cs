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
        private Board gameBoard;
        private static Dictionary<string, Board> _gameBoards = new Dictionary<string, Board>();


        public BoardController(ILogger<BoardController> logger, IWebHostEnvironment webHostEnvironment)
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
            return View("Board",currentGameBoard);
        }

        public IActionResult FlipCard(int id)
        {
            var currentGameBoard = _gameBoards.Values.First();
            var match = currentGameBoard.FlipCard(id);
            return View("Board", currentGameBoard);
        }
    }
}