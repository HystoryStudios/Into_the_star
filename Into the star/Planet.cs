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
        public int Size;
        public Dictionary<Vector2, float> Chunk {  get; set; }

        public bool isLive {get; set;}
        public Planet(Vector3 position, string name, string type,int size, bool isLive)
        {
            Position = position;
            Name = name;
            Type = type;
            Size = size;
            this.isLive = isLive;
            Chunk = new();
        }
        public void Info()
        {
            Tools.Whrite.Color_Write(ConsoleColor.Yellow, $"Name : {Name}\n");
            Tools.Whrite.Color_Write(ConsoleColor.Yellow, $"Type : {Type}\n");
            Tools.Whrite.Color_Write(ConsoleColor.Yellow, $"Life : {isLive.ToString()}\n");
            Tools.Whrite.Color_Write(ConsoleColor.Yellow, $"Size : {Size.ToString()}\n");
        }
        public void Generate()
        {
            Random rd = new Random();
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    Chunk.Add(new Vector2(i, j), rd.Next(1, 4));
                }
            }
        }
    }
}
