using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escape_Room
{
    public struct Size
    {
        public int width;
        public int height;

        public override string ToString() => $"({width}, {height})";
    }
}
