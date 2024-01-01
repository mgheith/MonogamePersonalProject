using MonogamePersonalProject.Components;
using MonogamePersonalProject.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonogamePersonalProject.Systems
{
    internal class SpriteAnimatorSystem : ISystem
    {
        public int Index { get { return 9; } }

        public List<IComponent> ComponentSubscribers { get { return _components; } } 
        private List<IComponent> _components = new List<IComponent>();

        public void Update(GameEngine engine)
        {
            foreach (var component in ComponentSubscribers) 
            {
                component.Execute();
            }
        }
    }
}
