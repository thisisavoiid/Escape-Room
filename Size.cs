using System;

namespace Escape_Room
{
    public struct Size
    {
        public int width;
        public int height;

        /// <summary>
        /// Returns a string representation of the size in the form "(width, height)".
        /// </summary>
        public readonly override string ToString() => $"({width}, {height})";
    }
}
