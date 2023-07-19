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
        private int? prevX, prevY;
        public int matchedCells = 0;

        public Board(IWebHostEnvironment _environment, int m, int n)
        {
            
            Environment = _environment;
            deck = new Deck(_environment);
            if (m > 0 && n > 0)
            {
                this.m = m;
                this.n = n;
            }
            else if (m * n > deck.GetNumberOfCardsInDeck()) throw new ArgumentOutOfRangeException("Insufficient number of cards! ");
            else throw new ArgumentOutOfRangeException("Incorrect input number of cards!");
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
            if (x >= m || y >= n) throw new ArgumentOutOfRangeException();
            
            if (cells[x][y].IsFlipped) return;

            if (previouslyFlippedCard == null)
            {
                cells[x][y].IsFlipped = true;
                previouslyFlippedCard = cells[x][y];
                prevX = x; prevY = y;
                return;
            };
            var match = CheckForMatches(previouslyFlippedCard, cells[x][y]);
            if (match)
            {
                cells[x][y].IsFlipped = false;
                cells[prevX.Value][prevY.Value].IsFlipped = false;
                cells[x][y].IsMatched = true;
                cells[prevX.Value][prevY.Value].IsMatched = true;
                matchedCells += 2;
            }
            else
            {
                cells[x][y].IsFlipped = false;
                cells[prevX.Value][prevY.Value].IsFlipped = false;
            }

            previouslyFlippedCard = null;
            prevX = null; prevY = null;
        }

        public bool CheckForMatches(Card first, Card second)
        {
            return first.Image.Equals(second.Image);
        }
    }
}
