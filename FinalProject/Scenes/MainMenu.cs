using FinalProject.BaseClasses;
using FinalProject.Classes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace FinalProject.Scenes
{
    /// <summary>
    /// The mainmenu scene
    /// </summary>
    internal class MainMenu : Scene
    {
        public MainMenu(Game game, SpriteBatch batch, GraphicsDeviceManager graphics) : base(game, batch, graphics)
        {
            Scenes.Add(nameof(MainMenu), this);
            _backgroundName = "Backgrounds/MainMenu";
		}

        public override void Load()
        {
            base.Load();
            if (MediaPlayer.State != MediaState.Playing)
            {
                Game1.SoundManager.PlayMusic("mainmenu");
            }
            Label titleLabel = new(
                _game, 
                _spriteBatch, 
                new Vector2(_graphics.PreferredBackBufferWidth / 2, 100f), 
                Color.White, 
                text: "Fruit Basket", 
                font: _game.Content.Load<SpriteFont>("title"));
			Button startButton = new(
                _game, 
                _spriteBatch, 
                new Vector2(_graphics.PreferredBackBufferWidth / 2, 200f), 
                new Color(62, 66, 74), "Play");
            startButton.OnClick += () => Scenes["Level1"].Load();
			Button leaderboardButton = new(
				_game,
				_spriteBatch,
				new Vector2(_graphics.PreferredBackBufferWidth / 2, 260f),
				new Color(62, 66, 74), "Leaderboards");
			leaderboardButton.OnClick += OnLeaderboardsButtonClick;
			Button helpButton = new(
                _game, 
                _spriteBatch,
                new Vector2(_graphics.PreferredBackBufferWidth / 2, 320), 
                new Color(62, 66, 74), "Help");
            helpButton.OnClick += OnHelpButtonClick;
			Button creditsButton = new(
                _game, 
                _spriteBatch, 
                new Vector2(_graphics.PreferredBackBufferWidth / 2, 380),
                new Color(62, 66, 74), "Credits");
            creditsButton.OnClick += OnCreditsButtonClick;
            Button settingsButton = new(
                _game,
                _spriteBatch,
                new Vector2(130, 440),
                new Color(62, 66, 74), "Settings");
            settingsButton.OnClick += OnSettingsButtonClick;
            Button exitButton = new(
                _game, 
                _spriteBatch, 
                new Vector2(_graphics.PreferredBackBufferWidth / 2, 440f),
                new Color(62, 66, 74), "Ex it");
            exitButton.OnClick += OnExitButtonClick;
        }

        private void OnLeaderboardsButtonClick()
        {
            Scenes["LeaderBoard"].Load();
        }

        private void OnHelpButtonClick()
        {
            Scenes["Help"].Load();
        }

        private void OnCreditsButtonClick()
        {
            Game1.SceneManager.LoadScene("Credits");
        }

        private void OnSettingsButtonClick()
        {
            Game1.SceneManager.LoadScene("Settings");
        }

        private void OnExitButtonClick()
        {
            _game.Exit();
        }
    }
}
