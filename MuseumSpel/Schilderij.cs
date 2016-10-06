using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuseumSpel
{
    class Schilderij : SpelObject
    {
        public int cor_X { get; private set; }
        public int cor_Y { get; private set; }
        public Schilderij(int cor_X, int cor_Y) : base("Schilderij", cor_X, cor_Y, "Afbeeldingen\\Floor.png", false)
        {
            this.cor_X = cor_X;
            this.cor_Y = cor_Y;
        }
    }
}
