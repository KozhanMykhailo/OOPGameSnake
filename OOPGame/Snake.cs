using NConsoleGraphics;
using System.Collections.Generic;
using System.Linq;

namespace OOPGame
{

    public class Snake : IGameObject
    {
        private List<SnakePart> snake = new List<SnakePart>();
        private ConsoleGraphics g;
        RandomCoordinate randomCoordinate;

        public Snake(ConsoleGraphics graphics, RandomCoordinate rand)
        {
            randomCoordinate = rand;
            g = graphics;
            SnakeAdd();
        }

        public void SnakeAdd()
        {
            snake.Add(new SnakePart(randomCoordinate.RandomY(g.ClientWidth), randomCoordinate.RandomX(g.ClientHeight), g));
        }
        public void Render(ConsoleGraphics graphics)
        {
            foreach (var item in snake)
            {
                item.Render(g);
            }
        }

        public void Update(GameEngine engine)
        {
            BodyMovement(engine);
            snake.OfType<SnakePart>().First().Update(engine);
            BodyEatingTest(engine);
            EatingFood(engine, g);
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
            var headSnake = snake.OfType<SnakePart>().First();
            var snakeBoby = snake.OfType<SnakePart>().Where(w => w != snake.OfType<SnakePart>().First()).ToList();
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
            var headSnake = snake.OfType<SnakePart>().First();
            var foodForTheSnake = gameEngine.gameObjects.OfType<Food>().First();
            var foodForTheSnakeX = foodForTheSnake.X;
            var foodForTheSnakeY = foodForTheSnake.Y;
            var headSnakeX = headSnake.X;
            var headSnakeY = headSnake.Y;
            if (foodForTheSnakeX == headSnakeX && foodForTheSnakeY == headSnakeY)
            {
                gameEngine.gameObjects.Remove(foodForTheSnake);
                snake.Add(new SnakePart(foodForTheSnakeX, foodForTheSnakeY, graphics));
                gameEngine.gameObjects.Add(new Food(randomCoordinate.RandomY(graphics.ClientWidth, headSnakeY, this.snake), randomCoordinate.RandomX(graphics.ClientHeight, headSnakeX, this.snake)));
                gameEngine.currentScore++;
            }
        }
    }
}