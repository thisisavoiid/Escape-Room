using System;

namespace Escape_Room
{
    /// <summary>
    /// Represents a drawable object on the map, such as the player, key, door, or ground.
    /// </summary>
    public class Sprite
    {
        /// <summary>
        /// The character used to visually represent this sprite in the console.
        /// </summary>
        public char character;

        /// <summary>
        /// The foreground color used when drawing this sprite.
        /// </summary>
        public ConsoleColor foregroundColor;

        /// <summary>
        /// The background color used when drawing this sprite.
        /// </summary>
        public ConsoleColor backgroundColor;

        /// <summary>
        /// The logical label of this sprite (used for game logic).
        /// </summary>
        public char label;

        /// <summary>
        /// The current position of this sprite on the map.
        /// </summary>
        protected Vector2 position;

        /// <summary>
        /// Initializes a new instance of the <see cref="Sprite"/> class.
        /// </summary>
        /// <param name="character">
        /// The character to display for this sprite.
        /// </param>
        /// <param name="label">
        /// The logical label for game logic.
        /// </param>
        /// <param name="fgcolor">
        /// The foreground color for drawing.
        /// </param>
        /// <param name="bgcolor">
        /// The background color for drawing.
        /// </param>
        public Sprite(char character, char label, ConsoleColor fgcolor, ConsoleColor bgcolor)
        {
            this.character = character;
            this.foregroundColor = fgcolor;
            this.backgroundColor = bgcolor;
            this.label = label;
        }

        /// <summary>
        /// Sets the position of this sprite on the map.
        /// </summary>
        /// <param name="pos">
        /// The new position as a <see cref="Vector2"/>.
        /// </param>
        public void SetPosition(Vector2 pos) => position = pos;

        /// <summary>
        /// Gets the current position of this sprite.
        /// </summary>
        /// <returns>
        /// The current position as a <see cref="Vector2"/>.
        /// </returns>
        public Vector2 GetPosition() => position;

        /// <summary>
        /// Draws the sprite at its current position using its character and colors.
        /// </summary>
        public void Draw()
        {
            Console.ForegroundColor = this.foregroundColor;
            Console.BackgroundColor = this.backgroundColor;
            Console.Write(character);
            Console.ResetColor();
        }
    }
}
