using MonogamePersonalProject.Components;
using MonogamePersonalProject.Entities;
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
    ///     Keeps dictionary of all Component-System pairs
    ///     Keeps another dictionary of all active Component counts
    ///     Only returns list of components with i > 0 components
    /// </summary>
    internal static class SystemsManager
    {
        /// <summary>
        /// Initialized Dictionary of Systems
        /// </summary>
        static Dictionary<Type, ISystem> ComponentSystemsDictionary = new Dictionary<Type, ISystem>()
        {
            { typeof(SpriteRendererComponent), new SpriteRenderedSystem() },
            { typeof(SpriteAnimatorComponent), new SpriteAnimatorSystem() },
            { typeof(TransformComponent), new TransformSystem()},
            { typeof(MoverComponent), new MoverSystem() },
            { typeof(EntityControllerComponent), new EntityControllerSystem() },
            { typeof(DebugControllerComponent), new EntityControllerSystem() }
        };

        /// <summary>
        /// Count of all concurrent components
        ///     KeyValuePair = Type(ISystem), int
        /// </summary>
        static Dictionary<Type, int> SystemComponentCounts = new Dictionary<Type, int>();

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

            /* Add component to System Subscribers */
            ComponentSystemsDictionary[compType].ComponentSubscribers.Add(component);

            /* Update SystemComponentCounts */
            if (!SystemComponentCounts.ContainsKey(sysType)) 
            {
                SystemComponentCounts.Add(sysType, 0);
            }
            SystemComponentCounts[sysType]++;
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
            SystemComponentCounts[sysType]--;
            if (SystemComponentCounts[sysType] < 1)
            {
                SystemComponentCounts.Remove(sysType);
            }
        }

        /// <summary>
        /// Returns only the active Systems of the ECS
        /// </summary>
        /// <returns></returns>
        public static PriorityQueue<ISystem, int> ActiveSystems()
        {
            PriorityQueue<ISystem, int> activeSystemsPQ = new PriorityQueue<ISystem, int>();
            foreach(KeyValuePair<Type, ISystem> type in ComponentSystemsDictionary)
            {
                if (SystemComponentCounts.ContainsKey(type.Value.GetType()))
                    activeSystemsPQ.Enqueue(type.Value, type.Value.Index);
            }
            return activeSystemsPQ;
        }
    }
}
