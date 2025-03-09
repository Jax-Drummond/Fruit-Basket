using FinalProject.BaseClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FinalProject.Classes
{
    /// <summary>
    /// Used for making a background
    /// </summary>
    public class Background : Component
    {
        private readonly Texture2D _texture;

        public Background(Game game, SpriteBatch spriteBatch, Vector2 position, Color color, Texture2D texture) : base(game, spriteBatch, position, color)
        {
            _texture = texture;
            Origins = Vector2.Zero;
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch.Begin();
            SpriteBatch.Draw(_texture, Position, null, Color, 0f, Origins, Vector2.One, SpriteEffects.None, 0f);
            SpriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
