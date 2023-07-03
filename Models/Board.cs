namespace MemoryGame
{
    public class Board : IBoard
    {
        private int n, m;
        public Cell[][] cells;
        public Board(int m, int n)
        {
            this.m = m;
            this.n = n;
            CellsBuild();
        }

        private void CellsBuild()
        {
            cells = new Cell[m][];
            for (int i = 0; i < m; i++)
            {
                cells[i] = new Cell[n];
                for (int j = 0; j < n; j++)
                    cells[i][j] = new Cell();
            }
        }

        public bool AllCardsFound()
        {
            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                    if (cells[i][j].IsFound() == false) return false;
            return true;
        }
    }
}
