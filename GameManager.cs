using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escape_Room
{
    /// <summary>
    /// Manages overall game flow: mode selection, level progression and game loop.
    /// </summary>
    public class GameManager
    {
        private enum E_GameMode
        {
            LevelBasedMode,
            CustomLevelMode
        }

        private static Size _maxMapSize = new Size { width = 20, height = 20 };
        private static Size _minMapSize = new Size { width = 10, height = 10 };
        private static E_GameMode _selectedGameMode;

        private static bool _isGameFinished = false;
        private static bool _hasPlayerFoundKeyInCurrentLevel = false;
        private static int _currentLevel = 0;
        private static int _levelCount = 0;

        private static Player _player = SpriteManager.GetPlayer();

        /// <summary>
        /// Starts the custom level setup flow. Prompts the user for map width and height,
        /// validates input and applies the chosen map size.
        /// </summary>

        private static void StartCustomLevelSetupFlow()
        {
            bool hasMapSizeSelectionFlowFinished = false;
            int selectionFlowSection = 0;
            string input = string.Empty;
            int inputToInteger = 0;

            Size desiredMapSize = new Size();

            while (!hasMapSizeSelectionFlowFinished)
            {
                Console.WriteLine("Map " + (selectionFlowSection == 0 ? "width" : "height") + ":\n");
                input = Console.ReadLine().ToString();

                if (!LogicLib.IsNumeral(input))
                {
                    Console.WriteLine("Not a number! - ");
                    continue;
                }

                inputToInteger = int.Parse(input);

                switch (selectionFlowSection)
                {
                    case 0:
                        {
                            if (!LogicLib.IsInRange(inputToInteger, _minMapSize.width, _maxMapSize.width))
                            {
                                Console.WriteLine("Not in range!");
                                continue;
                            }

                            desiredMapSize.width = inputToInteger;
                            selectionFlowSection++;
                            break;
                        }
                    case 1:
                        {
                            if (!LogicLib.IsInRange(inputToInteger, _minMapSize.width, _maxMapSize.width))
                            {
                                Console.WriteLine("Not in range!");
                                continue;
                            }

                            desiredMapSize.height = inputToInteger;
                            selectionFlowSection++;
                            hasMapSizeSelectionFlowFinished = true;
                            break;
                        }
                }
            }
            Map.SetSize(desiredMapSize);
        }

        /// <summary>
        /// Starts the game selection flow. Shows available game modes and waits for user input
        /// to select either a premade level mode or a custom level mode, then initializes the map accordingly.
        /// </summary>

        public static void StartGameSelectionFlow()
        {
            Console.WriteLine("[GameManager] Mode?" + "\n" + string.Join("\n", typeof(E_GameMode).GetEnumNames()));

            char inputChar = ' ';
            bool hasInputFlowFinished = false;
            int selectedGameModeIndex = 0;

            while (!hasInputFlowFinished)
            {
                inputChar = Console.ReadKey(true).KeyChar;
                if (LogicLib.IsNumeral(inputChar.ToString()))
                {
                    if (LogicLib.IsInRange(int.Parse(inputChar.ToString()), 1, typeof(E_GameMode).GetEnumNames().Count()))
                    {
                        selectedGameModeIndex = int.Parse(inputChar.ToString()) - 1;
                        hasInputFlowFinished = true;
                    }
                }
            }

            _selectedGameMode = (E_GameMode)selectedGameModeIndex;

            switch (_selectedGameMode)
            {
                case E_GameMode.LevelBasedMode:
                    {
                        _levelCount = Map.GetPremadeLevelCount();
                        Map.LoadLevelMap(1);
                        _currentLevel = 1;
                        break;
                    }

                case E_GameMode.CustomLevelMode:
                    {
                        _levelCount = 1;
                        _currentLevel = 1;
                        StartCustomLevelSetupFlow();
                        Map.Initialize();

                        break;
                    }
            }

            Console.Clear();
            Console.CursorVisible = false;
            Map.Print();

            StartGameLoop();

        }

        /// <summary>
        /// Returns the current level index.
        /// </summary>

        public static int GetCurrentLevel()
        {
            return _currentLevel;
        }

        /// <summary>
        /// Sets the current level index.
        /// </summary>
        /// <param name="currentLevel">
        /// The level index to set as the current level.
        /// </param>

        public static void SetCurrentLevel(int currentLevel)
        {
            _currentLevel = currentLevel;
        }

        /// <summary>
        /// Main game loop. Keeps processing player movement until the game is finished.
        /// </summary>

        public static void StartGameLoop()
        {
            while (!_isGameFinished)
            {
                _player.Move(InputManager.GetMoveDirection(InputManager.GetKeyPressed()));
            }
        }

        /// <summary>
        /// Starts the end game flow: disables player movement and performs finalization steps.
        /// </summary>

        private static void StartEndGameFlow()
        {
            _player.canMove = false;
        }

        /// <summary>
        /// Advances the game to the next level. If the current level is the last one, ends the game.
        /// </summary>

        public static void StartNextLevel()
        {
            if (_currentLevel >= _levelCount)
            {
                StartEndGameFlow();
                return;
            }

            _player.canMove = false;
            _isGameFinished = true;
            _currentLevel++;

            Map.LoadLevelMap(_currentLevel);
            Console.Clear();
            Map.Print();

            _isGameFinished = false;
            _player.canMove = true;

            StartGameLoop();
        }

        /// <summary>
        /// Called when the player collects the key in the current level. Updates the map and state.
        /// </summary>

        public static void CollectKeyInCurrentLevel()
        {
            Map.UpdateSprite(SpriteManager.GetDoor().GetPosition(), SpriteManager.GetGround());
            _hasPlayerFoundKeyInCurrentLevel = true;
        }

        /// <summary>
        /// Performs initial game setup such as making the cursor visible and creating sprites.
        /// </summary>

        public static void SetupGame()
        {
            Console.CursorVisible = true;
            SpriteManager.CreateAllGameSprites();
        }

    }
}
