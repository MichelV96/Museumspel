using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuseumSpel
{
    // Model
    class Schilderij : SpelObject
    {

        public Schilderij(int cor_X, int cor_Y) : base("Schilderij", cor_X, cor_Y, "Afbeeldingen\\Floor.jpg", false)
        {
  
        }

        public override void setPicture(int number)
        {
          
            switch (number)
            {
                case 1:
                    texture = new Bitmap("Afbeeldingen\\painting_dragon.png");
                    break;
                case 2:
                    texture = new Bitmap("Afbeeldingen\\painting_duck.png");
                    break;
                case 3:
                    texture = new Bitmap("Afbeeldingen\\painting_Flamingo.png");
                    break;
            }
        }
    }
}
