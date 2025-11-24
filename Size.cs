using System;

namespace Escape_Room
{
    /// <summary>
    /// Represents the dimensions of a map or object in terms of width and height.
    /// </summary>
    public struct Size
    {
        /// <summary>
        /// The width dimension.
        /// </summary>
        public int width;

        /// <summary>
        /// The height dimension.
        /// </summary>
        public int height;

        /// <summary>
        /// Returns a string representation of the Size in the format (width, height).
        /// </summary>
        /// <returns>
        /// A string in the format "(width, height)".
        /// </returns>
        public override string ToString() => $"({width}, {height})";
    }
}
