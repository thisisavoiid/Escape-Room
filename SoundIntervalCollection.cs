using System;
using System.Collections.Generic;

namespace Escape_Room
{
    /// <summary>
    /// Holds a collection of predefined <see cref="SoundInterval"/> objects for different game events.
    /// </summary>
    public class SoundIntervalCollection
    {
        /// <summary>
        /// Read-only dictionary mapping each sound type to its corresponding <see cref="SoundInterval"/>.
        /// Each <see cref="SoundInterval"/> contains one or more <see cref="Sound"/> objects defining frequency and duration.
        /// </summary>
        public static readonly IReadOnlyDictionary<E_Sound, SoundInterval> soundCollection =
            new Dictionary<E_Sound, SoundInterval>()
        {
            {
                E_Sound.Movement,
                new SoundInterval()
                {
                    sounds = new Sound[]
                    {
                        new Sound() { frequency = 523, duration = 80 }
                    }
                }
            },
            {
                E_Sound.WallCollision,
                new SoundInterval()
                {
                    sounds = new Sound[]
                    {
                        new Sound() { frequency = 330, duration = 80 },
                        new Sound() { frequency = 294, duration = 80 }
                    }
                }
            },
            {
                E_Sound.KeyPickup,
                new SoundInterval()
                {
                    sounds = new Sound[]
                    {
                        new Sound() { frequency = 392, duration = 100 },
                        new Sound() { frequency = 523, duration = 100 },
                        new Sound() { frequency = 659, duration = 100 }
                    }
                }
            },
            {
                E_Sound.LevelFinished,
                new SoundInterval()
                {
                    sounds = new Sound[]
                    {
                        new Sound { frequency = 196, duration = 100 },
                        new Sound { frequency = 440, duration = 80 },
                        new Sound { frequency = 220, duration = 100 },
                        new Sound { frequency = 415, duration = 80 },
                        new Sound { frequency = 196, duration = 100 },
                        new Sound { frequency = 392, duration = 80 },
                        new Sound { frequency = 196, duration = 120 }
                    }
                }
            },
            {
                E_Sound.GameFinished,
                new SoundInterval()
                {
                    sounds = new Sound[]
                    {
                        new Sound { frequency = 523, duration = 250 },
                        new Sound { frequency = 659, duration = 250 },
                        new Sound { frequency = 784, duration = 250 },
                        new Sound { frequency = 1047, duration = 250 },
                        new Sound { frequency = 784, duration = 250 },
                        new Sound { frequency = 659, duration = 250 },
                        new Sound { frequency = 523, duration = 250 }
                    }
                }
            },
            {
                E_Sound.InvalidInput,
                new SoundInterval()
                {
                    sounds = new Sound[]
                    {
                        new Sound { frequency = 164, duration = 60 },
                        new Sound { frequency = 147, duration = 60 }
                    }
                }
            },
            {
                E_Sound.ValidInput,
                new SoundInterval()
                {
                    sounds = new Sound[]
                    {
                        new Sound { frequency = 220, duration = 50 },
                        new Sound { frequency = 261, duration = 50 }
                    }
                }
            },
            {
                E_Sound.EndScreen,
                new SoundInterval()
                {
                    sounds = new Sound[]
                    {
                        new Sound { frequency = 100, duration = 50 },
                        new Sound { frequency = 500, duration = 50 },
                        new Sound { frequency = 100, duration = 50 },
                        new Sound { frequency = 500, duration = 50 }
                    }
                }
            }
        };
    }
}
