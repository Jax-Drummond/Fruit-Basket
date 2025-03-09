using FinalProject.Classes;
using FinalProject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace FinalProject.BaseClasses
{
    /// <summary>
    /// Base scene used for making scenes
    /// </summary>
    public abstract class Scene : GameComponent, IScene
    {
        internal Game _game;
        internal SpriteBatch _spriteBatch;
        internal GraphicsDeviceManager _graphics;
        internal string _backgroundName;
        public static readonly Dictionary<string, Scene> Scenes = new();

        public Scene(Game game, SpriteBatch batch, GraphicsDeviceManager graphics) : base(game)
        {
            _game = game;
            _spriteBatch = batch;
            _graphics = graphics;
        }

        /// <summary>
        /// Used to load the scene
        /// </summary>
        public virtual void Load()
        {
            _game.Components.Clear();
            _game.Content.Unload();
            if (_backgroundName != null)
            {
                _ = new Background(
                                   _game,
                                   _spriteBatch,
                                   Vector2.Zero,
                                   Color.White,
                                   _game.Content.Load<Texture2D>(_backgroundName)
                                   );
            }
			_game.Components.Add(this);

        }
    }
}
