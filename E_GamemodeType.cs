using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escape_Room
{
    /// <summary>
    /// Specifies the different gameplay mode types available in the game.
    /// Determines how levels are loaded and played.
    /// </summary>
    public enum E_GamemodeType
    {
        /// <summary>
        /// Standard mode where the player progresses through predefined levels.
        /// </summary>
        LevelBasedMode,

        /// <summary>
        /// Mode where the player loads and plays a custom-created level.
        /// </summary>
        CustomLevelMode
    }
}
