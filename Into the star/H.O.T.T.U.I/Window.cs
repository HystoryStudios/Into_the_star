using HOTTUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOTTUI
{
    public class Window
    {
        public int Height { get; set; }
        public int Width { get; set; }

        public char[,] chars;
        public char Background { get; set; }
        public Window(int height, int width, char backgrond)
        { 
            Height = height;
            Width = width;
            chars = new char[height, width];
            Background = backgrond;
        }
        public void CreateBackGround()
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    chars[x, y] = Background;
                }
            }
        }
        public void Change(int x, int y, char item)
        {
            chars[x, y] = item;
        }
        public void PrintUnicolor(ConsoleColor color)
        {
            for (int y = 0; y < chars.GetLength(0); y++)
            {
                for (int x = 0; x < chars.GetLength(1); x++)
                {
                    Console.SetCursorPosition(y, x);
                    Tools.Whrite.Color_Write(color, chars[x, y].ToString()); 
                }
            }
        }
    }
}