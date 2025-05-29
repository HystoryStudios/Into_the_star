using HOTTUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Into_the_star
{
    public class Nova
    {
        private Journal Journal {  get; set; }
        private int nboftalk = 0;
        public Nova(Journal journal) 
        {
            Journal = journal;
        }

        public void Update(Journal journal)
        {
            Journal = journal;
        }
        public void Talk()
        {
            nboftalk ++;

            switch (nboftalk)
            {
                case 1:
                    Tools.Whrite.WriteMachine($"[Nova] OH hello ! How are you ?\n", 50);
                    Tools.Whrite.WriteMachine("1) Bad\n", 50);
                    Tools.Whrite.WriteMachine("2) Good\n", 50);
                    string reponce = Console.ReadLine();
                    if (reponce == "1")
                    {
                        Tools.Whrite.WriteMachine($"[Nova] oh, i'm so sorry for you ... no i jokking i don't know who are you.Donc : JE M'EN BAS LEC !\n", 50);
                        Tools.Whrite.WriteMachine($"[Nova] Have a good bad day\n", 50);
                    }
                    else if (reponce == "2")
                    {
                        Tools.Whrite.WriteMachine($"[Nova] Nice, but... why you talk to me ?\n", 50);
                    }
                    break;
                case 2:
                    Tools.Whrite.WriteMachine("[Nova] Sorry for the last time. . . j'était énèrver d'ettre au fin fond de l'espace seule . . . \n", 100);
                    break;

                case 3:

                    break;

            }
        }

        public void Event(SpaceShip spaceShip)
        {
            if (spaceShip.Carburant <= 1)
            {
                Tools.Whrite.WriteMachine($"\n\n\n[Nova] Hey are you here ?\n", 200);
                Tools.Whrite.WriteMachine($"[Nova] You are in the void of the space, ", 50);
                Tools.Whrite.WriteMachine($"Into the star.\n", 200);
                Tools.Whrite.WriteMachine($"[Nova] No carburant, no planet, no asteroid... Nothing\n", 150);
                Tools.Whrite.WriteMachine($"[Nova] Juste toi et moi, dans le vide intercideral de l'espace...\n", 150);

            }
        }
    }
}
