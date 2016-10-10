using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MuseumSpel
{
    //abstracte class voor ieder spel object, behoort tot model
    public abstract class SpelObject
    {
        public Bitmap texture { get; set; }
        public string name { get; private set; }
        public bool isSolid { get; private set; }
        private int cor_X;
        private int cor_Y;

        public SpelObject(string name, int cor_X, int cor_Y, string picture, bool isSolid)
        {
            this.name = name;
            Cor_X = cor_X;
            Cor_Y = cor_Y;
            this.texture = new Bitmap(picture);
            this.isSolid= isSolid;

        }

        public void PrintSpelObject(int cor_X, int cor_Y, int vakGrootte, Graphics g)
        {
            g.DrawImage(texture, cor_X * vakGrootte, cor_Y * vakGrootte, vakGrootte, vakGrootte);
        }

        public int Cor_X
        {
            get
            {
                return cor_X;
            }
            set
            {
                if (value >= 0)
                {
                    cor_X = value;
                }
            }
        }

        public int Cor_Y
        {
            get
            {
                return cor_Y;
            }
            set
            {
                if (value >= 0)
                {
                    cor_Y = value;
                }
            }
        }
    }
}