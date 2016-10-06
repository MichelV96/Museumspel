using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuseumSpel
{
    // The Model, SuperClass
    public class SpeelVeld
    {
        //aantalRijen, aantalVakjes
        private int aantalVakkenX;
        private int aantalVakkenY;
        private int vakGrootte;
        public int borderX { get; set; }
        public int borderY { get; set; }
        public Speler speler { get; set; }
        //lists
        private List<SpelObject> spelObjecten;

        public SpeelVeld(int aantalVakkenX, int aantalVakkenY, Speler speler)
        {
            this.aantalVakkenX = aantalVakkenX;
            this.aantalVakkenY = aantalVakkenY;
            vakGrootte = 50;
            this.speler = speler;            
            borderY = vakGrootte * aantalVakkenY;
            borderX = vakGrootte * aantalVakkenX;
            spelObjecten = new List<SpelObject>();
        }

        // Methodes

        //public bool CollisionCheck() //First attempt
        //{
        //    foreach (SpelObject spelObject in spelObjecten) {
        //        if (speler.texture. spelObject.texture.GetBounds)
        //            return false;
        //            }
        //    return true;          
        //}

        public void SpelerMovement(string loopRichting)
        {
            switch (loopRichting)
            {
                case "up":
                    if (speler.Cor_Y >= 0)
                        speler.Cor_Y -= speler.speed;
                    break;
                case "down":
                    if (speler.Cor_Y + vakGrootte < borderY)
                        speler.Cor_Y += speler.speed;
                    break;
                case "left":
                    if (speler.Cor_X >= 0)
                        speler.Cor_X -= speler.speed;
                    break;
                case "right":
                    if (speler.Cor_X + vakGrootte < borderX)
                        speler.Cor_X += speler.speed;
                    break;
            }
        }
        // test om cordinaat op grid terug te krijgen
        //public int GetGridCordinate(int cor)
        //{
        //    double i = cor / vakGrootte;
        //    int j = Math.Round(i, 2)
        //    return i;
        //}

        public void VoegSpelObjectToe(SpelObject spelobject)
        {
            if (spelobject.Cor_X < aantalVakkenX && spelobject.Cor_Y < aantalVakkenY)
            spelObjecten.Add(spelobject);
        }

        public void PrintSpeelVeld(Graphics g)
        {
            foreach (SpelObject spelObject in spelObjecten)
            {
                spelObject.PrintSpelObject(spelObject.Cor_X, spelObject.Cor_Y, vakGrootte, g);
            }
        }
    }
}