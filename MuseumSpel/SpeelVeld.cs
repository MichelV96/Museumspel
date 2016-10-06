using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        private List<SpelObject> paintArray;

        public SpeelVeld(int aantalVakkenX, int aantalVakkenY, Speler speler)
        {
            this.aantalVakkenX = aantalVakkenX;
            this.aantalVakkenY = aantalVakkenY;
            vakGrootte = 50;
            this.speler = speler;            
            borderY = vakGrootte * aantalVakkenY;
            borderX = vakGrootte * aantalVakkenX;
            spelObjecten = new List<SpelObject>();
            paintArray = new List<SpelObject>();
            
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

            int outfitX = 0;
            int outfitY = 0;
            int key = 0;

            for (int x = 1; x < spelObjecten.Count(); x++)
            {
                if (spelObjecten[x].GetType() == typeof(PowerUp))
                {
                    outfitX = spelObjecten[x].Cor_X * 50;
                    outfitY = spelObjecten[x].Cor_Y * 50;
                    key = x;
                }
            }

            if (Enumerable.Range((outfitX - 15), 30).Contains(speler.Cor_X) && Enumerable.Range((outfitY - 15), 30).Contains(speler.Cor_Y))
            {
                Console.WriteLine("true");
                spelObjecten.RemoveAt(key);
                foreach (SpelObject spel in spelObjecten)
                {
                    Console.WriteLine(spel);
                }

            }
        }

        public void pakSchilderij(bool keyPressed)
        {
            for (int i = 0; i < paintArray.Count; i++)
            {
                int x = paintArray[i].Cor_X * 50;
                int y = paintArray[i].Cor_Y * 50;
                if (keyPressed == true && speler.Cor_X + 25 >= x + 15 && speler.Cor_X + 25 <= x + 35 && speler.Cor_Y - 25 >= y - 35 && speler.Cor_Y - 25 <= y - 15)
                {
                    if (Enumerable.Range(x, x + 25).Contains(speler.Cor_X + 25) && Enumerable.Range(y - 25, y).Contains(speler.Cor_Y - 25))
                    {
                        paintArray.Remove(paintArray[i]);
                    }
                }
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
            if (spelobject.Cor_X < aantalVakkenX && spelobject.Cor_Y < aantalVakkenY && spelobject.GetType() != typeof(Schilderij))
            {
                spelObjecten.Add(spelobject);
            }
            else
            {
                paintArray.Add(spelobject);
            }
        }

        public void PrintSpeelVeld(Graphics g)
        {
            foreach (SpelObject spelObject in spelObjecten)
            {
                spelObject.PrintSpelObject(spelObject.Cor_X, spelObject.Cor_Y, vakGrootte, g);
            }
            foreach (SpelObject schilderij in paintArray)
            {
                schilderij.PrintSpelObject(schilderij.Cor_X, schilderij.Cor_Y, vakGrootte, g);
            }
        }
    }
}