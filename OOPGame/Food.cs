using System;
using NConsoleGraphics;

namespace OOPGame
{
    internal class Food : IGameObject
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        private const int size = 40;

        public Food(int x, int y)
        {
            X = x;
            Y = y;
        }
        public int SetX(int x) => X = x;
        public int SetY(int y) => Y = y;

        public void Render(ConsoleGraphics graphics)
        {
            graphics.FillRectangle(0xFFFF1100, X, Y, size, size);
        }

        public void Update(GameEngine engine)
        {
            //throw new NotImplementedException();
        }
    }
}