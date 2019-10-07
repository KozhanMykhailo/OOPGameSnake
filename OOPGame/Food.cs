using System;
using NConsoleGraphics;

namespace OOPGame
{
    internal class Food : IGameObject
    {
        private const uint color = 0xFFFF1100;
        public int X { get; set; }
        public int Y { get; set; }
        private const int size = 40;

        public Food(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void Render(ConsoleGraphics graphics)
        {
            graphics.FillRectangle(color, X, Y, size, size);
        }

        public void Update(GameEngine engine)
        {
        }
    }
}