using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escape_Room
{
    public class LogicLib
    {
        /// <summary>
        /// Determines whether the given string represents a valid integer numeral.
        /// </summary>
        /// <param name="input">The string to check.</param>
        /// <returns>True if the string is a numeral; otherwise, false.</returns>
        public static bool IsNumeral(string input) => int.TryParse(input, out _);

        /// <summary>
        /// Determines whether the given integer falls within the specified range (inclusive).
        /// </summary>
        /// <param name="input">The number to check.</param>
        /// <param name="min">The minimum value in the range.</param>
        /// <param name="max">The maximum value in the range.</param>
        /// <returns>True if the number is within the range; otherwise, false.</returns>
        public static bool IsInRange(int input, int min, int max) => input <= max && input >= min;
    }
}
