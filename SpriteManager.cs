using Escape_Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escape_Room
{
    public class SpriteManager
    {
        private static Player player;
        private static Sprite ground;
        private static Sprite wall;
        private static Sprite key;
        private static Sprite door;

        public static void CreateAllGameSprites()
        {
            player = new Player(' ', ConsoleColor.White, ConsoleColor.Blue);
            ground = new Sprite(' ', ConsoleColor.White, ConsoleColor.Gray);
            wall = new Sprite(' ', ConsoleColor.White, ConsoleColor.DarkGray);
            key = new Sprite(' ', ConsoleColor.White, ConsoleColor.Yellow);
            door = new Sprite(' ', ConsoleColor.White, ConsoleColor.Magenta);
            Console.WriteLine("Created all Sprite instances.");
        }

        public static Player GetPlayer() => player;
        public static Sprite GetGround() => ground;
        public static Sprite GetWall() => wall;
        public static Sprite GetKey() => key;
        public static Sprite GetDoor() => door;


    }
}
