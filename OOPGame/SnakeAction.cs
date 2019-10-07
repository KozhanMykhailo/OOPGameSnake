using NConsoleGraphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGame
{
    class SnakeAction
    {
        public void HeadMovement(List<IGameObject> obj, GameEngine engine)
        {
            obj.OfType<Snake>().First().Update(engine);
        }
        public void BodyMovement(List<IGameObject> obj, GameEngine engine)
        {
            if (obj.OfType<Snake>().Count() > 1)
            {
                var headSnake = obj.OfType<Snake>().First();
                var snakeBoby = obj.OfType<Snake>().Where(w => w != obj.OfType<Snake>().First()).ToList();
                int headSnakeXTemp = headSnake.X;
                int headSnakeYTemp = headSnake.Y;
                for (int i = snakeBoby.Count - 1; i > 0; i--)
                {
                    snakeBoby[i].X = snakeBoby[i - 1].X;
                    snakeBoby[i].Y = snakeBoby[i - 1].Y;
                }
                Snake firstSnakeBobyPart = snakeBoby[0];
                firstSnakeBobyPart.X = headSnakeXTemp;
                firstSnakeBobyPart.Y = headSnakeYTemp;
            }
        }

        public void BodyEatingTest(List<IGameObject> obj, GameEngine gameEngine)
        {
            var headSnake = obj.OfType<Snake>().First();
            var snakeBoby = obj.OfType<Snake>().Where(w => w != obj.OfType<Snake>().First()).ToList();
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
        public void EatingFood(List<IGameObject> obj, GameEngine gameEngine, RandomCoordinate Rand, ConsoleGraphics graphics)
        {
            var headSnake = obj.OfType<Snake>().First();
            var foodForTheSnake = obj.OfType<Food>().First();
            var foodForTheSnakeX = foodForTheSnake.X;
            var foodForTheSnakeY = foodForTheSnake.Y;
            var headSnakeX = headSnake.X;
            var headSnakeY = headSnake.Y;

            if (foodForTheSnakeX == headSnakeX && foodForTheSnakeY == headSnakeY)
            {
                obj.Remove(foodForTheSnake);
                obj.Add(new Snake(foodForTheSnakeY, foodForTheSnakeX, graphics));
                obj.Add(new Food(Rand.RandomY(graphics.ClientWidth, headSnakeY, obj), Rand.RandomX(graphics.ClientHeight, headSnakeX, obj)));
                gameEngine.currentScore++;
            }
        }
    }
}
