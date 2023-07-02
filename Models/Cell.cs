namespace MemoryGame
{
    public class Cell
    {
        private string Image { get; set; }
        private bool Found { get; set; } = false;
        public Cell()
        {
        }

        public string GetImage()
        {
            return this.Image;
        }

        public void SetImage(string image)
        {
            Image = image;
        }

        public bool IsFound()
        {
            return this.Found;
        }

        public void SetAsFound()
        {
            Found = true;
        }
    }
}
