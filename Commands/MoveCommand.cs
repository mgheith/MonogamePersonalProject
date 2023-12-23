using MonogamePersonalProject.Components;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonogamePersonalProject.Commands
{
    /// <summary>
    /// Basic Movement command
    /// </summary>
    internal class MoveCommand : ICommand
    {
        Vector2 Velocity;
        MoverComponent MoverComponent;

        public MoveCommand(MoverComponent component, Vector2 velocity) 
        {
            MoverComponent = component;
            Velocity = velocity;
        }

        public void Execute() 
        {
            MoverComponent.Move(Velocity);
        }
    }
}
