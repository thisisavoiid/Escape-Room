using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escape_Room
{
    /// <summary>
    /// Represents a single sound with a specific frequency and duration.
    /// </summary>
    public struct Sound
    {
        /// <summary>
        /// Frequency of the sound in Hertz.
        /// </summary>
        public int frequency;

        /// <summary>
        /// Duration of the sound in milliseconds.
        /// </summary>
        public int duration;
    }
}
