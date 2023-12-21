using MonogamePersonalProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonogamePersonalProject.Components
{
    /// <summary>
    /// Component Interface. All Components must have a "Start" method, "Execute" method, and Parent entity
    /// </summary>
    internal interface IComponent
    {
        /// <summary>
        /// Parent Entity of component
        /// </summary>
        public IEntity Parent { get; }

        /// <summary>
        /// Method for Starting (different from initializing- used for connecting neighboring components and subscribing component)
        /// </summary>
        public void Start();

        /// <summary>
        /// Used primarily to halt Component instruction- Unsubscribe from System
        /// </summary>
        public void Stop();

        /// <summary>
        /// Used to clear any and all references
        /// </summary>
        public void Clear();

        /// <summary>
        /// Method for executing component.
        /// </summary>
        public void Execute();
    }
}
