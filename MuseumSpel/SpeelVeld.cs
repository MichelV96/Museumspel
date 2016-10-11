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
    public delegate void ModelChangedEventHandeler2();

    public enum Direction
    {
        Up, Down, Left, Right, UpIdle, DownIdle, LeftIdle, RightIdle
    }
    
    // The Model, SuperClass
    public class SpeelVeld
    {
        //aantalRijen, aantalVakjes
        private int aantalVakkenX;
        private int aantalVakkenY;
        public int vakGrootte { get; set; }
        public int borderX { get; set; }
        public int borderY { get; set; }
        public Speler speler { get; set; }
        //lists
        public List<SpelObject> spelObjecten;
        private List<SpelObject> paintArray;
        private List<SpelObject> waterplassen;
        //event
        //public event ModelChangedEventHandeler ModelChanged; // wanneer je de View aanroepen doe je: ModelChanged();

        //gameloop
        public GameLoop gameLoop { get; private set; }
        public bool started { get; set; }
        public bool idle { get; set; }
        public int richting { get; set; }

        
        //Powerup 
        int outfitX;
        int outfitY;
        //de key voor de spelobjecten array waar de powerup staat
        int key;
        //voor het checken dat de powerup maar 1x wordt verwijderd uit de array
        int p = 0;

        public SpeelVeld(int aantalVakkenX, int aantalVakkenY, Speler speler, GameLoop gameloop)
        {
            this.aantalVakkenX = aantalVakkenX;
            this.aantalVakkenY = aantalVakkenY;
            vakGrootte = 50;
            this.speler = speler;            
            borderY = vakGrootte * aantalVakkenY;
            borderX = vakGrootte * aantalVakkenX;
            spelObjecten = new List<SpelObject>();
            paintArray = new List<SpelObject>();
            waterplassen = new List<SpelObject>();

            this.gameLoop = gameloop;
        }

        // Methodes

        public void loop()
        {
            started = true;
            while (!gameLoop.p_gameOver)
            {
                gameLoop.gameLoop();
                //Console.WriteLine(speler.speed);

                if (speler.isDisguised == true && DateTime.Compare(DateTime.Now, speler.endTime) == 1)
                {
                    speler.PowerDown();
                    speler.setPicture(Direction.Down);
                    gameLoop.redraw();
                }

                if(speler.isStunned && gameLoop.p_currentTime >= speler.startStun + 2000)
                {
                    Console.WriteLine("stunned is true");
                    speler.EndStun(gameLoop.p_currentTime);
                }

                if(speler.stunCooldown && gameLoop.p_currentTime >= speler.startCooldown + 10000)
                {
                    Console.WriteLine("stund cooldown is true");
                    speler.EndCooldown();
                }
            }
        }


        public void setRichting(Direction loopRichting)
        {
            idle = false;
            if (loopRichting == Direction.Up)
            {
                richting = 1;
            }
            else if (loopRichting == Direction.Right)
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
            int marge = speler.speed;

            if (richting == Direction.Up)
            {
                x_p1 = GetGridCordinate(speler.Cor_X + marge);
                y_p1 = GetGridCordinate(speler.Cor_Y - speler.speed);
                x_p2 = GetGridCordinate(speler.Cor_X + vakGrootte - marge);
                y_p2 = GetGridCordinate(speler.Cor_Y - speler.speed);
            }else if (richting == Direction.Down)
            {
                x_p1 = GetGridCordinate(speler.Cor_X + marge);
                y_p1 = GetGridCordinate(speler.Cor_Y + vakGrootte + speler.speed);
                x_p2 = GetGridCordinate(speler.Cor_X + vakGrootte - marge);
                y_p2 = GetGridCordinate(speler.Cor_Y + vakGrootte + speler.speed);
            }else if (richting == Direction.Left)
            {
                x_p1 = GetGridCordinate(speler.Cor_X - speler.speed);
                y_p1 = GetGridCordinate(speler.Cor_Y + marge);
                x_p2 = GetGridCordinate(speler.Cor_X - speler.speed);
                y_p2 = GetGridCordinate(speler.Cor_Y + vakGrootte - marge);
            }
            else if (richting == Direction.Right)
            {
                x_p1 = GetGridCordinate(speler.Cor_X + vakGrootte + speler.speed);
                y_p1 = GetGridCordinate(speler.Cor_Y + marge);
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
                {
                    int over = speler.Cor_X % vakGrootte;
                    return false;
                }
            }
            return true;
        }

        public void SpelerMovement(Direction loopRichting)
        {

            if (!idle && !speler.isStunned)
            {
                switch (loopRichting)
                {
                    case Direction.Up:
                        if (speler.Cor_Y >= 0 && CollisionCheck(Direction.Up))
                            speler.Cor_Y -= speler.speed;
                            speler.setPicture(Direction.Up);
                        break;
                    case Direction.Right:
                        if (speler.Cor_X + vakGrootte < borderX && CollisionCheck(Direction.Right))
                            speler.Cor_X += speler.speed;
                            speler.setPicture(Direction.Right);
                        break;
                    case Direction.Down:
                        if (speler.Cor_Y + vakGrootte < borderY && CollisionCheck(Direction.Down))
                            speler.Cor_Y += speler.speed;
                            speler.setPicture(Direction.Down);
                        break;
                    case Direction.Left:
                        if (speler.Cor_X >= 0 && CollisionCheck(Direction.Left))
                            speler.Cor_X -= speler.speed;
                            speler.setPicture(Direction.Left);
                        break;
                }
            }
            //power up
            //check of de speler - 15 of + 15 voor of na het power up plaatje zit zodat je er niet precies op hoeft te staan
            if (Enumerable.Range((outfitX - 15), 30).Contains(speler.Cor_X) && Enumerable.Range((outfitY - 15), 30).Contains(speler.Cor_Y) && p < 1)
            {
                //verwijder de power up uit de array
                spelObjecten.RemoveAt(this.key);
                speler.isDisguised = true;
                speler.endTime = DateTime.Now.AddSeconds(speler.duration);
                this.p += 1;
            }

            if (!speler.isStunned && !speler.stunCooldown)
            {
                foreach (Waterplas waterplas in waterplassen)
                {
                    if (Enumerable.Range(((waterplas.Cor_X * vakGrootte) - 15), 30).Contains(speler.Cor_X) && Enumerable.Range(((waterplas.Cor_Y * vakGrootte) - 15), 30).Contains(speler.Cor_Y) && !speler.stunCooldown && !speler.isStunned)
                    {
                        //Console.WriteLine("shit");
                        speler.Waterplas(gameLoop.p_currentTime);
                        break;
                    }
                }
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
                    if (keyPressed && (Enumerable.Range(x - 25, 50).Contains(speler.Cor_X) && Enumerable.Range(y - 25, 50).Contains(speler.Cor_Y)))
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
                if(spelObjecten[x].GetType() == typeof(Waterplas))
                {
                    //this.waterplasX = spelObjecten[x].Cor_X * vakGrootte;
                    //this.waterplasY = spelObjecten[x].Cor_Y * vakGrootte;
                    waterplassen.Add(spelObjecten[x]);
                }
            }

            
        }



        public void GuardMovment(int corEindX, int corEindY, Direction Direction, SpelObject bewaker)
        {

            if (Direction == Direction.Up &&  bewaker.Cor_Y >= corEindY)
            {
                bewaker.Cor_Y -= 1;
            }
            else if (Direction == Direction.Down && bewaker.Cor_Y <= corEindY)
            {
                bewaker.Cor_Y += 1;

            }
            else if (Direction == Direction.Left && bewaker.Cor_X >= corEindX)
            {
                bewaker.Cor_X -= 1;

            }
            else if (Direction == Direction.Right && bewaker.Cor_X <= corEindX)
            {
                bewaker.Cor_X += 1;

            }


        }
    }
}