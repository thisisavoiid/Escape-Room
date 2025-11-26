namespace Escape_Room
{
    /// <summary>
    /// Represents a drawable object on the map, such as the _player, _key, _door, or _ground.
    /// </summary>
    public class Sprite
    {
        public char Character { get; protected set; }
        public ConsoleColor ForegroundColor { get; protected set; }
        public ConsoleColor BackgroundColor { get; protected set; }
        public char Label { get; protected set; }

        protected Vector2 _position;

        /// <summary>
        /// Initializes a new instance of the <see cref="Sprite"/> class with the specified visual properties and Label.
        /// </summary>
        /// <param name="character">The character used to represent the sprite on the console.</param>
        /// <param name="Label">The internal Label identifying the sprite.</param>
        /// <param name="fgcolor">The foreground color of the sprite.</param>
        /// <param name="bgcolor">The background color of the sprite.</param>
        public Sprite(char character, char Label, ConsoleColor fgcolor, ConsoleColor bgcolor)
        {
            this.Character = character;
            this.ForegroundColor = fgcolor;
            this.BackgroundColor = bgcolor;
            this.Label = Label;
        }

        /// <summary>
        /// Sets the position of the sprite on the map.
        /// </summary>
        /// <param name="pos">The new position for the sprite.</param>
        public void SetPosition(Vector2 pos) => _position = pos;

        /// <summary>
        /// Returns the current position of the sprite on the map.
        /// </summary>
        /// <returns>The <see cref="Vector2"/> representing the sprite's position.</returns>
        public Vector2 GetPosition() => _position;

        /// <summary>
        /// Draws the sprite to the console using its character and colors.
        /// </summary>
        public void Draw()
        {
            Console.ForegroundColor = this.ForegroundColor;
            Console.BackgroundColor = this.BackgroundColor;
            Console.Write(Character);
            Console.ResetColor();
        }
    }
}
