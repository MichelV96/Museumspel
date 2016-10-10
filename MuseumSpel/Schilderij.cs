using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuseumSpel
{
    // Model
    class Schilderij : SpelObject
    {
 
        public Schilderij(int cor_X, int cor_Y) : base("Schilderij", cor_X, cor_Y, "Afbeeldingen\\Floor.png", false)
        {
            
        }
    }
}
