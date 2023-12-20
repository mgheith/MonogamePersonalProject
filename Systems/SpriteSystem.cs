using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonogamePersonalProject.Components;
using MonogamePersonalProject.Engine;
using MonogamePersonalProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonogamePersonalProject.Systems
{
    internal class SpriteSystem : ISystem
    {
        /// <summary>
        /// Update order of system
        /// </summary>
        private int index = 10;

        /// <summary>
        /// Index for order of admittance
        /// </summary>
        public int Index { get { return index; } }

        public List<IComponent> ComponentSubscribers { get; private set; }


        /// <summary>
        /// Update all Sprites
        /// </summary>
        public void Update(GameEngine engine)
        {
            foreach (var component in ComponentSubscribers) 
            {
                component.Execute();
            }
        }
    }
}
