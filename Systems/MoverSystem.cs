using MonogamePersonalProject.Components;
using MonogamePersonalProject.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonogamePersonalProject.Systems
{
    internal class MoverSystem : ISystem
    {
        /// <summary>
        /// Fairly high priority
        /// </summary>
        public int Index { get { return 5; } }

        public List<IComponent> ComponentSubscribers { get; set; }

        public MoverSystem() 
        { 
            ComponentSubscribers = new List<IComponent>();
        }

        public void Update(GameEngine engine)
        {
            foreach (var component in ComponentSubscribers) 
            {
                component.Execute();
            }
        }
    }
}
