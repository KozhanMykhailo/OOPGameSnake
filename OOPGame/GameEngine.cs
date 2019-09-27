using NConsoleGraphics;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;

namespace OOPGame
{

    public abstract class GameEngine
    {
        public int maxScore;
        public int currentScore;
        private const uint colorCanvas = 0xFFd3fd45;
        private bool whileRepeat = true;
        private ConsoleGraphics graphics;
        private List<IGameObject> headSnakeAndFood = new List<IGameObject>();
        private List<Food> snakeBoby = new List<Food>();
        private List<IGameObject> tempObjects = new List<IGameObject>();
        Canvas canvas;

        public GameEngine(ConsoleGraphics graphics)
        {
            this.graphics = graphics;
        }

        public void AddObject(IGameObject obj)
        {
            tempObjects.Add(obj);
        }
        private void ClearGameObject()
        {
            headSnakeAndFood.Clear();
            snakeBoby.Clear();
            whileRepeat = true;
            currentScore = 0;
        }
        public void RepeatFalse()
        {
            whileRepeat = false;
        }
        public void NewSnake()
        {
                AddObject(new Food(Rand.RandomY(graphics), Rand.RandomX(graphics)));
                AddObject(new HeadSnake(Rand.RandomY(graphics), Rand.RandomX(graphics), graphics));
        }
        private void Restart()
        {
            canvas = new Canvas(0xFFd7c645, graphics.ClientWidth, graphics.ClientHeight);
            canvas.Render(graphics);
            graphics.DrawString("Игра окончена", "Arial", 0xFFc98d5a, graphics.ClientWidth - graphics.ClientWidth, graphics.ClientHeight - graphics.ClientHeight, 25);
            graphics.DrawString($"Ваш счёт : {currentScore}", "Arial", 0xFFFFFFFF, graphics.ClientWidth - graphics.ClientWidth, graphics.ClientHeight - graphics.ClientHeight + 40, 25);
            graphics.DrawString($"Ваш лучший счёт : {maxScore}", "Arial", 0xFFFFFFFF, graphics.ClientWidth - graphics.ClientWidth, graphics.ClientHeight - graphics.ClientHeight + 80, 25);
            graphics.DrawString("Нажмите Y для рестарта или N для выхода", "Arial", 0xFFFFFFFF, graphics.ClientWidth - graphics.ClientWidth, graphics.ClientHeight - graphics.ClientHeight + 120, 20);
            graphics.FlipPages();
            bool temp = true;
            do
            {
                var answer = Console.ReadLine().ToLower();
                if (answer == "y")
                {
                    ClearGameObject();
                    NewSnake();
                    Start();
                    temp = false;
                }
                else if (answer == "n")
                {
                    temp = false;
                }
            }
            while (temp);
        }


        public void Start()
        {

            while (whileRepeat)
            {
                foreach (var obj in headSnakeAndFood)
                {
                    obj.Update(this);
                }
                headSnakeAndFood.AddRange(tempObjects);
                {
                    tempObjects.Clear();
                }
                canvas = new Canvas(colorCanvas, graphics.ClientWidth, graphics.ClientHeight);
                foreach (var obj in snakeBoby)
                {
                    obj.Render(graphics);
                }
                foreach (var obj in headSnakeAndFood)
                {
                    obj.Render(graphics);
                }
                CoordinateCheck(headSnakeAndFood, snakeBoby);
                if (snakeBoby.Count > 0)
                {
                    SnakeBodyMove(headSnakeAndFood, snakeBoby);
                }
                graphics.FlipPages();
                canvas.Render(graphics);
                Thread.Sleep(100);
            }
            if (currentScore > maxScore) maxScore = currentScore;
            Restart();
        }
        
        private void CoordinateCheck(List<IGameObject> headSnakeAndFood, List<Food> snakeBoby)
        {
            int foodForTheSnakeX = default(int), foodForTheSnakeY = default(int), headSnakeX = default(int), headSnakeY = default(int);
            var headSnake = headSnakeAndFood.OfType<HeadSnake>().Select(s => s).First();//потому что в листе headSnakeAndFood всегда 1 объект "головы" 
            var foodForTheSnake = headSnakeAndFood.OfType<Food>().Select(s => s).First();//потому что в листе headSnakeAndFood всегда 1 объект "еды" 
            foodForTheSnakeX = foodForTheSnake.X;
            foodForTheSnakeY = foodForTheSnake.Y;
            headSnakeX = headSnake.X;
            headSnakeY = headSnake.Y;

            foreach (var body in snakeBoby)
            {
                if (headSnakeX == body.X && headSnakeY == body.Y)//проверка не съел ли он сам себя
                {
                    RepeatFalse();
                    break;
                }
            }

            if (foodForTheSnakeX == headSnakeX && foodForTheSnakeY == headSnakeY)
            {
                headSnakeAndFood.Remove(foodForTheSnake);
                snakeBoby.Add(foodForTheSnake);
                AddObject(new Food(Rand.RandomY(graphics, headSnakeY, this.snakeBoby), Rand.RandomX(graphics, headSnakeX, this.snakeBoby)));
                //AddObject(new Food(Rand.RandomY(graphics), Rand.RandomX(graphics)));
                currentScore++;
            }
        }
        private void SnakeBodyMove(List<IGameObject> headSnakeAndFood, List<Food> snakeBoby)
        {
            var headSnake = headSnakeAndFood.OfType<HeadSnake>().Select(s => s).First();
            int headSnakeXTemp = headSnake.X;
            int headSnakeYTemp = headSnake.Y;
            for (int i = snakeBoby.Count - 1; i > 0; i--)
            {
                snakeBoby[i].SetX(snakeBoby[i - 1].X);
                snakeBoby[i].SetY(snakeBoby[i - 1].Y);
            }
            Food firstSnakeBobyPart = snakeBoby[0];
            firstSnakeBobyPart.SetX(headSnakeXTemp);
            firstSnakeBobyPart.SetY(headSnakeYTemp);
        }
    }
}
