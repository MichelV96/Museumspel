using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuseumSpel
{
    class Bewaker : SpelObject
    {
        public Bewaker(int cor_X, int cor_Y) : base("Bewaker", cor_X, cor_Y, "Afbeeldingen\\0.png", false)
        {

        }


        public void setPicture(DirectionGuard DirectionGuard)
        {
            if (DirectionGuard == DirectionGuard.Up)
            {
                texture = new Bitmap("Afbeeldingen\\12.png");
            }
            else if (DirectionGuard == DirectionGuard.Down)
            {
                texture = new Bitmap("Afbeeldingen\\0.png");
            }
            else if (DirectionGuard == DirectionGuard.Left)
            {
                texture = new Bitmap("Afbeeldingen\\4.png");
            }
            else if (DirectionGuard == DirectionGuard.Right)
            {
                texture = new Bitmap("Afbeeldingen\\8.png");
            }
            if (DirectionGuard == DirectionGuard.UpIdle)
            {
                texture = new Bitmap("Afbeeldingen\\14.png");
            }
            else if (DirectionGuard == DirectionGuard.DownIdle)
            {
                texture = new Bitmap("Afbeeldingen\\2.png");
            }
            else if (DirectionGuard == DirectionGuard.LeftIdle)
            {
                texture = new Bitmap("Afbeeldingen\\6.png");
            }
            else if (DirectionGuard == DirectionGuard.RightIdle)
            {
                texture = new Bitmap("Afbeeldingen\\10.png");
            }
        }


    }

}

