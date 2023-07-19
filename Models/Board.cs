using MemoryGameMVC.Models;

namespace MemoryGame
{
    public class Board
    {
        private IWebHostEnvironment Environment;
        private int m, n;
        private Deck deck;
        public Card[][] cells;
        private Card previouslyFlippedCard;
        public int matchedCells = 0;
        private int? previousX;
        private int? previousY;

        public Board(IWebHostEnvironment _environment, int m, int n)
        {
            if (m > 0 && n > 0)
            {
                this.m = m;
                this.n = n;
            }
            else throw new ArgumentOutOfRangeException();
            Environment = _environment;
            deck = new Deck(_environment);
            CellsBuild();
        }

        public int GetM()
        {
            return m;
        }

        public int GetN()
        {
            return n;
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
                previousX = x;
                previousY = y;
                cells[x][y].IsFlipped = true;
                return;
            };
            var match = CheckForMatches(previouslyFlippedCard, cardToFlip);
            if (match)
            {
                cells[x][y].IsFlipped = true;
                cells[previousX.Value][previousY.Value].IsFlipped = true;
                matchedCells += 2;
            }
            else
            {
                cells[x][y].IsFlipped = false;
                cells[previousX.Value][previousY.Value].IsFlipped = false;
            }

            previouslyFlippedCard = null;
            previousX = null;
            previousY = null;
        }

        public bool CheckForMatches(Card first, Card second)
        {
            return first.Image.Equals(second.Image);
        }
    }
}
