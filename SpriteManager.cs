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

        public static void CreateAllGameSprites()
        {
            ground = new Sprite(GroundLabel, GroundLabel, ConsoleColor.White, ConsoleColor.Gray);
            wall = new Sprite(WallLabel, WallLabel, ConsoleColor.White, ConsoleColor.DarkGray);
            key = new Sprite(KeyLabel, KeyLabel, ConsoleColor.White, ConsoleColor.Yellow);
            door = new Sprite(DoorLabel, DoorLabel, ConsoleColor.White, ConsoleColor.Magenta);
            player = new Player(PlayerLabel, PlayerLabel, ConsoleColor.White, ConsoleColor.Blue);
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
        /// Returns the sprite associated with a given character.
        /// </summary>
        /// <param name="spriteChar">The character representing a sprite.</param>
        /// <returns>The corresponding <see cref="Sprite"/> object.</returns>
        public static Sprite GetSpriteFromChar(char spriteChar)
        {
            return (_spriteKeyPairs[spriteChar]);
        }

        /// <summary>
        /// Returns the player sprite.
        /// </summary>
        public static Player GetPlayer() => player;

        /// <summary>
        /// Returns the ground sprite.
        /// </summary>
        public static Sprite GetGround() => ground;

        /// <summary>
        /// Returns the wall sprite.
        /// </summary>
        public static Sprite GetWall() => wall;

        /// <summary>
        /// Returns the key sprite.
        /// </summary>
        public static Sprite GetKey() => key;

        /// <summary>
        /// Returns the door sprite.
        /// </summary>
        public static Sprite GetDoor() => door;
    }
}
