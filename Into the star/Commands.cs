using HOTTUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

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
        public static void Mine(Univers univers, SpaceShip spaceShip)
        {
            foreach (var a in univers.Asteroids)
            {
                if (a.Position == spaceShip.Position)
                {
                    if (spaceShip.Inventory.ContainsKey(a.Ore.Name))
                    {
                        spaceShip.Inventory.TryGetValue(a.Ore.Name, out var item);
                        spaceShip.Inventory.Remove(a.Ore.Name);
                        spaceShip.Inventory.Add(a.Ore.Name, item+ a.OreNumber);
                        Tools.Whrite.Color_Write(ConsoleColor.Green, $"You have received {a.OreNumber} {a.Ore.Name} !\n");
                    }
                    else
                    {
                        spaceShip.Inventory.Add(a.Ore.Name, a.OreNumber);
                        Tools.Whrite.Color_Write(ConsoleColor.Green, $"You have received {a.OreNumber} {a.Ore.Name} !\n");
                    }
                }
            }
        }
        public static void Inventory(SpaceShip spaceShip)
        {
            if (spaceShip.Inventory.Count == 0)
            {
                Tools.Whrite.Color_Write(ConsoleColor.Red, "[SpaceShip] Your Inventory is empty!\n");
            }
            foreach (var item in spaceShip.Inventory)
            {
                Console.WriteLine($"{item.Key} : {item.Value}");
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
            Console.WriteLine("| mine : for mine asteroid");
            Console.WriteLine("| inventory : open your inventory");
        }
        public static void SpaceShipinfo(SpaceShip spaceShip)
        {
            Console.WriteLine($"|ID : {spaceShip.ID}");
            Console.WriteLine($"|Name : {spaceShip.Name}");
            Console.WriteLine($"|Scan Size : {spaceShip.ScanSize}");
            Console.WriteLine($"|Carburant : {spaceShip.Carburant}");
            Console.WriteLine($"|Position : {spaceShip.Position}");
        }
        public static void GoIn(SpaceShip spaceShip, Univers univers)
        {   
            foreach (var p in univers.Planets)
            {
                if (p.Position == spaceShip.Position)
                {
                    p.Generate();

                    Tools.Whrite.WriteMachine($"[Nova] Welcome on {p.Name}\n", 100);

                    while (true)
                    {
                        Tools.Whrite.Color_Write(ConsoleColor.Green, ">>");
                        string input = Console.ReadLine();


                        if (input == "go out")
                        {
                            Tools.Whrite.WriteMachine("[Nova] GO BACK IN THE SPACE !\n", 100);
                            Tools.Whrite.WriteMachine($"[Nova] See You again {p.Name} !\n", 100);
                            break;
                        }
                        else
                        {
                            Tools.Whrite.Color_Write(ConsoleColor.Red, "[Nova] Is it... a command ?");
                        }
                    }
                }
            }
        }
        public static void Charge(SpaceShip spaceShip, int nb)
        {
            spaceShip.Inventory.TryGetValue("Uranium", out int save);
            for (int i = 0; i < nb; i++)
            {
                if (spaceShip.Inventory.ContainsKey("Uranium"))
                {
                    spaceShip.Inventory.TryGetValue("Uranium", out var item);
                    spaceShip.Inventory.Remove("Uranium");
                    spaceShip.Inventory.Add("Uranium", item - 1);
                }
                else
                {
                    spaceShip.Inventory.Remove("Uranium");
                    spaceShip.Inventory.Add("Uranium", save);
                    Tools.Whrite.Color_Write(ConsoleColor.Red, "[SpaceShip] You don't have any Uranium !!!");
                    break;
                }
            }
        }
    }
}
