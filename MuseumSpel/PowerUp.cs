﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuseumSpel
{
    // Model
    class PowerUp : SpelObject
    {  
        public PowerUp(int x, int y) : base("Outfit", x, y, "Afbeeldingen\\power4.png", false)
        {
            
        }
    }
}