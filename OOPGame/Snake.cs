using NConsoleGraphics;
using System.Collections.Generic;
using System.Linq;

namespace OOPGame
{

    public class Snake : IGameObject
    {
        public int X { get; set; }
        public int Y { get; set; }
        private const int size = 40;
        private const int speed = 40;
        private List<Snake> snake = new List<Snake>();
        private ConsoleGraphics g;
        public delegate void StopGame();
        int xSpeed, ySpeed;
        RandomCoordinate randomCoordinate;

        public Snake(ConsoleGraphics graphics, RandomCoordinate rand)
        {
            randomCoordinate = rand;
            g = graphics;
        }

        public Snake(int x, int y, ConsoleGraphics g)
        {
            X = x;
            Y = y;
            this.g = g;
        }
        public void SnakeAdd()
        {
            snake.Add(new Snake(randomCoordinate.RandomY(g.ClientWidth), randomCoordinate.RandomX(g.ClientHeight), g));
        }
        public void Render(ConsoleGraphics graphics)
        {
            foreach (var item in snake)
            {
                item.RenderBody(g);
            }
        }
        public void RenderBody(ConsoleGraphics graphics)
        {
            graphics.DrawRectangle(0xFFFF0000, X, Y, size, size, 1);
        }

        public void Update(GameEngine engine)
        {
            BodyMovement(engine);
            snake.OfType<Snake>().First().HeadMovement(engine);
            BodyEatingTest(engine);
            EatingFood(engine, g);
        }

        public void HeadMovement(GameEngine engine)
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

        public void BodyMovement(GameEngine engine)
        {
            for (int i = snake.Count - 1; i > 0; i--)
            {
                snake[i].X = snake[i - 1].X;
                snake[i].Y = snake[i - 1].Y;
            }
        }

        public void BodyEatingTest(GameEngine gameEngine)
        {
            var headSnake = snake.OfType<Snake>().First();
            var snakeBoby = snake.OfType<Snake>().Where(w => w != snake.OfType<Snake>().First()).ToList();
            var headSnakeX = headSnake.X;
            var headSnakeY = headSnake.Y;
            foreach (var body in snakeBoby)
            {
                if (headSnakeX == body.X && headSnakeY == body.Y)
                {
                    gameEngine.RepeatFalse();
                    break;
                }
            }
        }

        public void EatingFood(GameEngine gameEngine, ConsoleGraphics graphics)
        {
            var headSnake = snake.OfType<Snake>().First();
            var foodForTheSnake = gameEngine.gameObjects.OfType<Food>().First();
            var foodForTheSnakeX = foodForTheSnake.X;
            var foodForTheSnakeY = foodForTheSnake.Y;
            var headSnakeX = headSnake.X;
            var headSnakeY = headSnake.Y;
            if (foodForTheSnakeX == headSnakeX && foodForTheSnakeY == headSnakeY)
            {
                gameEngine.gameObjects.Remove(foodForTheSnake);
                snake.Add(new Snake(foodForTheSnakeX, foodForTheSnakeY, graphics));
                gameEngine.gameObjects.Add(new Food(randomCoordinate.RandomY(graphics.ClientWidth, headSnakeY, gameEngine.gameObjects), randomCoordinate.RandomX(graphics.ClientHeight, headSnakeX, gameEngine.gameObjects)));
                gameEngine.currentScore++;
            }
        }
    }
}