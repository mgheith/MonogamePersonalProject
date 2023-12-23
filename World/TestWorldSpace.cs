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
            IEntity firstEntity = new BasicEntity("FirstEntity");
            firstEntity.AddComponent(typeof(TransformComponent));
            firstEntity.AddComponent(typeof(SpriteComponent));
            firstEntity.AddComponent(typeof(MoverComponent));
            firstEntity.AddComponent(typeof(EntityControllerComponent));
            Root.AddChild(firstEntity);
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
