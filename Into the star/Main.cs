using HOTTUI;
using Into_the_star;
using System.Numerics;
void Intro()
{

    // Begin

    Tools.Whrite.WriteMachine("SpaceShip Reset, Please wait\n", 100);
    Tools.Whrite.Color_Write(ConsoleColor.Green, "[");
    Tools.Loading_Bar(20, ConsoleColor.Green, 150);
    Tools.Whrite.Color_Write(ConsoleColor.Green, "]\n");
    Console.Clear();
    Tools.Whrite.WriteMachine("[???] Welcome Into The Star !\n", 100);
    Tools.Whrite.WriteMachine("[???] Welcome in the void of the space \n", 100);
    Tools.Whrite.WriteMachine(". . .\n", 200);
    Tools.Whrite.WriteMachine("[???] I'm Nova, your AI for... Mental Helping ! \n", 100);
    Tools.Whrite.WriteMachine("[Nova] You can get help with the command help, yes is very easy... \n", 100);
    Thread.Sleep(500);
    Tools.Whrite.WriteMachine("[Nova] And if you need to talk, i'm here !\n", 100);
    Tools.Whrite.WriteMachine("[Nova] Please don't go out the SpaceShip in the space, Il fait au moins -8000 !!!\n", 100);
    Tools.Whrite.WriteMachine("[Nova] Have a nice Journey !\n", 100);
    Thread.Sleep(1000);
    Console.Clear();
}
Random rd = new Random();
int planetnb = 100;
Univers univers = new Univers();
SpaceShip spaceShip = new SpaceShip("test", 0, new Vector3(rd.Next(planetnb *10), rd.Next(planetnb * 10), rd.Next(planetnb * 10)), planetnb / 2);

int day = 0;
univers.Generate(planetnb);

bool adminmode = false;


// Pre-Lunch
Tools.Whrite.WriteMachine("Welcome to Into the Star !\n", 100);

Tools.Whrite.WriteMachine("Warning : This game is in french and english\n", 100);
Tools.Whrite.WriteMachine("Attention : Ce jeu est en francais et en anglais\n", 100);
Tools.Whrite.WriteMachine("What's your name ?\n", 100);
Journal journal = new Journal(Console.ReadLine());
Tools.Whrite.Color_Write(ConsoleColor.Green, "Do you want the Intro ? [y, n]");
switch (Console.ReadLine())
{
    case "y":
        Intro();
        break;
    case "n":
        Tools.Whrite.WriteMachine("SpaceShip Reset, Please wait\n", 100);
        Tools.Whrite.Color_Write(ConsoleColor.Green, "[");
        Tools.Loading_Bar(20, ConsoleColor.Green, 150);
        Tools.Whrite.Color_Write(ConsoleColor.Green, "]\n");
        Console.Clear();
        break;
}
Nova nova = new Nova(journal);

while (true)
{
    day += 1;
    string daystring = $"Hour : {day}";
    Tools.Horizontal_Line(Console.WindowWidth, ConsoleColor.Green, '-');
    Tools.Whrite.Color_Write(ConsoleColor.Green, "\n|");
    Tools.Horizontal_Line((Console.WindowWidth / 2 - (daystring.Length / 2)) -1, ConsoleColor.Green, ' ');
    Tools.Whrite.WriteMachine($"Day : {day}", 200);
    Tools.Horizontal_Line((Console.WindowWidth / 2 - (daystring.Length / 2)) -1, ConsoleColor.Green, ' ');
    Tools.Whrite.Color_Write(ConsoleColor.Green, "|\n");
    Tools.Horizontal_Line(Console.WindowWidth, ConsoleColor.Green, '-');
    Console.WriteLine("");
    Tools.Whrite.Color_Write(ConsoleColor.Cyan, ">");
    string input = Tools.Color_Input(ConsoleColor.Red);

    if (input == "info") { Commands.info(spaceShip.Position, univers); }
    else if (input == "exit") { break; }
    else if (input =="help") { Commands.Help(); }
    else if (input == "Nova") { nova.Talk(); }
    else if (input == "position") { Console.Write($"Your position is :"); Tools.Whrite.WriteMachine(spaceShip.Position.ToString(), 100); Console.WriteLine(""); }
    else if (input.StartsWith("go to")) 
    { 
        string[] test = input.Split(' ');
        if (test.Length == 5)
        {
            Commands.Goto(spaceShip, input);
        }
        else
        {
            Tools.Whrite.Color_Write(ConsoleColor.Red, "[Nova] Not the good argument !\n");
        }

    }
    else if (input == "scan")
    {
        Commands.Scan(univers, spaceShip);
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
    journal.Whrite(input);
    nova.Update(journal);
    nova.Event();
}