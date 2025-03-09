using FinalProject.BaseClasses;
using FinalProject.Classes;
using Fruit_Basket.BaseClasses;
using Fruit_Basket.Managers;
using Fruit_Basket.Structs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace FinalProject.Scenes
{
    /// <summary>
    /// The Game End scene
    /// </summary>
    internal class GameEnd : Scene
    {
        public GameEnd(Game game, SpriteBatch batch, GraphicsDeviceManager graphics) : base(game, batch, graphics)
        {
			Scenes.Add(nameof(GameEnd), this);
			_backgroundName = "Backgrounds/GameEnd";
		}

        public override void Load()
        {
            base.Load();
            AddToLeaderBoard();
            Label titleLabel = new(_game, _spriteBatch, new Vector2(_graphics.PreferredBackBufferWidth / 2, 50), Color.White, text: "Level Finished", font: _game.Content.Load<SpriteFont>("title"));
            Label helpText = new(_game, _spriteBatch, new Vector2(_graphics.PreferredBackBufferWidth / 2, 170), Color.White, text: $"Player: {Game1.PlayerName}\nFinal score: {Game1.FinalScore}\n", font: _game.Content.Load<SpriteFont>("text"));
            if (Level.NextLevel != null)
            {
				Button nextButton = new(_game, _spriteBatch, new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2), new Color(62, 66, 74), "Next Level");
                nextButton.OnClick += OnNextButtonClick;
            }
			Button backButton = new(_game, _spriteBatch, new Vector2(_graphics.PreferredBackBufferWidth /2, _graphics.PreferredBackBufferHeight/ 2 + 60), new Color(62, 66, 74), "Back");
            backButton.OnClick += OnBackButtonClick;
        }
        private void AddToLeaderBoard()
        {
            LeaderBoardInfo info = new LeaderBoardInfo()
            {
                Name = Game1.PlayerName,
                Score = Game1.FinalScore,
                ScoreDate = DateTime.Now,
                LevelName = Game1.CurrentLevelName
            };

            FileManager.LeaderBoardInfos.Add(info);
            FileManager.SaveLeaderBoard();

        }

        private void OnBackButtonClick()
        {
            Scenes["MainMenu"].Load();
        }

        private void OnNextButtonClick()
        {
            Level.NextLevel.Load();
        }
    }
}
