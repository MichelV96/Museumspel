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

        public Muur(int cor_X, int cor_Y) : base("Muur", cor_X, cor_Y, "Afbeeldingen\\wall_normal.png", true)
        {

        }

        public override void setPicture()
        {
            if (up && down)
                texture = new Bitmap("Afbeeldingen\\wall_up_down.png");
            else if (up && right)
                texture = new Bitmap("Afbeeldingen\\wall_up_right.png");
            else if (up && left)
                texture = new Bitmap("Afbeeldingen\\wall_up_left.png");
            else if (left && right)
                texture = new Bitmap("Afbeeldingen\\wall_left_right.png");
            else if(down && right)
                texture = new Bitmap("Afbeeldingen\\wall_down_right.png");
            else if (down && left)
                texture = new Bitmap("Afbeeldingen\\wall_down_left.png");
            else if (up)
                texture = new Bitmap("Afbeeldingen\\wall_up.png");
            else if (down)
                texture = new Bitmap("Afbeeldingen\\wall_down.png");
            else if (right)
                texture = new Bitmap("Afbeeldingen\\wall_right.png");
            else if (left)
                texture = new Bitmap("Afbeeldingen\\wall_left.png");
            else
                texture = new Bitmap("Afbeeldingen\\wall_normal.png");
        }
    }
}
