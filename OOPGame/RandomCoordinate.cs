using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace OOPGame
{
    public class RandomCoordinate
    {
        Random r = new Random();
        const int cons = 40;
        public int RandomX(int clientHeight)
        {
            var result = r.Next(cons, clientHeight - cons);
            return result -= result % cons;
        }
        public int RandomY(int clientWidth)
        {
            var result = r.Next(cons, clientWidth - cons);
            return result -= result % cons;
        }
        public int RandomX(int clientHeight, int head, List<SnakePart> obj)
        {
            int newX = default;
            var boolForReturn = true;
            do
            {
                var newXTemp = RandomX(clientHeight);
                if (head != newXTemp)
                {
                    foreach (var item in obj)
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
        }

        public int RandomY(int clientWidth, int head, List<SnakePart> obj)
        {
            int newY = default;
            var boolForReturn = true;
            do
            {
                var newYTemp = RandomX(clientWidth);
                if (head != newYTemp)
                {
                    foreach (var item in obj)
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
        }

        public int RandomNumberIndex()
        {
            return r.Next(1,5);
        }
    }
}
