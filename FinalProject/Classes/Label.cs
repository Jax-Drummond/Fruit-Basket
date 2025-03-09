using FinalProject.BaseClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FinalProject.Classes
{
    /// <summary>
    /// Used for creating labels
    /// </summary>
    internal class Label : Component
    {

        public string Text { get; set; }
        public float TextScale { get; set; }
        public SpriteFont Font { get; set; }
        private Vector2 _textSize { get; set; }
        private float _layerDepth;
        public Label(Game game, SpriteBatch spriteBatch, Vector2 position, Color color,float textSize = 1, string text = "", SpriteFont font = null, float layerDepth = 1f, bool centerOrigin = true) : base(game, spriteBatch, position, color)
        {
            Text = text;
            TextScale = textSize;
            _layerDepth = layerDepth;
            if (font == null)
            {
                Font = Game.Content.Load<SpriteFont>("text");
            }
            else
            {
                Font = font;
            }
            if (centerOrigin)
            {
                _textSize = Font.MeasureString(Text);
            }
            else
            {
                _textSize = Vector2.Zero;
            }
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch.Begin();
            SpriteBatch.DrawString(Font, Text, Position, Color.White, 0f, new Vector2(_textSize.X / 2, _textSize.Y /2), TextScale, SpriteEffects.None, _layerDepth);
            SpriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
