using FinalProject.Interfaces;
using FinalProject.Managers;
using FinalProject.Structs;
using Fruit_Basket.BaseClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace FinalProject.Scenes
{
	/// <summary>
	/// The Level1 scene
	/// </summary>
    internal class Level1 : Level
    {
        public Level1(Game game, SpriteBatch batch, GraphicsDeviceManager graphics) : base(game, batch, graphics)
        {
			Scenes.Add(nameof(Level1), this);
			_backgroundName = "Backgrounds/Level1";
		}

        public override void Load()
		{ 
			base.Load();
			Game1.SoundManager.PlayMusic("gameplay");
			NextLevel = (ILevel)Scenes["Level2"];
			Game1.CurrentLevelName = "Level 1";
			DropItemInfo dropItemInfo = new DropItemInfo()
            {
                Texture = Game.Content.Load<Texture2D>("DropSprites/Apple"),
                points = 95,
                speed = 2.5f,
                cols = 4,
                rows = 2,
            };
			DropManager.dropItems.Add(dropItemInfo);
			dropItemInfo = new DropItemInfo()
			{
				Texture = Game.Content.Load<Texture2D>("DropSprites/Orange"),
				points = 60,
				speed = 2,
				cols = 4,
				rows = 2,
			};
			DropManager.dropItems.Add(dropItemInfo);
			dropItemInfo = new DropItemInfo()
			{
				Texture = Game.Content.Load<Texture2D>("DropSprites/Watermelon"),
				points = 360,
				speed = 1.5f,
				cols = 4,
				rows = 2,
			};
			DropManager.dropItems.Add(dropItemInfo);
		}

    }
}
