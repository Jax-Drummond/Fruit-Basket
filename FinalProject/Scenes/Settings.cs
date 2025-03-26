using FinalProject.BaseClasses;
using FinalProject.Classes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;


namespace FinalProject.Scenes
{
    /// <summary>
    /// The enter user name scene
    /// </summary>
    internal class Settings : Scene
    {
        TextBox inputBox;
        public Settings(Game game, SpriteBatch batch, GraphicsDeviceManager graphics) : base(game, batch, graphics)
        {
			Scenes.Add(nameof(Settings), this);
			_backgroundName = "Backgrounds/UsernameEntry";
		}

        public override void Load() 
        {
            base.Load();
            Label titleLabel = new(_game, _spriteBatch, new Vector2(_graphics.PreferredBackBufferWidth / 2, 50), Color.White, text: "Settings", font: _game.Content.Load<SpriteFont>("title"));
            _ = new Label(Game, _spriteBatch, new Vector2(Game.GraphicsDevice.Viewport.Width/ 2, 100), Color.Black, text: "Music Volume");
            inputBox = new(Game, _spriteBatch, new Vector2(Game.GraphicsDevice.Viewport.Width / 2 - 150, 125), Color.White);
            inputBox.OnEnter += OnSetVolumeButtonClicked;
            inputBox.maxLength = 3;
            inputBox.NumberLock = true;

            Button setVolumeButton = new(
                _game,
                _spriteBatch,
                new Vector2(Game.GraphicsDevice.Viewport.Width / 2, 225),
                new Color(62, 66, 74), "Set");
            setVolumeButton.OnClick += OnSetVolumeButtonClicked;

            Button backButton = new(
                _game,
                _spriteBatch, 
                new Vector2(125f, _graphics.PreferredBackBufferHeight - 28f), 
                new Color(62, 66, 74), "Back");
            backButton.OnClick += OnBackButtonClick;

        }

        private void OnBackButtonClick()
        {
            Scenes["MainMenu"].Load();
        }

        private void OnSetVolumeButtonClicked()
        {
            if (inputBox.InputText.Length == 0) return;

            float newVolume = float.Parse(inputBox.InputText) / 100;
            Game1.SoundManager.SetVolume(newVolume);
        }
    }
}
