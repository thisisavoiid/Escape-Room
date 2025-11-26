using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Transactions;

namespace Escape_Room
{
    public class GameManager
    {
        private static Size _maxMapSize = new Size { Width = 20, Height = 20 };
        private static Size _minMapSize = new Size { Width = 10, Height = 10 };
        private static GamemodeType _selectedGameMode;
        
        private static bool _isGameFinished = false;
        public static bool HasPlayerFoundKeyInCurrentLevel { get; private set; } = false;
        public static Stopwatch Stopwatch { get; private set; } = new Stopwatch();

        private static int _currentLevel = 0;
        private static int _levelCount = 0;

        private static Player _player = SpriteManager.GetPlayer();

        /// <summary>
        /// Handles the flow for setting up a custom level, allowing the _player to select map dimensions.
        /// </summary>
        private static void StartCustomLevelSetupFlow()
        {
            GUIManager.ClearConsole(true);

            bool hasMapSizeSelectionFlowFinished = false;
            int selectionFlowSection = 0;
            string input = string.Empty;
            int inputToInteger = 0;

            Size desiredMapSize = new Size();

            while (!hasMapSizeSelectionFlowFinished)
            {
                GUIManager.ClearConsole(false);

                ConsolePrinter.Print(
                    PrintLevel.Infoboard,
                    "Enter your desired map " + (selectionFlowSection == 0 ? "width" : "height") + ":"
                );

                input = Console.ReadLine().ToString();

                if (!LogicLib.IsNumeral(input))
                {
                    SoundPlayer.Play(SoundType.InvalidInput);
                    ConsolePrinter.Print(
                        PrintLevel.Error,
                        $"Invalid input. Please enter a valid number for the map {(selectionFlowSection == 0 ? "width" : "height")}.",
                        2000
                    );
                    
                    continue;
                }

                inputToInteger = int.Parse(input);

                switch (selectionFlowSection)
                {
                    case 0:
                        {
                            if (!LogicLib.IsInRange(inputToInteger, _minMapSize.Width, _maxMapSize.Width))
                            {
                                SoundPlayer.Play(SoundType.InvalidInput);
                                ConsolePrinter.Print(
                                    PrintLevel.Error,
                                    $"The number you entered is outside the valid range ({_minMapSize.Width}–{_maxMapSize.Width}).",
                                    2000
                                );
                                
                                continue;
                            }

                            SoundPlayer.Play(SoundType.ValidInput);
                            desiredMapSize.Width = inputToInteger+2;
                            selectionFlowSection++;
                            break;
                        }
                    case 1:
                        {
                            if (!LogicLib.IsInRange(inputToInteger, _minMapSize.Height, _maxMapSize.Height))
                            {
                                SoundPlayer.Play(SoundType.InvalidInput);
                                ConsolePrinter.Print(
                                    PrintLevel.Error,
                                    $"The number you entered is outside the valid range ({_minMapSize.Height}–{_maxMapSize.Height}).",
                                    2000
                                );
                                
                                continue;
                            }

                            SoundPlayer.Play(SoundType.ValidInput);
                            desiredMapSize.Height = inputToInteger+2;
                            selectionFlowSection++;
                            hasMapSizeSelectionFlowFinished = true;
                            break;
                        }
                }
            }

            Map.SetSize(desiredMapSize);
        }

        /// <summary>
        /// Starts the game mode selection flow, allowing the _player to choose between predefined or custom levels.
        /// Initializes the selected mode and begins the game loop.
        /// </summary>
        public static void StartGameSelectionFlow()
        {

            for (int i = 0; i < typeof(GamemodeType).GetEnumValues().Length; i++)
            {
                ConsolePrinter.Print(
                    PrintLevel.Dialog,
                    $"[{i + 1}] {GamemodeExtensions.InfoMap[(GamemodeType)i].DisplayName}\n{GamemodeExtensions.InfoMap[(GamemodeType)i].DisplayDescription}\n"
                );
            }

            ConsolePrinter.Print(
                PrintLevel.Warning,
                "Press a number to select the game mode..."
            );

            char inputChar = ' ';
            int selectedGameModeIndex = 0;

            while (true)
            {
                inputChar = Console.ReadKey(true).KeyChar;
                
                if (LogicLib.IsNumeral(inputChar.ToString()))
                {
                    if (LogicLib.IsInRange(int.Parse(inputChar.ToString()), 1, typeof(GamemodeType).GetEnumNames().Count()))
                    {
                        selectedGameModeIndex = int.Parse(inputChar.ToString()) - 1;
                        break;
                    }
                }
                SoundPlayer.Play(SoundType.InvalidInput);
            }

            SoundPlayer.Play(SoundType.ValidInput);

            _selectedGameMode = (GamemodeType)selectedGameModeIndex;

            switch (_selectedGameMode)
            {
                case GamemodeType.LevelBasedMode:
                    {
                        _levelCount = Map.GetPremadeLevelCount();
                        Map.LoadLevelMap(1);
                        _currentLevel = 1;
                        break;
                    }

                case GamemodeType.CustomLevelMode:
                    {
                        _levelCount = 1;
                        _currentLevel = 1;
                        StartCustomLevelSetupFlow();
                        Map.Initialize();
                        break;
                    }
            }

            GUIManager.ClearConsole(true);
            Console.CursorVisible = false;
            Map.Print();

            Stopwatch.Start();

            StartGameLoop();
        }

        /// <summary>
        /// Returns the current level number.
        /// </summary>
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
        /// Starts the main game loop, continuously handling _player movement and updating the GUI.
        /// </summary>
        public static void StartGameLoop()
        {
            GUIManager.SetInfoDialogBar("Objective: Find the key!");

            while (!_isGameFinished)
            {
                GUIManager.DrawGUI();
                _player.Move(InputManager.GetMoveDirection(InputManager.GetKeyPressed()));
            }
        }

        /// <summary>
        /// Handles the end-of-game flow, updating the map and displaying the end screen.
        /// </summary>
        private static void StartEndGameFlow()
        {
            Stopwatch.Stop();
            Map.UpdateSprite(_player.GetPosition(), SpriteManager.GetGround());
            _isGameFinished = true;
            _player.DisableMovement();
            SoundPlayer.PlayAsync(SoundType.GameFinished);
            GUIManager.ClearConsole(true, true);

            SoundPlayer.PlayAsync(SoundType.EndScreen);

            GUIManager.DrawEndScreen();
        }

        /// <summary>
        /// Advances the game to the next level or ends the game if the last level has been reached.
        /// </summary>
        public static void StartNextLevel()
        {
            if (!_isGameFinished)
            {

                if (_currentLevel >= _levelCount)
                {
                    StartEndGameFlow();
                    return;
                }

                _player.DisableMovement();
                SoundPlayer.PlayAsync(SoundType.LevelFinished);
                _isGameFinished = true;
                _currentLevel++;

                Map.LoadLevelMap(_currentLevel);
                GUIManager.ClearConsole(true);
                Map.Print();

                _isGameFinished = false;
                _player.EnableMovement();

                GUIManager.DrawGUI();
                StartGameLoop();
            }
        }

        /// <summary>
        /// Marks the _key in the current level as collected and updates the objective message.
        /// </summary>
        public static void CollectKeyInCurrentLevel()
        {
            Map.UpdateSprite(SpriteManager.GetDoor().GetPosition(), SpriteManager.GetGround());
            GUIManager.SetInfoDialogBar("Objective: The door has opened! Go through it!");
            HasPlayerFoundKeyInCurrentLevel = true;
        }

        /// <summary>
        /// Sets up the game environment by creating all necessary sprites.
        /// </summary>
        public static void SetupGame()
        {
            Console.CursorVisible = true;
            SpriteManager.CreateAllGameSprites();
        }
    }
}
