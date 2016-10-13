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
        public int richting; //1=boven, 2=beneden, 3=rechts, 4=links
        public int path;
        public int aantalpaths;
        public int speed;

        public Bewaker(int cor_X, int cor_Y, int eind_cor_X, int eind_cor_Y, int speed) : base("Bewaker", cor_X * 50, cor_Y * 50, "Afbeeldingen\\guard3.png", false)
        {
            {  
                wayPoints = new int[2, 2] { { cor_X, cor_Y }, { eind_cor_X, eind_cor_Y } };
                this.speed = speed;
                path = 1;
                aantalpaths = 2;
                richting = 1;        
            }
        }

        public Bewaker(int cor_X1, int cor_Y1, int cor_X2, int cor_Y2, int cor_X3, int cor_Y3, int cor_X4, int cor_Y4, int speed) : base("Bewaker", cor_X1 * 50, cor_Y1 * 50, "Afbeeldingen\\guard3.png", false)
        {
            wayPoints = new int[4, 2] { { cor_X1, cor_Y1 }, { cor_X2, cor_Y2 }, { cor_X3, cor_Y3 }, { cor_X4, cor_Y4 } };
            this.speed = speed;
            path = 1;
            aantalpaths = 4;
        }


        public override void PrintSpelObject(int cor_X, int cor_Y, int vakGrootte, Graphics g)
        {
            g.DrawImage(texture, cor_X , cor_Y, vakGrootte, vakGrootte);
        }

    }

}

