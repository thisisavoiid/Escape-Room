namespace Escape_Room
{
    /// <summary>
    /// Handles playing sounds defined in the <see cref="SoundIntervalCollection"/>.
    /// </summary>
    public class SoundPlayer
    {
        /// <summary>
        /// Plays all the <see cref="Sound"/> objects associated with a specific game sound type asynchronously.
        /// </summary>
        /// <param name="sound">The type of sound to play from the <see cref="SoundIntervalCollection"/>.</param>
        public static void PlayAsync(SoundType sound)
        {
            Task.Run(() =>
            {
                foreach (Sound soundItem in SoundIntervalCollection.soundCollection[sound].Sounds)
                {
                    Console.Beep(
                        soundItem.Frequency,
                        soundItem.Duration
                    );
                }
            });
        }

        /// <summary>
        /// Plays all the <see cref="Sound"/> objects associated with a specific game sound type.
        /// </summary>
        /// <param name="sound">The type of sound to play from the <see cref="SoundIntervalCollection"/>.</param>
        public static void Play(SoundType sound)
        {
            foreach (Sound soundItem in SoundIntervalCollection.soundCollection[sound].Sounds)
            {
                Console.Beep(
                    soundItem.Frequency,
                    soundItem.Duration
                );
            }
        }
    }
}
