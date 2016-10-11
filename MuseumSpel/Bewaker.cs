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
        public int[,] wayPoints;
        public bool heenweg { get; set; }
        public int speed { get; set; }

        public Bewaker(int cor_X, int cor_Y, int eind_cor_X, int eind_cor_Y, int speed) : base("Bewaker", cor_X * 50, cor_Y * 50, "Afbeeldingen\\guard3.png", false)
        {
            wayPoints = new int[2,2] { { cor_X, cor_Y }, { eind_cor_X,  eind_cor_Y} };
            heenweg = true;
            this.speed = speed;

            // TESTEN
            Console.WriteLine(wayPoints[0,0] + " " + wayPoints[0,1] + "\n" + wayPoints[1,0] + " " + wayPoints[1, 1]);
            //foreach (int way in wayPoints)
            //{
            //    Console.WriteLine(way);
            //}
        }

        public override void PrintSpelObject(int cor_X, int cor_Y, int vakGrootte, Graphics g)
        {
            g.DrawImage(texture, cor_X , cor_Y, vakGrootte, vakGrootte);
        }

    }

}

