using MemoryGame;

namespace MemoryGameMVC.Models
{
    public class CurrentGame
    {
        public bool EndGame;
        public int GameLevel = 1;
        public Board GameBoard;
    }
}
