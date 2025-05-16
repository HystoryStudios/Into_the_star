using HOTTUI;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace HOTTGF
{
    public class Texture
    {
        private string File {  get; set; }
        private Dictionary<Vector2, char> TextureDic{  get; set; }
        private StreamReader TextureFile { get; set; }
        public Texture(string file)
        {
            File = file;
            TextureDic = new Dictionary<Vector2, char>();
            TextureFile = new StreamReader(file);
            CreateTexture();
        }

        private void CreateTexture()
        {
        }
        public void Print()
        {
            foreach (var j in TextureDic)
            {
                Console.SetCursorPosition((int)j.Key.X, (int)j.Key.Y);
                Console.WriteLine(j.Value);
            }
        }
    }
}
