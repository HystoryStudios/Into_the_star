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
        List<int[,]> Contenue;
        public bool isLive {get; set;}
        public Planet(Vector3 position, string name, string type, bool isLive)
        {
            Position = position;
            Name = name;
            Type = type;
            this.isLive = isLive;
            Contenue = new List<int[,]>();
        }
        public void Info()
        {
            Tools.Whrite.Color_Write(ConsoleColor.Yellow, $"Name : {Name}\n");
            Tools.Whrite.Color_Write(ConsoleColor.Yellow, $"Type : {Type}\n");
            Tools.Whrite.Color_Write(ConsoleColor.Yellow, $"Life : {isLive.ToString()}\n");
        }
        public void Generate()
        {

        }
    }
}
