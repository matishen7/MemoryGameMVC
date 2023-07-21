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
        private static Dictionary<string, Board>? _progress = new Dictionary<string, Board>();
        private string sessionId;

        public BoardController(ILogger<BoardController> logger, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;

        }

        public IActionResult Index()
        {
            int m = 4;
            int n = 5;
            if (_progress.Count == 0)
            {
                gameBoard = new Board(_webHostEnvironment, m, n);
                gameBoard.Shuffle();
                sessionId = HttpContext.Session.Id;
                _progress.Add(sessionId, gameBoard);
            }
            var currentGameBoard = _progress.Values.First();
            var viewModel = new BoardViewModel
            {
                GameBoard = currentGameBoard,
                MatchedCellsCount = currentGameBoard.matchedCells
            };
            return View("Board", viewModel);
        }

        [HttpPost]
        public IActionResult FlipCard(int x, int y)
        {
            var currentGameBoard = _progress.Values.First();
            var key = _progress.Keys.First();
            currentGameBoard.FlipCard(x, y);
            _progress[key] = currentGameBoard;
            var viewModel = new BoardViewModel
            {
                GameBoard = currentGameBoard,
                MatchedCellsCount = currentGameBoard.matchedCells
            };
            return View("Board", viewModel);
        }
    }
}