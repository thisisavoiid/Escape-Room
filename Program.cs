
using System.Numerics;
using Vector2 = Escape_Room.Vector2;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Escape_Room
{
    class Program
    {

        static void Main(string[] args)
        {

           

            GameManager.SetupGame();
            GameManager.StartGameSelectionFlow();

            // Keepalive
            Console.ReadKey(true);
        }
    }
}



