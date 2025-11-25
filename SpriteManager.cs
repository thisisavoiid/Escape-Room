using Escape_Room;
using System;
using System.Collections.Generic;

namespace Escape_Room
{
    public class SpriteManager
    {
        private static Player player;
        private static Sprite ground;
        private static Sprite wall;
        private static Sprite key;
        private static Sprite door;

        public const char KeyLabel = 'K';
        public const char DoorLabel = 'D';
        public const char PlayerLabel = 'P';
        public const char WallLabel = 'W';
        public const char GroundLabel = 'G';

        /// <summary>
        /// Initializes all core game sprites with their respective characters and colors.
        /// </summary>
        public static void CreateAllGameSprites()
        {
            ground = new Sprite(' ', GroundLabel, ConsoleColor.White, ConsoleColor.Gray);
            wall = new Sprite(' ', WallLabel, ConsoleColor.White, ConsoleColor.DarkGray);
            key = new Sprite(' ', KeyLabel, ConsoleColor.White, ConsoleColor.Yellow);
            door = new Sprite(' ', DoorLabel, ConsoleColor.White, ConsoleColor.Magenta);
            player = new Player(' ', PlayerLabel, ConsoleColor.White, ConsoleColor.Blue);
        }

        private static Dictionary<char, Sprite> _spriteKeyPairs => new()
        {
            {WallLabel, GetWall() },
            {DoorLabel, GetDoor() },
            {PlayerLabel, GetPlayer() },
            {KeyLabel, GetKey() },
            {GroundLabel, GetGround() }
        };

        /// <summary>
        /// Returns the <see cref="Sprite"/> associated with a given character.
        /// </summary>
        /// <param name="spriteChar">The character representing a <see cref="Sprite"/>.</param>
        /// <returns>The corresponding <see cref="Sprite"/> object.</returns>
        public static Sprite GetSpriteFromChar(char spriteChar)
        {
            return (_spriteKeyPairs[spriteChar]);
        }

        /// <returns>
        /// The player <see cref="Sprite"/> instance.
        /// </returns>
        public static Player GetPlayer() => player;

        /// <returns>
        /// The ground <see cref="Sprite"/> instance.
        /// </returns>
        public static Sprite GetGround() => ground;

        /// <returns>
        /// The wall <see cref="Sprite"/> instance.
        /// </returns>
        public static Sprite GetWall() => wall;

        /// <returns>
        /// The key <see cref="Sprite"/> instance.
        /// </returns>
        public static Sprite GetKey() => key;

        /// <returns>
        /// The door <see cref="Sprite"/> instance.
        /// </returns>
        public static Sprite GetDoor() => door;
    }
}
