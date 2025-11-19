using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escape_Room
{
    public class Sprite
    {
        public char character;
        public ConsoleColor foregroundColor;
        public ConsoleColor backgroundColor;
        protected Vector2 position;

        public Sprite(char character, ConsoleColor fgcolor, ConsoleColor bgcolor)
        {
            Console.WriteLine("Sprite has been created!");
            this.character = character;
            this.foregroundColor = fgcolor;
            this.backgroundColor = bgcolor;
        }

        public void SetPosition(Vector2 pos) => position = pos;
        public Vector2 GetPosition() => position;

        public void Draw()
        {
            Console.ForegroundColor = this.foregroundColor;
            Console.BackgroundColor = this.backgroundColor;
            Console.Write(character);
            Console.ResetColor();
        }
    }

}
