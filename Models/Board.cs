using MemoryGameMVC.Models;

namespace MemoryGame
{
    public class Board
    {
        public int n = 3, m = 2;
        public Deck deck;
        public List<Cell> cells;
        public Board()
        {
            deck = new Deck();
        }

        public void Shuffle()
        {
            cells = new List<Cell>();
            for (int i = 0; i < (m * n); i++)
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
            var cellToFlip = cells.First(x=>x.Id == cardId);
            if (cellToFlip != null) { cellToFlip.IsFlipped = true; return true; }
            return false;
        }

        public bool CheckForMatches()
        {
            // Implement match checking logic
            return false;
        }
    }
}
