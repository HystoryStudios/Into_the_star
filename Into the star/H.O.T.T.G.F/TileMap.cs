using HOTTUI;
using System.Drawing;

namespace HOTTGF
{
    public class TileMap
    {
        public char[,] chars;
        public Window window { get; set; }
        public TileMap(char[,] tilemap) 
        {
            chars = tilemap;
        }
        public void DrawUniColor(ConsoleColor color)
        {
            for (int y = 0; y < chars.GetLength(0); y++)
            {
                for (int x = 0; x < chars.GetLength(1); x++)
                {
                    Console.SetCursorPosition(x, y);
                    Tools.Whrite.Color_Write(color, chars[y, x].ToString());
                }
            }
        }
        public void DrawColor(Dictionary<char, ConsoleColor> colors)
        {
            for (int y = 0; y < chars.GetLength(0); y++)
            {
                for (int x = 0; x < chars.GetLength(1); x++)
                {
                    ConsoleColor consoleColor;
                    colors.TryGetValue(chars[y, x], out consoleColor);
                    Console.SetCursorPosition(x, y);
                    Tools.Whrite.Color_Write(consoleColor, chars[y, x].ToString());
                }
            }
        }
    }
}
