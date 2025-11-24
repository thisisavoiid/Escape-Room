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
    /// <summary>
    /// Handles user keyboard input and converts pressed keys into movement vectors.
    /// </summary>
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
        /// Gets the key pressed by the user without echoing it to the console.
        /// </summary>
        public static ConsoleKey GetKeyPressed() => Console.ReadKey(true).Key;

        /// <summary>
        /// Converts a ConsoleKey input into a movement direction vector.
        /// </summary>
        /// <param name="key">
        /// The pressed key to translate into a movement vector.
        /// </param>
        public static Vector2 GetMoveDirection(ConsoleKey key) => _inputMap.GetValueOrDefault(key, Vector2.Zero());
    }
}
