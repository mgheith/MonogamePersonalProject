using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonogamePersonalProject.Tools
{
    internal class SpriteAnimation
    {
        Texture2D texture;
        Rectangle[] sprites;
        int frameRate;
        int index;
        int time = 0;
        int animSize = 1;

        /// <summary>
        /// SpriteAnimation containing the current frame of an animated sprite
        /// </summary>
        /// <param name="texture"></param>
        /// <param name="sprites"></param>
        /// <param name="frameRate"></param>
        public SpriteAnimation(Texture2D texture, Rectangle[] sprites, int frameRate) 
        {
            this.texture = texture;
            this.sprites = sprites;
            this.frameRate = 60/frameRate;
            animSize = sprites.Length;
        }

        /// <summary>
        /// Reset values. Useful for each new state.
        /// </summary>
        public void Restart()
        {
            index = 0;
            time = 0;
        }

        /// <summary>
        /// Update 
        /// </summary>
        public void Update()
        {
            time++;
            if(time > frameRate) 
            {
                index++;
                time = 0;
                if (index == animSize) 
                {
                    index = 0;
                }
            }
        }

        /// <summary>
        /// Returns the Texture2D and sourceRectangle of the currentSprite
        /// </summary>
        /// <returns></returns>
        public (Texture2D, Rectangle) ReturnSprite()
        {
            return (texture, sprites[index]);
        }
    }
}
