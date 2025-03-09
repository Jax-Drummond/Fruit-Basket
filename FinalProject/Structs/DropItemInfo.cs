using Microsoft.Xna.Framework.Graphics;


namespace FinalProject.Structs
{
    /// <summary>
    /// Used for storing drop item information
    /// </summary>
    public struct DropItemInfo
    {
        public Texture2D Texture;
        public float points;
        public float speed;
        public int rows;
        public int cols;
        public bool isBacteria;
        public bool isUpgrade;
        public string upgradeString;
	}
}
