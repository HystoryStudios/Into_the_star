using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Into_the_star
{
    public class Ore
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Ore(string name, string description)
        {
            Name = name; 
            Description = description;
            Random random = new Random();
            random.Next();
        }
    }

    public class Ores
    { 
        public List<Ore> ores;

        public Ores()
        {
            ores = new List<Ore>();
            Ore acier = new Ore("Acier", "jsp");
            Ore cuivre = new Ore("Cuivre", "jsp");
            Ore or = new Ore("Or", "jsp");
            Ore uranium = new Ore("Uranium", "for charging your spaceship");
            ores.Add(acier);
            ores.Add(cuivre);
            ores.Add(or);
            ores.Add(uranium);
        }
    }
}
