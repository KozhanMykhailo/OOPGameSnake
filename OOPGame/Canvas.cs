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
        private int _clientHeight;
        private int _clientWidth;

        public Canvas(uint color, int clientHeight, int clientWidth)
        {
            _color = color;
            _clientHeight = clientHeight;
            _clientWidth = clientWidth;
        }

        public void Render(ConsoleGraphics g)
        {
            g.FillRectangle(_color, 0, 0, _clientHeight, _clientWidth);
        }
    }
}
