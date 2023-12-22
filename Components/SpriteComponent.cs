using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using MonogamePersonalProject.Engine;
using MonogamePersonalProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonogamePersonalProject.Systems;
using System.Xml.Serialization;
using System.Runtime.CompilerServices;

namespace MonogamePersonalProject.Components
{
    /// <summary>
    /// Sprite Component
    /// </summary>
    internal class SpriteComponent : GenericComponent
    {
        /// <summary>
        /// Parent Entity
        /// </summary>
        public IEntity Parent { get { return parent; } }
        IEntity parent;

        /// <summary>
        /// Personal private pointer to game SpriteBatch
        /// </summary>
        private SpriteBatch spriteBatch;

        /// <summary>
        /// Sprite to change/update
        /// </summary>
        public Texture2D texture;

        /// <summary>
        /// TransformComponent to pass Position off of
        /// </summary>
        public TransformComponent transform;

        /// <summary>
        /// Rectangle Source
        /// </summary>
        public Rectangle sourceRectangle;
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="spriteBatch"></param>
        /// <param name="texture"></param>
        /// <param name="sourceRectangle"></param>
        public SpriteComponent(IEntity parent, Texture2D texture = null, Rectangle sourceRectangle = new Rectangle() ) : base(parent)
        {
            this.parent = parent;
            this.spriteBatch = Globals.spriteBatch;
            if( texture == null )
            {
                this.texture = new Texture2D(Globals.graphicsDevice, 8, 8);
                this.texture.SetData(MakeDefaultSprite(8, 8));
            }
            if ( sourceRectangle.IsEmpty ) 
            {
                this.sourceRectangle = new Rectangle(0, 0, 8, 8);
            }
            transform = Parent.ComponentList.GetComponent(typeof(TransformComponent)) as TransformComponent;
        }

        #region
        /// <summary>
        /// Makes a default checkerboard pattern
        /// </summary>
        /// <param name="width">Width of board</param>
        /// <param name="height">Height of board</param>
        /// <returns></returns>
        private Color[] MakeDefaultSprite(int width, int height, int size = 2)
        {
            Color[] Checkboard = new Color[width * height];
            Color paint = Color.White;

            for (int pixel = 0; pixel < Checkboard.Count(); pixel++)
            {
                if(pixel % 2 == 0)
                {
                    Checkboard[pixel] = Color.White;
                }
                else
                {
                    Checkboard[pixel] = Color.Yellow;
                }
            }
            return Checkboard;
        }
        #endregion


        /// <summary>
        /// Clear all references
        /// </summary>
        public override void Clear()
        {
            parent = null;
            spriteBatch = null;
            texture = null;
        }

        /// <summary>
        /// Run the Component
        /// </summary>
        public override void Execute()
        {
            spriteBatch.Draw(texture, transform.Position, sourceRectangle, Color.White);
        }
    }
}
