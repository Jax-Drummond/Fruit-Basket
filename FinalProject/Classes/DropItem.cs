using FinalProject.BaseClasses;
using FinalProject.Managers;
using FinalProject.Structs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace FinalProject.Classes
{
    /// <summary>
    /// Used for making drop items, e.g. Watermelon
    /// </summary>
    public class DropItem : Component
    {
        private float _points;
        private float _speed;
        private Texture2D _texture;
		private AnimatedSprite _sprite;
		public float Radius => 40;
        public bool IsBacteria;
        public bool IsUpgrade;
        public string UpgradeString;

        public DropItem(Game game, SpriteBatch spriteBatch, Vector2 position, Color color, DropItemInfo dropItemInfo ) : base(game, spriteBatch, position, color)
        {
            _texture = dropItemInfo.Texture;
            _points = dropItemInfo.points;
            _speed = dropItemInfo.speed;
			IsBacteria = dropItemInfo.isBacteria;
            IsUpgrade = dropItemInfo.isUpgrade;
            UpgradeString = dropItemInfo.upgradeString;
            Origins = new Vector2(Radius, Radius);
            _sprite = new AnimatedSprite(game, spriteBatch, Position, Color, _texture, dropItemInfo.cols, dropItemInfo.rows, 0.25f);
            CollisionManager.DropItems.Add(this);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            
			Position += new Vector2(0, _speed);
            _sprite.Position = Position;
		}


        /// <summary>
        /// Checks if the object intersects with a rectangle
        /// </summary>
        /// <param name="rect">The rect that it intersects</param>
        /// <returns></returns>
        public bool Intersects(Rectangle rect)
        {
            // Find the closest point on the rectangle to the circle's center
            float tempX = Math.Max(rect.Left, Math.Min(Position.X, rect.Right));
            float tempY = Math.Max(rect.Top, Math.Min(Position.Y, rect.Bottom));

            // Compute squared distance from circle center to the closest point
            float relativeX = Position.X - tempX;
            float relativeY = Position.Y - tempY;
            float distanceSquared = relativeX * relativeX + relativeY * relativeY;

            // Compare squared distances to avoid unnecessary sqrt()
            return distanceSquared <= Radius * Radius;

        }

        /// <summary>
        /// An upgrade method that doubles the points of this dropitem
        /// </summary>
        public void DoublePoints()
        {
            _points *= 2;
        }

        /// <summary>
        /// A Debuff that halfs all of the points of this drop item
        /// </summary>
        public void HalfPoints()
        {
            _points /= 2;
        }

        /// <summary>
        /// Used to collect points
        /// </summary>
        /// <returns></returns>
        public float CollectPoints()
        {
            Destroy();
            return _points;
        }

        /// <summary>
        /// Used for removing dropitems
        /// </summary>
        public void Destroy()
        {
            CollisionManager.DropItems.Remove(this);
            Game.Components.Remove(this);
            Game.Components.Remove(_sprite);
        }

        
    }
}
