namespace MemoryGame
{
    public interface IBoard
    {
        bool AllCardsFound();
        bool CheckIfCardsMatch(int x, int y, int a, int b);
        void Display();
        void Display(int x, int y);
        void Display(int x, int y, int a, int b);
        void RevealAllCards();
    }
}