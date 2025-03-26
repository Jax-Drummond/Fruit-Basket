using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace FinalProject.Managers
{
    /// <summary>
    /// Used for managing sounds
    /// </summary>
    public class SoundManager : GameComponent
    {
        const string PREFIX = "SFX/";

		public SoundManager(Game game) : base(game)
        {
        }

        /// <summary>
        /// Used to play a sound
        /// </summary>
        /// <param name="soundName">The sound to play</param>
        public void PlaySound(string soundName)
        {
            string soundNameWithPrefix = PREFIX + soundName;
            SoundEffectInstance newSoundEffect = Game.Content.Load<SoundEffect>(soundNameWithPrefix).CreateInstance();
            newSoundEffect.Play();
        }

        /// <summary>
        /// Used to play music
        /// </summary>
        /// <param name="musicName">The music to play</param>
        public void PlayMusic(string musicName)
        {
            string musicNameWithPrefix = PREFIX + musicName;
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(Game.Content.Load<Song>(musicNameWithPrefix));
        }

        public void SetVolume(float volume)
        {
            MediaPlayer.Volume = volume;
        }

	}
}
