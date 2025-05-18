using HOTTUI;
using Into_the_star;
using System.Numerics;

Random rd = new Random();
int planetnb = 100;
Univers univers = new Univers();
SpaceShip spaceShip = new SpaceShip("test", 0, new Vector3(rd.Next(planetnb *10), rd.Next(planetnb * 10), rd.Next(planetnb * 10)), planetnb / 2);
univers.Generate(planetnb);

bool adminmode = false;
while (true)
{
    Tools.Whrite.Color_Write(ConsoleColor.Cyan, ">");
    string input = Tools.Color_Input(ConsoleColor.Red);

    if (input == "info") { Commands.info(spaceShip.Position, univers); }
    else if (input == "exit") { break; }
    else if (input == "position") { Console.Write($"Your position is :"); Tools.Whrite.WriteMachine(spaceShip.Position.ToString(), 100); Console.WriteLine(""); }
    else if (input.StartsWith("go to")) { spaceShip.Move(input); Tools.Whrite.Color_Write(ConsoleColor.Green, $"Your new position is : {spaceShip.Position}\n"); }
    else if (input == "scan") 
    { 
        List<Vector3> g = Commands.Scan(univers, spaceShip); 

        foreach (Vector3 c in g)
        {
            Console.WriteLine(c.ToString());
        }
    }

    else if (input == "Admin Mode")
    {
        adminmode = true;
        Console.WriteLine("Admin Mode On");
    }
    else if (input == "ScanAll" && adminmode)
    {
        foreach (Planet planet in univers.Planets)
        {
            Console.WriteLine(planet.Position.ToString());
        }
    }

}