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
        public int ClientHeight { get; }
        public int ClientWidth { get; }


        public Canvas(uint color, int clientHeight, int clientWidth)
        {
            this._color = color;
            this.ClientHeight = clientHeight;
            this.ClientWidth = clientWidth;
        }

        public void Render(ConsoleGraphics g)
        {
            g.FillRectangle(_color, 0, 0, ClientHeight, ClientWidth);
        }
    }
}
