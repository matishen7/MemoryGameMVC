namespace MemoryGame
{
    public class Board
    {
        public int n, m;
        public List<Card> cards;
        public Board(int m, int n)
        {
            cards = new List<Card>();
        }

        public void Shuffle()
        {

        }

        public void FlipCard(int cardId)
        {
            var cardToFlip = cards.First(x => x.Id == cardId);
            if (cardToFlip != null) { cardToFlip.IsFlipped = true; }
        }

        public bool CheckForMatches()
        {
            // Implement match checking logic
            return false;
        }
    }
}
