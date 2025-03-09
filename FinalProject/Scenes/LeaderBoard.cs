using FinalProject.BaseClasses;
using FinalProject.Classes;
using Fruit_Basket.Managers;
using Fruit_Basket.Structs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;

namespace FinalProject.Scenes
{
    /// <summary>
    /// The LeaderBoard scene
    /// </summary>
    internal class LeaderBoard : Scene
    {
        public LeaderBoard(Game game, SpriteBatch batch, GraphicsDeviceManager graphics) : base(game, batch, graphics)
        {
			Scenes.Add(nameof(LeaderBoard), this);
            FileManager.LoadLeaderBoard();
			_backgroundName = "Backgrounds/Leaderboard";
		}

        public override void Load()
        {
            base.Load();
            FileManager.LoadLeaderBoard();
            List<LeaderBoardInfo> leaderBoardInfos = FileManager.LeaderBoardInfos.OrderByDescending(info => info.Score).ThenBy(info => info.ScoreDate).Take(5).ToList();

            string leaderboardText = "Name  |  Score  |  Level\n";
            if (leaderBoardInfos.Count > 0)
            {
                foreach (LeaderBoardInfo info in leaderBoardInfos)
                {
                    leaderboardText += $"{info.Name}  |  {info.Score}  |  {info.LevelName}\n";
                }
            }
            else
            {
                leaderboardText = "There are no records.";
            }
            
			Label titleLabel = new(_game, _spriteBatch, new Vector2(_graphics.PreferredBackBufferWidth / 2, 50), Color.White, text: "Leaderboards", font: _game.Content.Load<SpriteFont>("title"));
            Label leaderBoardText = new(_game, _spriteBatch, new Vector2(250, 140), Color.White, text: leaderboardText, font: _game.Content.Load<SpriteFont>("text"), centerOrigin: false);

			Button backButton = new(_game, _spriteBatch, new Vector2(125f, _graphics.PreferredBackBufferHeight - 28f), new Color(62, 66, 74), "Back");
            backButton.OnClick += OnBackButtonClick;
        }

        private void OnBackButtonClick()
        {
            Scenes["MainMenu"].Load();
        }
    }
}
