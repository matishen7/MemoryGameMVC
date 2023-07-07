using MemoryGame;

namespace MemoryGameMVC.Models
{
    internal class FlipCardViewModel
    {
        public Board GameBoard { get; set; }
        public bool Match { get; set; }
    }
}