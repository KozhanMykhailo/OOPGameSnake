using NConsoleGraphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGame
{

    static class Rand
    {
        static Random r = new Random();
        const int cons = 40;
        static public int RandomX(ConsoleGraphics graphics)
        {
            var result = r.Next(cons, graphics.ClientHeight - cons);
            return result = result - result % cons;
        }
        static public int RandomY(ConsoleGraphics graphics)
        {
            var result = r.Next(cons, graphics.ClientWidth - cons);
            return result = result - result % cons;
        }
        static public int RandomX(ConsoleGraphics graphics, int head, List<Food> snakeBoby)
        {
            int newX = default(int);
            var boolForReturn = true;
            do
            {
                var newXTemp = RandomX(graphics);
                if (head != newXTemp)
                {
                    foreach (var item in snakeBoby)
                    {
                        if (item.X != newXTemp)
                        {
                            boolForReturn = false;
                            newX = newXTemp;
                        }
                        else
                        {
                            boolForReturn = true;
                        }
                    }
                    
                }
            }
            while (boolForReturn);
            return newX;

            //var boolReturnResult = false;
            //var newX = RandomX(graphics);
            //if (head != newX)
            //{
            //    foreach (var item in snakeBoby)
            //    {
            //        if (item.X != newX)
            //        {
            //            boolReturnResult = true;
            //        }
            //        else
            //        {
            //            boolReturnResult = false;
            //        }
            //    }
            //}

            //if (boolReturnResult)
            //{
            //    return newX;
            //}
            //else
            //{
            //    return RandomX(graphics, head, snakeBoby);
            //}

        }


        static public int RandomY(ConsoleGraphics graphics, int head, List<Food> snakeBoby)
        {
            int newY = default(int);
            var boolForReturn = true;
            do
            {
                var newYTemp = RandomX(graphics);
                if (head != newYTemp)
                {
                    foreach (var item in snakeBoby)
                    {
                        if (item.Y != newYTemp)
                        {
                            boolForReturn = false;
                            newY = newYTemp;
                        }
                        else
                        {
                            boolForReturn = true;
                        }
                    }
                }
            }
            while (boolForReturn);
            return newY;

            //var newY = RandomY(graphics);

            //var boolReturnResult = false;
            //if (head != newY)
            //{
            //    foreach (var item in snakeBoby)
            //    {
            //        if (item.Y != newY)
            //        {
            //            boolReturnResult = true;
            //        }
            //        else
            //        {
            //            boolReturnResult = false;
            //        }
            //    }
            //}
            //if (boolReturnResult)
            //{
            //    return newY;
            //}
            //else
            //{
            //    return RandomX(graphics, head, snakeBoby);
            //}
        }

    }


    public class SampleGameEngine : GameEngine
    {

        public SampleGameEngine(ConsoleGraphics graphics)
           : base(graphics)
        {
        }



    }
}
