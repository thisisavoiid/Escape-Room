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
            {ConsoleKey.UpArrow, Vector2.Up()},
            {ConsoleKey.DownArrow, Vector2.Down()}
        };

        public static ConsoleKey GetKeyPressed() => Console.ReadKey(true).Key;
        public static Vector2 GetMoveDirection(ConsoleKey key)
        {
            return _inputMap.GetValueOrDefault(key, Vector2.Zero());
        }
    }
}
