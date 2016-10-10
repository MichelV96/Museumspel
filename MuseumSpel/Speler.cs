using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuseumSpel
{
    // Model
    public class Speler : SpelObject
    {
        public int speed { get; set; }

        public Speler(string name, int cor_X, int cor_Y, int speed) : base(name, cor_X, cor_Y, "Afbeeldingen\\0.png", true)
        {
            Speed = speed;
        }


        public void setPicture(Direction direction)
        {
            if(direction == Direction.Up)
            {
                texture = new Bitmap("Afbeeldingen\\12.png");
            }
            else if (direction == Direction.Down)
            {
                texture = new Bitmap("Afbeeldingen\\0.png");
            }
            else if (direction == Direction.Left)
            {
                texture = new Bitmap("Afbeeldingen\\4.png");
            }
            else if (direction == Direction.Right)
            {
                texture = new Bitmap("Afbeeldingen\\8.png");
            }
            if (direction == Direction.UpIdle)
            {
                texture = new Bitmap("Afbeeldingen\\14.png");
            }
            else if (direction == Direction.DownIdle)
            {
                texture = new Bitmap("Afbeeldingen\\2.png");
            }
            else if (direction == Direction.LeftIdle)
            {
                texture = new Bitmap("Afbeeldingen\\6.png");
            }
            else if (direction == Direction.RightIdle)
            {
                texture = new Bitmap("Afbeeldingen\\10.png");
            }
        }
        //method

        //getter en setter
        public int Speed
        {
            get
            {
                return speed;
            }
            set
            {
                if (value >= 0)
                {
                    speed = value;
                } else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}
