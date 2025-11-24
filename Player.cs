using Escape_Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escape_Room
{
    public class Player : Sprite
    {
        private readonly List<Sprite> _nonTrespassableSprites;

        public int stepsDone { get; private set; } = 0;
        public bool canMove { get; private set; } = true;

        public Player(char character, char label, ConsoleColor fgcolor, ConsoleColor bgcolor) : base(character, label, fgcolor, bgcolor)
        {
            this._nonTrespassableSprites = new List<Sprite>() { SpriteManager.GetDoor(), SpriteManager.GetWall() };
            this.stepsDone = 0;
            this.foregroundColor = fgcolor;
            this.backgroundColor = bgcolor;
            this.character = character;
        }

        /// <summary>
        /// Determines whether the sprite at the given position can be moved onto.
        /// </summary>
        /// <param name="position">The target position to check.</param>
        /// <returns>True if the position is trespassable; otherwise, false.</returns>
        private bool IsTrespassable(Vector2 position)
        {
            Sprite spriteAtTargetPosition = Map.GetSpriteAt(position);
            return !_nonTrespassableSprites.Select(sprite => sprite.label).Contains(spriteAtTargetPosition.label);
        }

        /// <summary>
        /// Determines whether the sprite at the given position is collectible (i.e., a key).
        /// </summary>
        /// <param name="position">The target position to check.</param>
        /// <returns>True if the position contains a collectible; otherwise, false.</returns>
        private static bool IsCollectible(Vector2 position)
        {
            Sprite spriteAtTargetPosition = Map.GetSpriteAt(position);
            return spriteAtTargetPosition.label == SpriteManager.KeyLabel;
        }

        public void DisableMovement()
        {
            canMove = false;
        }

        public void EnableMovement()
        {
            canMove = true;
        }

        /// <summary>
        /// Determines whether the given position is the level exit (door).
        /// </summary>
        /// <param name="position">The target position to check.</param>
        /// <returns>True if the position is the level exit; otherwise, false.</returns>
        private bool IsLevelExit(Vector2 position) => position == SpriteManager.GetDoor().GetPosition();

        /// <summary>
        /// Moves the player in the specified direction, handling collisions, collectibles, and level progression.
        /// </summary>
        /// <param name="direction">The direction to move the player.</param>
        public void Move(Vector2 direction)
        {
            Vector2 targetPosition = new Vector2(this.position.x, this.position.y) + new Vector2(direction.x, direction.y);

            if (targetPosition != this.position)
            {
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
}
