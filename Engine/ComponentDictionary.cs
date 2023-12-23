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
    internal class ComponentDictionary
    {
        /// <summary>
        /// The Component List itself
        /// </summary>
        Dictionary<Type, IComponent> componentDictionary = new Dictionary<Type, IComponent>();

        /// <summary>
        /// Parent list belongs to
        /// </summary>
        public IEntity Parent;

        /// <summary>
        /// Constructor for Component List
        /// </summary>
        /// <param name="entity">Entity ComponentList belongs to</param>
        public ComponentDictionary(IEntity entity)
        {
            Parent = entity;
        }

        /// <summary>
        /// Returns the current list of Components
        /// </summary>
        /// <returns> List<Components> active</returns>
        public List<IComponent> GetComponents()
        {
            return componentDictionary.Values.ToList();
        }

        /// <summary>
        /// Returns the fist component of the given component
        /// </summary>
        /// <param name="componentType"></param>
        /// <returns>Matching component</returns>
        public IComponent GetComponent(Type componentType) 
        {
            return componentDictionary[componentType];
        }

        /// <summary>
        /// Component Adder method
        /// If Component already exists, deny and complain to console
        /// </summary>
        /// <param name="component">IComponent to add</param>
        public void AddComponent(IComponent component)
        {
            if(!componentDictionary.ContainsKey(component.GetType()) )
            { 
                componentDictionary.Add(component.GetType(), component);
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
            componentDictionary.Remove(component.GetType());
        }

        /// <summary>
        /// Clears everything
        /// </summary>
        public void Destroy()
        {
            foreach(IComponent component in componentDictionary.Values) 
            {
                component.Clear();
            }
            componentDictionary.Clear();
            Parent = null;
        }


    }
}
