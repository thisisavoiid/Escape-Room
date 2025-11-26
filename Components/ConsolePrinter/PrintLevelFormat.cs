namespace Escape_Room
{
    /// <summary>
    /// Provides predefined color formats for each <see cref="PrintLevel"/>.
    /// This allows consistent coloring of console messages based on their severity or type.
    /// </summary>
    public class PrintLevelFormat
    {
        /// <summary>
        /// A read-only dictionary mapping each print level to its corresponding foreground and background colors.
        /// </summary>
        public static readonly IReadOnlyDictionary<PrintLevel, ColorFormat> printFormat = new Dictionary<PrintLevel, ColorFormat>()
        {
            {
                PrintLevel.Error,
                new ColorFormat() {
                    ForegroundColor = ConsoleColor.Red,
                    BackgroundColor = ConsoleColor.Black
                }
            },
            {
                PrintLevel.Warning,
                new ColorFormat() {
                    ForegroundColor = ConsoleColor.Yellow,
                    BackgroundColor = ConsoleColor.Black
                }
            },
            {
                PrintLevel.Infoboard,
                new ColorFormat() {
                    ForegroundColor = ConsoleColor.White,
                    BackgroundColor = ConsoleColor.Black
                }
            },
            {
                PrintLevel.Dialog,
                new ColorFormat() {
                    ForegroundColor = ConsoleColor.Green,
                    BackgroundColor = ConsoleColor.Black
                }
            },
        };
    };
}
