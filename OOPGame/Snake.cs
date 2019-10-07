using NConsoleGraphics;

namespace OOPGame
{

    public class Snake : IGameObject
    {
        public int X { get; set; }
        public int Y { get; set; }
        private const int size = 40;
        private const int speed = 40;
        private ConsoleGraphics g;
        public delegate void StopGame();
        int speedLeftX, speedRightX, speedUpY, speedDownY;
        public Snake(int x, int y, ConsoleGraphics g)
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

            X -= speedLeftX;
            X += speedRightX;
            Y -= speedUpY;
            Y += speedDownY;
            if (Input.IsKeyDown(Keys.LEFT))
            {
                speedLeftX = speed;
                speedRightX = default;
                speedUpY = default;
                speedDownY = default;
            }
            if (Input.IsKeyDown(Keys.RIGHT))
            {
                speedLeftX = default;
                speedRightX = speed;
                speedUpY = default;
                speedDownY = default;
            }
            if (Input.IsKeyDown(Keys.UP))
            {
                speedLeftX = default;
                speedRightX = default;
                speedUpY = speed;
                speedDownY = default;
            }
            if (Input.IsKeyDown(Keys.DOWN))
            {
                speedLeftX = default;
                speedRightX = default;
                speedUpY = default;
                speedDownY = speed;
            }
        }
    }
}