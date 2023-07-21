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
        private static Dictionary<string, CurrentGame> _progress = new Dictionary<string, CurrentGame>();
        private string sessionId;

        public BoardController(ILogger<BoardController> logger, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;

        }

        public IActionResult Index()
        {
            if (_progress.Count == 0 || _progress.Values.First().EndGame)
            {
                int m = 2;
                int n = 2;
                gameBoard = new Board(_webHostEnvironment, m, n);
                gameBoard.Shuffle();
                sessionId = HttpContext.Session.Id;
                _progress.Add(sessionId, new CurrentGame()
                {
                    EndGame = false,
                    GameBoard = gameBoard,
                    GameLevel = 1,
                });
            }
            var currentProgress = _progress.Values.First();
            var viewModel = new BoardViewModel
            {
                GameBoard = currentProgress.GameBoard,
                MatchedCellsCount = currentProgress.GameBoard.matchedCells
            };

            if (viewModel.MatchedCellsCount == viewModel.GameBoard.GetM() * viewModel.GameBoard.GetN())
            {
                currentProgress.GameLevel++;
                currentProgress.EndGame = true;
                _progress.Clear();
                _progress.Add(sessionId, currentProgress);
            }
            return View("Board", viewModel);
        }

        public IActionResult FlipCard(int x, int y)
        {
            var currentProgress = _progress.Values.First();
            var key = _progress.Keys.First();
            currentProgress.GameBoard.FlipCard(x, y);
            _progress[key] = currentProgress;
            var viewModel = new BoardViewModel
            {
                GameBoard = currentProgress.GameBoard,
                MatchedCellsCount = currentProgress.GameBoard.matchedCells
            };
            return View("Board", viewModel);
        }
    }
}