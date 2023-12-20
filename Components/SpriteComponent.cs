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

namespace MonogamePersonalProject.Components
{
    /// <summary>
    /// Sprite Component
    /// </summary>
    internal class SpriteComponent : IComponent
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
        /// Position to draw from
        /// </summary>
        public Vector2 position;

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
        /// <param name="destinationRectangle"></param>
        public SpriteComponent(IEntity parent, SpriteBatch spriteBatch, Texture2D texture = null, Rectangle destinationRectangle = new Rectangle() ) 
        {
            this.parent = parent;
            this.spriteBatch = spriteBatch;
            if( texture == null )
            {
                texture = new Texture2D(Globals.graphicsDevice, 16, 16);
            }
        }

        /// <summary>
        /// This will be called on GameStart
        /// </summary>
        public void Start()
        {
            /* Add Component to the System it belongs to */
            SystemsManager.Subscribe(this);
        }

        /// <summary>
        /// Run the Component
        /// </summary>
        public void Execute()
        {
            spriteBatch.Draw(texture, position, sourceRectangle, Color.White);
        }
    }
}
