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
using MonogamePersonalProject.World;

namespace MonogamePersonalProject.Engine
{
    /// <summary>
    /// An Engine for the ECS
    /// </summary>
    internal class GameEngine
    {   
        /// <summary>
        /// GDM for all components to access
        /// </summary>
        public GraphicsDeviceManager graphicsDeviceManager { get { return game._graphics; } }

        /// <summary>
        /// SpriteBatch for all components to access
        /// </summary>
        public SpriteBatch spriteBatch { get { return game.SpriteBatch; } }

        private Game1 game;

        private IWorldSpace currentWorld;

        /// <summary>
        /// Constructor for the base engine. Used to get needed values from Game1
        /// </summary>
        /// <param name="game">Game1 this comes from</param>
        public GameEngine(Game1 game) 
        {
            this.game = game;
        }

        /// <summary>
        /// Set the currentWorld IWorldSpace for running
        /// </summary>
        /// <param name="worldSpace"></param>
        public void LoadWorldSpace(IWorldSpace worldSpace) 
        {
            currentWorld = worldSpace;
        }

        public void UnloadCurrentWorldSpace()
        {
            currentWorld.EndWorld();
        }

        /// <summary>
        /// Iterate over all systems in currentSystemList. 
        /// </summary>
        public void Run()
        {
            /* Request PQ of active systems from SystemsManager */
            PriorityQueue<ISystem, int> activeSystems = SystemsManager.ActiveSystems();

            /* Iterate over each system
               Each system told to update */
            while (activeSystems.Count > 0)
            {
                activeSystems.Peek().Update(this);
                activeSystems.Dequeue();
            }
        }

    }
}
