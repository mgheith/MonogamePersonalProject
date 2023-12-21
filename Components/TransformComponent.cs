using MonogamePersonalProject.Entities;
using MonogamePersonalProject.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MonogamePersonalProject.Components
{
    /// <summary>
    /// Component for IEntity Transform
    /// </summary>
    internal class TransformComponent : IComponent
    {
        /// <summary>
        /// Accessible Position Value
        /// </summary>
        public Vector2 Position { get; set; }

        /// <summary>
        /// Accessible Parent Entity
        /// </summary>
        public IEntity Parent { get; set; }

        /// <summary>
        /// Run on creation
        /// </summary>
        public void Start()
        {
            SystemsManager.Subscribe(this);
        }

        /// <summary>
        /// Clear out all subscriptions
        /// </summary>
        public void Stop()
        {
            SystemsManager.Unsubscribe(this);
        }

        /// <summary>
        /// Clear all references
        /// </summary>
        public void Clear()
        {
            Parent = null;
        }

        /// <summary>
        /// Execution of Transform (nothing to execute)
        /// </summary>
        public void Execute()
        {
            /* Nothing to run */
        }

        
    }
}
