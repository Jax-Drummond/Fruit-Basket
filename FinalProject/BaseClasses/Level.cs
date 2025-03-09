using FinalProject;
using FinalProject.BaseClasses;
using FinalProject.Classes;
using FinalProject.Interfaces;
using FinalProject.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Fruit_Basket.BaseClasses
{
	/// <summary>
	/// A base class used to be derived from for levels
	/// </summary>
	public abstract class Level : Scene, ILevel
	{
		public static ILevel NextLevel { get; set; }
		public float Score { get; set; }
		public int Health { get; set; }
		public Collector Collector { get; set; }
		public CollisionManager CollisionManager { get; set; }
		public DropManager DropManager { get; set; }

		internal Label _scoreLabel;
		internal Label _healthLabel;

		public Level(Game game, SpriteBatch batch, GraphicsDeviceManager graphics) : base(game, batch, graphics)
		{
		}

		/// <summary>
		/// Used for loading levels
		/// </summary>
		public override void Load()
		{
			base.Load();
			NextLevel = null;
			Collector = new Collector(
			   _game,
			   _spriteBatch,
			   new(_graphics.PreferredBackBufferWidth / 2, 440f),
			   Color.White,
			   _game.Content.Load<Texture2D>("basket"));
			Collector.SetSpeed(7);
			_scoreLabel = new(
				_game,
				_spriteBatch,
				new Vector2(55, 15),
				Color.White,
				text: "Score: 0",
				font: _game.Content.Load<SpriteFont>("text"));
			_healthLabel = new(
				_game,
				_spriteBatch,
				new Vector2(5, 30),
				Color.White,
				font: _game.Content.Load<SpriteFont>("text"));
			Health = 3;
			Score = 0;
			SetHealthLabel();
			CollisionManager = new(_game, this);
			DropManager = new(_game, _spriteBatch);
			DropManager.SpawnRate = 1;
			
		}

		/// <summary>
		/// Used for updating the health label
		/// </summary>
		internal void SetHealthLabel()
		{
			if( Health <= 0 )
			{
				Game1.FinalScore = Score;
				Scenes["GameEnd"].Load();
			}
			_healthLabel.Text = "";
			for (int i = 0; i < Health; i++)
			{
				_healthLabel.Text += "<3";
			}
		}

		public override void Update(GameTime gameTime)
		{
			var keyState = Keyboard.GetState();
			if (keyState.IsKeyDown(Keys.Escape)) // Remove later or setup a different way
			{
				Scenes["MainMenu"].Load();
				Game1.SoundManager.PlayMusic("mainmenu");
			}

			if (Score > 0)
			{
				_scoreLabel.Text = $"Score: {Score}";
			}
			base.Update(gameTime);
		}

		/// <summary>
		/// Used to take damage
		/// </summary>
		/// <param name="damage">The amount of damage</param>
		public void TakeDamage(int damage)
		{
			Health -= damage;
			SetHealthLabel();
		}
	}
}
