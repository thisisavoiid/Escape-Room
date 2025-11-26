using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escape_Room
{
    /// <summary>
    /// Enum representing all the different types of sounds used in the game.
    /// </summary>
    public enum SoundType
    {
        LevelFinished,
        GameFinished,
        InvalidInput,
        ValidInput,
        WallCollision,
        KeyPickup,
        Movement,
        EndScreen
    }
}
