using MonogamePersonalProject.Components;
using MonogamePersonalProject.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonogamePersonalProject.Entities
{
    internal class BasicEntity : IEntity
    {
        public string ID { get; set; }

        public ComponentList ComponentList { get; set; }

        public IEntity Parent { get; set; }

        public List<IEntity> Children { get; set; }

        public BasicEntity(string id, IEntity parent = null, List<IEntity> children = null) 
        {
            ID = id;
            if(parent != null) 
            {
                Parent = parent;
            }
            if(children != null)
            {
                Children = children;
            }
            else
            {
                Children = new List<IEntity>();
            }
            ComponentList = new ComponentList(this);
        }

        public void AddChild(IEntity entity)
        {
            Children.Add(entity);
        }

        public void AddCompnent(IComponent component)
        {
            ComponentList.AddComponent(component);
        }

        public void RemoveChild(IEntity entity)
        {
            Children.Remove(entity);
        }

        public void RemoveCompnent(IComponent component)
        {
            ComponentList.RemoveComponent(component);
        }

        public void Destroy()
        {
            foreach(IEntity child in Children) 
            {
                child.Destroy();
            }
            ComponentList.Destroy();
        }
    }
}
