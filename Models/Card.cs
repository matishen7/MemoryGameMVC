namespace MemoryGame
{
    public class Card
    {
        public string Name { get; set; }

        public Card()
        {
        }
    }

    public class Cell
    {
        private static int maxId = 0;

        public int Id { get; set; }
        public bool IsFlipped { get; set; }
        public bool IsMatched { get; set; }
        public string Image { get; set; }

        public Cell()
        {
            Id = maxId++;
        }
    }
}
