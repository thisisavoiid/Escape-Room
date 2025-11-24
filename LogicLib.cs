using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escape_Room
{
    public class LogicLib
    {
        public static bool IsNumeral(string input) => int.TryParse(input, out _);
        public static bool IsInRange(int input, int min, int max) => input <= max && input >= min;
    }
}
