using Escape_Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Vector2 = Escape_Room.Vector2;

namespace Escape_Room
{
    public class InputManager
    {
        // Maps arrow keys to corresponding movement vectors
        private static readonly Dictionary<ConsoleKey, Vector2> _inputMap = new Dictionary<ConsoleKey, Vector2>()
        {
            {ConsoleKey.LeftArrow, Vector2.Left()},
            {ConsoleKey.RightArrow, Vector2.Right()},
            {ConsoleKey.UpArrow, Vector2.Down()},
            {ConsoleKey.DownArrow, Vector2.Up()}
        };
        
        /// <summary>
        /// Returns the next _key pressed by the user.
        /// </summary>
        public static ConsoleKey GetKeyPressed() => Console.ReadKey(true).Key;

        /// <summary>
        /// Returns the movement vector associated with a given _key.
        /// Defaults to zero vector if _key is not mapped.
        /// </summary>
        /// <param name="key">The _key to translate into a movement vector.</param>
        public static Vector2 GetMoveDirection(ConsoleKey key) => _inputMap.GetValueOrDefault(key, Vector2.Zero());
    }
}
