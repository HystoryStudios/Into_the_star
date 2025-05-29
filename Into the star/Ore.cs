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
        }
    }

    public class Ores
    { 
        public List<Ore> ores;

        public Ores()
        {
            ores = new List<Ore>();
            Ore acier = new Ore("Acier", "jsp");
            Ore cuivre = new Ore("cuivre", "jsp");
            Ore or = new Ore("or", "jsp");
            ores.Add(acier);
            ores.Add(cuivre);
            ores.Add(or);
        }
    }
}
