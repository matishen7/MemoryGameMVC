using MemoryGameMVC.Models;

namespace MemoryGame
{
    public class Board
    {
        public int n = 3, m = 2;
        public Deck deck;
        public List<Cell> cells;
        public Stack<Cell> stack;
        public int matchedCells = 0;
        public Board()
        {
            deck = new Deck();
            cells = new List<Cell>();
            stack = new Stack<Cell>();
        }

        public void Shuffle()
        {
            for (int i = 0; i < (m * n) / 2; i++)
            {
                var pickedCard = deck.PickRandomCardFromDeck();
                cells.Add(new Cell() { Image = pickedCard.Name });
                cells.Add(new Cell() { Image = pickedCard.Name });
            }

            Random random = new Random();

            int a = cells.Count;
            while (a > 1)
            {
                a--;
                int k = random.Next(a + 1);
                Cell value = cells[k];
                cells[k] = cells[n];
                cells[n] = value;
            }
        }

        public bool FlipCard(int cardId)
        {
            var cellToFlip = cells.First(x => x.Id == cardId);
            if (stack.Count == 0) { stack.Push(cellToFlip); return false; };
            if (stack.Count == 1)
            {
                var firstCell = stack.Pop();
                var match = CheckForMatches(firstCell, cellToFlip);
                if (match)
                {
                    firstCell.IsMatched = true;
                    cellToFlip.IsMatched = true;
                    matchedCells++;
                }
                return match;
            }
            return false;
        }

        public bool CheckForMatches(Cell first, Cell second)
        {
            return first.Image.Equals(second.Image);
        }

        public bool EndGame()
        {
            for (int i = 0; i < cells.Count; i++)
                if (cells[i].IsMatched == false) return false;
            return true;
        }
    }
}
