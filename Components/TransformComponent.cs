using MonogamePersonalProject.Entities;
using Microsoft.Xna.Framework;
using MonogamePersonalProject.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonogamePersonalProject.Components
{
    /// <summary>
    /// Component for IEntity Transform
    /// </summary>
    internal class TransformComponent : GenericComponent
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="parent">Parent Entity</param>
        public TransformComponent(IEntity parent) : base(parent)
        {
            Parent = parent;
        }

        /// <summary>
        /// Accessible Position Value
        /// </summary>
        public Vector2 Position { get; set; }


        /// <summary>
        /// Clear all references
        /// </summary>
        public override void Clear()
        {
            Parent = null;
        }

        
    }
}
