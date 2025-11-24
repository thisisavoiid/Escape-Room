using Escape_Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escape_Room
{
    /// <summary>
    /// Represents the player character in the game, inherits from <see cref="Sprite"/>.
    /// Handles movement, collisions, and interactions with collectibles and level exits.
    /// </summary>
    public class Player : Sprite
    {
        /// <summary>
        /// List of sprites that the player cannot move through.
        /// </summary>
        private readonly List<Sprite> _nonTrespassableSprites;

        /// <summary>
        /// Number of steps the player has taken.
        /// </summary>
        public int stepsDone = 0;

        /// <summary>
        /// Whether the player is allowed to move.
        /// </summary>
        public bool canMove = true;

        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class.
        /// </summary>
        /// <param name="character">
        /// The character displayed for the player.
        /// </param>
        /// <param name="label">
        /// The label representing the player internally.
        /// </param>
        /// <param name="fgcolor">
        /// Foreground color of the player sprite.
        /// </param>
        /// <param name="bgcolor">
        /// Background color of the player sprite.
        /// </param>
        public Player(char character, char label, ConsoleColor fgcolor, ConsoleColor bgcolor) : base(character, label, fgcolor, bgcolor)
        {
            this._nonTrespassableSprites = new List<Sprite>() { SpriteManager.GetDoor(), SpriteManager.GetWall() };
            this.stepsDone = 0;
            this.foregroundColor = fgcolor;
            this.backgroundColor = bgcolor;
            this.character = character;
        }

        /// <summary>
        /// Checks if a given position is passable by the player.
        /// </summary>
        /// <param name="position">
        /// The target position to check.
        /// </param>
        /// <returns>
        /// True if the position is passable; otherwise, false.
        /// </returns>
        private bool IsTrespassable(Vector2 position)
        {
            Sprite spriteAtTargetPosition = SpriteManager.GetSpriteFromChar(Map.GetChars()[position.x, position.y]);
            return !_nonTrespassableSprites.Select(sprite => sprite.label).Contains(spriteAtTargetPosition.label);
        }

        /// <summary>
        /// Checks if the player can collect a sprite at a given position.
        /// </summary>
        /// <param name="position">
        /// The target position to check.
        /// </param>
        /// <returns>
        /// True if the position contains a collectible; otherwise, false.
        /// </returns>
        private bool IsCollectible(Vector2 position)
        {
            Sprite spriteAtTargetPosition = SpriteManager.GetSpriteFromChar(Map.GetChars()[position.x, position.y]);
            return spriteAtTargetPosition.label == 'K';
        }

        /// <summary>
        /// Checks if a given position is the level exit.
        /// </summary>
        /// <param name="position">
        /// The target position to check.
        /// </param>
        /// <returns>
        /// True if the position is the level exit; otherwise, false.
        /// </returns>
        private bool IsLevelExit(Vector2 position) => position == SpriteManager.GetDoor().GetPosition();

        /// <summary>
        /// Moves the player in a specified direction if allowed.
        /// Handles collisions, collectibles, and level progression.
        /// </summary>
        /// <param name="direction">
        /// The direction vector to move the player.
        /// </param>
        public void Move(Vector2 direction)
        {
            Vector2 targetPosition = new Vector2(this.position.x, this.position.y) + new Vector2(direction.x, direction.y);

            if ((targetPosition.x < Map.GetSize().width && targetPosition.x >= 0) &&
                (targetPosition.y <= Map.GetSize().height && targetPosition.y >= 0))
            {
                if (!IsTrespassable(targetPosition)) { return; }
                if (!canMove) { return; }
                if (IsCollectible(targetPosition)) { GameManager.CollectKeyInCurrentLevel(); }
                if (IsLevelExit(targetPosition)) { GameManager.StartNextLevel(); }

                Map.UpdateSprite(this.position, SpriteManager.GetGround());
                this.position = targetPosition;
                Map.UpdateSprite(this.position, SpriteManager.GetPlayer());
                stepsDone++;
            }
        }
    }
}
