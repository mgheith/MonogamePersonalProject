using Microsoft.Xna.Framework.Input;
using MonogamePersonalProject.Entities;
using MonogamePersonalProject.Commands;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonogamePersonalProject.Components
{
    internal class EntityControllerComponent : GenericComponent
    {
        MoverComponent moverComponent;
        Dictionary<Keys, ICommand> keyboardMap = new Dictionary<Keys, ICommand>();
        public EntityControllerComponent(IEntity parent) : base(parent)
        {
            Parent = parent;
            moverComponent = parent.ComponentList.GetComponent(typeof(MoverComponent)) as MoverComponent;
            keyboardMap.Add(Keys.W, new MoveCommand(moverComponent, new Vector2(0, -1)));
            keyboardMap.Add(Keys.S, new MoveCommand(moverComponent, new Vector2(0, 1)));
            keyboardMap.Add(Keys.D, new MoveCommand(moverComponent, new Vector2(1, 0)));
            keyboardMap.Add(Keys.A, new MoveCommand(moverComponent, new Vector2(-1, 0)));

        }

        public override void Execute()
        {
            foreach(Keys key in Keyboard.GetState().GetPressedKeys()) 
            {
                if(keyboardMap.ContainsKey(key))
                    keyboardMap[key].Execute();
            }
        }
    }
}
