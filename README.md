# Escape Room (C# Console Game)

A **C# console-based Escape Room game** featuring a tile-based world, interactive objects, multiple gamemodes, and a fully modular architecture.  
The project includes a **console GUI**, **sound system**, **input manager**, **world renderer**, and a clean component-based structure.

Repository: **https://github.com/thisisavoiid/Escape-Room**

---

## Table of Contents

- [Features](#features)
- [Installation](#installation)
- [Usage](#usage)
- [Project Structure](#project-structure)
- [Core Mechanics & Design](#core-mechanics--design)
- [Author](#author)

---

## Features

- **Tile-based Escape Room** rendered directly in the console.
- Multiple **gamemodes** (Level-Based, Custom).
- **Dynamic console HUD** and GUI elements (info board, dialogs, end screen).
- **Sound feedback system** using `Console.Beep()` with custom sound intervals.
- **Sprite-based architecture** (player, walls, keys, doors, floor).
- **Collision system** and interaction handling (picking up keys, opening doors).
- **Configurable map loading & drawing** through a central `Map` system.
- Clean modular architecture that is easy to extend.

---

## Installation

1. Clone the repository:

```bash
git clone https://github.com/thisisavoiid/Escape-Room.git
````

2. Navigate into the project directory:

```bash
cd Escape-Room
```

3. Open the project in **Visual Studio** or build via command line:

```bash
dotnet build
```

---

## Usage

Start the game with:

```bash
dotnet run
```

The onboarding process guides you through:

* Selecting a **gamemode**
* Choosing or defining a **map**
* Playing the Escape Room

Move using the **arrow keys**, pick up keys, avoid walls, and reach the exit to complete the level.

---

## Project Structure

Below is an overview of the main components of the codebase:

| Component               | Files                                                                                        | Main Function                                | Detailed Responsibility                                                                                                                                            |
| :---------------------- | :------------------------------------------------------------------------------------------- | :------------------------------------------- | :----------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| **Core Control**        | `GameManager.cs`, `Program.cs`                                                               | Orchestrates game flow.                      | `Program.cs` starts the app. `GameManager` initializes all systems, manages gamemode & level selection, runs the main loop, tracks playtime via a stopwatch.       |
| **Game Logic (Player)** | `Player.cs`                                                                                  | Defines player behavior and movement.        | Inherits from `Sprite`. Computes movement targets, checks collisions (`Wall`), interacts with objects (keys → `CollectKeyInCurrentLevel`), and updates step count. |
| **World State**         | `Map.cs`                                                                                     | Stores, loads & renders tile-based maps.     | Holds level layout as `char[,]`. Draws the world by requesting sprite instances from `SpriteManager` and printing them via the console interface.                  |
| **Sprites & Objects**   | `Sprite.cs`, `SpriteManager.cs`                                                              | Base classes & central registry.             | `Sprite` defines shared properties (position, char, color). `SpriteManager` creates and maps all sprite types (walls, floor, keys, door, player).                  |
| **Geometry & Position** | `Vector2.cs`, `Size.cs`                                                                      | Core math structs.                           | `Vector2` is a simple integer vector with addition overloads. `Size` stores map width & height.                                                                    |
| **Input**               | `InputManager.cs`                                                                            | Converts keyboard input to movement vectors. | Maps `ConsoleKey` to direction `Vector2` values, respecting console coordinate orientation.                                                                        |
| **Console Graphics**    | `GUIManager.cs`, `ConsolePrinter.cs`                                                         | Handles GUI/HUD rendering.                   | `GUIManager` draws dialogs, info boards & end screens. `ConsolePrinter` formats output with colors based on print level.                                           |
| **Print Formatting**    | `E_PrintLevel.cs`, `ColorFormat.cs`, `PrintLevelFormat.cs`                                   | Structured message formatting.               | Defines priority categories (Error, Dialog, Infoboard) and maps them to color schemes.                                                                             |
| **Audio System**        | `SoundPlayer.cs`, `E_Sound.cs`, `SoundIntervalCollection.cs`, `Sound.cs`, `SoundInterval.cs` | Plays adjustable beep sequences.             | Uses collections of `Sound` structs (frequency + duration) to form sequences, which `SoundPlayer` executes.                                                        |
| **Gamemode Info**       | `E_GamemodeType.cs`, `GamemodeInfo.cs`, `GamemodeExtensions.cs`                              | Defines gamemodes & metadata.                | Maps gamemode types to readable names and descriptions.                                                                                                            |
| **Utility Functions**   | `LogicLib.cs`                                                                                | Misc helpers.                                | Includes `IsNumeral`, numeric range validation, and other general helpers.                                                                                         |

---

## Core Mechanics & Design

### **Tile-Based Rendering**

* The `Map` stores a 2D character array.
* On each frame, the renderer queries `SpriteManager` for the correct sprite based on the character label.
* Console is redrawn using color-coded `ConsolePrinter` output.

### **Sprite System**

* Every entity is a `Sprite`.
* Each sprite is mapped to a character and color.
* Makes world logic extremely modular and extendable.

### **Input Mapping**

* Arrow key presses → `Vector2` movement deltas.
* InputManager prevents invalid movement (out-of-bounds, wall collisions).

### **Sound Feedback**

* Every important event (correct/incorrect input, item pickup, level finish) has its own `SoundInterval`.
* Sounds are constructed from short frequency/duration pairs.

### **Gamemode Flow**

* Gamemode selection leads to loading or generating a map.
* GameManager controls progression and checks for win state (reaching the exit after collecting all keys).

---

## Author

**Jonathan Huber** – Developer of the Escape Room console game project.

---

> Built with ❤️ in C#.
