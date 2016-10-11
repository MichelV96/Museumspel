using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuseumSpel
{
    // Model
    public class Muur : SpelObject
    {

        public Muur(int cor_X, int cor_Y) : base("Muur", cor_X, cor_Y, "Afbeeldingen\\wall2.png", true)
        {

        }
    }
}
