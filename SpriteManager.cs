using Escape_Room;
using System;
using System.Collections.Generic;

namespace Escape_Room
{
    /// <summary>
    /// Manages all game sprites and provides access to them by type or character label.
    /// </summary>
    public class SpriteManager
    {
        private static Player player;
        private static Sprite ground;
        private static Sprite wall;
        private static Sprite key;
        private static Sprite door;

        /// <summary>
        /// Creates all game sprites with their default characters and colors.
        /// </summary>
        public static void CreateAllGameSprites()
        {
            ground = new Sprite('G', 'G', ConsoleColor.White, ConsoleColor.Gray);
            wall = new Sprite('W', 'W', ConsoleColor.White, ConsoleColor.DarkGray);
            key = new Sprite('K', 'K', ConsoleColor.White, ConsoleColor.Yellow);
            door = new Sprite('D', 'D', ConsoleColor.White, ConsoleColor.Magenta);
            player = new Player('P', 'P', ConsoleColor.White, ConsoleColor.Blue);
        }

        /// <summary>
        /// Provides a dictionary mapping sprite labels to their respective Sprite instances.
        /// </summary>
        private static Dictionary<char, Sprite> _spriteKeyPairs => new()
        {
            {'W', GetWall() },
            {'D', GetDoor() },
            {'P', GetPlayer() },
            {'K', GetKey() },
            {'G', GetGround() }
        };

        /// <summary>
        /// Returns the <see cref="Sprite"/> associated with a given character label.
        /// </summary>
        /// <param name="spriteChar">
        /// The character label of the sprite.
        /// </param>
        /// <returns>
        /// The <see cref="Sprite"/> corresponding to the character.
        /// </returns>
        public static Sprite GetSpriteFromChar(char spriteChar)
        {
            return (_spriteKeyPairs[spriteChar]);
        }

        /// <summary>
        /// Returns the player sprite.
        /// </summary>
        /// <returns>
        /// The <see cref="Player"/> instance.
        /// </returns>
        public static Player GetPlayer() => player;

        /// <summary>
        /// Returns the ground sprite.
        /// </summary>
        /// <returns>
        /// The <see cref="Sprite"/> representing the ground.
        /// </returns>
        public static Sprite GetGround() => ground;

        /// <summary>
        /// Returns the wall sprite.
        /// </summary>
        /// <returns>
        /// The <see cref="Sprite"/> representing a wall.
        /// </returns>
        public static Sprite GetWall() => wall;

        /// <summary>
        /// Returns the key sprite.
        /// </summary>
        /// <returns>
        /// The <see cref="Sprite"/> representing the key.
        /// </returns>
        public static Sprite GetKey() => key;

        /// <summary>
        /// Returns the door sprite.
        /// </summary>
        /// <returns>
        /// The <see cref="Sprite"/> representing the door.
        /// </returns>
        public static Sprite GetDoor() => door;
    }
}
