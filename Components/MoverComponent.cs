using MonogamePersonalProject.Entities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonogamePersonalProject.Components
{
    /// <summary>
    /// Component for a moving Entity
    /// </summary>
    internal class MoverComponent : GenericComponent
    {
        
        /// <summary>
        /// Neighboring Transform Component (required exists)
        /// </summary>
        TransformComponent TransformComponent { get; set; }

        /// <summary>
        /// Velocity set for Update
        /// </summary>
        Vector2 Velocity { get; set; }

        public MoverComponent(IEntity parent) : base(parent)
        {
            Parent = parent;
            TransformComponent = Parent.ComponentList.GetComponent(typeof(TransformComponent)) as TransformComponent;
            Velocity = Vector2.Zero;
        }

        public override void Clear()
        {
            TransformComponent = null;
            Parent = null;
        }

        /// <summary>
        /// Set velocity for execution
        /// </summary>
        /// <param name="velocity"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void Push(Vector2 velocity)
        {
            Velocity = velocity;
        }

        /// <summary>
        /// Immediately increment Position with velocity
        /// </summary>
        /// <param name="velocity"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void Move(Vector2 velocity)
        {
            TransformComponent.Position += velocity;
        }

        /// <summary>
        /// Increments TransformComponent with velocity. Sets Velocity back to zero
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public override void Execute()
        {
            Velocity = new Vector2(1, 0);
            TransformComponent.Position += Velocity;
            Velocity = Vector2.Zero;
        }

        
    }
}
