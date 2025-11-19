
using System.Numerics;
using Vector2 = Escape_Room.Vector2;

namespace Escape_Room
{
    class Program
    {

        static string titleicon = $" _______  _______  _______  _______  _______  _______    ______    _______  _______  __   __ \r\n|       ||       ||       ||   _   ||       ||       |  |    _ |  |       ||       ||  |_|  |\r\n|    ___||  _____||       ||  |_|  ||    _  ||    ___|  |   | ||  |   _   ||   _   ||       |\r\n|   |___ | |_____ |       ||       ||   |_| ||   |___   |   |_||_ |  | |  ||  | |  ||       |\r\n|    ___||_____  ||      _||       ||    ___||    ___|  |    __  ||  |_|  ||  |_|  ||       |\r\n|   |___  _____| ||     |_ |   _   ||   |    |   |___   |   |  | ||       ||       || ||_|| |\r\n|_______||_______||_______||__| |__||___|    |_______|  |___|  |_||_______||_______||_|   |_|\n";


        static int currentLevel = 0;
        static int gameMode = 0; // 0 = Custom Modus, 1 = Level-basierter Modus
        static int moveCounter = 0;


        static char[,] mapChars;

        static char[,,] levelMapChars = new char[5, 15, 15]
        {
            // LEVEL 1
            {
            { 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W' },
            { 'W', 'G', 'G', 'G', 'W', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'W', 'K', 'W' },
            { 'W', 'W', 'W', 'G', 'W', 'W', 'W', 'W', 'W', 'G', 'W', 'G', 'W', 'G', 'W' },
            { 'W', 'G', 'G', 'G', 'W', 'G', 'G', 'G', 'G', 'G', 'W', 'G', 'W', 'G', 'W' },
            { 'W', 'G', 'W', 'W', 'W', 'G', 'W', 'W', 'W', 'W', 'W', 'G', 'W', 'G', 'W' },
            { 'W', 'G', 'W', 'G', 'G', 'G', 'W', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'W' },
            { 'W', 'G', 'W', 'W', 'W', 'G', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W' },
            { 'W', 'G', 'G', 'G', 'W', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'W' },
            { 'W', 'W', 'W', 'G', 'W', 'G', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'G', 'W' },
            { 'W', 'G', 'W', 'G', 'W', 'G', 'W', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'W' },
            { 'W', 'G', 'W', 'G', 'W', 'G', 'W', 'G', 'W', 'W', 'W', 'W', 'W', 'G', 'W' },
            { 'W', 'G', 'G', 'G', 'W', 'G', 'W', 'G', 'W', 'G', 'G', 'G', 'W', 'G', 'W' },
            { 'W', 'G', 'W', 'W', 'W', 'W', 'W', 'G', 'W', 'G', 'W', 'G', 'W', 'G', 'W' },
            { 'W', 'P', 'G', 'G', 'G', 'G', 'G', 'G', 'W', 'G', 'W', 'G', 'G', 'G', 'W' },
            { 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'D', 'W' },
            },

            // LEVEL 2
            {
            { 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W' },
            { 'W', 'P', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'W', 'G', 'G', 'G', 'W' },
            { 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'G', 'W', 'G', 'W', 'W', 'W' },
            { 'W', 'G', 'G', 'G', 'W', 'G', 'G', 'G', 'W', 'G', 'W', 'G', 'G', 'G', 'W' },
            { 'W', 'G', 'W', 'W', 'W', 'G', 'W', 'G', 'W', 'G', 'W', 'W', 'W', 'G', 'W' },
            { 'W', 'G', 'G', 'G', 'G', 'G', 'W', 'G', 'W', 'G', 'G', 'G', 'G', 'G', 'W' },
            { 'W', 'G', 'W', 'W', 'W', 'W', 'W', 'G', 'W', 'W', 'W', 'W', 'W', 'G', 'W' },
            { 'W', 'G', 'W', 'G', 'G', 'G', 'W', 'G', 'G', 'G', 'W', 'G', 'G', 'G', 'W' },
            { 'W', 'G', 'W', 'G', 'W', 'G', 'W', 'G', 'W', 'G', 'W', 'G', 'W', 'W', 'W' },
            { 'W', 'G', 'W', 'G', 'W', 'G', 'G', 'G', 'W', 'G', 'W', 'G', 'G', 'G', 'W' },
            { 'W', 'G', 'W', 'G', 'W', 'W', 'W', 'W', 'W', 'G', 'W', 'W', 'W', 'G', 'W' },
            { 'W', 'G', 'W', 'G', 'G', 'G', 'G', 'G', 'W', 'G', 'G', 'G', 'W', 'G', 'W' },
            { 'W', 'G', 'W', 'W', 'W', 'W', 'W', 'G', 'W', 'W', 'W', 'W', 'W', 'G', 'W' },
            { 'W', 'G', 'G', 'G', 'G', 'K', 'W', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'D' },
            { 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W' },
            },

            // LEVEL 3
            {
            { 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'D', 'W', 'W', 'W', 'W', 'W' },
            { 'W', 'G', 'G', 'G', 'W', 'G', 'W', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'W' },
            { 'W', 'W', 'W', 'G', 'W', 'G', 'W', 'G', 'W', 'W', 'W', 'G', 'W', 'G', 'W' },
            { 'W', 'G', 'W', 'G', 'W', 'G', 'G', 'G', 'W', 'G', 'G', 'G', 'W', 'G', 'W' },
            { 'W', 'G', 'W', 'G', 'W', 'G', 'W', 'W', 'W', 'G', 'W', 'W', 'W', 'G', 'W' },
            { 'W', 'G', 'G', 'G', 'W', 'G', 'G', 'G', 'W', 'G', 'G', 'G', 'W', 'G', 'W' },
            { 'W', 'G', 'W', 'W', 'W', 'W', 'W', 'G', 'W', 'W', 'W', 'G', 'W', 'W', 'W' },
            { 'W', 'G', 'G', 'G', 'G', 'G', 'W', 'G', 'G', 'K', 'W', 'G', 'G', 'G', 'W' },
            { 'W', 'W', 'W', 'W', 'W', 'G', 'W', 'W', 'W', 'W', 'W', 'G', 'W', 'G', 'W' },
            { 'W', 'G', 'G', 'G', 'G', 'G', 'W', 'G', 'G', 'G', 'W', 'G', 'W', 'G', 'W' },
            { 'W', 'G', 'W', 'W', 'W', 'W', 'W', 'G', 'W', 'G', 'W', 'W', 'W', 'G', 'W' },
            { 'W', 'G', 'W', 'G', 'G', 'G', 'G', 'G', 'W', 'G', 'G', 'G', 'W', 'G', 'W' },
            { 'W', 'G', 'W', 'W', 'W', 'W', 'W', 'G', 'W', 'W', 'W', 'G', 'W', 'G', 'W' },
            { 'W', 'P', 'G', 'G', 'G', 'G', 'G', 'G', 'W', 'G', 'G', 'G', 'G', 'G', 'W' },
            { 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W' },
            },

            // LEVEL 4
            {
            { 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'D', 'W', 'W', 'W', 'W', 'W' },
            { 'W', 'P', 'W', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'W', 'G', 'G', 'G', 'W' },
            { 'W', 'G', 'W', 'G', 'W', 'W', 'W', 'W', 'W', 'G', 'W', 'G', 'W', 'W', 'W' },
            { 'W', 'G', 'G', 'G', 'W', 'G', 'W', 'G', 'G', 'G', 'W', 'G', 'G', 'G', 'W' },
            { 'W', 'W', 'W', 'W', 'W', 'G', 'W', 'G', 'W', 'W', 'W', 'G', 'W', 'G', 'W' },
            { 'W', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'W', 'G', 'W', 'G', 'W', 'G', 'W' },
            { 'W', 'G', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'G', 'W', 'G', 'W', 'G', 'W' },
            { 'W', 'G', 'G', 'G', 'W', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'W', 'G', 'W' },
            { 'W', 'W', 'W', 'G', 'W', 'W', 'W', 'G', 'W', 'W', 'W', 'W', 'W', 'G', 'W' },
            { 'W', 'G', 'W', 'G', 'G', 'G', 'W', 'G', 'W', 'K', 'W', 'G', 'G', 'G', 'W' },
            { 'W', 'G', 'W', 'W', 'W', 'G', 'W', 'G', 'W', 'G', 'W', 'G', 'W', 'G', 'W' },
            { 'W', 'G', 'W', 'G', 'G', 'G', 'W', 'G', 'G', 'G', 'W', 'G', 'W', 'G', 'W' },
            { 'W', 'G', 'W', 'G', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'G', 'W', 'G', 'W' },
            { 'W', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'W', 'G', 'W' },
            { 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W' },
            },

            // LEVEL 5
            {
            { 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W' },
            { 'D', 'K', 'W', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'W' },
            { 'W', 'G', 'W', 'G', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'G', 'W' },
            { 'W', 'G', 'G', 'G', 'W', 'G', 'G', 'G', 'G', 'G', 'W', 'G', 'G', 'G', 'W' },
            { 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'G', 'W', 'G', 'W', 'G', 'W', 'W', 'W' },
            { 'W', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'W', 'G', 'W', 'G', 'W', 'G', 'W' },
            { 'W', 'G', 'W', 'W', 'W', 'G', 'W', 'W', 'W', 'W', 'W', 'G', 'W', 'G', 'W' },
            { 'W', 'G', 'W', 'G', 'G', 'G', 'W', 'G', 'G', 'G', 'W', 'G', 'W', 'G', 'W' },
            { 'W', 'W', 'W', 'G', 'W', 'W', 'W', 'G', 'W', 'G', 'W', 'G', 'W', 'G', 'W' },
            { 'W', 'G', 'G', 'G', 'W', 'G', 'G', 'G', 'W', 'G', 'W', 'G', 'G', 'G', 'W' },
            { 'W', 'G', 'W', 'W', 'W', 'G', 'W', 'W', 'W', 'G', 'W', 'W', 'W', 'G', 'W' },
            { 'W', 'G', 'W', 'G', 'G', 'G', 'W', 'G', 'W', 'G', 'W', 'G', 'G', 'G', 'W' },
            { 'W', 'G', 'W', 'G', 'W', 'W', 'W', 'G', 'W', 'G', 'W', 'G', 'W', 'W', 'W' },
            { 'W', 'P', 'G', 'G', 'G', 'G', 'G', 'G', 'W', 'G', 'G', 'G', 'G', 'G', 'W' },
            { 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W' },
            }, 

        };

        //static Position playerPos;
        //static Position keyPos;
        //static Position doorPos;
        static int test;
        static bool hasGameStarted = false;
        static bool hasPlayerFoundKey = false;

        static ConsoleColor dialogueTextForegroundColor = ConsoleColor.White;
        static ConsoleColor dialogueTextBackgroundColor = ConsoleColor.Black;

        static Random random = new Random();

        static void Main(string[] args)
        {
            Map.SetSize(new Size { height = 10, width = 10 });
            GameManager.SetupGame();
            
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKey keyPressed = InputManager.GetKeyPressed();
                    Vector2 movementVector = InputManager.GetMoveDirection(keyPressed);
                    if (movementVector != Vector2.Zero())
                    {
                        SpriteManager.GetPlayer().Move(InputManager.GetMoveDirection(keyPressed));
                    }
                }

            }
            Console.CursorVisible = false;

            //HandleGameOnboarding();
            //StartGameLoop();

            // Keepalive
            Console.ReadKey(true);
        }



        //static void PrintIngameUI()
        //{
        //    Console.SetCursorPosition(0, mapHeight + 2);
        //    Console.ForegroundColor = ConsoleColor.DarkBlue;
        //    Console.BackgroundColor = ConsoleColor.Cyan;
        //    Console.Write($"Move-Counter: {moveCounter}" + (gameMode == 1 ? $" | Level: {currentLevel + 1}/{levelMapChars.GetLength(0)}" : ""));
        //    Console.ResetColor();
        //}

        //public static void PrintMap() // Zeichnet die gesamte Karte in die Konsole und merkt sich Positionen von Spieler, Schlüssel und Tür.
        //{
        //    for (int y = 0; y < mapHeight; y++)
        //    {
        //        for (int x = 0; x < mapWidth; x++)
        //        {
        //            if (mapChars[y, x] == 'W')
        //            {
        //                wall.SetColors();
        //            }
        //            else if (mapChars[y, x] == 'P')
        //            {
        //                playerPos = new Vector2 { x = x, y = y };
        //                player.SetColors();
        //            }
        //            else if (mapChars[y, x] == 'K')
        //            {
        //                keyPos = new Vector2 { x = x, y = y };
        //                key.SetColors();
        //            }
        //            else if (mapChars[y, x] == 'D')
        //            {
        //                doorPos = new Vector2 { x = x, y = y };
        //                door.SetColors();
        //            }
        //            else
        //            {
        //                ground.SetColors();
        //            }
        //            Console.Write(" ");
        //        }
        //        Console.Write("\n");
        //    }
        //}

        //static void DisplayWinMessage() // Gibt die Gewinnmeldung aus, spielt die Erfolgs-Melodie und zeigt die Nachricht unterhalb der Karte an
        //{
        //    Console.SetCursorPosition(0, mapHeight + 2);

        //    // "Melodie", wenn der Spieler entkommt
        //    Console.Beep(300, 50);
        //    Console.Beep(500, 50);
        //    Console.Beep(700, 50);
        //    Console.Beep(900, 50);
        //    Console.Beep(1200, 150);

        //    TypewriterPrint(
        //        text: $"Herzlichen Glückwunsch, du hast es geschafft!\nDu bist mit {moveCounter} Schritten entkommen!",
        //        foregroundColor: ConsoleColor.Yellow,
        //        backgroundColor: ConsoleColor.DarkYellow,
        //        enableSound: true
        //    );

        //    Console.ResetColor();
        //}

        //static void MapSetupDialogue(int state) // Interaktive Dialogschleife zur Abfrage und Validierung der Raumgröße
        //{
        //    int userInput;

        //    while (true)
        //    {

        //        Console.ForegroundColor = ConsoleColor.Red;
        //        Console.WriteLine(titleicon);

        //        Console.ForegroundColor = dialogueTextForegroundColor;
        //        Console.BackgroundColor = dialogueTextBackgroundColor;

        //        TypewriterPrint(
        //            text: "Lege die " + (state == 1 ? "Breite" : "Höhe") + " des Raums fest: ",
        //            foregroundColor: ConsoleColor.DarkRed,
        //            backgroundColor: ConsoleColor.Red,
        //            enableSound: true
        //    );

        //        try
        //        {
        //            userInput = int.Parse(Console.ReadLine());
        //            if (userInput >= 10 && userInput <= 20)
        //            {
        //                switch (state)
        //                {
        //                    case 1:
        //                        {
        //                            mapHeight = userInput + 2;
        //                            break;
        //                        }
        //                    case 2:
        //                        {
        //                            mapWidth = userInput + 2;
        //                            break;
        //                        }
        //                }
        //                break;
        //            }
        //            else
        //            {
        //                Console.ForegroundColor = ConsoleColor.Red;
        //                Console.WriteLine("\nDer Raum muss zwischen 10 und 20 Blöcke " + (state == 1 ? "breit" : "hoch") + " sein!");
        //                Thread.Sleep(1000);
        //                Console.Clear();
        //            }
        //        }
        //        catch (Exception e)
        //        {
        //            Console.ForegroundColor = ConsoleColor.Red;
        //            Console.WriteLine("\nDeine Eingabe muss eine Zahl sein!");
        //            Thread.Sleep(1000);
        //            Console.Clear();
        //        }
        //    }
        //    Console.Clear();
        //}


        //static void TypewriterPrint(string text, ConsoleColor foregroundColor, ConsoleColor backgroundColor, bool enableSound = false) // Gibt Text zeichenweise mit Typewriter-Effekt aus und erzeugt optional kurz Töne
        //{
        //    Random random = new Random();

        //    Console.ForegroundColor = foregroundColor;
        //    Console.BackgroundColor = backgroundColor;

        //    foreach (char c in text)
        //    {
        //        //if (enableSound)
        //        //{
        //        //    if (c == ' ')
        //        //    {
        //        //        Console.Beep(random.Next(500, 600), random.Next(5, 10));
        //        //    }
        //        //    else
        //        //    {
        //        //        Console.Beep(random.Next(3000, 3200), random.Next(5, 10));
        //        //    }
        //        //}

        //        Console.Write(c);
        //        // Thread.Sleep(random.Next(30, 50));
        //    }
        //    Console.ResetColor();
        //}



        //static void ChooseDoorPosition() // Sammelt alle möglichen Kantenpositionen (ohne Ecken) und wählt zufällig eine als Türposition aus
        //{
        //    List<Vector2> possibleDoorCoordinates = new List<Vector2>(); // Deklaration & Initialisation eines neuen Listen-Objekts, in dem die möglichen Positionen zwischengespeichert werden

        //    for (int y = 0; y < mapHeight; y++)
        //    {
        //        for (int x = 0; x < mapWidth; x++)
        //        {
        //            if (((y == 0 || y == mapHeight - 1) && !(x == 0 || x == mapWidth - 1)) || ((x == 0 || x == mapWidth - 1) && !(y == 0 || y == mapHeight - 1))) // Falls der Pointer sich gerade am Rand befindet, entspricht die Bedingung TRUE
        //            {
        //                possibleDoorCoordinates.Add(new Vector2 { x = x, y = y }); // Fügt die mögliche Position zum Array hinzu
        //            }
        //        }
        //    }

        //    Vector2 selectedDoorPos = possibleDoorCoordinates[random.Next(possibleDoorCoordinates.Count)];

        //    doorPos = new Vector2
        //    {
        //        x = selectedDoorPos.x,
        //        y = selectedDoorPos.y
        //    };

        //}

        //public static void HandleGameOnboarding() // Zeigt Title/Begrüßung, steuert die Modus-Auswahl und startet das passende Setup (Custom- oder Level-Modus).
        //{
        //    Console.ForegroundColor = ConsoleColor.Red;

        //    foreach (string icon_line in titleicon.Split('\n'))
        //    {
        //        Console.WriteLine(icon_line);
        //        Thread.Sleep(100);
        //    }

        //    Console.ForegroundColor = dialogueTextForegroundColor;
        //    Console.BackgroundColor = dialogueTextBackgroundColor;

        //    TypewriterPrint(
        //        text: "Willkommen zum Escape Room! Du bist gefangen in einem dunklen Raum. Dein Ziel ist es, zu entkommen.\nDafür benötigst du einen Schlüssel, der auf der Karte versteckt ist!\nDu kannst dich mit den WASD-Tasten fortbewegen.\n\nDrücke eine beliebige Taste, um fortzufahren...",
        //        foregroundColor: ConsoleColor.DarkRed,
        //        backgroundColor: ConsoleColor.Red,
        //        enableSound: true
        //    );

        //    // Wartet, bis irgendeine Taste gedrückt wird
        //    if (Console.ReadKey(true) != null)
        //    {
        //        Console.Clear();
        //    }

        //    int userInput;

        //    while (true)
        //    {
        //        Console.ForegroundColor = ConsoleColor.Red;
        //        Console.WriteLine(titleicon);

        //        TypewriterPrint(
        //            text: "\nBitte wähle einen der beiden Spielmodi aus, um fortzufahren:\n\n(1) Karte mit wählbarer Größe\n(2) Level-Modus",
        //            foregroundColor: ConsoleColor.DarkRed,
        //            backgroundColor: ConsoleColor.Red,
        //            enableSound: true
        //        );

        //        try
        //        {
        //            userInput = int.Parse(Console.ReadKey(true).KeyChar.ToString());
        //            if (new int[] { 1, 2 }.Contains(userInput))
        //            {
        //                switch (userInput)
        //                {
        //                    case 1:
        //                        {
        //                            Console.Clear();
        //                            MapSetupDialogue(1);
        //                            MapSetupDialogue(2);
        //                            ChooseDoorPosition();
        //                            InitializeMapArray();
        //                            gameMode = 0;
        //                            break;
        //                        }
        //                    case 2:
        //                        {
        //                            Console.Clear();
        //                            mapWidth = levelMapChars.GetLength(1);
        //                            mapHeight = levelMapChars.GetLength(2);
        //                            mapChars = new char[15, 15];
        //                            gameMode = 1;
        //                            break;
        //                        }
        //                }
        //                break;
        //            }
        //            else
        //            {
        //                Console.ForegroundColor = ConsoleColor.Red;
        //                Console.WriteLine("\nDeine Eingabe ist ungültig. Bitte wähle eine der angezeigten Spielmodi aus.");
        //                Thread.Sleep(1000);
        //                Console.Clear();
        //            }
        //        }
        //        catch (Exception e)
        //        {
        //            Console.ForegroundColor = ConsoleColor.Red;
        //            Console.WriteLine("\nDeine Eingabe muss eine Zahl sein!");
        //            Thread.Sleep(1000);
        //            Console.Clear();
        //        }
        //    }
        //}
    }
}



