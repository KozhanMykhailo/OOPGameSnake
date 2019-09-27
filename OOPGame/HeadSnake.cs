using NConsoleGraphics;

namespace OOPGame
{

    public class HeadSnake : IGameObject
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        private const int size = 40;
        private const int speed = 40;
        private ConsoleGraphics g;
        public delegate void StopGame();
        private bool KeyDownLeft, KeyDownRight, KeyDownUp, KeyDownDown;

        public HeadSnake(int x, int y,ConsoleGraphics g)
        {
            X = x;
            Y = y;
            this.g = g;
        }
        public void Render(ConsoleGraphics graphics)
        {
            graphics.DrawRectangle(0xFFFF0000, X, Y, size, size,1);
        }
        
        public void Update(GameEngine engine)
        {
            StopGame stopGame = engine.RepeatFalse;
            if(X >= g.ClientWidth)
            {
                stopGame?.Invoke();
            }
            else if( X < 0 )
            {
                stopGame?.Invoke();
            }
            if(Y >= g.ClientHeight )
            {
                stopGame?.Invoke();
            }
            else if (Y < 0 )
            {
                stopGame?.Invoke();
            }

            if(Input.IsKeyDown(Keys.LEFT))
            {
                if (KeyDownRight)
                {
                    KeyDownLeft = false; ;//просто ничего не происходит!
                }
                else
                {
                    KeyDownRight = false;
                    KeyDownDown = false;
                    KeyDownUp = false;
                    KeyDownLeft = true;
                }
            }
            if(Input.IsKeyDown(Keys.RIGHT))
            {
                if (KeyDownLeft)
                {
                    KeyDownRight = false;
                }
                else
                {
                    KeyDownLeft = false;
                    KeyDownDown = false;
                    KeyDownUp = false;
                    KeyDownRight = true;
                }
            }
            if(Input.IsKeyDown(Keys.UP))
            {
                if (KeyDownDown)
                {
                    KeyDownUp =false;
                }
                else
                {
                    KeyDownLeft = false;
                    KeyDownRight = false;
                    KeyDownDown = false;
                    KeyDownUp = true;
                }
            }
            if(Input.IsKeyDown(Keys.DOWN))
            {
                if (KeyDownUp)
                {
                    KeyDownDown = false;
                }
                else
                {
                    KeyDownRight = false;
                    KeyDownLeft = false;
                    KeyDownUp = false;
                    KeyDownDown = true;
                }
            }

            if (KeyDownLeft)
            {
                X -= speed;
            }
            else if (KeyDownRight)
            {
                X += speed;
            }
            if (KeyDownUp)
            {
                Y -= speed;
            }
            else if (KeyDownDown)
            {
                Y += speed;
            }
        }
    }
}