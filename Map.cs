using Escape_Room;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Escape_Room
{
    public class Map
    {
        private static Random random = new Random();
        private static Size mapSize = new Size() { height = 0, width = 0 };
        private static char[,] mapChars;

        private static char[,,] levelMapChars = new char[5, 15, 15]
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

        public static Size GetSize()
        {
            return mapSize;
        }

        public static void SetSize(Size size)
        {
            mapSize = size;
            Console.WriteLine($"[MAP] Size has been set to {size} -");
        }

        private static Vector2 GetPossibleDoorPosition()
        {
            List<Vector2> possibleDoorCoordinates = new List<Vector2>(); // Deklaration & Initialisation eines neuen Listen-Objekts, in dem die möglichen Positionen zwischengespeichert werden

            for (int y = 0; y < mapSize.height; y++)
            {
                for (int x = 0; x < mapSize.width; x++)
                {
                    if (((y == 0 || y == mapSize.height - 1) && !(x == 0 || x == mapSize.width - 1)) || ((x == 0 || x == mapSize.width - 1) && !(y == 0 || y == mapSize.height - 1))) // Falls der Pointer sich gerade am Rand befindet, entspricht die Bedingung TRUE
                    {
                        possibleDoorCoordinates.Add(new Vector2 { x = x, y = y }); // Fügt die mögliche Position zum Array hinzu
                    }
                }
            }

            Vector2 selectedDoorPos = possibleDoorCoordinates[random.Next(possibleDoorCoordinates.Count)];

            return new Vector2
            {
                x = selectedDoorPos.x,
                y = selectedDoorPos.y
            };
        }

        public static char[,] GetChars()
        {
            return mapChars;
        }

        public static int GetPremadeLevelCount()
        {
            return levelMapChars.GetLength(0);
        }

        public static void LoadLevelMap(int level)
        {
            mapSize.width = levelMapChars.GetLength(1);
            mapSize.height = levelMapChars.GetLength(2);
            mapChars = new char[mapSize.width, mapSize.height];

            for (int y = 0; y < mapSize.height; y++)
            {
                for (int x = 0; x < mapSize.width; x++)
                {
                    mapChars[x, y] = levelMapChars[level - 1, x, y];

                    switch (mapChars[x, y])
                    {
                        case 'K':
                            {
                                SpriteManager.GetKey().SetPosition(new Vector2(x, y));
                                Console.WriteLine(SpriteManager.GetKey().GetPosition().ToString());
                                break;
                            }
                        case 'P':
                            {
                                SpriteManager.GetPlayer().SetPosition(new Vector2(x, y));
                                break;
                            }
                        case 'D':
                            {
                                SpriteManager.GetDoor().SetPosition(new Vector2(x, y));
                                break;
                            }
                    }
                }
            }

            GameManager.SetCurrentLevel(level);

        }

        public static void UpdateSprite(Vector2 spritePos, Sprite newSprite)
        {
            mapChars[spritePos.x, spritePos.y] = newSprite.label;
            Console.SetCursorPosition(spritePos.x, spritePos.y);
            newSprite.Draw();
        }

        public static void Initialize()
        {
            mapChars = new char[mapSize.width, mapSize.height];

            Player player = SpriteManager.GetPlayer();
            Sprite key = SpriteManager.GetKey();
            Sprite door = SpriteManager.GetDoor();

            player.SetPosition(new Vector2
            {
                x = (int)random.NextInt64(2, mapSize.width - 2),
                y = (int)random.NextInt64(2, mapSize.height - 2)
            });

            key.SetPosition(new Vector2
            {
                x = (int)random.NextInt64(2, mapSize.width - 2),
                y = (int)random.NextInt64(2, mapSize.height - 2)
            });

            door.SetPosition(GetPossibleDoorPosition());

            for (int y = 0; y < mapSize.height; y++)
            {

                for (int x = 0; x < mapSize.width; x++)
                {
                    if ((y == 0 || y == mapSize.height - 1 || x == 0 || x == mapSize.width - 1) && (x, y) != (door.GetPosition().x, door.GetPosition().y))
                    {
                        mapChars[x, y] = 'W';
                    }
                    else if ((x, y) == (player.GetPosition().x, player.GetPosition().y))
                    {
                        mapChars[x, y] = 'P';
                    }
                    else if ((x, y) == (key.GetPosition().x, key.GetPosition().y))
                    {
                        mapChars[x, y] = 'K';
                    }
                    else if ((x, y) == (door.GetPosition().x, door.GetPosition().y))
                    {
                        mapChars[x, y] = 'D';
                    }
                    else
                    {
                        mapChars[x, y] = 'G';
                    }
                }
            }
        }


        public static void Print()
        {
            Console.Clear();
            Size mapSize = GetSize();
            Sprite sprite;

            for (int y = 0; y < mapSize.height; y++)
            {
                for (int x = 0; x < mapSize.width; x++)
                {
                    sprite = SpriteManager.GetSpriteFromChar(mapChars[x, y]);
                    sprite.Draw();
                }
                Console.Write("\n");
            }
        }
    }
}

