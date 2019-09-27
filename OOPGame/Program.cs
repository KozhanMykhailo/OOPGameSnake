using NConsoleGraphics;
using System;

namespace OOPGame
{

    public class Program
    {


        static void Main(string[] args)
        {

            Console.WindowWidth = 80;
            Console.WindowHeight = 40;
            Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.CursorVisible = false;
            Console.Clear();

            ConsoleGraphics graphics = new ConsoleGraphics();

            GameEngine engine = new SampleGameEngine(graphics);
            engine.NewSnake(); 
            engine.Start();
        }

    }
}
