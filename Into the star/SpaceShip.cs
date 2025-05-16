using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Into_the_star
{
    public class SpaceShip
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public Vector3 Position { get; set; }
        public int ScanSize { get; set; }
        public SpaceShip(string name, int iD, Vector3 position, int scansize)
        {
            Name = name;
            ID = iD;
            Position = position;
            ScanSize = scansize;
        }

        public void Move(string input) 
        {
            string[] pos = input.Split(" ");
            Position = new Vector3(int.Parse(pos[2]), int.Parse(pos[3]), int.Parse(pos[4]));
        }
    }
}
