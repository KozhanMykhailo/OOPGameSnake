using NConsoleGraphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGame
{
    class Canvas
    {
        private readonly uint _color;
        private int ClientHeight { get; }
        private int ClientWidth { get; }

        public Canvas(uint color, int clientHeight, int clientWidth)
        {
            _color = color;
            ClientHeight = clientHeight;
            ClientWidth = clientWidth;
        }

        public void Render(ConsoleGraphics g)
        {
            g.FillRectangle(_color, 0, 0, ClientHeight, ClientWidth);
        }
    }
}
