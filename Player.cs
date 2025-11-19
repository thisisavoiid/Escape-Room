using Escape_Room;
using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escape_Room
{
    public class Player : Sprite
    {
        public Player(char character, ConsoleColor fgcolor, ConsoleColor bgcolor) : base(character, fgcolor, bgcolor)
        {
            foregroundColor = fgcolor;
            backgroundColor = bgcolor;
            this.character = character;
        }

        public void Move(Vector2 direction)
        {
            Vector2 targetPosition = new Vector2(direction.x, direction.y) + this.position;

            if ((targetPosition.x < Map.GetSize().width && targetPosition.x >= 0) && (targetPosition.y <= Map.GetSize().height && targetPosition.y >= 0))
            {
                this.position += new Vector2(Math.Clamp(direction.x, -1, 1), Math.Clamp(direction.y, -1, 1));
                Console.WriteLine(this.position.ToString());
            } else
            {
                Console.WriteLine("Player ran against a wall!");
            }

        }
    }
}
