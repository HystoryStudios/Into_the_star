using HOTTGF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Into_the_star
{
    public class Player : GameObject
    {
        public Dictionary<string, ConsoleKey> Keyboard {  get; set; }

        public Player(char texture, Vector2 pos)
        {
            X = (int) pos.Y;
            Y = (int) pos.Y;
            Texture = texture;
        }

        public void Move()
        {
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.UpArrow:
                    Y += 1;
                    break;
                case ConsoleKey.DownArrow:
                    Y -= 1;
                    break;
                case ConsoleKey.RightArrow:
                    X += 1;
                    break;
                case ConsoleKey.LeftArrow:
                    X -= 1;
                    break;
            }
        }
    }
}
