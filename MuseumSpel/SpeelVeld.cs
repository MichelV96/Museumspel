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

        public bool CollisionCheck(string richting) //First attempt
        {
            int x_p1, y_p1;
            int x_p2, y_p2;
            
            if (richting == "up")
            {
                x_p1 = GetGridCordinate(speler.Cor_X);
                y_p1 = GetGridCordinate(speler.Cor_Y - speler.speed);
                x_p2 = GetGridCordinate(speler.Cor_X + vakGrootte);
                y_p2 = GetGridCordinate(speler.Cor_Y - speler.speed);
            }else if (richting == "down")
            {
                x_p1 = GetGridCordinate(speler.Cor_X);
                y_p1 = GetGridCordinate(speler.Cor_Y + vakGrootte + speler.speed);
                x_p2 = GetGridCordinate(speler.Cor_X + vakGrootte);
                y_p2 = GetGridCordinate(speler.Cor_Y + vakGrootte + speler.speed);
            }else if (richting == "left")
            {
                x_p1 = GetGridCordinate(speler.Cor_X - speler.speed);
                y_p1 = GetGridCordinate(speler.Cor_Y);
                x_p2 = GetGridCordinate(speler.Cor_X - speler.speed);
                y_p2 = GetGridCordinate(speler.Cor_Y + vakGrootte);
            }
            else if (richting == "right")
            {
                x_p1 = GetGridCordinate(speler.Cor_X + vakGrootte + speler.speed);
                y_p1 = GetGridCordinate(speler.Cor_Y);
                x_p2 = GetGridCordinate(speler.Cor_X + vakGrootte + speler.speed);
                y_p2 = GetGridCordinate(speler.Cor_Y -10 + vakGrootte);
            } else
            {
                x_p1 = 0;
                y_p1 = 0;
                x_p2 = 0;
                y_p2 = 0;
            }

            foreach (SpelObject spelObject in spelObjecten)
            {
                if (x_p1 == spelObject.Cor_X && y_p1 == spelObject.Cor_Y || x_p2 == spelObject.Cor_X && y_p2 == spelObject.Cor_Y)
                    return false;
            }
            return true;
        }

        public void SpelerMovement(string loopRichting)
        {
            switch (loopRichting)
            {
                case "up":
                    if (speler.Cor_Y >= 0 && CollisionCheck("up"))
                        speler.Cor_Y -= speler.speed;
                    break;
                case "down":
                    if (speler.Cor_Y + vakGrootte < borderY && CollisionCheck("down"))
                        speler.Cor_Y += speler.speed;
                    break;
                case "left":
                    if (speler.Cor_X >= 0 && CollisionCheck("left"))
                        speler.Cor_X -= speler.speed;
                    break;
                case "right":
                    if (speler.Cor_X + vakGrootte < borderX && CollisionCheck("right"))
                        speler.Cor_X += speler.speed;
                    break;
            }
        }
        // test om cordinaat op grid terug te krijgen
        public int GetGridCordinate(int cor)
        {
            //double i = cor / vakGrootte;
            //double j = Math.Floor(i);
            //return Convert.ToInt32(j);
            return cor / vakGrootte;
        }

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