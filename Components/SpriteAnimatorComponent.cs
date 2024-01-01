using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonogamePersonalProject.Entities;
using MonogamePersonalProject.Tools;
using MonogamePersonalProject.XML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MonogamePersonalProject.Components
{
    internal class SpriteAnimatorComponent : GenericComponent
    {
        SpriteRendererComponent SpriteRendererComponent { get; set; }
        Dictionary<string, SpriteAnimation> spriteAnimations = new Dictionary<string, SpriteAnimation>();
        string currentSprite;

        /// <summary>
        /// Constructor for developing 
        /// </summary>
        /// <param name="parent"></param>
        public SpriteAnimatorComponent(IEntity parent) : base(parent)
        {
            Parent = parent;
            SpriteRendererComponent = Parent.ComponentList.GetComponent(typeof(SpriteRendererComponent)) as SpriteRendererComponent;
        }

        /// <summary>
        /// Attempt SpriteSet load from XMLParser
        /// </summary>
        /// <param name="SetName"></param>
        public void LoadAnimations(string SetName)
        {
            (Texture2D, Dictionary<string, Rectangle[]>) SpriteSet = XMLParser.ParseCharacter(SetName);
            foreach(KeyValuePair<string, Rectangle[]> animation in SpriteSet.Item2)
            {
                spriteAnimations.Add(animation.Key, new SpriteAnimation(SpriteSet.Item1, animation.Value, 5));
            }
        }

        public void SetSprite(string key)
        {
            if(spriteAnimations.ContainsKey(key))
            {
                currentSprite = key;
            }
        }

        /// <summary>
        /// On update, increment current animation
        /// </summary>
        public override void Execute()
        {
            spriteAnimations[currentSprite].Update();
            (Texture2D, Rectangle) frame = spriteAnimations[currentSprite].ReturnSprite();
            SpriteRendererComponent.SetSprite(frame.Item1, frame.Item2);
        }
    }
}
