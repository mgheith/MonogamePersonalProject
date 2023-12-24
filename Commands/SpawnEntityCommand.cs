using MonogamePersonalProject.Components;
using MonogamePersonalProject.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonogamePersonalProject.Commands
{
    internal class SpawnEntityCommand : ICommand
    {
        IEntity Parent;

        public SpawnEntityCommand(IEntity parent)
        {
            Parent = parent;
        }

        public void Execute()
        {
            IEntity newEntity = new BasicEntity("NewEntity");
            newEntity.AddComponent(typeof(TransformComponent));
            newEntity.AddComponent(typeof(SpriteComponent));
            newEntity.AddComponent(typeof(MoverComponent));
            newEntity.AddComponent(typeof(EntityControllerComponent));
            Parent.AddChild(newEntity);
        }
    }
}
