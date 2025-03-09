using FinalProject.BaseClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FinalProject.Classes
{
    /// <summary>
    /// Used for creating animated sprites
    /// </summary>
    internal class AnimatedSprite : Component
    {
        private Texture2D texture;
        private int columns;
        private int rows;
        private int currentFrame;
        private int totalFrames => columns * rows;
        private double timer = 0;
        private double delay;
        public AnimatedSprite(Game game, SpriteBatch spriteBatch, Vector2 position, Color color, Texture2D texture, int columns, int rows, double delay, int startingFrame = 0) : base(game, spriteBatch, position, color)
        {
            this.texture = texture;
            this.columns = columns;
            this.rows = rows;
            this.delay = delay;
            currentFrame = startingFrame;
        }

        public override void Update(GameTime gameTime)
        {
            timer += gameTime.ElapsedGameTime.TotalSeconds;
            if (timer > delay)
            {
                currentFrame++;
                timer = 0;
                if (currentFrame == totalFrames)
                {
                    currentFrame = 0;
                }
            }
            
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            int width = texture.Width / columns;
            int height = texture.Height / rows;
            int row = currentFrame / columns;
            int col = currentFrame % columns;

            Rectangle sourceRectangle = new Rectangle(col * width, row * height, width, height);
            Rectangle destRectangle = new Rectangle((int)Position.X, (int)Position.Y, width, height);

            SpriteBatch.Begin();
            SpriteBatch.Draw(texture, destRectangle, sourceRectangle, Color);
            SpriteBatch.End();

        }


    }
}
