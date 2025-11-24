using System;

namespace Escape_Room
{
    /// <summary>
    /// Represents a drawable object on the map, such as the player, key, door, or ground.
    /// </summary>
    public class Sprite
    {
        public char character { get; protected set; }
        public ConsoleColor foregroundColor { get; protected set; }
        public ConsoleColor backgroundColor { get; protected set; }
        public char label { get; protected set; }
        protected Vector2 position;

        public Sprite(char character, char label, ConsoleColor fgcolor, ConsoleColor bgcolor)
        {
            this.character = character;
            this.foregroundColor = fgcolor;
            this.backgroundColor = bgcolor;
            this.label = label;
        }

        /// <summary>
        /// Sets the position of the sprite on the map.
        /// </summary>
        /// <param name="pos">The new position for the sprite.</param>
        public void SetPosition(Vector2 pos) => position = pos;

        /// <summary>
        /// Returns the current position of the sprite on the map.
        /// </summary>
        /// <returns>The <see cref="Vector2"/> representing the sprite's position.</returns>
        public Vector2 GetPosition() => position;

        /// <summary>
        /// Draws the sprite to the console using its character and colors.
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
