using FinalProject.Classes;
using FinalProject.Managers;

namespace FinalProject.Interfaces
{
    /// <summary>
    /// An interface used for levels
    /// </summary>
    public interface ILevel
    {
        public float Score { get; set; }
        public int Health { get; set; }
        public Collector Collector { get; set; }
        public CollisionManager CollisionManager { get; set; }
        public DropManager DropManager { get; set; }

        public void TakeDamage(int damage);

        public void Load();
        
    }
}
