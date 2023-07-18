using MemoryGame;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace MemoryGameMVC.Models
{
    public class Deck
    {
        private IWebHostEnvironment Environment;
        private string folderPath = "\\images\\cards\\";
        private Stack<Card> cards;
        public Deck(IWebHostEnvironment _environment)
        {
            Environment = _environment;
            cards = GetDeck();
        }

        private Stack<Card> GetDeck()
        {
            var c = new Stack<Card>();
            string[] files = Directory.GetFiles(Environment.WebRootPath + folderPath);
            for (int i = 0; i < files.Length; i++)
            {
                var card = files[i].Split('\\');
                var nameOfCard = card[card.Length - 1];
                c.Push(new Card() { Image = folderPath + nameOfCard });
            }

            return ShuffleDeck(c);
        }

        public Card GetCard()
        {
            return cards.Pop();
        }

        private Stack<T> ShuffleDeck<T>(Stack<T> stack)
        {
            List<T> tempList = new List<T>(stack);
            Random rng = new Random();

            int n = tempList.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = tempList[k];
                tempList[k] = tempList[n];
                tempList[n] = value;
            }

            stack.Clear();
            foreach (var item in tempList)
            {
                stack.Push(item);
            }
            return stack;
        }
    }
}
