using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escape_Room
{
    /// <summary>
    /// Provides descriptive information for each game mode type.
    /// </summary>
    public class GamemodeExtensions
    {
        /// <summary>
        /// Maps each <see cref="GamemodeType"/> to its corresponding <see cref="GamemodeInfo"/>,
        /// containing the display name and description for the mode.
        /// </summary>
        public static readonly IReadOnlyDictionary<GamemodeType, GamemodeInfo> InfoMap =
            new Dictionary<GamemodeType, GamemodeInfo>()
        {
            {
                GamemodeType.LevelBasedMode,
                new GamemodeInfo()
                {
                    DisplayName = "Level-Based Mode",
                    DisplayDescription =
                        "Play through a series of preset escape rooms with increasing difficulty."
                }
            },
            {
                GamemodeType.CustomLevelMode,
                new GamemodeInfo()
                {
                    DisplayName = "Custom Level Mode",
                    DisplayDescription =
                        "Create a custom room by choosing your own map size."
                }
            }
        };
    }
}
