using MonogamePersonalProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonogamePersonalProject.World
{
    /// <summary>
    /// Interface for "WorldSpace" object. 
    /// World space is where lists of Entities shall be instantiated. Components shall only interact with the components within the same world space. 
    /// </summary>
    internal interface IWorldSpace
    {
        /// <summary>
        /// Root IEntity. 
        /// </summary>
        public IEntity Root { get; }

        /// <summary>
        /// Adds entity to the world space root
        /// </summary>
        /// <param name="entity">IEntity to add</param>
        public void AddEntity(IEntity entity);

        /// <summary>
        /// Removes Entitiy from world space root
        /// </summary>
        /// <param name="entity"></param>
        public void RemoveEntity(IEntity entity);

        /// <summary>
        /// Used to clear all objects and their components
        /// </summary>
        public void EndWorld();
    }
}
