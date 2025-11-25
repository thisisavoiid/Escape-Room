using Escape_Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escape_Room
{
    /// <summary>
    /// Provides predefined color formats for each <see cref="E_PrintLevel"/>.
    /// This allows consistent coloring of console messages based on their severity or type.
    /// </summary>
    public class PrintLevelFormat
    {
        /// <summary>
        /// A read-only dictionary mapping each print level to its corresponding foreground and background colors.
        /// </summary>
        public static readonly IReadOnlyDictionary<E_PrintLevel, ColorFormat> printFormat = new Dictionary<E_PrintLevel, ColorFormat>()
        {
            {
                E_PrintLevel.Error,
                new ColorFormat() {
                    foregroundColor = ConsoleColor.Red,
                    backgroundColor = ConsoleColor.Black
                }
            },
            {
                E_PrintLevel.Warning,
                new ColorFormat() {
                    foregroundColor= ConsoleColor.Yellow,
                    backgroundColor= ConsoleColor.Black
                }
            },
            {
                E_PrintLevel.Infoboard,
                new ColorFormat() {
                    foregroundColor= ConsoleColor.White,
                    backgroundColor= ConsoleColor.Black
                }
            },
            {
                E_PrintLevel.Dialog,
                new ColorFormat() {
                    foregroundColor= ConsoleColor.Green,
                    backgroundColor= ConsoleColor.Black
                }
            },
        };
    };
}
