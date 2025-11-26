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



