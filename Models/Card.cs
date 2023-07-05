namespace MemoryGame
{
    public class Card
    {
        public int Id { get; set; }
        public bool IsFlipped { get; set; }
        public bool IsMatched { get; set; }
        public string Image { get; set; }

        public Card()
        {
        }
    }
}
