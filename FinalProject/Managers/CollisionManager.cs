using FinalProject.Classes;
using FinalProject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace FinalProject.Managers
{
    /// <summary>
    /// Used for managing Collisions
    /// </summary>
    public class CollisionManager : GameComponent
    {
        private ILevel _level;
        public static List<DropItem> DropItems;
        /// <summary>
        /// Constructor for collisionsmanager
        /// </summary>
        /// <param name="game">The game</param>
        /// <param name="level">The level for the manager</param>
        public CollisionManager(Game game, ILevel level) : base(game)
        {
            _level = level;
            DropItems = new List<DropItem>();
            game.Components.Add(this);
        }

        public override void Update(GameTime gameTime)
        {
            MouseState mouseState = Mouse.GetState();
            try
            {
                foreach (DropItem dropItem in DropItems)
                {

                    if (dropItem != null)
                    {
                        if (dropItem.Intersects(_level.Collector.GetRectangle()) && !dropItem.IsUpgrade)
                        {
                            if (dropItem.IsBacteria)
                            {
                                dropItem.Destroy();
                                _level.TakeDamage(999);
                                Game1.SoundManager.PlaySound("bacteriacollect");
                            }
                            else if (dropItem.UpgradeString != "" && dropItem.UpgradeString != null) // For Debuffs
                            {
                                dropItem.Destroy();
                                switch (dropItem.UpgradeString)
                                {
                                    case "HalfPoints":
                                        HalfPoints();
                                        break;
                                    case "HalfSpeed":
                                        _level.Collector.HalfSpeed();
                                        break;
                                }
                                Game1.SoundManager.PlaySound("bacteriacollect");
                            }
                            else
                            {
							    _level.Score += dropItem.CollectPoints();
								Game1.SoundManager.PlaySound("fruitcollect");
							}
                           
                        }
                        else if (dropItem.IsUpgrade && (mouseState.LeftButton == ButtonState.Pressed))
                        {
							float relativeX = dropItem.Position.X - mouseState.Position.X;
							float relativeY = dropItem.Position.Y - mouseState.Position.Y;
							float distance = (float)Math.Sqrt(Math.Pow(relativeX, 2) + Math.Pow(relativeY, 2));
                                
                            if (distance <= 64)
                            {
                                dropItem.Destroy();
                                switch (dropItem.UpgradeString)
                                {
                                    case "2xPoints":
                                        DoublePoints();
                                        break;
                                    case "KillBacteria":
                                        KillAllBacteria();
                                        break;
                                    case "HealthUp":
                                        HealthUp();
                                        break;
                                    case "HalfPoints":
                                        HalfPoints();
                                        break;
                                }
                                Game1.SoundManager.PlaySound("boostcollect");
                            }
                            
						}
                        if(dropItem.Position.Y >= Game.GraphicsDevice.Viewport.Height + dropItem.Radius) 
                        {  
                            Debug.WriteLine("dropItem removed");
                            dropItem.Destroy();
                            if (!dropItem.IsBacteria && !dropItem.IsUpgrade)
                            {
                                _level.TakeDamage(1);
								Game1.SoundManager.PlaySound("bacteriacollect");
							}
                        }
                    }
                }
            }
            catch
            {
                Debug.WriteLine("DropItems was modified.");
            }      
        }

        /// <summary>
        /// Used for doubling points for all drops on screen
        /// </summary>
        private void DoublePoints()
        {
            try
            {
                foreach(DropItem dropItem in DropItems)
                {
                    if(!dropItem.IsBacteria && !dropItem.IsUpgrade)
                    {
                        dropItem.DoublePoints();
                    }
                }
            }
            catch
            {
                DoublePoints();
            }
        }

        /// <summary>
        /// Used for halving points for all drops on screen
        /// </summary>
        private void HalfPoints()
        {
            try
            {
                foreach (DropItem dropItem in DropItems)
                {
                    if (!dropItem.IsBacteria && !dropItem.IsUpgrade)
                    {
                        dropItem.HalfPoints();
                    }
                }
            }
            catch
            {
                HalfPoints();
            }
        }

        /// <summary>
        /// Used for killing all bacteria on screen
        /// </summary>
        private void KillAllBacteria()
        {
			try
			{
				foreach (DropItem dropItem in DropItems)
				{
					if (dropItem.IsBacteria)
					{
                        dropItem.Destroy();
					}
				}
			}
			catch
			{
                KillAllBacteria();
			}
		}

        /// <summary>
        /// Used to add health to the player
        /// </summary>
		private void HealthUp()
		{
            _level.TakeDamage(-1);
		}

	}
}
