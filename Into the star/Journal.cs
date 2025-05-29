using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Into_the_star
{
    public class Journal
    {
        public string PlayerName {  get; set; }
        public Dictionary<int, string> Journaldic { get; set; }
        public Journal(string playerName) 
        {
            PlayerName = playerName;
            Journaldic = new Dictionary<int, string>();
        }

        public void Write(string input)
        {
            
        }
    }
}
