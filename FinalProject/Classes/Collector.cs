using FinalProject.BaseClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FinalProject.Classes
{
    /// <summary>
    /// A class for creating and handling the collector
    /// </summary>
    public class Collector : Component
    {
        private float _speed = 5;
        private readonly Texture2D _texture;

        public Collector(Game game, SpriteBatch spriteBatch, Vector2 position, Color color, Texture2D texture) : base(game, spriteBatch, position, color)
        {
            _texture = texture;
            Origins = new(_texture.Width / 2, _texture.Height / 2);
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState keyboard = Keyboard.GetState();

            if ((keyboard.IsKeyDown(Keys.Left) || keyboard.IsKeyDown(Keys.A)) && Position.X - _texture.Width / 2 > 0)
            {
                Position -= new Vector2(_speed, 0);
            }
            if ((keyboard.IsKeyDown(Keys.Right) || keyboard.IsKeyDown(Keys.D)) && Position.X + _texture.Width / 2 < Game.GraphicsDevice.Viewport.Width)
            {
					Position += new Vector2(_speed, 0);
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch.Begin();
            SpriteBatch.Draw(_texture, Position, null, Color, 0f, Origins, Vector2.One, SpriteEffects.None, 0f);
            SpriteBatch.End();
            base.Draw(gameTime);
        }

        /// <summary>
        /// Sets the move speed of the collector
        /// </summary>
        /// <param name="speed"></param>
        public void SetSpeed(float speed)
        {
            _speed = speed;
        }

        /// <summary>
        /// Gets the rectangle of the collector
        /// </summary>
        /// <returns></returns>
        public Rectangle GetRectangle()
        {
            return new Rectangle((int)Position.X - _texture.Width / 2, (int)Position.Y - _texture.Height / 2, _texture.Width - 50, _texture.Height - 50);
        }
    }
}
