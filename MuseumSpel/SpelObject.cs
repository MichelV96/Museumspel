﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MuseumSpel
{
    //abstracte class voor ieder spel object
    public abstract class SpelObject
    {
        public Bitmap texture { get; set; }
        public string name { get; set; }
        private int cor_X;
        private int cor_Y;
        //private int hoogte;
        //private int breedte;

        public SpelObject(string name, int cor_X, int cor_Y, string picture)
        {
            this.name = name;
            Cor_X = cor_X -1;
            Cor_Y = cor_Y -1;
            this.texture = new Bitmap(picture); 

        }

        public void PrintSpelObject(int cor_X, int cor_Y, int vakGrootte, Graphics g)
        {
            g.DrawImage(texture, cor_X * vakGrootte, cor_Y * vakGrootte, vakGrootte, vakGrootte);
            //texture.Location = new System.Drawing.Point(cor_X, cor_Y);
            //texture.Size = new System.Drawing.Size(vakGrootte, vakGrootte);
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