using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfEventsGame
{
    public static class Names
    {
        private static readonly string[] PlayerNames = new string[] { 
            "Maxim", "Mileto", "Siegfried", "Bart", "Kasper", "William", "Joachim", "Dries",
            "Tine", "Jan", "Dieter", "Kristien", "Olivier", "Eva", "Stef", "Brecht"
        };
        
        public static string GetRandomPlayerName()
        {
            Random random = new Random();
            return PlayerNames[random.Next(1, PlayerNames.Length)];
        }
    }
}
