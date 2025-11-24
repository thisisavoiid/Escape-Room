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
        private static readonly Dictionary<ConsoleKey, Vector2> _inputMap = new Dictionary<ConsoleKey, Vector2>()
        {
            {ConsoleKey.LeftArrow, Vector2.Left()},
            {ConsoleKey.RightArrow, Vector2.Right()},
            {ConsoleKey.UpArrow, Vector2.Down()},
            {ConsoleKey.DownArrow, Vector2.Up()}
        };

        /// <summary>
        /// Returns the next key pressed by the user.
        /// </summary>
        /// <returns>The <see cref="ConsoleKey"/> representing the key pressed.</returns>
        public static ConsoleKey GetKeyPressed() => Console.ReadKey(true).Key;

        /// <summary>
        /// Returns the movement vector associated with a given key.
        /// </summary>
        /// <param name="key">The key to translate into a movement vector.</param>
        /// <returns>A <see cref="Vector2"/> representing the movement direction.</returns>
        public static Vector2 GetMoveDirection(ConsoleKey key) => _inputMap.GetValueOrDefault(key, Vector2.Zero());
    }
}
