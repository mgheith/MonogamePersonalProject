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
        static Dictionary<Type, ISystem> ComponentSystemsDictionary = new Dictionary<Type, ISystem>()
        {
            { typeof(SpriteComponent), new SpriteSystem() },
            { typeof(TransformComponent), new TransformSystem()}
        };

        /// <summary>
        /// Count of all concurrent components
        ///     KeyValuePair = Type(ISystem), int
        /// </summary>
        static Dictionary<Type, int> ComponentCounts = new Dictionary<Type, int>();

        /// <summary>
        /// Subscribe component to proper system
        /// Update System Component Count
        /// If component not in ComponentCounts, add it
        /// </summary>
        /// <param name="component">Component to add</param>
        public static void Subscribe(IComponent component)
        {
            Type compType = component.GetType();
            Type sysType = ComponentSystemsDictionary[compType].GetType();
            if (!ComponentCounts.ContainsKey(sysType)) 
            {
                ComponentCounts.Add(sysType, 0);
            }
            ComponentCounts[sysType]++;
        }

        /// <summary>
        /// Unsubscribe component from proper system
        /// Update System Component Count
        /// If Count less than 1, remove it
        /// </summary>
        /// <param name="component">Component to remove</param>
        public static void Unsubscribe(IComponent component) 
        {
            Type compType = component.GetType();
            Type sysType = ComponentSystemsDictionary[compType].GetType();
            ComponentCounts[sysType]--;
            if (ComponentCounts[sysType] < 1)
            {
                ComponentCounts.Remove(sysType);
            }
        }

        /// <summary>
        /// Returns only the active Systems of the ECS
        /// </summary>
        /// <returns></returns>
        public static PriorityQueue<ISystem, int> ActiveSystems()
        {
            PriorityQueue<ISystem, int> activeSystemsPQ = new PriorityQueue<ISystem, int>();
            foreach(KeyValuePair<Type, int> type in ComponentCounts)
            {
                if(type.Value > 0)
                    activeSystemsPQ.Enqueue(ComponentSystemsDictionary[type.Key], ComponentSystemsDictionary[type.Key].Index);
            }
            return activeSystemsPQ;
        }
    }
}
