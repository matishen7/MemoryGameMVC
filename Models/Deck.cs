using MemoryGame;

namespace MemoryGameMVC.Models
{
    public class Deck
    {
        private string folderPath = "/images/cards/";
        public List<Card> cards;
        public Deck()
        {
            cards = GetDeck();
        }

        private List<Card> GetDeck()
        {
            var c = new List<Card>();
            string[] files = Directory.GetFiles(folderPath);
            for (int i = 0; i < files.Length; i++)
            {
                var card = files[i].Split('\\');
                var nameOfCard = card[card.Length - 1];
                c.Add(new Card() { Name = nameOfCard });
            }
            return c;
        }

        public Card PickRandomCardFromDeck()
        {
            var random = new Random();
            int pickedIndex = random.Next(0, cards.Count - 1);
            var pickedCard = cards[pickedIndex];
            cards.RemoveAt(pickedIndex);
            return pickedCard;
        }
    }
}
