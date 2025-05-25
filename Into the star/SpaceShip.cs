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
        public float Carburant { get; set; }
        public SpaceShip(string name, int iD, Vector3 position, int scansize)
        {
            Name = name;
            ID = iD;
            Position = position;
            ScanSize = scansize;
            Carburant = 100.0f;
        }

        public void Move(string input) 
        {
            string[] jsp = input.Split(" ");
            Vector3 pos = new Vector3(int.Parse(jsp[2]), int.Parse(jsp[3]), int.Parse(jsp[4]));
            Vector3 carburantusedvec = Position - pos;
            float carburantused = (carburantusedvec.X + carburantusedvec.Y + carburantusedvec.Z) / 2;

            Carburant -= carburantused;
            if (Carburant > 0)
            {
                Position = pos;
                Console.WriteLine(Carburant);
            }
            else
            {
                Console.WriteLine("[SpaceShip] You don't have any Carburant for go to this position");
            }

        }
    }
}
