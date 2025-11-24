using Escape_Room;
using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Escape_Room
{
    public class Player : Sprite
    {
        private readonly List<Sprite> _nonTrespassableSprites;

        public int stepsDone = 0;

        public bool canMove = true;

        public Player(char character, char label, ConsoleColor fgcolor, ConsoleColor bgcolor) : base(character, label, fgcolor, bgcolor)
        {
            this._nonTrespassableSprites = new List<Sprite>() { SpriteManager.GetDoor(), SpriteManager.GetWall() };
            this.stepsDone = 0;
            this.foregroundColor = fgcolor;
            this.backgroundColor = bgcolor;
            this.character = character;
        }

        private bool IsTrespassable(Vector2 position)
        {
            Sprite spriteAtTargetPosition = SpriteManager.GetSpriteFromChar(Map.GetChars()[position.x, position.y]);
            return !_nonTrespassableSprites.Select(sprite => sprite.label).Contains(spriteAtTargetPosition.label);
        }

        private bool IsCollectible(Vector2 position)
        {
            Sprite spriteAtTargetPosition = SpriteManager.GetSpriteFromChar(Map.GetChars()[position.x, position.y]);
            return spriteAtTargetPosition.label == 'K';
        }

        private bool IsLevelExit(Vector2 position) => position == SpriteManager.GetDoor().GetPosition();

        public void Move(Vector2 direction)
        {
            Vector2 targetPosition = new Vector2(this.position.x, this.position.y) + new Vector2(direction.x, direction.y);
            
            if ((targetPosition.x < Map.GetSize().width && targetPosition.x >= 0) && (targetPosition.y <= Map.GetSize().height && targetPosition.y >= 0))
            {
                if (!IsTrespassable(targetPosition)) { return;  }
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
