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
            ground = new Sprite('G', 'G', ConsoleColor.White, ConsoleColor.Gray);
            wall = new Sprite('W', 'W', ConsoleColor.White, ConsoleColor.DarkGray);
            key = new Sprite('K', 'K', ConsoleColor.White, ConsoleColor.Yellow);
            door = new Sprite('D', 'D', ConsoleColor.White, ConsoleColor.Magenta);
            player = new Player('P', 'P', ConsoleColor.White, ConsoleColor.Blue);
        }

        private static Dictionary<char, Sprite> _spriteKeyPairs => new()
        {
            {'W', GetWall() },
            {'D', GetDoor() },
            {'P', GetPlayer() },
            {'K', GetKey() },
            {'G', GetGround() }
        };

        public static Sprite GetSpriteFromChar(char spriteChar)
        {
            return (_spriteKeyPairs[spriteChar]);
        }

        public static Player GetPlayer() => player;
        public static Sprite GetGround() => ground;
        public static Sprite GetWall() => wall;
        public static Sprite GetKey() => key;
        public static Sprite GetDoor() => door;


    }
}
