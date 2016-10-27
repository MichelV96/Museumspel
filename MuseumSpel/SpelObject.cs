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
        //starting values
        public int start_cor_x;
        public int start_cor_y;
        public bool up = false;
        public bool down = false;
        public bool left = false;
        public bool right = false;

        public Bitmap texture;
        public string name;
        public bool isSolid;
        private int cor_X;
        private int cor_Y;

        public SpelObject(string name, int cor_X, int cor_Y, string picture, bool isSolid)
        {
            this.name = name;
            Cor_X = cor_X;
            start_cor_x = cor_X;
            Cor_Y = cor_Y;
            start_cor_y = cor_Y;
            this.isSolid = isSolid;
            try
            {
                texture = new Bitmap(picture);
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            } 
        }

        public virtual void setPicture( int number = 0)
        {

        }

        public virtual void PrintSpelObject(int cor_X, int cor_Y, int vakGrootte, Graphics g)
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