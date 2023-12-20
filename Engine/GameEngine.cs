using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonogamePersonalProject.Components;
using MonogamePersonalProject.Systems;

namespace MonogamePersonalProject.Engine
{
    /// <summary>
    /// An Engine for the ECS. Game demands 
    /// </summary>
    internal class GameEngine
    {

        PriorityQueue<ISystem, int> currentSystemList = new PriorityQueue<ISystem, int>();

        
        
        /// <summary>
        /// GDM for all components to access
        /// </summary>
        public readonly GraphicsDeviceManager graphicsDeviceManager;

        /// <summary>
        /// SpriteBatch for all components to access
        /// </summary>
        public readonly SpriteBatch spriteBatch;

        /// <summary>
        /// Constructor for the base engine. Used to get needed values from Game1
        /// </summary>
        /// <param name="game">Game1 this comes from</param>
        public GameEngine(Game1 game) 
        {
            graphicsDeviceManager = game._graphics;
            spriteBatch = game.SpriteBatch;
        }


        public void AddSystem(IComponent component)
        {

        }

        public void RemoveSystem(IComponent component) 
        {
            
        }

        /// <summary>
        /// Iterate over all systems in currentSystemList. 
        /// </summary>
        public void Run()
        {
            PriorityQueue<ISystem, int> nextQueue = new PriorityQueue<ISystem, int>();
            while (currentSystemList.Count > 0)
            {
                currentSystemList.Peek().Update(this);
                (ISystem, int) next;
                currentSystemList.TryDequeue(out next.Item1, out next.Item2);
                nextQueue.Enqueue(next.Item1, next.Item2);
            }
            currentSystemList = nextQueue;
        }

    }
}
