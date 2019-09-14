namespace SnakeGame.GameObjects.Points.Contracts
{
    public interface Point
    {
        int LeftX { get; set; }
        int TopY { get; set; }

        void Draw(char symbol);
        void Draw(int leftX, int topY, char symbol);
    }
}
