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
        private static Random _random = new Random();
        private static Size _mapSize = new Size() { Height = 0, Width = 0 };
        private static char[,] _mapChars;

        private static readonly char[,,] _levelMapChars = new char[5, 15, 15]
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
            return _mapSize;
        }

        /// <summary>
        /// Sets the map's size.
        /// </summary>
        public static void SetSize(Size size)
        {
            _mapSize = size;
        }

        /// <summary>
        /// Determines a _random possible _door position on the map edges.
        /// </summary>
        /// <returns>
        /// A _random possible _door position on the map edges as <see cref="Vector2"/>.
        /// </returns>
        private static Vector2 GetPossibleDoorPosition()
        {
            List<Vector2> possibleDoorCoordinates = new List<Vector2>();

            for (int y = 0; y < _mapSize.Height; y++)
            {
                for (int x = 0; x < _mapSize.Width; x++)
                {
                    if (((y == 0 || y == _mapSize.Height - 1) && !(x == 0 || x == _mapSize.Width - 1)) ||
                        ((x == 0 || x == _mapSize.Width - 1) && !(y == 0 || y == _mapSize.Height - 1)))
                    {
                        possibleDoorCoordinates.Add(new Vector2 { X = x, Y = y });
                    }
                }
            }

            Vector2 selectedDoorPos = possibleDoorCoordinates[_random.Next(possibleDoorCoordinates.Count)];
            return new Vector2 { X = selectedDoorPos.X, Y = selectedDoorPos.Y };
        }

        /// <summary>
        /// Returns the 2D array of map characters.
        /// </summary>
        /// <returns>
        /// The 2D array of map characters
        /// </returns>
        public static char[,] GetChars()
        {
            return _mapChars;
        }

        /// <summary>
        /// Returns the total number of premade levels.
        /// </summary>
        /// <returns>
        /// The total number of premade levels.
        /// </returns>
        public static int GetPremadeLevelCount()
        {
            return _levelMapChars.GetLength(0);
        }

        /// <summary>
        /// Loads the specified premade level into the map.
        /// </summary>
        public static void LoadLevelMap(int level)
        {
            _mapSize.Width = _levelMapChars.GetLength(1);
            _mapSize.Height = _levelMapChars.GetLength(2);
            _mapChars = new char[_mapSize.Width, _mapSize.Height];

            for (int y = 0; y < _mapSize.Height; y++)
            {
                for (int x = 0; x < _mapSize.Width; x++)
                {
                    _mapChars[x, y] = _levelMapChars[level - 1, x, y];

                    switch (_mapChars[x, y])
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
            _mapChars[spritePos.X, spritePos.Y] = newSprite.Label;
            Console.SetCursorPosition(spritePos.X, spritePos.Y);
            newSprite.Draw();
        }

        /// <summary>
        /// Returns the sprite located at a given position on the map.
        /// </summary>
        public static Sprite GetSpriteAt(Vector2 position)
        {
            if (position.X < 0 || position.X > _mapSize.Width || position.Y < 0 || position.Y > _mapSize.Height)
            {
                return SpriteManager.GetWall();
            }
            return SpriteManager.GetSpriteFromChar(_mapChars[position.X, position.Y]);
        }

        /// <summary>
        /// Initializes a custom map with _random positions for _player, _key, and _door.
        /// </summary>
        public static void Initialize()
        {
            _mapChars = new char[_mapSize.Width, _mapSize.Height];

            Player player = SpriteManager.GetPlayer();
            Sprite key = SpriteManager.GetKey();
            Sprite door = SpriteManager.GetDoor();

            player.SetPosition(new Vector2
            {
                X = (int)_random.NextInt64(2, _mapSize.Width - 2),
                Y = (int)_random.NextInt64(2, _mapSize.Height - 2)
            });

            key.SetPosition(new Vector2
            {
                X = (int)_random.NextInt64(2, _mapSize.Width - 2),
                Y = (int)_random.NextInt64(2, _mapSize.Height - 2)
            });

            door.SetPosition(GetPossibleDoorPosition());

            for (int y = 0; y < _mapSize.Height; y++)
            {
                for (int x = 0; x < _mapSize.Width; x++)
                {
                    if ((y == 0 || y == _mapSize.Height - 1 || x == 0 || x == _mapSize.Width - 1) &&
                        (x, y) != (door.GetPosition().X, door.GetPosition().Y))
                    {
                        _mapChars[x, y] = SpriteManager.WallLabel;
                    }
                    else if ((x, y) == (player.GetPosition().X, player.GetPosition().Y))
                    {
                        _mapChars[x, y] = SpriteManager.PlayerLabel;
                    }
                    else if ((x, y) == (key.GetPosition().X, key.GetPosition().Y))
                    {
                        _mapChars[x, y] = SpriteManager.KeyLabel;
                    }
                    else if ((x, y) == (door.GetPosition().X, door.GetPosition().Y))
                    {
                        _mapChars[x, y] = SpriteManager.DoorLabel;
                    }
                    else
                    {
                        _mapChars[x, y] = SpriteManager.GroundLabel;
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

            for (int y = 0; y < mapSize.Height; y++)
            {
                for (int x = 0; x < mapSize.Width; x++)
                {
                    sprite = SpriteManager.GetSpriteFromChar(_mapChars[x, y]);
                    sprite.Draw();
                }
                Console.Write("\n");
            }
        }
    }
}