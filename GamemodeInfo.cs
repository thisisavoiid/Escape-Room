using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escape_Room
{
    /// <summary>
    /// Holds descriptive information for a game mode, including its name and description.
    /// Can be used to display details about each mode in selection menus or info dialogs.
    /// </summary>
    public struct GamemodeInfo
    {
        /// <summary>
        /// The display name of the game mode.
        /// </summary>
        public string displayName;

        /// <summary>
        /// A brief description of the game mode.
        /// </summary>
        public string displayDescription;
    }
}
