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
    internal class ComponentList : List<IComponent>
    {
        /// <summary>
        /// The Component List itself
        /// </summary>
        List<IComponent> componentList;
        
        IEntity entity;

        /// <summary>
        /// Constructor for Component List
        /// </summary>
        /// <param name="entity">Entity ComponentList belongs to</param>
        public ComponentList(IEntity entity)
        {
            this.entity = entity;
            componentList = new List<IComponent>();
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
    }
}
