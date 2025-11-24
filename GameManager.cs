using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Escape_Room
{
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
        public static bool hasPlayerFoundKeyInCurrentLevel { get; private set; } = false;
        private static int _currentLevel = 0;
        private static int _levelCount = 0;

        private static Player _player = SpriteManager.GetPlayer();


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
        /// Starts the game mode selection flow and initializes the chosen mode.
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
        /// Returns the current level number.
        /// </summary>
        /// <returns>The current level index.</returns>
        public static int GetCurrentLevel()
        {
            return _currentLevel;
        }

        /// <summary>
        /// Sets the current level number.
        /// </summary>
        /// <param name="currentLevel">The level to set as current.</param>
        public static void SetCurrentLevel(int currentLevel)
        {
            _currentLevel = currentLevel;
        }

        /// <summary>
        /// Starts the main game loop, handling player movement.
        /// </summary>
        public static void StartGameLoop()
        {
            GUIManager.SetInfoDialogBar("Find the key!");

            while (!_isGameFinished)
            {
                GUIManager.DrawGUI();
                _player.Move(InputManager.GetMoveDirection(InputManager.GetKeyPressed()));

            }
        }

        private static void StartEndGameFlow()
        {
            _player.DisableMovement();
            GUIManager.SetInfoDialogBar("You managed to escape! Congrats!");
        }

        /// <summary>
        /// Advances the game to the next level or ends the game if the last level has been reached.
        /// </summary>
        public static void StartNextLevel()
        {
            if (_currentLevel >= _levelCount)
            {
                StartEndGameFlow();
                return;
            }

            _player.DisableMovement();
            _isGameFinished = true;
            _currentLevel++;

            Map.LoadLevelMap(_currentLevel);
            Console.Clear();
            Map.Print();

            _isGameFinished = false;
            _player.EnableMovement();

            GUIManager.DrawGUI();
            StartGameLoop();
        }

        /// <summary>
        /// Collects the key in the current level and updates the door sprite.
        /// </summary>
        public static void CollectKeyInCurrentLevel()
        {
            Map.UpdateSprite(SpriteManager.GetDoor().GetPosition(), SpriteManager.GetGround());
            GUIManager.SetInfoDialogBar("The door has opened! Go through it!");
            hasPlayerFoundKeyInCurrentLevel = true;
        }

        /// <summary>
        /// Sets up the game by creating all necessary sprites.
        /// </summary>
        public static void SetupGame()
        {
            Console.CursorVisible = true;
            SpriteManager.CreateAllGameSprites();
        }
    }
}
