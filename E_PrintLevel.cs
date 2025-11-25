using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escape_Room
{
    /// <summary>
    /// Defines the different levels of printed messages used by the game.
    /// </summary>
    public enum E_PrintLevel
    {
        /// <summary>
        /// Represents an error message.
        /// </summary>
        Error,

        /// <summary>
        /// Represents a warning message.
        /// </summary>
        Warning,

        /// <summary>
        /// Represents a dialog or user-facing message.
        /// </summary>
        Dialog,

        /// <summary>
        /// Represents an infoboard or informational message.
        /// </summary>
        Infoboard
    }
}
