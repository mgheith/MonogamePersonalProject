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
    /// System for Controller Components
    /// </summary>
    internal class EntityControllerSystem : ISystem
    {
        /// <summary>
        /// Highest priority (first thing to check- button pressed)
        /// </summary>
        public int Index { get { return 0; } }

        public List<IComponent> ComponentSubscribers {get; set; }

        /// <summary>
        /// Contructor, Initiliaze subscribers 
        /// </summary>
        public EntityControllerSystem() 
        {
            ComponentSubscribers = new List<IComponent>();
        }

        /// <summary>
        /// Update every single Controller
        /// </summary>
        /// <param name="engine"></param>
        public void Update(GameEngine engine)
        {
            foreach(var component in ComponentSubscribers) 
            {
                component.Execute();
            }
        }
    }
}
