using MonogamePersonalProject.Components;
using MonogamePersonalProject.Engine;
using MonogamePersonalProject.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MonogamePersonalProject.Entities
{
    internal class BasicEntity : IEntity
    {
        public string ID { get; set; }

        public ComponentDictionary ComponentList { get; set; }

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
            ComponentList = new ComponentDictionary(this);
        }

        public void AddChild(IEntity entity)
        {
            Children.Add(entity);
        }

        public void AddComponent(IComponent component)
        {
            ComponentList.AddComponent(component);
        }

        /// <summary>
        /// Generates new component based on type and adds to IEntity parent (this)
        /// </summary>
        /// <param name="type">Type of IComponent</param>
        public void AddComponent(Type type)
        {
            /* Get component Constructor */
            ConstructorInfo[] info = type.GetConstructors();

            /* Set up parameters */
            var paramteres = info[0].GetParameters();
            object[] args = new object[paramteres.Length];

            /* Set first parameter to Parent entity */
            args[0] = this;

            /* Incase of default parameters, just set the rest to null */
            for (int i = 1; i < paramteres.Length; i++) 
            {
                args[i] = null;
            }
            
            /* Invoke, create, and add! */
            IComponent newComponent = info[0].Invoke(args) as IComponent;
            ComponentList.AddComponent(newComponent);
        }

        public void RemoveChild(IEntity entity)
        {
            Children.Remove(entity);
        }

        public void RemoveComponent(IComponent component)
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

        /// <summary>
        /// Deconstructor
        /// </summary>
        ~BasicEntity() 
        {
            Destroy();
        }
    }
}
