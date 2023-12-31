﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using MonogamePersonalProject.Components;
using MonogamePersonalProject.Engine;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonogamePersonalProject.Entities
{
    /// <summary>
    /// Interface for Entities to follow ECS
    /// </summary>
    internal interface IEntity
    {
        /// <summary>
        /// Public ID string
        /// </summary>
        public string ID { get; }

        /// <summary>
        /// Public list of components
        /// </summary>
        public ComponentDictionary ComponentList { get; }

        /// <summary>
        /// Parent Entity (if one exists)
        /// </summary>
        public IEntity Parent { get; set; }

        /// <summary>
        /// List of IEntity children
        /// </summary>
        public List<IEntity> Children { get; }

        /// <summary>
        /// Add Child IEntity
        /// </summary>
        /// <param name="entity">Entity to add</param>
        public void AddChild(IEntity entity);

        /// <summary>
        /// Remove Child IEntity
        /// </summary>
        /// <param name="entity">Entity to remove</param>
        public void RemoveChild(IEntity entity);

        /// <summary>
        /// Add component to Entity
        /// </summary>
        /// <param name="component">Component to add</param>
        public void AddComponent(IComponent component);

        /// <summary>
        /// Add new component of Type
        /// </summary>
        /// <param name="componentType">Type of Component</param>
        public void AddComponent(Type componentType);

        /// <summary>
        /// Remove component from Entity
        /// </summary>
        /// <param name="component">Component to remove</param>
        public void RemoveComponent(IComponent component);

        /// <summary>
        /// Destroy GameObject, its children, and its components
        /// </summary>
        public void Destroy();

    }
}
