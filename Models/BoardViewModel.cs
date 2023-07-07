using MemoryGame;

namespace MemoryGameMVC.Models
{
    public class BoardViewModel
    {
        public Board GameBoard { get; set; }
        public int MatchedCellsCount { get; set; }
    }
}