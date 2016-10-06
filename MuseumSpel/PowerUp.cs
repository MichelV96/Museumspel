using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuseumSpel
{
    class PowerUp : SpelObject
    {
        public int CorX { get; private set; }
        public int CorY { get; private set; }

        public PowerUp(int x, int y) : base("Outfit", x, y, "Afbeeldingen\\power.png")
        {
            this.CorX = x;
            this.CorY = y;
        }
    }
}
