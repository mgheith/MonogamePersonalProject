using Microsoft.Xna.Framework;
using MonogamePersonalProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonogamePersonalProject.Components
{
    internal class AnimatorComponent : GenericComponent
    {

        public AnimatorComponent(IEntity parent) : base(parent)
        {
            Parent = parent;
        }
    }
}
