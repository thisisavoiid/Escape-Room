using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escape_Room
{
    /// <summary>
    /// Provides utility logic functions such as number validation and range checking.
    /// </summary>
    public class LogicLib
    {
        /// <summary>
        /// Checks whether the given string can be parsed into an integer.
        /// </summary>
        /// <param name="input">
        /// The string to validate.
        /// </param>
        public static bool IsNumeral(string input) => int.TryParse(input, out _);

        /// <summary>
        /// Checks whether the given integer lies within a specified inclusive range.
        /// </summary>
        /// <param name="input">
        /// The number to check.
        /// </param>
        /// <param name="min">
        /// The minimum accepted value.
        /// </param>
        /// <param name="max">
        /// The maximum accepted value.
        /// </param>
        public static bool IsInRange(int input, int min, int max) => input <= max && input >= min;
    }
}
