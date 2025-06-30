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
        public List<Asteroid> Asteroids { get; set; }
        private List<string> Types { get; set; }

        public Univers() 
        { 
            Planets = new List<Planet>();
            Types = new List<string>();
            Asteroids = new List<Asteroid>();
            Types.Add("Gazeuse");
            Types.Add("Radioactive");
            Types.Add("Paradise");
            Types.Add("Little");
            Types.Add("Big");
            Types.Add("Water");
        }

        public void GeneratePlanet(int size)
        {
            List<char> chars = new List<char>();
            string imp = "AZERTYUIOPQSDFGHJKLMWXCVBNazertyuiopqsdfghjklmwxcvbn";
            foreach (char c in imp)
            {
                chars.Add(c);
            }
            Random random = new Random();
            string nm;
            nm = $"{chars[random.Next(chars.Count)]}-{random.Next(9999).ToString()}|{chars[random.Next(chars.Count)]}";
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
                Planet planet = new Planet(new Vector3(random.Next(size * 10), random.Next(size * 10), random.Next(size * 10)), nm, Types[random.Next(Types.Count)], random.Next(10, 1000), tkt);
                Planets.Add(planet);
            }
        }
        public void GenerateAsteroid(int size)
        {
            List<char> chars = new List<char>();
            string imp = "AZERTYUIOPQSDFGHJKLMWXCVBN";
            foreach (char c in imp)
            {
                chars.Add(c);
            }
            Random random = new Random();
            string nm;
            nm = $"{chars[random.Next(chars.Count)]} - {random.Next(999999999).ToString()}";
            Ores ores = new Ores();
            
            for (int i = 0; i < size; i++)
            {
                Asteroid asteroid = new Asteroid(nm, new Vector3(random.Next(size * 10), random.Next(size * 10), random.Next(size * 10)), ores.ores[random.Next(ores.ores.Count)]);
                Asteroids.Add(asteroid);
                
            }
        }
    }
}
