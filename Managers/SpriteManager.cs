using Escape_Room;
using System;
using System.Collections.Generic;

namespace Escape_Room
{
    public class SpriteManager
    {
        private static Player _player;
        private static Sprite _ground;
        private static Sprite _wall;
        private static Sprite _key;
        private static Sprite _door;

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
            _ground = new Sprite(' ', GroundLabel, ConsoleColor.White, ConsoleColor.Gray);
            _wall = new Sprite(' ', WallLabel, ConsoleColor.White, ConsoleColor.DarkGray);
            _key = new Sprite(' ', KeyLabel, ConsoleColor.White, ConsoleColor.Yellow);
            _door = new Sprite(' ', DoorLabel, ConsoleColor.White, ConsoleColor.Magenta);
            _player = new Player(' ', PlayerLabel, ConsoleColor.White, ConsoleColor.Blue);
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
        /// The _player <see cref="Sprite"/> instance.
        /// </returns>
        public static Player GetPlayer() => _player;

        /// <returns>
        /// The _ground <see cref="Sprite"/> instance.
        /// </returns>
        public static Sprite GetGround() => _ground;

        /// <returns>
        /// The _wall <see cref="Sprite"/> instance.
        /// </returns>
        public static Sprite GetWall() => _wall;

        /// <returns>
        /// The _key <see cref="Sprite"/> instance.
        /// </returns>
        public static Sprite GetKey() => _key;

        /// <returns>
        /// The _door <see cref="Sprite"/> instance.
        /// </returns>
        public static Sprite GetDoor() => _door;
    }
}
