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
            foreach (var a in univers.Asteroids)
            {
                if (a.Position == position)
                {
                    a.Info();
                }
            }
        }
        
        public static void Scan(Univers univers, SpaceShip spaceShip)
        {
            int range = spaceShip.ScanSize;
            var list = new List<Vector3>();
            for (int y = (int)spaceShip.Position.Y - range; y <= spaceShip.Position.Y + range; y++)
            {
                for (int x = (int)spaceShip.Position.X - range; x <= spaceShip.Position.X + range; x++)
                {
                    for (int z = (int)spaceShip.Position.Z - range; z <= spaceShip.Position.Z + range; z++)
                    {
                        var pos = new Vector3(x, y, z);

                        foreach (var p in univers.Planets)
                        {
                            if (pos == p.Position)
                            {
                                list.Add(p.Position);
                            }
                        }
                        foreach (var a in univers.Asteroids)
                        {
                            if (pos == a.Position)
                            {
                                list.Add(a.Position);
                            }
                        }

                    }
                }
            }
            if (list.Count == 0)
            {
                Tools.Whrite.Color_Write(ConsoleColor.Red, "[Scanner] No signal found \n");
            }
            else
            {
                foreach (Vector3 pos in list)
                {
                    if (pos != spaceShip.Position)
                    {
                        Tools.Whrite.Color_Write(ConsoleColor.Green, $"[Scanner] Signal found at : {pos.ToString()}\n");
                    }
                }
                
            }
            
        }
        public static void Goto(SpaceShip spaceShip, string gtpos)
        {
            spaceShip.Move(gtpos);
            
        }
        public static void Help()
        {
            Console.WriteLine("| go to : For go to a 3D position write 'gp to x y z'");
            Console.WriteLine("| Nova : For talk to Nova");
            Console.WriteLine("| position : For get your actual position");
            Console.WriteLine("| scan : For scan the space");
            Console.WriteLine("| info : For get information of your actual position");
            Console.WriteLine("| info spaceship : For get all the information of your spaceship");
        }
        public static void SpaceShipinfo(SpaceShip spaceShip)
        {
            Console.WriteLine($"|ID : {spaceShip.ID}");
            Console.WriteLine($"|Name : {spaceShip.Name}");
            Console.WriteLine($"|Scan Size : {spaceShip.ScanSize}");
            Console.WriteLine($"|Carburant : {spaceShip.Carburant}");
            Console.WriteLine($"|Position : {spaceShip.Position}");
        }
    }
}
