using MemoryGameMVC.Models;

namespace MemoryGame
{
    public class Board
    {
        public int n, m;
        public Deck deck;
        public List<List<Cell>> cells;
        public Board()
        {
            deck = new Deck();
        }

        public void Shuffle()
        {
            cells = new List<List<Cell>>();
            int index = 0;

            for (int i = 0; i < m; i++)
            {
                var row = new List<Cell>();
                for (int j = 0; j < n; j++)
                {
                    var pickedCard = deck.PickRandomCardFromDeck();

                    row.Add(new Cell()
                    {
                        Id = index,
                        Image = pickedCard.Name,
                    });

                    index++;
                }
                cells.Add(row);
            }

        }

        public bool FlipCard(int cardId)
        {
            var cellToFlip = cells.First(x => x.Id == cardId);
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
