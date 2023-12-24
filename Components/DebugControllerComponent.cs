using Microsoft.Xna.Framework.Input;
using MonogamePersonalProject.Commands;
using MonogamePersonalProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MonogamePersonalProject.Components
{
    internal class DebugControllerComponent : GenericComponent
    {

        SpawnEntityCommand spawnEntityCommand;

        public DebugControllerComponent(IEntity parent) : base(parent)
        {
            Parent = parent;
            spawnEntityCommand = new SpawnEntityCommand(Parent);
        }

        public override void Execute()
        {
            if(Keyboard.GetState
                ().IsKeyDown(Keys.E)) 
            {
                spawnEntityCommand.Execute();
            }
        }
    }
}
