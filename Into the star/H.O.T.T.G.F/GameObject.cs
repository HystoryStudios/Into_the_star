using HOTTGF;
using HOTTUI;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HOTTGF
{
    public class GameObject
    {
        public char Texture {  get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public GameObject(char texture, Vector2 position)
        {
            Texture = texture;
            X = (int) position.X;
            Y = (int) position.Y;
        }

        public void Draw(ConsoleColor color)
        {
            Console.SetCursorPosition(X, Y);
            Tools.Whrite.Color_Write(color, Texture.ToString());
        }
    }
}
