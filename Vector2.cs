using System;
using Vector2 = Escape_Room.Vector2;

namespace Escape_Room
{
    /// <summary>
    /// Represents a 2D integer vector for positions or directions.
    /// </summary>
    public struct Vector2
    {
        /// <summary>
        /// The X coordinate of the vector.
        /// </summary>
        public int x;

        /// <summary>
        /// The Y coordinate of the vector.
        /// </summary>
        public int y;

        /// <summary>
        /// Initializes a new instance of <see cref="Vector2"/> with (0, 0).
        /// </summary>
        public Vector2()
        {
            x = 0;
            y = 0;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="Vector2"/> with specified coordinates.
        /// </summary>
        /// <param name="x">
        /// The X coordinate.
        /// </param>
        /// <param name="y">
        /// The Y coordinate.
        /// </param>
        public Vector2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Returns a string representation of the vector.
        /// </summary>
        /// <returns>
        /// A string in the format "(x, y)".
        /// </returns>
        public override string ToString() => $"({this.x}, {this.y})";

        /// <summary>
        /// Adds two vectors together.
        /// </summary>
        /// <param name="vector01">
        /// The first vector.
        /// </param>
        /// <param name="vector02">
        /// The second vector.
        /// </param>
        /// <returns>
        /// A new <see cref="Vector2"/> that is the sum of the two vectors.
        /// </returns>
        public static Vector2 operator +(Vector2 vector01, Vector2 vector02)
        {
            return new Vector2() { x = vector01.x + vector02.x, y = vector01.y + vector02.y };
        }

        /// <summary>
        /// Checks if two vectors are equal.
        /// </summary>
        /// <param name="vector01">
        /// The first vector.
        /// </param>
        /// <param name="vector02">
        /// The second vector.
        /// </param>
        /// <returns>
        /// True if both X and Y coordinates are equal; otherwise, false.
        /// </returns>
        public static bool operator ==(Vector2 vector01, Vector2 vector02) => vector01.x == vector02.x && vector01.y == vector02.y;

        /// <summary>
        /// Checks if two vectors are not equal.
        /// </summary>
        /// <param name="vector01">
        /// The first vector.
        /// </param>
        /// <param name="vector02">
        /// The second vector.
        /// </param>
        /// <returns>
        /// True if either X or Y coordinates differ; otherwise, false.
        /// </returns>
        public static bool operator !=(Vector2 vector01, Vector2 vector02) => vector01.x != vector02.x || vector01.y != vector02.y;

        /// <summary>
        /// Returns a vector pointing up (0, 1).
        /// </summary>
        /// <returns>
        /// A new <see cref="Vector2"/> pointing up.
        /// </returns>
        public static Vector2 Up() => new Vector2() { x = 0, y = 1 };

        /// <summary>
        /// Returns a vector pointing down (0, -1).
        /// </summary>
        /// <returns>
        /// A new <see cref="Vector2"/> pointing down.
        /// </returns>
        public static Vector2 Down() => new Vector2() { x = 0, y = -1 };

        /// <summary>
        /// Returns a vector pointing left (-1, 0).
        /// </summary>
        /// <returns>
        /// A new <see cref="Vector2"/> pointing left.
        /// </returns>
        public static Vector2 Left() => new Vector2() { x = -1, y = 0 };

        /// <summary>
        /// Returns a vector pointing right (1, 0).
        /// </summary>
        /// <returns>
        /// A new <see cref="Vector2"/> pointing right.
        /// </returns>
        public static Vector2 Right() => new Vector2() { x = 1, y = 0 };

        /// <summary>
        /// Returns the zero vector (0, 0).
        /// </summary>
        /// <returns>
        /// A new <see cref="Vector2"/> representing zero.
        /// </returns>
        public static Vector2 Zero() => new Vector2() { x = 0, y = 0 };
    }
}
