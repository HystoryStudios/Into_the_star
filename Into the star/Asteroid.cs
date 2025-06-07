using HOTTUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Into_the_star
{
    public class Asteroid
    {
        public string Name { get; set; }
        public Vector3 Position { get; set; }
        public Ore Ore {  get; set; }
        public int OreNumber { get; set; }
        public Asteroid(string name, Vector3 position,Ore ore)
        {
            Random random = new Random();
            Ore = ore;
            Name = name;
            Position = position;
            OreNumber = random.Next(1, 5);
        }

        public void Info()
        {
            Tools.Whrite.Color_Write(ConsoleColor.Yellow, $"Name : {Name}\n");
            Tools.Whrite.Color_Write(ConsoleColor.Yellow, $"Ore : {Ore.Name}\n");
        }
    }
}
