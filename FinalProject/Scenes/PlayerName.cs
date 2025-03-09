using FinalProject.BaseClasses;
using FinalProject.Classes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace FinalProject.Scenes
{
    /// <summary>
    /// The enter user name scene
    /// </summary>
    internal class PlayerName : Scene
    {
        TextBox inputBox;
        public PlayerName(Game game, SpriteBatch batch, GraphicsDeviceManager graphics) : base(game, batch, graphics)
        {
			Scenes.Add(nameof(PlayerName), this);
			_backgroundName = "Backgrounds/UsernameEntry";
		}

        public override void Load()
        {
            base.Load();
            _ = new Label(Game, _spriteBatch, new Vector2(Game.GraphicsDevice.Viewport.Width/ 2, 200), Color.Black, text: "Please enter your player name.\n         Press enter once done.");
            inputBox = new(Game, _spriteBatch, new Vector2(Game.GraphicsDevice.Viewport.Width/2 - 140, 250), Color.White);
            inputBox.OnEnter += OnTextBoxEnter;
        }

        private void OnTextBoxEnter()
        {
            if(inputBox != null && inputBox.InputText.Length > 0)
            {
                Game1.PlayerName = inputBox.InputText;
                Scenes["MainMenu"].Load();
            }
        }
    }
}
