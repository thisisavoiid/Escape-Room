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
        /// Maps each <see cref="E_GamemodeType"/> to its corresponding <see cref="GamemodeInfo"/>,
        /// containing the display name and description for the mode.
        /// </summary>
        public static readonly IReadOnlyDictionary<E_GamemodeType, GamemodeInfo> InfoMap =
            new Dictionary<E_GamemodeType, GamemodeInfo>()
        {
            {
                E_GamemodeType.LevelBasedMode,
                new GamemodeInfo()
                {
                    displayName = "Level-Based Mode",
                    displayDescription =
                        "Play through a series of preset escape rooms with increasing difficulty."
                }
            },
            {
                E_GamemodeType.CustomLevelMode,
                new GamemodeInfo()
                {
                    displayName = "Custom Level Mode",
                    displayDescription =
                        "Create a custom room by choosing your own map size."
                }
            }
        };
    }
}
