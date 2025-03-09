using FinalProject.Classes;
using FinalProject.Structs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace FinalProject.Managers
{
    /// <summary>
    /// Used to manage drops
    /// </summary>
    public class DropManager : GameComponent
    {
        private SpriteBatch _spriteBatch;
        public List<DropItemInfo> dropItems = new List<DropItemInfo>();
        public List<DropItemInfo> upgradeItems = new List<DropItemInfo>();
        public DropItemInfo Bacteria { get; set; }
        public int SpawnRate = 1;
        private Random Random;
        private float upgradeTimer;
        private float upgradeDelay = 10f;
        private float bacteriaTimer;
        private float bacteriaDelay = 3f;
        private float dropTimer;
        private float delay = 1f; // In seconds
        private Vector2 lastPosition;
        public DropManager(Game game, SpriteBatch spriteBatch) : base(game)
        {
            Random = new Random(Environment.TickCount);
            _spriteBatch = spriteBatch;
            game.Components.Add(this);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            
            dropTimer += (float)gameTime.ElapsedGameTime.TotalSeconds * SpawnRate;

            if(dropTimer >= delay)
            {
                if (dropItems.Count > 0)
                {
                    DropItemInfo dropItem = dropItems[Random.Next(0, dropItems.Count)];
                    Vector2 position = GetRandomPostion();
					_ = new DropItem(Game, _spriteBatch, position, Color.White, dropItem);
                    dropTimer = 0f;
                }
            }

            if(Bacteria.Texture != null )
            {
                bacteriaTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                
                if(bacteriaTimer >= bacteriaDelay)
                {
                    Vector2 position = GetRandomPostion();
					_ = new DropItem(Game, _spriteBatch, position, Color.White, Bacteria);
                    bacteriaTimer = 0f;
                }
            }

            if(upgradeItems.Count > 0)
            {
                upgradeTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;

                if(upgradeTimer >= upgradeDelay)
                {
					DropItemInfo upgradeItem = upgradeItems[Random.Next(0, upgradeItems.Count)];
					Vector2 position = GetRandomPostion();
					_ = new DropItem(Game, _spriteBatch, position, Color.White, upgradeItem);
					upgradeTimer = 0f;
				}
            }
        }

        /// <summary>
        /// Gets a random position on screen at y = -100 
        /// </summary>
        /// <returns>The vector spawn position</returns>
        private Vector2 GetRandomPostion()
        {
            if(lastPosition != Vector2.Zero)
            {
                Vector2 newPosition = new Vector2(Random.Next(32, Game.GraphicsDevice.Viewport.Width - 32), -100);
                float relativeX = lastPosition.X - newPosition.X;
                float relativeY = lastPosition.Y - newPosition.Y;
                float distance = (float)Math.Sqrt(Math.Pow(relativeX, 2) + Math.Pow(relativeY, 2));
                if(distance < 64)
                {
                    return GetRandomPostion();
                }
                return newPosition;
            }
            return lastPosition = new Vector2(Random.Next(32, Game.GraphicsDevice.Viewport.Width - 32), -100);
        }
    }
}
