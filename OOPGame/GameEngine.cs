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
        public int currentScore = 1;
        private const uint colorCanvas = 0xFFd3fd45;
        private bool whileRepeat = true;
        private ConsoleGraphics graphics;
        public List<IGameObject> gameObjects = new List<IGameObject>();
        Canvas canvas;
        RandomCoordinate randomCoordinate = new RandomCoordinate();

        public GameEngine(ConsoleGraphics graphics)
        {
            this.graphics = graphics;
        }

        public void AddObject(IGameObject obj)
        {
            gameObjects.Add(obj);
        }
        private void ClearGameObject()
        {
            gameObjects.Clear();
            gameObjects.Clear();
            whileRepeat = true;
            currentScore = 1;
        }
        
        public void RepeatFalse()
        {
            whileRepeat = false;
        }

        public void NewSnake()
        {
            AddObject(new Food(randomCoordinate.RandomY(graphics.ClientWidth), randomCoordinate.RandomX(graphics.ClientHeight)));
            AddObject(new Snake(graphics,randomCoordinate));
        }

        private const uint colorCanvasToRestart = 0xFFd7c645;
        private const uint colorTextToRestart1 = 0xFFc98d5a;
        private const uint colorTextToRestart2 = 0xFFFFFFFF;

        private void Restart()
        {
            canvas = new Canvas(colorCanvasToRestart, graphics.ClientWidth, graphics.ClientHeight);
            canvas.Render(graphics);
            graphics.DrawString("Игра окончена", "Arial", colorTextToRestart1, graphics.ClientWidth - graphics.ClientWidth, graphics.ClientHeight - graphics.ClientHeight, 25);
            graphics.DrawString($"Ваш счёт : {currentScore}", "Arial", colorTextToRestart2, graphics.ClientWidth - graphics.ClientWidth, graphics.ClientHeight - graphics.ClientHeight + 40, 25);
            graphics.DrawString($"Ваш лучший счёт : {maxScore}", "Arial", colorTextToRestart2, graphics.ClientWidth - graphics.ClientWidth, graphics.ClientHeight - graphics.ClientHeight + 80, 25);
            graphics.DrawString("Нажмите Y для рестарта или N для выхода", "Arial", colorTextToRestart2, graphics.ClientWidth - graphics.ClientWidth, graphics.ClientHeight - graphics.ClientHeight + 120, 20);
            graphics.FlipPages();
            bool temp = true;
            do
            {
                if (Input.IsKeyDown(Keys.KEY_Y))
                {
                    ClearGameObject();
                    NewSnake();
                    Start();
                    temp = false;
                }
                else if (Input.IsKeyDown(Keys.KEY_N))
                {
                    temp = false;
                }
            }
            while (temp);
        }

        public void Start()
        {
            canvas = new Canvas(colorCanvas, graphics.ClientWidth, graphics.ClientHeight);
            while (whileRepeat)
            {
                for (int i = 0; i < gameObjects.Count; i++)
                {
                    gameObjects[i].Update(this);
                }
                foreach (var obj in gameObjects)
                {
                    obj.Render(graphics);
                }
                graphics.FlipPages();
                canvas.Render(graphics);
                Thread.Sleep(100);
            }
            if (currentScore > maxScore) maxScore = currentScore;
            Restart();
        }
    }
}
