using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escape_Room
{
    public class GameManager
    {
        public static void SetupGame()
        {
            SpriteManager.CreateAllGameSprites();
            Map.Initialize();

            Console.WriteLine("Game setup has been finished.");
        }

    }
}
