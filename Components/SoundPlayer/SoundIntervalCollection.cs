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
        public static readonly IReadOnlyDictionary<SoundType, SoundInterval> soundCollection =
            new Dictionary<SoundType, SoundInterval>()
        {
            {
                SoundType.Movement,
                new SoundInterval()
                {
                    Sounds =
                    [
                        new Sound() { Frequency = 523, Duration = 80 }
                    ]
                }
            },
            {
                SoundType.WallCollision,
                new SoundInterval()
                {
                    Sounds =
                    [
                        new Sound() { Frequency = 330, Duration = 80 },
                        new Sound() { Frequency = 294, Duration = 80 }
                    ]
                }
            },
            {
                SoundType.KeyPickup,
                new SoundInterval()
                {
                    Sounds =
                    [
                        new Sound() { Frequency = 392, Duration = 100 },
                        new Sound() { Frequency = 523, Duration = 100 },
                        new Sound() { Frequency = 659, Duration = 100 }
                    ]
                }
            },
            {
                SoundType.LevelFinished,
                new SoundInterval()
                {
                    Sounds =
                    [
                        new Sound { Frequency = 196, Duration = 100 },
                        new Sound { Frequency = 440, Duration = 80 },
                        new Sound { Frequency = 220, Duration = 100 },
                        new Sound { Frequency = 415, Duration = 80 },
                        new Sound { Frequency = 196, Duration = 100 },
                        new Sound { Frequency = 392, Duration = 80 },
                        new Sound { Frequency = 196, Duration = 120 }
                    ]
                }
            },
            {
                SoundType.GameFinished,
                new SoundInterval()
                {
                    Sounds =
                    [
                        new Sound { Frequency = 523, Duration = 250 },
                        new Sound { Frequency = 659, Duration = 250 },
                        new Sound { Frequency = 784, Duration = 250 },
                        new Sound { Frequency = 1047, Duration = 250 },
                        new Sound { Frequency = 784, Duration = 250 },
                        new Sound { Frequency = 659, Duration = 250 },
                        new Sound { Frequency = 523, Duration = 250 }
                    ]
                }
            },
            {
                SoundType.InvalidInput,
                new SoundInterval()
                {
                    Sounds =
                    [
                        new Sound { Frequency = 164, Duration = 60 },
                        new Sound { Frequency = 147, Duration = 60 }
                    ]
                }
            },
            {
                SoundType.ValidInput,
                new SoundInterval()
                {
                    Sounds =
                    [
                        new Sound { Frequency = 220, Duration = 50 },
                        new Sound { Frequency = 261, Duration = 50 }
                    ]
                }
            },
            {
                SoundType.EndScreen,
                new SoundInterval()
                {
                    Sounds =
                    [
                        new Sound { Frequency = 100, Duration = 50 },
                        new Sound { Frequency = 500, Duration = 50 },
                        new Sound { Frequency = 100, Duration = 50 },
                        new Sound { Frequency = 500, Duration = 50 }
                    ]
                }
            }
        };
    }
}
