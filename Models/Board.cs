using MemoryGameMVC.Models;

namespace MemoryGame
{
    public class Board
    {
        private IWebHostEnvironment Environment;
        public int n = 3, m = 2;
        public Deck deck;
        public Card[][] cells;
        private Card firstFlippedCard = null;
        public int matchedCells = 0;
        public Board(IWebHostEnvironment _environment)
        {
            Environment = _environment;
            deck = new Deck(_environment);
            CellsBuild();
        }

        private void CellsBuild()
        {
            cells = new Card[m][];
            for (int i = 0; i < m; i++)
            {
                cells[i] = new Card[n];
                for (int j = 0; j < n; j++)
                    cells[i][j] = new Card();
            }
        }

        public void Shuffle()
        {
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    var pickedCard = deck.GetCard();
                    cells[i][j].Image = pickedCard.Image;
                }
            }
        }

        public bool FlipCard(int x, int y)
        {
            var cellToFlip = cells[x][y];
            if (firstFlippedCard == null) { firstFlippedCard = cellToFlip; return false; };
            var match = CheckForMatches(firstFlippedCard, cellToFlip);
            if (match)
                matchedCells += 2;
            return match;
        }

        public bool CheckForMatches(Card first, Card second)
        {
            return first.Image.Equals(second.Image);
        }
    }
}
