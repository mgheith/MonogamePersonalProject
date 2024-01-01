using MonogamePersonalProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonogamePersonalProject.Tools;
using MonogamePersonalProject.Engine;
using System.Xml.Linq;
using System.IO;
using Microsoft.Xna.Framework.Content;
using MonogamePersonalProject.Data;

namespace MonogamePersonalProject.XML
{
    /// <summary>
    /// XMLParsers for all XML files. Put XML function for parsing
    /// </summary>
    internal static class XMLParser
    {
        /// <summary>
        /// Required Content Varaible for loading new Texture2Ds into the game
        /// </summary>
        public static Game1 Game1 { get; set; }

        /// <summary>
        /// Parses the subtree under an "Animation" node
        /// </summary>
        /// <param name="xml">The XML Reader currently at "Animation" node</param>
        /// <returns>a Rectangle[] of the Sprite source Rectangles</returns>
        public static Rectangle[] ParseAnimation(XElement xml)
        {
            List<Rectangle> rects = new List<Rectangle>();
            foreach(XElement element in xml.Elements("Sprite")) 
            {
                int x = (int)element.Attribute("x");
                int y = (int)element.Attribute("y");
                int width = (int)element.Attribute("width");
                int height = (int)element.Attribute("height");
                rects.Add(new Rectangle(x, y, width, height));
            }
            return rects.ToArray();
        }

        /// <summary>
        /// Parses a Character XML Tree, starting at the Character node
        /// </summary>
        /// <param name="xml">XmlReader currently at "Character"</param>
        /// <returns>Returns a Tuple of a Texture2D and a Dictionary of Rectangles</returns>
        public static (Texture2D, Dictionary<string, Rectangle[]>) ParseCharacter(string character)
        {
            /* Fix this eventually. This isn't good */
            string dir = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            XElement doc = XElement.Load(dir + "/XML/" + character + ".xml");

            Texture2D texture = TextureData.Textues[doc.Element("Texture").Attribute("texture").Value];
            Dictionary<string, Rectangle[]> animations = new Dictionary<string, Rectangle[]>();
            
            foreach (XElement element in doc.Element("SpriteSet").Elements("Animation").ToList()) 
            {
                animations.Add(element.Attribute("name").Value.ToString(), ParseAnimation(element));
            }
            return(texture, animations);
        }
    }
}
