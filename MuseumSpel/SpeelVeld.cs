using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MuseumSpel
{
    public delegate void ModelChangedEventHandeler();

    public enum Direction
    {
        Up, Down, Left, Right
    }
    // The Model, SuperClass
    public class SpeelVeld
    {
        //aantalRijen, aantalVakjes
        private int aantalVakkenX;
        private int aantalVakkenY;
        private int vakGrootte;
        private int loopOptie;
        public bool started = false;
        public int borderX { get; set; }
        public int borderY { get; set; }
        public Speler speler { get; set; }
        public GameLoop gameLoop;
        //lists
        private List<SpelObject> spelObjecten;
        private List<SpelObject> paintArray;

        public int richting { get; set; }
        public bool idle { get; set; }

        int outfitX;
        int outfitY;
        int key;
        int p = 0;

        public SpeelVeld(int aantalVakkenX, int aantalVakkenY, Speler speler, GameLoop gameLoop)
        {
            this.aantalVakkenX = aantalVakkenX;
            this.aantalVakkenY = aantalVakkenY;
            vakGrootte = 50;
            this.speler = speler;            
            borderY = vakGrootte * aantalVakkenY;
            borderX = vakGrootte * aantalVakkenX;
            spelObjecten = new List<SpelObject>();
            paintArray = new List<SpelObject>();
            this.gameLoop = gameLoop;
        }

        // Methodes

        public void loop()
        {
            started = true;
            while (!gameLoop.p_gameOver)
            {
                gameLoop.gameLoop();

            }
        }

        public void setRichting(Direction loopRichting)
        {
           if (loopRichting == Direction.Up)
            {
                richting = 1;
            }else if (loopRichting == Direction.Right)
            {
                richting = 2;
            }
            else if (loopRichting == Direction.Down)
            {
                richting = 3;
            }
            else if (loopRichting == Direction.Left)
            {
                richting = 4;
            }
        }

        public bool CollisionCheck(Direction richting) //First attempt
        {
            int x_p1, y_p1;
            int x_p2, y_p2;
            int marge = 10;

            if (richting == Direction.Up)
            {
                x_p1 = GetGridCordinate(speler.Cor_X);
                y_p1 = GetGridCordinate(speler.Cor_Y - speler.speed);
                x_p2 = GetGridCordinate(speler.Cor_X + vakGrootte - marge);
                y_p2 = GetGridCordinate(speler.Cor_Y - speler.speed);
            }else if (richting == Direction.Down)
            {
                x_p1 = GetGridCordinate(speler.Cor_X);
                y_p1 = GetGridCordinate(speler.Cor_Y + vakGrootte + speler.speed - marge);
                x_p2 = GetGridCordinate(speler.Cor_X + vakGrootte - marge);
                y_p2 = GetGridCordinate(speler.Cor_Y + vakGrootte + speler.speed);
            }else if (richting == Direction.Left)
            {
                x_p1 = GetGridCordinate(speler.Cor_X - speler.speed);
                y_p1 = GetGridCordinate(speler.Cor_Y);
                x_p2 = GetGridCordinate(speler.Cor_X - speler.speed);
                y_p2 = GetGridCordinate(speler.Cor_Y + vakGrootte - marge);
            }
            else if (richting == Direction.Right)
            {
                x_p1 = GetGridCordinate(speler.Cor_X + vakGrootte + speler.speed);
                y_p1 = GetGridCordinate(speler.Cor_Y);
                x_p2 = GetGridCordinate(speler.Cor_X + vakGrootte + speler.speed);
                y_p2 = GetGridCordinate(speler.Cor_Y - marge + vakGrootte);
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

        public void SpelerMovement(int loopRichting)
        {
            switch (loopRichting)
            {
                case 1:
                    if (speler.Cor_Y >= 0 && CollisionCheck(Direction.Up))
                        speler.Cor_Y -= speler.speed;
                    break;
                case 2:
                    if (speler.Cor_X + vakGrootte < borderX && CollisionCheck(Direction.Right))
                        speler.Cor_X += speler.speed;
                    break;
                case 3:
                    if (speler.Cor_Y + vakGrootte < borderY && CollisionCheck(Direction.Down))
                        speler.Cor_Y += speler.speed;
                    break;
                case 4:
                    if (speler.Cor_X >= 0 && CollisionCheck(Direction.Left))
                        speler.Cor_X -= speler.speed;
                    break;
            }

            //check of de speler - 15 of + 15 voor of na het power up plaatje zit zodat je er niet precies op hoeft te staan
            if (Enumerable.Range((outfitX - 15), 30).Contains(speler.Cor_X) && Enumerable.Range((outfitY - 15), 30).Contains(speler.Cor_Y) && p < 1)
            {
                Console.WriteLine(p);
                //verwijder de power up uit de array
                spelObjecten.RemoveAt(this.key);
                this.p += 1;
            }
        }

        public void pakSchilderij(bool keyPressed)
        {
            
            for (int i = 0; i < paintArray.Count; i++)
            {
                int x = paintArray[i].Cor_X * vakGrootte;
                int y = paintArray[i].Cor_Y * vakGrootte;
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

            for (int x = 0; x < spelObjecten.Count(); x++)
            {
                if (spelObjecten[x].GetType() == typeof(PowerUp))
                {
                    //x en y zijn in grids, 50 is de breedte en hoogte van een grid
                    this.outfitX = spelObjecten[x].Cor_X * vakGrootte;
                    this.outfitY = spelObjecten[x].Cor_Y * vakGrootte;
                    //key in de array onthouden voor het verwijderen als de powerup wordt gepakt 
                    this.key = x;
                }
            }
        }
    }
}