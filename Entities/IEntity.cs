using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using MonogamePersonalProject.Components;
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
        public List<IComponent> components { get; }

        public void AddCompnent()

    }
}
