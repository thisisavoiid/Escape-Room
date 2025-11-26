using Escape_Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Escape_Room
{
    public class GUIManager
    {
        private static string _infoDialogString = string.Empty;

        // Builds the top line of the info board displaying current level and _player steps
        private static string BuildTopLine() => $"Level: {GameManager.GetCurrentLevel()} | Steps: {SpriteManager.GetPlayer().StepsDone}";

        // Builds the bottom line of the info board displaying the current info dialog text
        private static string BuildBottomLine() => $"{_infoDialogString}";

        /// <summary>
        /// Draws the info board at the bottom of the map, including top and bottom lines.
        /// </summary>
        private static void DrawInfoBoard()
        {
            Console.SetCursorPosition(0, Map.GetSize().Height + 1);
            Console.WriteLine(BuildTopLine() + new string(' ', Console.BufferWidth - BuildTopLine().Length));
            Console.WriteLine(BuildBottomLine() + new string(' ', Console.BufferWidth - BuildBottomLine().Length));
        }

        /// <summary>
        /// Clears the console and optionally resets colors.
        /// Can clear instantly or line by line with a delay for visual effect.
        /// </summary>
        /// <param name="resetColors">Whether to reset the console colors.</param>
        /// <param name="lineByLine">Whether to clear line by line with a delay.</param>
        public static void ClearConsole(bool resetColors = false, bool lineByLine = false)
        {
            if (!lineByLine)
            {
                Console.Clear();
            }

            if (resetColors)
            {
                Vector2 prevCursorPosition = new Vector2(
                    Console.GetCursorPosition().Left,
                    Console.GetCursorPosition().Top
                );

                for (int y = 0; y < Console.BufferHeight; y++)
                {
                    Console.SetCursorPosition(0, y);
                    Console.ResetColor();
                    Console.WriteLine(new string(' ', Console.BufferWidth));
                    if (lineByLine)
                    {
                        Thread.Sleep(100);
                    }
                }

                Console.SetCursorPosition(prevCursorPosition.X, prevCursorPosition.Y);
            }
        }

        /// <summary>
        /// Displays the end screen with ASCII art and game statistics centered on the console.
        /// </summary>
        public static void DrawEndScreen()
        {
            string endLogo = " _____   ___  ___  ___ _____   _____  _   _ ___________ \r\n|  __ \\ / _ \\ |  \\/  ||  ___| |  _  || | | |  ___| ___ \\\r\n| |  \\// /_\\ \\| .  . || |__   | | | || | | | |__ | |_/ /\r\n| | __ |  _  || |\\/| ||  __|  | | | || | | |  __||    / \r\n| |_\\ \\| | | || |  | || |___  \\ \\_/ /\\ \\_/ / |___| |\\ \\ \r\n \\____/\\_| |_/\\_|  |_/\\____/   \\___/  \\___/\\____/\\_| \\_|\r\n                                                        \r\n                                                        ";

            // Split the logo into lines for vertical printing
            string[] endLogoParts = endLogo.Split("\n");

            Vector2 posAfterCenterPrint;

            // Calculate the size of the logo
            Size logoSize = new Size()
            {
                Height = endLogoParts.Length,
                Width = endLogoParts[0].Length
            };

            // Calculate starting position to center the logo on the console
            Vector2 startPos = new Vector2(
                Console.BufferWidth / 2 - logoSize.Width / 2,
                Console.BufferHeight / 2 - logoSize.Height / 2
            );

            // Print each line of the ASCII logo at the calculated position
            for (int y = 0; y < logoSize.Height; y++)
            {
                Console.SetCursorPosition(startPos.X, y + startPos.Y);
                Console.Write(endLogoParts[y]);
            }

            // Store the position after the logo has been printed for printing stats below
            posAfterCenterPrint = new Vector2(Console.GetCursorPosition().Left, Console.GetCursorPosition().Top);

            // Prepare the statistics strings to display
            string stepsTakenDisplay = $"Steps taken: " +
                                       $"{SpriteManager.GetPlayer().StepsDone}";

            string timeSpentDisplay = $"Time spent: " +
                                      $"{GameManager.Stopwatch.Elapsed.Minutes.ToString("D2")}:" +
                                      $"{GameManager.Stopwatch.Elapsed.Seconds.ToString("D2")}:" +
                                      $"{GameManager.Stopwatch.Elapsed.Milliseconds.ToString("D2")}";

            string longestDisplayPart = string.Empty;
            string[] endScreenStatDisplayParts = { stepsTakenDisplay, timeSpentDisplay };

            // Determine the longest string for proper centering
            for (int x = 0; x < endScreenStatDisplayParts.Length; x++)
            {
                if (endScreenStatDisplayParts[x].Length > longestDisplayPart.Length)
                {
                    longestDisplayPart = endScreenStatDisplayParts[x];
                }
                else
                {
                    // Add padding spaces to shorter strings to align them with the longest one
                    int spacesMeededPerSide = longestDisplayPart.Length - endScreenStatDisplayParts[x].Length / 2;
                    endScreenStatDisplayParts[x] = $"{new string(' ', spacesMeededPerSide)}{endScreenStatDisplayParts[x]}{new string(' ', spacesMeededPerSide)}";
                }
            }

            // Print the statistics centered below the logo
            for (int x = 0; x < endScreenStatDisplayParts.Length; x++)
            {
                Console.SetCursorPosition(Console.BufferWidth / 2 - endScreenStatDisplayParts[x].Length / 2, posAfterCenterPrint.Y + x + 1);
                Console.WriteLine(endScreenStatDisplayParts[x]);
            }
        }

        /// <summary>
        /// Updates the info dialog bar text and redraws the GUI.
        /// </summary>
        /// <param name="text">The text to display in the info dialog bar.</param>
        public static void SetInfoDialogBar(string text)
        {
            _infoDialogString = text;
            DrawGUI();
        }

        /// <summary>
        /// Redraws the GUI elements, including the info board.
        /// </summary>
        public static void DrawGUI()
        {
            DrawInfoBoard();
        }
    }
}
