using HOTTGF;
using HOTTUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Into_the_star
{
    public class Planet
    {
        public Vector3 Position;
        public string Name;
        public string Type;
        public int[,] Chunk;
        public Dictionary<int, TileMap> Content;
        public bool isLive {get; set;}
        public Planet(Vector3 position, string name, string type, bool isLive)
        {
            Position = position;
            Name = name;
            Type = type;
            this.isLive = isLive;
            Content = new Dictionary<int,TileMap>();
        }
        public void Info()
        {
            Tools.Whrite.Color_Write(ConsoleColor.Yellow, $"Name : {Name}\n");
            Tools.Whrite.Color_Write(ConsoleColor.Yellow, $"Type : {Type}\n");
            Tools.Whrite.Color_Write(ConsoleColor.Yellow, $"Life : {isLive.ToString()}\n");
        }
        private char[,] Generate(Vector2 ScreenSize)
        {
            char[,] content = null;

            for (int y = 0; y > ScreenSize.Y; y++)
            {
                for (int x = 0; x > ScreenSize.X; x++)
                {
                    content[x, y] = '.';
                }
            }
            return content;
        }
    }
}
