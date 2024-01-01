using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using MonogamePersonalProject.Commands;
using MonogamePersonalProject.Components;
using MonogamePersonalProject.Engine;
using MonogamePersonalProject.Entities;
using MonogamePersonalProject.XML;
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
            BasicEntity testObject = new BasicEntity("Test Object");
            testObject.AddComponent(typeof(TransformComponent));
            testObject.AddComponent(typeof(SpriteRendererComponent));
            testObject.AddComponent(typeof(SpriteAnimatorComponent));
            testObject.AddComponent(typeof(MoverComponent));
            testObject.AddComponent(typeof(EntityControllerComponent));
            SpriteAnimatorComponent testComponent = testObject.ComponentList.GetComponent(typeof(SpriteAnimatorComponent)) as SpriteAnimatorComponent;
            testComponent.LoadAnimations("Zelda");
            testComponent.SetSprite("walkingNorth");
            Root.AddChild(testObject);
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
