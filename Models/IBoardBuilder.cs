using static System.Net.Mime.MediaTypeNames;

namespace MemoryGame
{
    public interface IBoardBuilder
    {
        public IBoardBuilder WithDimensions(int m, int n);
        public Board Build();
    }
}
