﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuseumSpel
{
    // Model
    public class Speler : SpelObject
    {
        public int speed { get; set; }

        public Speler(string name, int cor_X, int cor_Y, int speed) : base(name, cor_X, cor_Y, "Afbeeldingen\\Front_50PX.png", true)
        {
            Speed = speed;
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