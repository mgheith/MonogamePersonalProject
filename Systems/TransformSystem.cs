using MonogamePersonalProject.Components;
using MonogamePersonalProject.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonogamePersonalProject.Systems
{
    /// <summary>
    /// System for object Transforms
    /// </summary>
    internal class TransformSystem : ISystem
    {
        /// <summary>
        /// Index for System (high priority)
        /// </summary>
        public int index = 1;
        public int Index { get { return index; } }

        /// <summary>
        /// List of components subscribed to System
        /// </summary>
        public List<IComponent> ComponentSubscribers { get { return new List<IComponent>(); } }

        /// <summary>
        /// Update all Transforms (not updates necessary)
        /// </summary>
        /// <param name="engine"></param>
        public void Update(GameEngine engine)
        {
            /*
             * foreach(IComponent component in ComponentSubscribers)
             * {
             *     component.Execute();
             * }
             * 
             * Uncomment if you add a function to Transform
            */
        }
    }
}
