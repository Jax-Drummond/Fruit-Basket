using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using FinalProject.Managers;

namespace FinalProject
{
    public class Game1 : Game
    {
        public static string PlayerName;
        public static float FinalScore;
        public static string CurrentLevelName;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public static SoundManager SoundManager;
        public static SceneManager SceneManager;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            SoundManager = new SoundManager(this);
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            SceneManager = new SceneManager(this, _spriteBatch, _graphics);
            SceneManager.LoadScene("PlayerName");

        }

        protected override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkGray);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}