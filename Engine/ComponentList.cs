using MonogamePersonalProject.Entities;
using System;
using System.Collections.Generic;
using MonogamePersonalProject.Components;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonogamePersonalProject.Engine
{
    /// <summary>
    /// Component List extension of List object for ease of use (denying duplicate Component types, 
    /// </summary>
    internal class ComponentList
    {
        /// <summary>
        /// The Component List itself
        /// </summary>
        List<IComponent> componentList;

        /// <summary>
        /// Parent list belongs to
        /// </summary>
        public IEntity Parent;

        /// <summary>
        /// Constructor for Component List
        /// </summary>
        /// <param name="entity">Entity ComponentList belongs to</param>
        public ComponentList(IEntity entity)
        {
            Parent = entity;
            componentList = new List<IComponent>();
        }

        /// <summary>
        /// Returns the current list of Components
        /// </summary>
        /// <returns> List<Components> active</returns>
        public List<IComponent> GetComponents()
        {
            return componentList;
        }

        /// <summary>
        /// Returns the fist component of the given component
        /// </summary>
        /// <param name="componentType"></param>
        /// <returns>Matching component</returns>
        public IComponent GetComponent(Type componentType) 
        {
            return componentList.FirstOrDefault(a => a.GetType() == componentType);
        }

        /// <summary>
        /// Component Adder method
        /// If Component already exists, deny and complain to console
        /// </summary>
        /// <param name="component">IComponent to add</param>
        public void AddComponent(IComponent component)
        {
            if(!componentList.Contains(component)) 
            { 
                componentList.Add(component);
                component.Start();
            }
        }

        /// <summary>
        /// Component remove method
        /// If component does not exist, complain
        /// </summary>
        /// <param name="component"></param>
        public void RemoveComponent(IComponent component)
        { 
            componentList.Remove(component);
        }

        /// <summary>
        /// Clears everything
        /// </summary>
        public void Destroy()
        {
            while(componentList.Count > 0) 
            {
                componentList[0].Clear();
                componentList.RemoveAt(0);
            }
            Parent = null;
        }


    }
}
