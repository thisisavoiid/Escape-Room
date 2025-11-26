namespace Escape_Room
{
    public class ConsolePrinter
    {
        /// <summary>
        /// Prints a message to the console using colors defined for the specified print level.
        /// After printing, optionally pauses execution for a specified duration.
        /// </summary>
        /// <param name="printLevel">The <see cref="PrintLevel"/> determining the message's color formatting.</param>
        /// <param name="text">The text message to print.</param>
        /// <param name="sleepFor">Optional delay in milliseconds after printing the message.</param>
        public static void Print(PrintLevel printLevel, string text, int sleepFor = 0)
        {
            bool hasCursorBeenEnabled = Console.CursorVisible;

            Console.CursorVisible = false;

            // Apply the foreground and background colors based on the print level
            Console.ForegroundColor = PrintLevelFormat.printFormat[printLevel].ForegroundColor;
            Console.BackgroundColor = PrintLevelFormat.printFormat[printLevel].BackgroundColor;

            // Print the message to the console
            Console.WriteLine(text);

            // Reset console colors to default
            Console.ResetColor();

            // Pause execution if a sleep duration is specified
            if (sleepFor > 0)
            {
                Thread.Sleep(sleepFor);
            }

            if (hasCursorBeenEnabled)
            {
                Console.CursorVisible = true;
            }
        }
    }
}
