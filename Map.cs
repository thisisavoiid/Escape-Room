using Escape_Room;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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

        /// <summary>
        /// Returns the current size of the map.
        /// </summary>
        /// <returns>
        /// The current size of the map.
        /// </returns>
        public static Size GetSize()
        {
            return mapSize;
        }

        /// <summary>
        /// Sets the map's size.
        /// </summary>
        public static void SetSize(Size size)
        {
            mapSize = size;
        }

        /// <summary>
        /// Determines a random possible door position on the map edges.
        /// </summary>
        /// <returns>
        /// A random possible door position on the map edges as <see cref="Vector2"/>.
        /// </returns>
        private static Vector2 GetPossibleDoorPosition()
        {
            List<Vector2> possibleDoorCoordinates = new List<Vector2>();

            for (int y = 0; y < mapSize.height; y++)
            {
                for (int x = 0; x < mapSize.width; x++)
                {
                    if (((y == 0 || y == mapSize.height - 1) && !(x == 0 || x == mapSize.width - 1)) ||
                        ((x == 0 || x == mapSize.width - 1) && !(y == 0 || y == mapSize.height - 1)))
                    {
                        possibleDoorCoordinates.Add(new Vector2 { x = x, y = y });
                    }
                }
            }

            Vector2 selectedDoorPos = possibleDoorCoordinates[random.Next(possibleDoorCoordinates.Count)];
            return new Vector2 { x = selectedDoorPos.x, y = selectedDoorPos.y };
        }

        /// <summary>
        /// Returns the 2D array of map characters.
        /// </summary>
        /// <returns>
        /// The 2D array of map characters
        /// </returns>
        public static char[,] GetChars()
        {
            return mapChars;
        }

        /// <summary>
        /// Returns the total number of premade levels.
        /// </summary>
        /// <returns>
        /// The total number of premade levels.
        /// </returns>
        public static int GetPremadeLevelCount()
        {
            return levelMapChars.GetLength(0);
        }

        /// <summary>
        /// Loads the specified premade level into the map.
        /// </summary>
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
                        case SpriteManager.KeyLabel:
                            SpriteManager.GetKey().SetPosition(new Vector2(x, y));
                            break;
                        case SpriteManager.PlayerLabel:
                            SpriteManager.GetPlayer().SetPosition(new Vector2(x, y));
                            break;
                        case SpriteManager.DoorLabel:
                            SpriteManager.GetDoor().SetPosition(new Vector2(x, y));
                            break;
                    }
                }
            }

            GameManager.SetCurrentLevel(level);
        }

        /// <summary>
        /// Updates the sprite at the specified position and redraws it on the console.
        /// </summary>
        public static void UpdateSprite(Vector2 spritePos, Sprite newSprite)
        {
            mapChars[spritePos.x, spritePos.y] = newSprite.label;
            Console.SetCursorPosition(spritePos.x, spritePos.y);
            newSprite.Draw();
        }

        /// <summary>
        /// Returns the sprite located at a given position on the map.
        /// </summary>
        public static Sprite GetSpriteAt(Vector2 position)
        {
            if (position.x < 0 || position.x > mapSize.width || position.y < 0 || position.y > mapSize.height)
            {
                return SpriteManager.GetWall();
            }
            return SpriteManager.GetSpriteFromChar(mapChars[position.x, position.y]);
        }

        /// <summary>
        /// Initializes a custom map with random positions for player, key, and door.
        /// </summary>
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
                    if ((y == 0 || y == mapSize.height - 1 || x == 0 || x == mapSize.width - 1) &&
                        (x, y) != (door.GetPosition().x, door.GetPosition().y))
                    {
                        mapChars[x, y] = SpriteManager.WallLabel;
                    }
                    else if ((x, y) == (player.GetPosition().x, player.GetPosition().y))
                    {
                        mapChars[x, y] = SpriteManager.PlayerLabel;
                    }
                    else if ((x, y) == (key.GetPosition().x, key.GetPosition().y))
                    {
                        mapChars[x, y] = SpriteManager.KeyLabel;
                    }
                    else if ((x, y) == (door.GetPosition().x, door.GetPosition().y))
                    {
                        mapChars[x, y] = SpriteManager.DoorLabel;
                    }
                    else
                    {
                        mapChars[x, y] = SpriteManager.GroundLabel;
                    }
                }
            }
        }

        /// <summary>
        /// Prints the current map to the console.
        /// </summary>
        public static void Print()
        {
            GUIManager.ClearConsole(true);
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