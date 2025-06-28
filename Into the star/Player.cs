using HOTTGF;
using HOTTUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Into_the_star
{
    public class Player
    {
        public Dictionary<string, ConsoleKey> Keyboard {  get; set; }
        private Vector2 Prepos = new();
        public Vector2 Position = new();
        public char Texture { get; set; }

        public Player(char texture, Vector2 pos)
        {
            Position = pos;
            Texture = texture;
            Prepos = pos;
        }

        public void Move()
        {
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.UpArrow:
                    Prepos = new Vector2(Position.X, Position.Y);
                    Position.Y -= 1;
                    break;
                case ConsoleKey.DownArrow:
                    Prepos = new Vector2(Position.X, Position.Y);
                    Position.Y += 1;
                    break;
                case ConsoleKey.RightArrow:
                    Prepos = new Vector2(Position.X, Position.Y);
                    Position.X += 1;
                    break;
                case ConsoleKey.LeftArrow:
                    Prepos = new Vector2(Position.X, Position.Y);
                    Position.X -= 1;
                    break;
            }
        }
        public void Draw(ConsoleColor color)
        {
            Console.SetCursorPosition((int)Prepos.X, (int)Prepos.Y);
            Console.Write(" ");
            Console.SetCursorPosition((int)Position.X, (int)Position.Y);
            Tools.Whrite.Color_Write(color,Texture.ToString());
        }
    }
}
