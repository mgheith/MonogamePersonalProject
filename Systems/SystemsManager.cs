using MonogamePersonalProject.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace MonogamePersonalProject.Systems
{
    /// <summary>
    /// System Manager for all Systems
    /// </summary>
    internal static class SystemsManager
    {
        /// <summary>
        /// Initialized Dictionary of Systems
        /// </summary>
        static Dictionary<Type, ISystem> SystemsDictionary = new Dictionary<Type, ISystem>()
        {
            { typeof(SpriteComponent), new SpriteSystem() },
            { typeof(TransformComponent), new TransformSystem()}
        };

        static Dictionary<Type, int> ComponentCounts = new Dictionary<Type, int>()
        {
            {typeof(SpriteSystem), 0},
            {typeof(TransformSystem), 0}
        };

        /// <summary>
        /// Subscribe component to proper syste
        /// </summary>
        /// <param name="component">Component to add</param>
        public static void Subscribe(IComponent component)
        {
            SystemsDictionary[component.GetType()].ComponentSubscribers.Add(component);
            ComponentCounts[component.GetType()]++; 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="component">Component to remove</param>
        public static void Unsubscribe(IComponent component) 
        {
            SystemsDictionary[component.GetType()].ComponentSubscribers.Remove(component);
            ComponentCounts[component.GetType()]++;
        }

        public PriorityQueue<ISystem, int> ActiveSystems()
        {
            PriorityQueue<ISystem, int> priorityQueue = new PriorityQueue<ISystem, int>();
            foreach()
            return 
        }
    }
}
