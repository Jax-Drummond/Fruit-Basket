using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FinalProject.BaseClasses
{
    /// <summary>
    /// The base component used for making component classes
    /// </summary>
    public abstract class Component : DrawableGameComponent
    {
        public Vector2 Position { get; set; }
        public Color Color { get; set; }
        public SpriteBatch SpriteBatch { get; set; }
        public Vector2 Origins { get; set; }

        protected Component(Game game, SpriteBatch spriteBatch, Vector2 position, Color color) : base(game)
        {
            SpriteBatch = spriteBatch;
            Position = position;
            Color = color;
            game.Components.Add(this);
        }
    }
}
