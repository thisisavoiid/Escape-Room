using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escape_Room
{
    /// <summary>
    /// Represents a pair of foreground and background colors for console text formatting.
    /// Can be used to apply consistent color schemes to text output in the console.
    /// </summary>
    public struct ColorFormat
    {
        /// <summary>
        /// The color of the text itself.
        /// </summary>
        public ConsoleColor ForegroundColor;

        /// <summary>
        /// The color of the text background.
        /// </summary>
        public ConsoleColor BackgroundColor;
    }
}
