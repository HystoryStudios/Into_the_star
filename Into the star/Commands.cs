using HOTTUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Into_the_star
{
    public class Commands
    {
        public static void info(Vector3 position, Univers univers)
        {
            foreach (var planet in univers.Planets)
            {
                if (planet.Position == position)
                {
                    planet.Info();
                }
            }
        }

        public static List<Vector3> Scan(Univers univers, SpaceShip spaceShip)
        {
            int range = spaceShip.ScanSize;
            var list = new List<Vector3>();
            for (int y = (int)spaceShip.Position.Y - range; y <= range; y++)
            {
                for (int x = (int)spaceShip.Position.X - range; x <= range; x++)
                {
                    for (int z = (int)spaceShip.Position.Z - range; z <= range; z++)
                    {
                        var pos = new Vector3(x, y, z);

                        foreach (var p in univers.Planets)
                        {
                            if (pos == p.Position)
                            {
                                list.Add(p.Position);
                            }
                        }
                    }
                }
            }
            return list;
        }
    }
}
