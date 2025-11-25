using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escape_Room
{
    /// <summary>
    /// Handles playing sounds defined in the <see cref="SoundIntervalCollection"/>.
    /// </summary>
    public class SoundPlayer
    {
        /// <summary>
        /// Plays all the <see cref="Sound"/> objects associated with a specific game sound type.
        /// </summary>
        /// <param name="sound">The type of sound to play from the <see cref="SoundIntervalCollection"/>.</param>
        public static void Play(E_Sound sound)
        {
            foreach (Sound soundItem in SoundIntervalCollection.soundCollection[sound].sounds)
            {
                Console.Beep(
                    soundItem.frequency,
                    soundItem.duration
                );
            }
        }
    }
}
