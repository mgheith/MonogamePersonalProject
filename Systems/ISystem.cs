using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonogamePersonalProject.Components;
using System;
using System.Collections.Generic;
using MonogamePersonalProject.Engine;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonogamePersonalProject.Systems
{
    /// <summary>
    /// Interface for any system of ECS.
    /// All systems must have:
    ///     1: "Update" method (Method for exeucting all belonging Components)
    ///     2: "Index" Int (Order in list of sytems for game to update)
    /// </summary>
    internal interface ISystem
    {
        /// <summary>
        /// Order in list of systems to update (IE- Collisions checks done before Sprite rendering)
        /// </summary>
        int Index { get; }

        /// <summary>
        /// 
        /// </summary>
        public List<IComponent> ComponentSubscribers { get; }

        /// <summary>
        /// Execute all components of system
        /// </summary>
        /// <param name="engine">The GameEngine class running the ISystem</param>
        public void Update(GameEngine engine);
    }
}
