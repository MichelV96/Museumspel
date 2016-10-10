using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public bool isDisguised { get; private set; }

        public Speler(string name, int cor_X, int cor_Y, int speed) : base(name, cor_X, cor_Y, "Afbeeldingen\\Front_50PX.png", true)
        {
            Speed = speed;
            this.isDisguised = false;
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

        public void PowerUp()
        {
            //nieuw plaatje omdat je de powerup hebt opgepakt
            Bitmap t = new Bitmap(base.texture);
            texture = new Bitmap("Afbeeldingen\\3.png");
            //isdisguised op true zetten omdat je vermomd bent
            this.isDisguised = true;
            //na 5 sec terug naar oude plaatje
            //texture = new Bitmap(t);
        }
    }
}
