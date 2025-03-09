using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using FinalProject.BaseClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FinalProject.Managers
{
    /// <summary>
    /// Used for managing scenes
    /// </summary>
    public class SceneManager : GameComponent
    {
        public SceneManager(Game game, SpriteBatch spriteBatch, GraphicsDeviceManager graphics) : base(game)
        {
            CreateScenes(spriteBatch, graphics);
        }
        
        /// <summary>
        /// Used for creating all the scenes automatically
        /// </summary>
        /// <param name="spriteBatch">The games sprite batch</param>
        /// <param name="graphics">The games graphics device manager</param>
        private void CreateScenes(SpriteBatch spriteBatch, GraphicsDeviceManager graphics)
        {
            var sceneClasses = Assembly.GetExecutingAssembly().GetTypes()
                .Where(sc => sc.Namespace != null && sc.Namespace.StartsWith("FinalProject.Scenes"));
            foreach (var sceneClass in sceneClasses)
            {
                Debug.WriteLine(sceneClass);
                try
                {
                    Activator.CreateInstance(sceneClass, Game, spriteBatch, graphics);
                }
                catch (Exception exception)
                {
                    Debug.WriteLine($"Error: Unable to create scene, {exception}");
                }
            }
        }

        /// <summary>
        /// Used for loading a scene
        /// </summary>
        /// <param name="sceneName">The scene to load</param>
        public void LoadScene(string sceneName)
        {
            Scene.Scenes[sceneName].Load();
        }
    }
}
