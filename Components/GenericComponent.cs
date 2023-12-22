using MonogamePersonalProject.Entities;
using MonogamePersonalProject.Systems;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonogamePersonalProject.Components
{
    internal abstract class GenericComponent : IComponent
    {
        public IEntity Parent {get; set;}

        public GenericComponent(IEntity parent)
        {
            Parent = parent;
        }

        public virtual void Clear()
        {

        }

        public virtual void Execute()
        {

        }

        public void Start()
        {
            SystemsManager.Subscribe(this);
        }

        public void Stop()
        {
            SystemsManager.Unsubscribe(this);
        }
    }
}
