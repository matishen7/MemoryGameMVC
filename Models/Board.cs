using MemoryGameMVC.Models;

namespace MemoryGame
{
    public class Board
    {
        private IWebHostEnvironment Environment;
        public int n = 3, m = 2;
        public Deck deck;
        public Card[][] cells;
        private Card previouslyFlippedCard = null;
        private int? previousX = null;
        private int? previousY = null;
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
            var cards = new List<Card>();
            for (int i = 0; i < (m * n) / 2; i++)
            {
                var pickedCard = deck.GetCard();
                cards.Add(pickedCard);
                cards.Add(pickedCard);
            }

            Random rng = new Random();

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    var indexToPick = rng.Next(0, cards.Count);
                    cells[i][j].Image = cards[indexToPick].Image;
                    cards.RemoveAt(indexToPick);
                }
            }
        }

        public void FlipCard(int x, int y)
        {
            if (previousX == x && previousY == y) return;
            var cardToFlip = cells[x][y];
            if (previouslyFlippedCard == null)
            {
                previouslyFlippedCard = cardToFlip;
                previousX= x;
                previousY= y;
                return;
            };
            var match = CheckForMatches(previouslyFlippedCard, cardToFlip);
            if (match)
                matchedCells += 2;
        }

        public bool CheckForMatches(Card first, Card second)
        {
            return first.Image.Equals(second.Image);
        }
    }
}
