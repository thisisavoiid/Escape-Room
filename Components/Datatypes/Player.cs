namespace Escape_Room
{
    public class Player : Sprite
    {
        private readonly List<Sprite> _nonTrespassableSprites;

        public int StepsDone { get; private set; } = 0;
        public bool CanMove { get; private set; } = true;

        /// <summary>
        /// Initializes a new instance of the Player class with the specified visual properties.
        /// </summary>
        /// <param name="character">The character representing the _player on the map.</param>
        /// <param name="Label">The Label used internally for the _player sprite.</param>
        /// <param name="fgcolor">The foreground color of the _player.</param>
        /// <param name="bgcolor">The background color of the _player.</param>
        public Player(char character, char Label, ConsoleColor fgcolor, ConsoleColor bgcolor) : base(character, Label, fgcolor, bgcolor)
        {
            this._nonTrespassableSprites = new List<Sprite>() { SpriteManager.GetDoor(), SpriteManager.GetWall() };
            this.StepsDone = 0;
            this.ForegroundColor = fgcolor;
            this.BackgroundColor = bgcolor;
            this.Character = character;
        }

        /// <summary>
        /// Determines whether the sprite at the given position can be moved onto.
        /// </summary>
        /// <param name="position">The target position to check.</param>
        /// <returns>True if the position is trespassable; otherwise, false.</returns>
        private bool IsTrespassable(Vector2 position)
        {
            Sprite spriteAtTargetPosition = Map.GetSpriteAt(position);
            return !_nonTrespassableSprites.Select(sprite => sprite.Label).Contains(spriteAtTargetPosition.Label);
        }

        /// <summary>
        /// Determines whether the sprite at the given position is collectible (i.e., a _key).
        /// </summary>
        /// <param name="position">The target position to check.</param>
        /// <returns>True if the position contains a collectible; otherwise, false.</returns>
        private static bool IsCollectible(Vector2 position)
        {
            Sprite spriteAtTargetPosition = Map.GetSpriteAt(position);
            return spriteAtTargetPosition.Label == SpriteManager.KeyLabel;
        }

        /// <summary>
        /// Disables the _player's ability to move.
        /// </summary>
        public void DisableMovement()
        {
            CanMove = false;
        }

        /// <summary>
        /// Enables the _player's ability to move.
        /// </summary>
        public void EnableMovement()
        {
            CanMove = true;
        }

        /// <summary>
        /// Determines whether the given position is the level exit (_door).
        /// </summary>
        /// <param name="position">The target position to check.</param>
        /// <returns>True if the position is the level exit; otherwise, false.</returns>
        private bool IsLevelExit(Vector2 position) => position == SpriteManager.GetDoor().GetPosition();

        /// <summary>
        /// Moves the _player in the specified direction, handling collisions, collectibles, and level progression.
        /// Updates the _player's position on the map and increments the step counter.
        /// </summary>
        /// <param name="direction">The direction to move the _player.</param>
        public void Move(Vector2 direction)
        {
            Vector2 targetPosition = new Vector2(this._position.X, this._position.Y) + new Vector2(direction.X, direction.Y);

            if (targetPosition != this._position)
            {
                if ((targetPosition.X < Map.GetSize().Width && targetPosition.X >= 0) &&
                    (targetPosition.Y <= Map.GetSize().Height && targetPosition.Y >= 0))
                {

                    if (!CanMove) { return; }

                    if (!IsTrespassable(targetPosition))
                    {
                        SoundPlayer.PlayAsync(SoundType.WallCollision);
                        return;
                    }

                    if (IsCollectible(targetPosition))
                    {
                        GameManager.CollectKeyInCurrentLevel();
                        SoundPlayer.PlayAsync(SoundType.KeyPickup);
                    }

                    Map.UpdateSprite(this._position, SpriteManager.GetGround());
                    this._position = targetPosition;
                    Map.UpdateSprite(this._position, SpriteManager.GetPlayer());

                    SoundPlayer.PlayAsync(SoundType.Movement);

                    StepsDone++;

                    if (IsLevelExit(targetPosition)) { GameManager.StartNextLevel(); }
                }
            }
        }
    }
}
