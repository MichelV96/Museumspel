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

        public bool CollisionCheck(string richting) //First attempt
        {
            int x_p1, y_p1;
            int x_p2, y_p2;
            
            if (richting == "up")
            {
                x_p1 = GetGridCordinate(speler.Cor_X);
                y_p1 = GetGridCordinate(speler.Cor_Y - speler.speed);
                x_p2 = GetGridCordinate(speler.Cor_X + vakGrootte -10);
                y_p2 = GetGridCordinate(speler.Cor_Y - speler.speed);
            }else if (richting == "down")
            {
                x_p1 = GetGridCordinate(speler.Cor_X);
                y_p1 = GetGridCordinate(speler.Cor_Y + vakGrootte + speler.speed);
                x_p2 = GetGridCordinate(speler.Cor_X + vakGrootte -10);
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
                if (spelObject.isSolid && (x_p1 == spelObject.Cor_X && y_p1 == spelObject.Cor_Y || x_p2 == spelObject.Cor_X && y_p2 == spelObject.Cor_Y))
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

            int outfitX = 0;
            int outfitY = 0;
            int key = 0;

            for (int x = 1; x < spelObjecten.Count(); x++)
            {
                if (spelObjecten[x].GetType() == typeof(PowerUp))
                {
                    //x en y zijn in grids, 50 is de breedte en hoogte van een grid
                    outfitX = spelObjecten[x].Cor_X * 50;
                    outfitY = spelObjecten[x].Cor_Y * 50;
                    //key in de array onthouden voor het verwijderen als de powerup wordt gepakt 
                    key = x;
                }
            }
            //check of de speler - 15 of + 15 voor of na het power up plaatje zit zodat je er niet precies op hoeft te staan
            if (Enumerable.Range((outfitX - 15), 30).Contains(speler.Cor_X) && Enumerable.Range((outfitY - 15), 30).Contains(speler.Cor_Y))
            {
                //verwijder de power up uit de array
                spelObjecten.RemoveAt(key);
            }
        }

        public void pakSchilderij(bool keyPressed)
        {
            
            for (int i = 0; i < paintArray.Count; i++)
            {
                int x = paintArray[i].Cor_X * 50;
                int y = paintArray[i].Cor_Y * 50;
                    Console.WriteLine("intx: " + x + " inty " + y);
                    Console.WriteLine("spelerx: " + speler.Cor_X + " spelery: " + speler.Cor_Y);
                    if (keyPressed && (Enumerable.Range(x, x + 25).Contains(speler.Cor_X + 25) && Enumerable.Range(y - 25, y).Contains(speler.Cor_Y - 25)))
                    {
                        Console.WriteLine("Keypressed3");
                        paintArray.Remove(paintArray[i]);
                    }
            }

        }
        // test om cordinaat op grid terug te krijgen
        public int GetGridCordinate(int cor)
        {
            return (cor - 2) / vakGrootte;
        }

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