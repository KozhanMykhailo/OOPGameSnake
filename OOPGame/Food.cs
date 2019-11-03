using System;
using NConsoleGraphics;




namespace OOPGame
{
    internal class Food : IGameObject
    {
        private uint color = 0xFFFF1100;
        private RandomCoordinate randomCoordinate;
        private readonly uint[] colors = { 0xFF684999, 0xFF348ce3, 0xFFfa8e00, 0xFFffffff, 0xFF080707 };
        private int tempIndexHEX;
        public int X { get; set; }
        public int Y { get; set; }
        private const int size = 40;

        public Food(int x, int y, RandomCoordinate r)
        {
            randomCoordinate = r;
            X = x;
            Y = y;
        }

        public void Render(ConsoleGraphics graphics)
        {
            graphics.FillRectangle(color, X, Y, size, size);
        }

        public void Update(GameEngine engine)
        {
            tempIndexHEX = randomCoordinate.RandomNumberIndex();
            color = colors[tempIndexHEX];
        }
    }

    
}