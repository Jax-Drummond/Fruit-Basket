using FinalProject.Managers;
using FinalProject.Structs;
using Fruit_Basket.BaseClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace FinalProject.Scenes
{
	/// <summary>
	/// The Level2 scene
	/// </summary>
    internal class Level2 : Level
    {
        public Level2(Game game, SpriteBatch batch, GraphicsDeviceManager graphics) : base(game, batch, graphics)
        {
			Scenes.Add(nameof(Level2), this);
			_backgroundName = "Backgrounds/Level2";
		}

        public override void Load()
        {
			base.Load();
			Game1.CurrentLevelName = "Level 2";
			DropItemInfo dropItemInfo = new DropItemInfo()
            {
                Texture = Game.Content.Load<Texture2D>("DropSprites/Cherry"),
                points = 100,
                speed = 2.25f,
                cols = 4,
                rows = 2,
            };
			DropManager.dropItems.Add(dropItemInfo);
			dropItemInfo = new DropItemInfo()
			{
				Texture = Game.Content.Load<Texture2D>("DropSprites/pineapple"),
				points = 450,
				speed = 1.3f,
				cols = 4,
				rows = 2,
			};
			DropManager.dropItems.Add(dropItemInfo);
			dropItemInfo = new DropItemInfo()
			{
				Texture = Game.Content.Load<Texture2D>("DropSprites/Strawberry"),
				points = 200,
				speed = 1.75f,
				cols = 4,
				rows = 2,
			};
			DropManager.dropItems.Add(dropItemInfo);
			dropItemInfo = new DropItemInfo()
			{
				Texture = Game.Content.Load<Texture2D>("DropSprites/Bacteria"),
				speed = 1.5f,
				cols = 4,
				rows = 2,
				isBacteria = true
			};

			DropManager.Bacteria = dropItemInfo;

			DropItemInfo upgradeItemInfo = new DropItemInfo()
			{
				Texture = Game.Content.Load<Texture2D>("DropSprites/2xPoints"),
				speed = 2.5f,
				cols = 3,
				rows = 2,
				isUpgrade = true,
				upgradeString = "2xPoints"
			};
			DropManager.upgradeItems.Add(upgradeItemInfo);

            upgradeItemInfo = new DropItemInfo()
            {
                Texture = Game.Content.Load<Texture2D>("DropSprites/HalfPoint"),
                speed = 5f,
                cols = 3,
                rows = 2,
                upgradeString = "HalfPoints"
            };
            DropManager.upgradeItems.Add(upgradeItemInfo);

			upgradeItemInfo = new DropItemInfo()
			{
				Texture = Game.Content.Load<Texture2D>("DropSprites/KillBacteria"),
				speed = 2.5f,
				cols = 3,
				rows = 2,
				isUpgrade = true,
				upgradeString = "KillBacteria"
			};
			DropManager.upgradeItems.Add(upgradeItemInfo);

			upgradeItemInfo = new DropItemInfo()
			{
				Texture = Game.Content.Load<Texture2D>("DropSprites/HealthUp"),
				speed = 2.5f,
				cols = 3,
				rows = 2,
				isUpgrade = true,
				upgradeString = "HealthUp"
			};
			DropManager.upgradeItems.Add(upgradeItemInfo);

		}

	}
}
