using FinalProject.BaseClasses;
using FinalProject.Classes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace FinalProject.Scenes
{
    /// <summary>
    /// The Help scene
    /// </summary>
    internal class Help : Scene
    {
        public Help(Game game, SpriteBatch batch, GraphicsDeviceManager graphics) : base(game, batch, graphics)
        {
			Scenes.Add(nameof(Help), this);
			_backgroundName = "Backgrounds/Help";
		}

        public override void Load()
        {
            base.Load();
            Label titleLabel = new(_game, _spriteBatch, new Vector2(_graphics.PreferredBackBufferWidth / 2, 50), Color.White, text: "Help", font: _game.Content.Load<SpriteFont>("title"));
            Label helpText = new(_game, _spriteBatch, new Vector2(400, 240), Color.White, text: "The goal of the game is to collect as many fruit as you can\n" +
                "before you run out of health.\n" +
                "You use 'A' or Left Arrow to move left\n" +
                "and 'D' or Right Arrow to move right.\n" +
                "Make sure to avoid any bacteria falling,\n" +
                "if you catch one of them, it is game over.\n" +
                "If you see a glowing drop it is an temporary\n" +
                "upgrade, click it and you'll get a boost.", font: _game.Content.Load<SpriteFont>("text"));

			Button backButton = new(_game, _spriteBatch, new Vector2(125f, _graphics.PreferredBackBufferHeight - 28f), new Color(62, 66, 74), "Back");
            backButton.OnClick += OnBackButtonClick;
        }

        private void OnBackButtonClick()
        {
            Scenes["MainMenu"].Load();
        }
    }
}
