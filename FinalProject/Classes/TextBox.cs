using FinalProject.BaseClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;


namespace FinalProject.Classes
{
    /// <summary>
    /// Used for creating text boxes
    /// </summary>
    internal class TextBox : Component
    {
		public event Action OnEnter;
		public string InputText { get; set; }
        public SpriteFont Font { get; set; }
        private Texture2D _background { get; set; }
        private Texture2D _caretTexture { get; set; }
        private AnimatedSprite _caret {  get; set; }
        private Vector2 _caretPosition { get; set; }
        private Vector2 _textPosition { get; set; }
        private KeyboardState _oldKeyBoardState;

        public TextBox(Game game, SpriteBatch spriteBatch, Vector2 position, Color color, string text = "") : base(game, spriteBatch, position, color)
        {
            InputText = text;
            Font = Game.Content.Load<SpriteFont>("text");
			_background = Game.Content.Load<Texture2D>("textBoxBackground");
            _caretTexture = Game.Content.Load<Texture2D>("caret");
            Origins = Vector2.Zero;
            _caretPosition = new Vector2(position.X + 5, position.Y);
            _textPosition = new Vector2(position.X + 5, position.Y + 13);
            _caret = new AnimatedSprite(Game, SpriteBatch, _caretPosition, Color.White, _caretTexture, 2, 1, 0.25);
		}

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch.Begin();
            SpriteBatch.Draw(_background, Position, null, Color, 0f, Origins, Vector2.One, SpriteEffects.None, 0f);
            SpriteBatch.DrawString(Font, InputText, _textPosition, Color.Black);
            SpriteBatch.End();
            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();

            var keysPressed = keyboardState.GetPressedKeys();
            Keys key = 0;

            if(keysPressed.Length > 0 )
            {
                if (keyboardState.IsKeyDown(keysPressed[0]) && _oldKeyBoardState.IsKeyUp(keysPressed[0])) 
                {
                    key = keysPressed[0];
                }
            }
            if( key != 0)
            {
                Vector2 textSize = Font.MeasureString(InputText);

				if (key == Keys.Back && InputText.Length > 0)
				{
					InputText = InputText.Remove(InputText.Length - 1);
				}
				else if (key == Keys.Enter)
                {
                    OnEnter?.Invoke();
                }
                else if (key == Keys.Space)
                {
                    InputText += " ";
                }
                else
                {
                    if (textSize.X < _background.Width - 20)
                    {
                        if (key.ToString().Length == 1)
                        {
                            if (keyboardState.IsKeyDown(Keys.LeftShift))
                            {
                                InputText += key.ToString();
                            }
                            else
                            {
                                InputText += key.ToString().ToLower();
                            }
                        }
                    }
                }

				textSize = Font.MeasureString(InputText);
				_caret.Position = new Vector2(_textPosition.X + textSize.X, _caret.Position.Y);
            }
                        
            _oldKeyBoardState = keyboardState;

            base.Update(gameTime);
        }
    }
}
