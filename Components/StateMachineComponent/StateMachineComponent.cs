using MonogamePersonalProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MonogamePersonalProject.Components.StateMachineComponent
{
    /// <summary>
    /// Component for giving entity a state machine
    /// State Machine swaps between pre-defined states to define behavior, and switch states based on acceptable transitions
    /// </summary>
    internal class StateMachineComponent : GenericComponent
    {
        Dictionary<string, Action> TransitionConditions = new Dictionary<string, Action>();

        public StateMachineComponent(IEntity parent, string presetName = null) : base(parent)
        {
            Parent = parent;
            if(presetName != null) 
            {
                LoadStateMachinePreset(presetName);
            }
        }

        public void LoadStateMachinePreset(string presetName)
        {
           
        }
    }
}
