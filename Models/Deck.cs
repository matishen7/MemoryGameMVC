using MemoryGame;
using Microsoft.AspNetCore.Hosting;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace MemoryGameMVC.Models
{
    public class Deck
    {
        private IWebHostEnvironment Environment;
        private string folderPath = "\\images\\cards\\";
        private List<Card> cards;
        public Deck(IWebHostEnvironment _environment)
        {
            Environment = _environment;
            cards = GetDeck();
        }

        private List<Card> GetDeck()
        {
            var c = new List<Card>();
            string[] files = Directory.GetFiles(Environment.WebRootPath + folderPath);
            for (int i = 0; i < files.Length; i++)
            {
                var card = files[i].Split('\\');
                var nameOfCard = card[card.Length - 1];
                //if (nameOfCard.Equals("backside.png")) continue;
                c.Add(new Card() { Image = folderPath + nameOfCard });
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
