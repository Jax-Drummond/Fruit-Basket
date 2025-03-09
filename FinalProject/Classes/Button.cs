using FinalProject.BaseClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace FinalProject.Classes
{
    /// <summary>
    /// Used for making buttons
    /// </summary>
    internal class Button : Component
    {
        public string Text { get; set; }
        public SpriteFont Font { get; set; }
        public Texture2D Background { get; set; }
        private Color[] _textureColor;
        private bool isHovering = false;
        private MouseState _oldMouseState;

        public event Action OnClick;
        public Button(Game game, SpriteBatch spriteBatch, Vector2 position, Color color, string text = "") : base(game, spriteBatch, position, color)
        {
            Text = text;
            Font = Game.Content.Load<SpriteFont>("text");
            Background = Game.Content.Load<Texture2D>("buttonBackground");
            Origins = new Vector2(Background.Width / 2, Background.Height / 2);
            _ = new Label(Game, SpriteBatch, Position, Color.White, text: text);
            ChangeColor(Color);
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch.Begin();
            SpriteBatch.Draw(Background, Position, null, Color, 0f, Origins, Vector2.One, SpriteEffects.None, 0f);
            SpriteBatch.End();
            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            MouseState mouseState = Mouse.GetState();

            if (!isHovering)
            {
                if (isWithinBounds())
                {
                    isHovering = true;
                    Color newColor = new Color(Color.R * 2f, Color.G * 2f, Color.B * 2f);
                    ChangeColor(newColor);
                    Game1.SoundManager.PlaySound("buttonHover");
                }
            }
            else if (isHovering)
            {
                if (mouseState.LeftButton == ButtonState.Pressed && _oldMouseState.LeftButton == ButtonState.Released)
                {
                    OnClick?.Invoke();
                    Game1.SoundManager.PlaySound("buttonClick");
                }
                if (!isWithinBounds())
                {
                    isHovering = false;
                    ChangeColor(Color);
                }
            }

            _oldMouseState = mouseState;
            base.Update(gameTime);
        }

        /// <summary>
        /// Used for chaning the background color of the button
        /// </summary>
        /// <param name="color">The color to change to</param>
        private void ChangeColor(Color color)
        {
            _textureColor = new Color[Background.Width * Background.Height];
            Background.GetData(_textureColor);
            Texture2D newTexture = new Texture2D(Game.GraphicsDevice, Background.Width, Background.Height, false, SurfaceFormat.Color);
            for (int i = 0; i < _textureColor.Length; i++)
            {
                if (_textureColor[i].A > 0)
                {
                    _textureColor[i] = color;
                }
            }
            newTexture.SetData<Color>(_textureColor);
            Background = newTexture;
        }

        /// <summary>
        /// Used to check if the mouse is within the bounds of the button
        /// </summary>
        /// <returns>Whether the mouse is within or not</returns>
        private bool isWithinBounds()
        {
            MouseState mouseState = Mouse.GetState();
            if (GetBounds().Contains(mouseState.Position.X, mouseState.Position.Y))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Gets the bounds of the button
        /// </summary>
        /// <returns></returns>
        private Rectangle GetBounds()
        {
            int leftSide = (int)Position.X - Background.Width / 2;
            int topSide = (int)Position.Y - Background.Height / 2;
            return new Rectangle(leftSide, topSide, Background.Width, Background.Height);
        }
    }
}
