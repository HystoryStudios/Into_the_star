using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HOTTUI
{
    public class Tools
    {
        public class Whrite
        {
            public static void Color_Write(ConsoleColor Color, string Text)
            {
                Console.ForegroundColor = Color;
                Console.Write(Text);
                Console.ResetColor();
            }
            public static void Color_Write_Back(ConsoleColor Color, ConsoleColor BackGround, string Text)
            {
                Console.BackgroundColor = BackGround;
                Console.ForegroundColor = Color;
                Console.Write(Text);
                Console.ResetColor();
            }
            public static void RainbowString(string text)
            {
                Random rd = new Random();

                foreach (var character in text)
                {
                    var consoleColors = (ConsoleColor)rd.Next(0, 16);
                    Color_Write(consoleColors, character.ToString());
                }
            }
            public static void WriteMachine(string text, int speed)
            {
                foreach (var character in text)
                {
                    Console.Write(character.ToString());
                    Thread.Sleep(speed);
                }
            }
        }
        public static string Color_Input(ConsoleColor Color)
        {
            Console.ForegroundColor = Color;
            return Console.ReadLine();
        }
        public static void Horizontal_Line(int size, ConsoleColor color, char type)
        {
            for (int i = 0; i < size; i++)
            {
                Whrite.Color_Write(color, type.ToString());
            }
        }
        public static void Vertical_Line(int size, ConsoleColor color)
        {
            //This Fonction is for create a vertical line in the left of the terminal
            for (int i = 0; i < size; i++)
            {
                Whrite.Color_Write(color, "|\n");
            }
        }
        public static void Loading_Bar(int size, ConsoleColor color, int DelayTime)
        {
            for (int i = 0; i < size; i++)
            {
                Thread.Sleep(DelayTime);
                Whrite.Color_Write_Back(color, color, " ");
            }
        }
        public static int Menu(ConsoleColor color, Dictionary<int, string> choise, string cursor)
        {
            int position = 1;
            bool jsp = true;
            Console.WriteLine(cursor);
            foreach (var s in choise)
            {
                Console.WriteLine($"{s.Key}. {s.Value}");
            }
            while (jsp)
            {
                switch (Console.ReadKey().Key)  
                {
                    case ConsoleKey.UpArrow:
                        position -= 1;
                        break;
                    case ConsoleKey.DownArrow:
                        position += 1;
                        break;
                    case ConsoleKey.Enter:
                        Console.Clear();
                        jsp = false;
                        break;
                }
                Console.Clear();
                if (position >= choise.Count + 1)
                {
                    position = 1;
                } 
                else if (position <= 1)
                {
                    position = 1;
                }
                foreach (var s in choise)
                {
                    if (s.Key == position)
                    {
                        Console.WriteLine($"{s.Key}. {s.Value}  {cursor}");
                    }
                    else
                    {
                        Console.WriteLine($"{s.Key}. {s.Value}");
                    }
                }
                
            }
            Console.Clear();
            Console.ResetColor();
            return position;

        }
        public static void Print_List_Int(List<int> ellementInt)
        {
            for (int i = 0; i < ellementInt.Count(); i++)
            {
                int ell = ellementInt.ElementAt(i);
                Console.WriteLine(ell);
            }
        }
        public static void Print_List_String(List<string> ellementString)
        {
            for (int i = 0; i < ellementString.Count(); i++)
            {
                string ell = ellementString.ElementAt(i);
                Console.WriteLine(ell);
            }
        }
        public static void PixelArt(ConsoleColor color, string symbol)
        {
            Whrite.Color_Write(color, symbol);
        }
        
        
        public static float Cursor(ConsoleColor color, float size, int Length, float power, string type)
        {
            float value = size / 2;

            int jsp = Length / (int) size;

            while (Console.ReadKey().Key != ConsoleKey.Enter)
            {
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.RightArrow:
                        value += power;
                        break; 
                    case ConsoleKey.LeftArrow:
                        value -= power;
                        break;
                }
                Console.Clear();

                Whrite.Color_Write(color, "[");

                for (int i = 0; i < (value / Length); i++)
                {
                    Console.Write("=");
                }
                
                for (int i =0; i < (Length/ value); i++)
                {
                    Console.Write("-");
                }
                Whrite.Color_Write(color, "]");
                Console.Write($" {value}");
            }

            return value;
        }
    }
}
