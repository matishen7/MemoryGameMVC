using Humanizer;
using MemoryGameMVC.Models;

namespace MemoryGame
{
    public class Board
    {
        private IWebHostEnvironment Environment;
        private int m, n;
        private Deck deck;
        public Card[][] cells;
        public int matchedCells = 0;
        private Stack<Coordinate> coordinates= new Stack<Coordinate>();
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

            if (coordinates.Count == 0)
            {
                cells[x][y].IsFlipped = true;
                coordinates.Push(new Coordinate(x, y));
            }

            else if (coordinates.Count == 1)
            {
                var prevCoordinate = coordinates.Peek();
                cells[x][y].IsFlipped = true;
                coordinates.Push(new Coordinate(x, y));
                cells[prevCoordinate.X][prevCoordinate.Y].IsFlipped = true;
                var match = CheckForMatches(cells[x][y], cells[prevCoordinate.X][prevCoordinate.Y]);
                if (match)
                {
                    cells[x][y].IsMatched = true;
                    cells[prevCoordinate.X][prevCoordinate.Y].IsMatched = true;
                }                
            }
        }

        public bool CheckForMatches(Card first, Card second)
        {
            return first.Image.Equals(second.Image);
        }
    }
}
