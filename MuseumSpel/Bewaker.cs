using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuseumSpel
{
    public class Bewaker : SpelObject
    {
        public Bewaker(int cor_X, int cor_Y) : base("Bewaker", cor_X, cor_Y, "Afbeeldingen\\0.png", false)
        {

        }
        


        public void setPicture(Direction Direction)
        {
            if (Direction == Direction.Up)
            {
                texture = new Bitmap("Afbeeldingen\\Guard1.png");
            }
            else if (Direction == Direction.Down)
            {
                texture = new Bitmap("Afbeeldingen\\Guard3.png");
            }
            else if (Direction == Direction.Left)
            {
                texture = new Bitmap("Afbeeldingen\\Guard2.png");
            }
            else if (Direction == Direction.Right)
            {
                texture = new Bitmap("Afbeeldingen\\Guard0.png");
            }
        }


    }

}

