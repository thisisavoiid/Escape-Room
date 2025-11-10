using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escape_Room
{
    public struct Sprite
    {
        public char Character;
        public ConsoleColor ForegroundColor;
        public ConsoleColor BackgroundColor;

        public Sprite(char character, ConsoleColor fgcolor, ConsoleColor bgcolor)
        {
            this.Character = character;
            this.ForegroundColor = fgcolor;
            this.BackgroundColor = bgcolor;
        }
        public void SetColors() // Setzt die Konsolenfarben auf die übergebenen Farben dieser Sprite

        {
            Console.ForegroundColor = this.ForegroundColor;
            Console.BackgroundColor = this.BackgroundColor;
        }
    }
}
