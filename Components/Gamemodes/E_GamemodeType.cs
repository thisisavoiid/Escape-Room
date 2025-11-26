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
    public enum GamemodeType
    {
        /// <summary>
        /// Standard mode where the _player progresses through predefined levels.
        /// </summary>
        LevelBasedMode,

        /// <summary>
        /// Mode where the _player loads and plays a custom-created level.
        /// </summary>
        CustomLevelMode
    }
}
