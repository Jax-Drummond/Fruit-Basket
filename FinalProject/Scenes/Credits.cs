using FinalProject.BaseClasses;
using FinalProject.Classes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace FinalProject.Scenes
{
    /// <summary>
    /// The Credits scene
    /// </summary>
    internal class Credits : Scene
    {
        public Credits(Game game, SpriteBatch batch, GraphicsDeviceManager graphics) : base(game, batch, graphics)
        {
            Scenes.Add(nameof(Credits), this);
			_backgroundName = "Backgrounds/Credits";
		}

        public override void Load()
        {
            base.Load();
            Texture2D nameAtlas = _game.Content.Load<Texture2D>("nameAtlas");
            Label titleLabel = new(
                _game, 
                _spriteBatch, 
                new Vector2(_graphics.PreferredBackBufferWidth / 2, 50), 
                Color.White, 
                text: "Credits", 
                font: _game.Content.Load<SpriteFont>("title"));
            Label developerLabel = new(
                _game, 
                _spriteBatch, 
                new Vector2(_graphics.PreferredBackBufferWidth / 2 - 120, 110), 
                Color.White, 
                text: "Programmer -", 
                font: _game.Content.Load<SpriteFont>("text"));
            AnimatedSprite developerAnimated = new(
                _game, 
                _spriteBatch, 
                new(_graphics.PreferredBackBufferWidth / 2 - 25, 80), 
                Color.White, 
                nameAtlas, 
                7, 
                1, 
                0.1);
            Label designerLabel = new(
                _game, 
                _spriteBatch, 
                new Vector2(_graphics.PreferredBackBufferWidth / 2 - 120, 170), 
                Color.White, 
                text: "Animation/Graphics -", 
                font: _game.Content.Load<SpriteFont>("text"));
            AnimatedSprite designerAnimated = new(
                _game, 
                _spriteBatch, 
                new(_graphics.PreferredBackBufferWidth / 2 + 25, 140), 
                Color.White, 
                nameAtlas, 
                7, 
                1, 
                0.1, 
                1);
            Button backButton = new(
                _game, 
                _spriteBatch, 
                new Vector2(125f, _graphics.PreferredBackBufferHeight - 28f), 
                new Color(62, 66, 74), 
                "Back");
            backButton.OnClick += OnBackButtonClick;
        }

        private void OnBackButtonClick()
        {
            Scenes["MainMenu"].Load();
        }
    }
}
