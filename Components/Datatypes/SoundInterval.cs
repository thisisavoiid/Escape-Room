namespace Escape_Room
{
    /// <summary>
    /// Represents a sequence of <see cref="Sound"/> objects that are played one after another.
    /// </summary>
    public struct SoundInterval
    {
        /// <summary>
        /// Array of <see cref="Sound"/> objects defining the frequency and duration of each sound in the interval.
        /// </summary>
        public Sound[] Sounds;
    }
}
