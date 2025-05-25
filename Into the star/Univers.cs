using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Security.AccessControl;

namespace Into_the_star
{
    public class Univers
    {
        public List<Planet> Planets { get; set; }
        private List<string> Types { get; set; }

        public Univers() 
        { 
            Planets = new List<Planet>();
            Types = new List<string>();
            Types.Add("Gazeuse");
            Types.Add("Radioactive");
            Types.Add("Paradise");
            Types.Add("Little");
            Types.Add("Big");
            Types.Add("Water");
        }

        public void Generate(int size)
        {
            Random random = new Random();
            bool tkt;
            for (int i = 0; i < size; i++)
            {
                int jsp = random.Next(0,1);
                if (jsp == 1)
                {
                    tkt = true;
                }
                else
                {
                    tkt = false;
                }
                Planet planet = new Planet(new Vector3(random.Next(size * 10), random.Next(size * 10), random.Next(size * 10)), random.Next(9999999).ToString(), Types[random.Next(Types.Count)], tkt);
                Planets.Add(planet);
            }
        }
    }
}
