using MonogamePersonalProject.Commands;
using MonogamePersonalProject.Components;
using MonogamePersonalProject.Engine;
using MonogamePersonalProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonogamePersonalProject.World
{
    internal class TestWorldSpace : IWorldSpace
    {
        public TestWorldSpace(GameEngine engine) 
        {
            Root = new BasicEntity("Root", null, null);
        }

        public IEntity Root {get; set;}

        public void AddEntity(IEntity entity)
        {
            Root.AddChild(entity);
        }

        public void RemoveEntity(IEntity entity)
        {
            Root.RemoveChild(entity);
        }

        public void EndWorld()
        {
            Root.Destroy();
            Root = null;
        }
    }
}
