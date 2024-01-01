using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonogamePersonalProject.Components.StateMachineComponent
{
    internal interface ICharacterStateComponent : IComponent
    {
        /// <summary>
        /// The machine this component manages
        /// </summary>
        StateMachineComponent Manager { get; }

        public void LoadComponents();
    }
}
