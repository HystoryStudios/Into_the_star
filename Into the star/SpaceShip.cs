using HOTTUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Net;
namespace Into_the_star
{
    public class SpaceShip
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public Vector3 Position { get; set; }
        public int ScanSize { get; set; }
        public float Carburant { get; set; }
        public Dictionary<string, int> Inventory { get; set; }
        public SpaceShip(string name, int iD, Vector3 position, int scansize)
        {
            Name = name;
            ID = iD;
            Position = position;
            ScanSize = scansize;
            Carburant = 100;
            Inventory = new Dictionary<string, int>();
        }

        public void Move(string input) 
        {
            float before = Carburant;
            string[] jsp = input.Split(" ");
            Vector3 pos = new Vector3(int.Parse(jsp[2]), int.Parse(jsp[3]), int.Parse(jsp[4]));
            Vector3 carburantusedvec = Position - pos;
            float carburantused = float.Abs((carburantusedvec.X + carburantusedvec.Y + carburantusedvec.Z) / 2);
            Carburant -= carburantused;
            if (Carburant > 0)
            {
                Position = pos;
                Console.WriteLine(Carburant);
                Tools.Loading_Bar(10, ConsoleColor.Magenta, (int) carburantused);
                Tools.Whrite.Color_Write(ConsoleColor.Green, $"\n[SpaceShip] Your new position is : {Position}\n");
            }
            else
            {
                Console.WriteLine("[SpaceShip] You don't have any Carburant for go to this position");
                Carburant = before;
            }

        }

        public void Charge(int size)
        {
            Inventory.TryGetValue("Uranium", out int value);
            Inventory.Remove("Uranium");
            Inventory.Add("Uranium", value - size);
            Carburant = size * 10;
        }
    }
}
