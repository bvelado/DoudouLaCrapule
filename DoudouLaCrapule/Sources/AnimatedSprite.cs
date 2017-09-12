using System.Collections.Generic;
using DataLibrary;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DoudouLaCrapule.Sources
{
    class AnimatedSprite : Sprite
    {
        private Dictionary<string, Rectangle[]> animationFramesByName;
        private Animations animations;
        /// <summary>
        /// Duration in miliseconds between 2 frames
        /// </summary>
        private float timeBetweenFrames;

        private int currentIndex;
        private float currentTimer;
        private Rectangle[] currentFramesIndexes;

        public AnimatedSprite(Texture2D texture, Point position, Point size, Animations animations, Color tint) : base (texture, position, size, tint)
        {
            this.animations = animations;

            animationFramesByName = new Dictionary<string, Rectangle[]>();
            foreach (var animation in animations.AnimationsList)
            {
                animationFramesByName.Add(animation.Name, animation.Frames);
            }

            timeBetweenFrames = 1000f / animations.FramesPerSecond;
        }

        public void Play(string animationName)
        {
            if (animationFramesByName.ContainsKey(animationName))
            {
                currentIndex = 0;
                currentTimer = 0f;
                currentFramesIndexes = animationFramesByName[animationName];
            }
        }

        public void Update(GameTime gameTime)
        {
            if(currentTimer > timeBetweenFrames)
            {
                // Next frame index
                if (currentIndex + 1 < currentFramesIndexes.Length)
                    currentIndex++;
                else
                    currentIndex = 0;

                currentTimer -= timeBetweenFrames;
            }

            currentTimer += gameTime.ElapsedGameTime.Milliseconds;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(texture, destRect, )
        }
    }
}
