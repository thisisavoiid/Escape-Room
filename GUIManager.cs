using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escape_Room
{
    public class GUIManager
    {
        private static string _infoDialogString = string.Empty;
        private static string BuildTopLine() => $"Level: {GameManager.GetCurrentLevel()} | Steps: {SpriteManager.GetPlayer().stepsDone}";
        private static string BuildBottomLine() => $"{_infoDialogString}";
        private static void DrawInfoBoard()
        {
            Console.SetCursorPosition(0, Map.GetSize().height + 1);
            Console.WriteLine(BuildTopLine() + new string(' ', Console.BufferWidth - BuildTopLine().Length));
            Console.WriteLine(BuildBottomLine() + new string(' ', Console.BufferWidth - BuildBottomLine().Length));
        }

        /// <summary>
        /// Sets the text displayed in the info dialog bar.
        /// </summary>
        /// <param name="text">The text to display.</param>
        public static void SetInfoDialogBar(string text)
        {
            _infoDialogString = text;
            DrawGUI();
        }

        /// <summary>
        /// Redraws the GUI, including the info board.
        /// </summary>
        public static void DrawGUI()
        {
            DrawInfoBoard();
        }
    }
}
