using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NConsoleGraphics;

namespace OOPGame
{
    public class SnakePart : IGameObject
    {
        public int X { get; set; }
        public int Y { get; set; }
        private const int size = 40;
        private const int speed = 40;
        ConsoleGraphics g;
        int xSpeed, ySpeed;
        public delegate void StopGame();

        public SnakePart(int x, int y, ConsoleGraphics g)
        {
            X = x;
            Y = y;
            this.g = g;
        }

        public void Render(ConsoleGraphics graphics)
        {
            graphics.DrawRectangle(0xFFFF0000, X, Y, size, size, 1);
        }

        public void Update(GameEngine engine)
        {
            StopGame stopGame = engine.RepeatFalse;
            if (X >= g.ClientWidth || X < 0 || Y >= g.ClientHeight || Y < 0)
            {
                stopGame?.Invoke();
            }
            if (Input.IsKeyDown(Keys.LEFT))
            {
                ySpeed = 0;
                xSpeed = -speed;
            }
            if (Input.IsKeyDown(Keys.RIGHT))
            {
                ySpeed = 0;
                xSpeed = speed;
            }
            if (Input.IsKeyDown(Keys.UP))
            {
                ySpeed = -speed;
                xSpeed = 0;
            }
            if (Input.IsKeyDown(Keys.DOWN))
            {
                ySpeed = speed;
                xSpeed = 0;
            }
            X += xSpeed;
            Y += ySpeed;
        }
    }
}
