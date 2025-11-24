using System;
using Vector2 = Escape_Room.Vector2;

namespace Escape_Room
{
    public struct Vector2
    {
        public int x;
        public int y;

        public Vector2()
        {
            x = 0;
            y = 0;
        }

        public Vector2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Returns a string representation of the vector in the form "(x, y)".
        /// </summary>
        public override string ToString() => $"({this.x}, {this.y})";

        /// <summary>
        /// Adds two vectors component-wise.
        /// </summary>
        /// <param name="vector01">The first vector.</param>
        /// <param name="vector02">The second vector.</param>
        /// <returns>The sum of the two vectors.</returns>
        public static Vector2 operator +(Vector2 vector01, Vector2 vector02)
        {
            return new Vector2() { x = vector01.x + vector02.x, y = vector01.y + vector02.y };
        }

        /// <summary>
        /// Determines whether two vectors are equal.
        /// </summary>
        public static bool operator ==(Vector2 vector01, Vector2 vector02) => vector01.x == vector02.x && vector01.y == vector02.y;

        /// <summary>
        /// Determines whether two vectors are not equal.
        /// </summary>
        public static bool operator !=(Vector2 vector01, Vector2 vector02) => vector01.x != vector02.x || vector01.y != vector02.y;

        /// <summary>
        /// Returns a vector pointing up (0, 1).
        /// </summary>
        public static Vector2 Up() => new Vector2() { x = 0, y = 1 };

        /// <summary>
        /// Returns a vector pointing down (0, -1).
        /// </summary>
        public static Vector2 Down() => new Vector2() { x = 0, y = -1 };

        /// <summary>
        /// Returns a vector pointing left (-1, 0).
        /// </summary>
        public static Vector2 Left() => new Vector2() { x = -1, y = 0 };

        /// <summary>
        /// Returns a vector pointing right (1, 0).
        /// </summary>
        public static Vector2 Right() => new Vector2() { x = 1, y = 0 };

        /// <summary>
        /// Returns a zero vector (0, 0).
        /// </summary>
        public static Vector2 Zero() => new Vector2() { x = 0, y = 0 };

    }
}
