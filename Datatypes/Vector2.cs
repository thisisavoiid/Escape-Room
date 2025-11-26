using System;
using Vector2 = Escape_Room.Vector2;

namespace Escape_Room
{
    /// <summary>
    /// Represents a two-dimensional vector with integer components.
    /// </summary>
    public struct Vector2
    {
        public int X;
        public int Y;

        /// <summary>
        /// Initializes a new <see cref="Vector2"/> with both components set to zero.
        /// </summary>
        public Vector2()
        {
            X = 0;
            Y = 0;
        }

        /// <summary>
        /// Initializes a new <see cref="Vector2"/> with specified x and y components.
        /// </summary>
        /// <param name="x">The x-component of the <see cref="Vector2"/>.</param>
        /// <param name="y">The y-component of the <see cref="Vector2"/>.</param>
        public Vector2(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// Returns a string representation of the <see cref="Vector2"/> in the form "(x, y)".
        /// </summary>
        public override string ToString() => $"({this.X}, {this.Y})";

        /// <summary>
        /// Adds two vectors component-wise.
        /// </summary>
        /// <param name="vector01">The first <see cref="Vector2"/>.</param>
        /// <param name="vector02">The second <see cref="Vector2"/>.</param>
        /// <returns>The sum of the two vectors.</returns>
        public static Vector2 operator +(Vector2 vector01, Vector2 vector02)
        {
            return new Vector2() { X = vector01.X + vector02.X, Y = vector01.Y + vector02.Y };
        }

        /// <summary>
        /// Determines whether two vectors are equal (same x and y components).
        /// </summary>
        public static bool operator ==(Vector2 vector01, Vector2 vector02) => vector01.X == vector02.X && vector01.Y == vector02.Y;

        /// <summary>
        /// Determines whether two vectors are not equal (different x or y component).
        /// </summary>
        public static bool operator !=(Vector2 vector01, Vector2 vector02) => vector01.X != vector02.X || vector01.Y != vector02.Y;

        /// <returns>
        /// A <see cref="Vector2"/> pointing up (0, 1).
        /// </returns>
        public static Vector2 Up() => new Vector2() { X = 0, Y = 1 };

        /// <returns>
        /// A <see cref="Vector2"/> pointing down (0, -1).
        /// </returns>
        public static Vector2 Down() => new Vector2() { X = 0, Y = -1 };

        /// <returns>
        /// A <see cref="Vector2"/> pointing left (-1, 0).
        /// </returns>
        public static Vector2 Left() => new Vector2() { X = -1, Y = 0 };

        /// <returns>
        /// A <see cref="Vector2"/> pointing right (1, 0).
        /// </returns>
        public static Vector2 Right() => new Vector2() { X = 1, Y = 0 };

        /// <returns>
        /// A zero vector (0, 0).
        /// </returns>
        public static Vector2 Zero() => new Vector2() { X = 0, Y = 0 };
    }
}
