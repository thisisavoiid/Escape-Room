using System;

namespace Escape_Room
{
    public struct Size
    {
        public int Width;
        public int Height;

        /// <summary>
        /// Returns a string representation of the size in the form "(width, height)".
        /// </summary>
        public readonly override string ToString() => $"({Width}, {Height})";
    }
}
