using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuseumSpel
{
    //Model
    class Eindpunt : SpelObject
    {
        public Eindpunt(int cor_X, int cor_Y) : base("Eindpunt", cor_X, cor_Y, "Afbeeldingen\\eindpunt.png", false)
        {

        }

    }
}
