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
    public delegate void ShutdownEventHandeler();

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
        private List<SpelObject> spelObjecten;
        private List<SpelObject> paintArray;
        private List<SpelObject> waterplassen;
        private List<SpelObject> powerups;
        public List<SpelObject> muren;
        private List<SpelObject> eindpunten;
        public List<Bewaker> bewakers;
        //event
        public event ShutdownEventHandeler shuttingUp;
        //public event ModelChangedEventHandeler ModelChanged; // wanneer je de View aanroepen doe je: ModelChanged();

        //gameloop
        public bool paused { get; set; }
        public GameLoop gameLoop { get; private set; }
        public bool started { get; set; }
        public bool idle { get; set; }
        public int richting { get; set; }

        //guard (kan mogelijk in class bewaker)
        private int RangeStartUpAndLeftBewaker; // moet 124 zijn bij vakgroote 50
        private int RangeEndUpAndLeftBewaker;  // moet 199 zijn bij vakgroote 50
        private int RangeStartDownAndRightBewaker; //moet 0 zijn bij elk vakgroote
        private int RangeEndDownAndRightBewaker; // moet 175 zijn bij vakgroote 50
        public bool opgepaktDoorBewaker = false;

        //Powerup 
        int outfitX;
        int outfitY;

        //voor het checken dat de powerup maar 1x wordt verwijderd uit de array
        int p = 0;

        //values voor reset
        private List<SpelObject> usedPowerUps;
        private List<SpelObject> takenPaintArray;
        //schilderij counter & score
        public int aantalSchilderijen;
        public int gepakteSchilderijen;
        private int score;
        private int beginScore;
        private int puntenPerSchilderij;


        

        public SpeelVeld(int aantalVakkenX, int aantalVakkenY, GameLoop gameloop)
        {
            this.aantalVakkenX = aantalVakkenX;
            this.aantalVakkenY = aantalVakkenY;
            vakGrootte = 50;
            this.speler = speler;
            borderY = vakGrootte * aantalVakkenY;
            borderX = vakGrootte * aantalVakkenX;
            spelObjecten = new List<SpelObject>();
            muren = new List<SpelObject>();
            paintArray = new List<SpelObject>();
            takenPaintArray = new List<SpelObject>();
            waterplassen = new List<SpelObject>();
            powerups = new List<SpelObject>();
            usedPowerUps = new List<SpelObject>();
            bewakers = new List<Bewaker>();
            //Guard Range bepalen (kan mogelijk in class bewaker).
            RangeStartUpAndLeftBewaker = (vakGrootte * 2) + (vakGrootte/2) - 1;
            RangeEndUpAndLeftBewaker = (vakGrootte * 4) - 1;
            RangeEndDownAndRightBewaker = (vakGrootte * 3) + (vakGrootte / 2);
            RangeStartDownAndRightBewaker = 0;
            eindpunten = new List<SpelObject>();
            this.gameLoop = gameloop;
            beginScore = 5000;
            puntenPerSchilderij = 3000;


        }

        public void SetPictures(List<SpelObject> lijst)// Juiste texturtes geven aan muren
        {

            foreach (SpelObject l in lijst)
            {
                foreach (SpelObject j in lijst)
                {
                    if (l.Cor_X + 1 == j.Cor_X && l.Cor_Y == j.Cor_Y)
                        l.right = true;
                    if (l.Cor_X -1 == j.Cor_X && l.Cor_Y == j.Cor_Y)
                        l.left = true;
                    if (l.Cor_X == j.Cor_X && l.Cor_Y + 1 == j.Cor_Y)
                        l.down = true;
                    if (l.Cor_X == j.Cor_X && l.Cor_Y - 1 == j.Cor_Y)
                        l.up = true;
                }
                l.setPicture();
            }
        }

        // Methodes
        public void loop()
        {
            started = true;
            while (!gameLoop.p_gameOver)
            {
                #region
                //cycle++;
                //if (gameLoop.p_currentTime >= cyclestart + 1000)
                //{
                //    Console.WriteLine(cycle.ToString());
                //    cyclestart = gameLoop.p_currentTime;
                //    cycle = 0;
                //}
                #endregion
                gameLoop.gameLoop();
                //Console.WriteLine(speler.speed);

                if (speler.isDisguised == true && DateTime.Compare(DateTime.Now, speler.endTime) == 1)
                {
                    speler.PowerDown();
                    speler.setPicture(Direction.Down);
                    gameLoop.redraw();
                }

                if (speler.isStunned && gameLoop.p_currentTime >= speler.startStun + 2000)
                {
                    Console.WriteLine("stunned is true");
                    speler.EndStun(gameLoop.p_currentTime);
                }


                if (speler.stunCooldown && gameLoop.p_currentTime >= speler.startCooldown + 1000)
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
            int marge = speler.speed + 2;

            if (richting == Direction.Up)
            {
                x_p1 = GetGridCordinate(speler.Cor_X + marge);
                y_p1 = GetGridCordinate(speler.Cor_Y - speler.speed);
                x_p2 = GetGridCordinate(speler.Cor_X + vakGrootte - marge);
                y_p2 = GetGridCordinate(speler.Cor_Y - speler.speed);
            }
            else if (richting == Direction.Down)
            {
                x_p1 = GetGridCordinate(speler.Cor_X + marge);
                y_p1 = GetGridCordinate(speler.Cor_Y + vakGrootte + speler.speed);
                x_p2 = GetGridCordinate(speler.Cor_X + vakGrootte - marge);
                y_p2 = GetGridCordinate(speler.Cor_Y + vakGrootte + speler.speed);
            }
            else if (richting == Direction.Left)
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
            }
            else
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

        public bool BewakerCollisionCheck(Bewaker bewaker) //First attempt
        {
            int x_p1, y_p1;
            int x_p2, y_p2;
            int marge = bewaker.speed + 2;

            //up
            if (bewaker.richting == 1)
            {
                x_p1 = GetGridCordinate(bewaker.Cor_X + marge);
                y_p1 = GetGridCordinate(bewaker.Cor_Y - vakGrootte - bewaker.speed);
                x_p2 = GetGridCordinate(bewaker.Cor_X + vakGrootte - marge);
                y_p2 = GetGridCordinate(bewaker.Cor_Y - vakGrootte - bewaker.speed);
            }
            //down
            else if (bewaker.richting == 2)
            {
                x_p1 = GetGridCordinate(bewaker.Cor_X + marge);
                y_p1 = GetGridCordinate(bewaker.Cor_Y + vakGrootte * 2 + bewaker.speed);
                x_p2 = GetGridCordinate(bewaker.Cor_X + vakGrootte - marge);
                y_p2 = GetGridCordinate(bewaker.Cor_Y + vakGrootte * 2 + bewaker.speed);
            }
            //right
            else if (bewaker.richting == 3)
            {
                x_p1 = GetGridCordinate(bewaker.Cor_X + vakGrootte * 2 + bewaker.speed);
                y_p1 = GetGridCordinate(bewaker.Cor_Y + marge);
                x_p2 = GetGridCordinate(bewaker.Cor_X + vakGrootte * 2 + bewaker.speed);
                y_p2 = GetGridCordinate(bewaker.Cor_Y - marge + vakGrootte);
            }
            //left
            else if (bewaker.richting == 4)
            {
                x_p1 = GetGridCordinate(bewaker.Cor_X - vakGrootte - bewaker.speed);
                y_p1 = GetGridCordinate(bewaker.Cor_Y + marge);
                x_p2 = GetGridCordinate(bewaker.Cor_X - vakGrootte - bewaker.speed);
                y_p2 = GetGridCordinate(bewaker.Cor_Y + vakGrootte - marge);
            }
            else
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
                    Console.WriteLine("Collision " + bewaker.richting);
                    return false;
                }
            }
            return true;
        }

        public void SpelerMovement(Direction loopRichting)
        {
            if (!idle && !speler.freezeMotion)
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
            if (powerups.Any())
            {
                if (Enumerable.Range((outfitX - 15), 30).Contains(speler.Cor_X) && Enumerable.Range((outfitY - 15), 30).Contains(speler.Cor_Y) && p < 1)
                {
                    //verwijder de power up uit de array
                    usedPowerUps.Add(powerups[0]);
                    powerups.RemoveAt(0);
                    speler.isDisguised = true;
                    speler.endTime = DateTime.Now.AddSeconds(speler.duration);
                    this.p += 1;
                }
            }

            //eindpunt
            #region Eindpunt
            foreach (Eindpunt e in eindpunten)
            {
                if (Enumerable.Range((e.Cor_X * vakGrootte - 15), 30).Contains(speler.Cor_X) && Enumerable.Range((e.Cor_Y * vakGrootte - 15), 30).Contains(speler.Cor_Y))
                {
                    if (gepakteSchilderijen == aantalSchilderijen)
                    {
                        MessageBox.Show("Eindtijd: "+ gameLoop.time + "\nScore: " + score );
                        gameLoop.ShutDown();
                        Application.Restart();
                    }
                }
            }
            #endregion
            //waterplas
            #region waterplas
            if (!speler.isStunned && !speler.stunCooldown)
            {
                foreach (Waterplas waterplas in waterplassen)
                {
                    if (Enumerable.Range(((waterplas.Cor_X * vakGrootte) - 15), 30).Contains(speler.Cor_X) && Enumerable.Range(((waterplas.Cor_Y * vakGrootte) - 15), 30).Contains(speler.Cor_Y) && !speler.stunCooldown && !speler.isStunned)
                    {
                        speler.isStunned = true;
                        speler.speed = 15;
                        for (int i = 0; i <= 4; i++)
                        {
                            gameLoop.redraw();
                        }
                        speler.Waterplas(gameLoop.p_currentTime);
                        gameLoop.redraw();
                        break;
                    }
                }
            }
            #endregion
        }

        //Bewaker
        #region Bewaker Movement
        public void GuardAutomaticMovement()
        {
            foreach (Bewaker bewaker in bewakers)
            {
                #region path 1
                if (bewaker.path == 1) // eerste waypoint
                {
                    //Beweging naar links
                    if (bewaker.wayPoints[0, 0] > bewaker.wayPoints[1, 0])
                    {
                        bewaker.richting = 4;
                        bewaker.Cor_X -= bewaker.speed;
                        if (bewaker.Cor_X <= (bewaker.wayPoints[1, 0] * vakGrootte) && bewaker.Cor_X % vakGrootte == 0)
                        {
                            bewaker.path = 2;
                        }
                    }
                    //Beweging naar rechts
                    else if (bewaker.wayPoints[0, 0] < bewaker.wayPoints[1, 0])
                    {
                        bewaker.richting = 3;
                        bewaker.Cor_X += bewaker.speed;
                        if (bewaker.Cor_X >= (bewaker.wayPoints[1, 0] * vakGrootte) && bewaker.Cor_X % vakGrootte == 0)
                        {
                            bewaker.path = 2;
                        }
                    }
                    //Beweging naar beneden
                    else if (bewaker.wayPoints[0,1] < bewaker.wayPoints[1,1])
                    {
                        bewaker.richting = 2;
                        bewaker.Cor_Y += bewaker.speed;
                        if (bewaker.Cor_Y >= (bewaker.wayPoints[1, 1] * vakGrootte) && bewaker.Cor_Y % vakGrootte == 0)
                        {
                            bewaker.path = 2;
                        }
                    }
                    //Beweging naar boven
                    else if (bewaker.wayPoints[0, 1] > bewaker.wayPoints[1, 1])
                    {
                        bewaker.richting = 1;
                        bewaker.Cor_Y -= bewaker.speed;
                        if (bewaker.Cor_Y <= (bewaker.wayPoints[1, 1] * vakGrootte) && bewaker.Cor_Y % vakGrootte == 0)
                        {
                            bewaker.path = 2;
                        }
                    }
                }
                #endregion
                #region path 2
                else if (bewaker.path == 2)//tweede waypoint
                {
                    if (bewaker.aantalpaths > 2)//bewakers met meer dan twee points
                    {
                        //beweging naar rechts
                        if (bewaker.wayPoints[1, 0] < bewaker.wayPoints[2, 0])
                        {
                            bewaker.richting = 3;
                            bewaker.Cor_X += bewaker.speed;
                            if (bewaker.Cor_X >= (bewaker.wayPoints[2, 0] * vakGrootte) && bewaker.Cor_X % vakGrootte == 0)
                            {
                                bewaker.path = 3;
                            }
                        }
                        //bewging naar links
                        else if (bewaker.wayPoints[1, 0] > bewaker.wayPoints[2, 0])
                        {
                            bewaker.richting = 4;
                            bewaker.Cor_X -= bewaker.speed;
                            if (bewaker.Cor_X <= (bewaker.wayPoints[2, 0] * vakGrootte) && bewaker.Cor_X % vakGrootte == 0)
                            {
                                bewaker.path = 3;
                            }
                        }
                        //bewging naar up
                        else if (bewaker.wayPoints[1, 1] > bewaker.wayPoints[2, 1])
                        {
                            bewaker.richting = 1;
                            bewaker.Cor_Y -= bewaker.speed;
                            if (bewaker.Cor_Y <= (bewaker.wayPoints[2, 1] * vakGrootte) && bewaker.Cor_Y % vakGrootte == 0)
                            {
                                bewaker.path = 3;
                            }
                        }
                        //bewging naar down
                        else if (bewaker.wayPoints[1, 1] < bewaker.wayPoints[2, 1])
                        {
                            bewaker.richting = 2;
                            bewaker.Cor_Y += bewaker.speed;
                            if (bewaker.Cor_Y >= (bewaker.wayPoints[2, 1] * vakGrootte) && bewaker.Cor_Y % vakGrootte == 0)
                            {
                                bewaker.path = 3;
                            }
                        }
                    }
                    else
                    {
                        //beweging naar rechts
                        if (bewaker.wayPoints[0, 0] > bewaker.wayPoints[1, 0])
                        {
                            bewaker.richting = 3;
                            bewaker.Cor_X += bewaker.speed;
                            if (bewaker.Cor_X >= (bewaker.wayPoints[0, 0]) * 50 && bewaker.Cor_X % 50 == 0)
                            {                     
                                bewaker.path = 1;
                            }
                        }
                        //beweging naar links
                        else if (bewaker.wayPoints[0, 0] < bewaker.wayPoints[1, 0])
                        {
                            bewaker.richting = 4;
                            bewaker.Cor_X -= bewaker.speed;
                            if (bewaker.Cor_X <= (bewaker.wayPoints[0, 0]) * 50 && bewaker.Cor_X % 50 == 0)
                            {
                               bewaker.path = 1;   
                            }
                        }
                        //Beweging naar boven
                        else if (bewaker.wayPoints[0, 1] < bewaker.wayPoints[1, 1])
                        {
                            bewaker.richting = 1;
                            bewaker.Cor_Y -= bewaker.speed;
                            if (bewaker.Cor_Y <= (bewaker.wayPoints[0, 1]) * 50 && bewaker.Cor_Y % 50 == 0)
                            {          
                                    bewaker.path = 1;
                            }
                        }
                        //Beweging naar beneden
                        else if (bewaker.wayPoints[0, 1] > bewaker.wayPoints[1, 1])
                        {
                            bewaker.richting = 2;
                            bewaker.Cor_Y += bewaker.speed;
                            if (bewaker.Cor_Y >= (bewaker.wayPoints[0, 1]) * 50 && bewaker.Cor_Y % 50 == 0)
                            {
                                if (bewaker.aantalpaths > 2)
                                    bewaker.path = 1;
                            }
                        }
                    }
                }
                #endregion
                #region path 3
                else if (bewaker.path == 3)
                {
                        //bewging naar rechts
                        if (bewaker.wayPoints[2, 0] < bewaker.wayPoints[3, 0])
                        {
                            bewaker.richting = 3;
                            bewaker.Cor_X += bewaker.speed;
                            if (bewaker.Cor_X >= (bewaker.wayPoints[3, 0] * vakGrootte) && bewaker.Cor_X % vakGrootte == 0)
                            {
                                bewaker.path = 4;
                            
                            }
                        }
                        //bewging naar link
                        else if (bewaker.wayPoints[2, 0] > bewaker.wayPoints[3, 0])
                        {
                            bewaker.richting = 4;
                            bewaker.Cor_X -= bewaker.speed;
                            if (bewaker.Cor_X <= (bewaker.wayPoints[3, 0] * vakGrootte) && bewaker.Cor_X % vakGrootte == 0)
                            {
                                bewaker.path = 4;                               
                            }
                        }
                        //bewging naar boven
                        else if (bewaker.wayPoints[2, 1] > bewaker.wayPoints[3, 1])
                        {
                            bewaker.richting = 1;
                            bewaker.Cor_Y -= bewaker.speed;
                            if (bewaker.Cor_Y <= (bewaker.wayPoints[3, 1] * vakGrootte) && bewaker.Cor_Y % vakGrootte == 0)
                            {
                                bewaker.path = 4;
                            }
                        }
                        //bewging naar beneden
                        else if (bewaker.wayPoints[2, 1] < bewaker.wayPoints[3, 1])
                        {
                            bewaker.richting = 2;
                            bewaker.Cor_Y += bewaker.speed;
                            if (bewaker.Cor_Y >= (bewaker.wayPoints[3, 1] * vakGrootte) && bewaker.Cor_Y % vakGrootte == 0)
                            {
                                bewaker.path = 4;
                            }
                        }
                }
                #endregion
                #region path 4
                else if (bewaker.path == 4)
                {
                    //Beweging naar rechts
                    if (bewaker.wayPoints[3, 0] < bewaker.wayPoints[0, 0])
                    {
                        bewaker.richting = 3;
                        bewaker.Cor_X += bewaker.speed;
                        if (bewaker.Cor_X >= (bewaker.wayPoints[0, 0] * vakGrootte) && bewaker.Cor_X % vakGrootte == 0)
                        {
                            bewaker.path = 1;
                        }
                    }
                    //Beweging naar links
                    else if (bewaker.wayPoints[3, 0] > bewaker.wayPoints[0, 0])
                    {
                        bewaker.richting = 4;
                        bewaker.Cor_X -= bewaker.speed;
                        if (bewaker.Cor_X <= (bewaker.wayPoints[0, 0] * vakGrootte) && bewaker.Cor_X % vakGrootte == 0)
                        {
                            bewaker.path = 1;
                        }
                    }
                    //Beweging naar boven
                    else if (bewaker.wayPoints[3, 1] > bewaker.wayPoints[0, 1])
                    {
                        bewaker.richting = 1;
                        bewaker.Cor_Y -= bewaker.speed;
                        if (bewaker.Cor_Y <= (bewaker.wayPoints[0, 1] * vakGrootte) && bewaker.Cor_Y % vakGrootte == 0)
                        {
                            bewaker.path = 1;
                        }
                    }
                    //Beweging naar beneden
                    else if (bewaker.wayPoints[3, 1] < bewaker.wayPoints[0, 1])
                    {
                        bewaker.richting = 2;
                        bewaker.Cor_Y += bewaker.speed;
                        if (bewaker.Cor_Y >= (bewaker.wayPoints[0, 1] * vakGrootte) && bewaker.Cor_Y % vakGrootte == 0)
                        {
                            bewaker.path = 1;
                        }
                    }
                }
                #endregion
            }
        }
        #endregion
        
        //Detecteren van speler als guard. 
        #region Guard Detection
        public void GuardDetectPlayer()
        {
            if (speler.isDisguised == false)
            {
                foreach (Bewaker bewaker in bewakers)
                {
                    switch (bewaker.richting)
                    {
                        //boven
                        case 1:
                            bewaker.setPicture();
                            if (Enumerable.Range((bewaker.Cor_X), vakGrootte).Contains(speler.Cor_X + (vakGrootte / 2)) && Enumerable.Range((bewaker.Cor_Y - RangeStartUpAndLeftBewaker), RangeEndUpAndLeftBewaker).Contains(speler.Cor_Y + (vakGrootte / 2)))
                            {
                                Console.WriteLine("Boven detectie");
                                    if (shuttingUp != null)
                                    {
                                        shuttingUp();
                                    }
                                }
                                break;
                        //onder
                        case 2:
                            bewaker.setPicture();
                            if (Enumerable.Range((bewaker.Cor_X), vakGrootte).Contains(speler.Cor_X + (vakGrootte / 2)) && Enumerable.Range((bewaker.Cor_Y + RangeStartDownAndRightBewaker), RangeEndDownAndRightBewaker).Contains(speler.Cor_Y + (vakGrootte / 2)))
                            {
                                Console.WriteLine("Onder detectie");
                                    if (shuttingUp != null)
                                    {
                                        shuttingUp();
                                    }
                                }
                            break;
                        //rechts
                        case 3:
                            bewaker.setPicture();
                            if (Enumerable.Range((bewaker.Cor_X + RangeStartDownAndRightBewaker), RangeEndDownAndRightBewaker).Contains(speler.Cor_X + (vakGrootte / 2)) && Enumerable.Range((bewaker.Cor_Y), vakGrootte).Contains(speler.Cor_Y + (vakGrootte / 2)))
                            {
                                Console.WriteLine("Rechts detectie");
                                    if (shuttingUp != null)
                                    {
                                        shuttingUp();
                                    }
                                }
                            break;
                        //links
                        case 4:
                            bewaker.setPicture();
                            if (Enumerable.Range((bewaker.Cor_X - RangeStartUpAndLeftBewaker), RangeEndUpAndLeftBewaker).Contains(speler.Cor_X + (vakGrootte / 2)) && Enumerable.Range((bewaker.Cor_Y), vakGrootte).Contains(speler.Cor_Y + (vakGrootte / 2)))
                            {
                                Console.WriteLine("Links detectie");
                                    if (shuttingUp != null)
                                    {
                                        shuttingUp();
                                    }
                                }
                            break;
                    }
                }

            }

        }
        #endregion
        public void OpgepaktDoorBewaker()
        {
            opgepaktDoorBewaker = true;
        }

        //Schilderij oppakken
        #region Schilderij pakken
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
                    takenPaintArray.Add(paintArray[i]);
                    paintArray.Remove(paintArray[i]);
                    gepakteSchilderijen = aantalSchilderijen - paintArray.Count;
                    Console.WriteLine(gepakteSchilderijen);
                    Console.WriteLine(aantalSchilderijen);
                }
            }


        }
        #endregion

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

        public void voegBewakerToe(Bewaker bewaker)
        {
            bewakers.Add(bewaker);
        }

        public void vulArraysMetObjecten()
        {

            for (int x = 0; x < spelObjecten.Count(); x++)
            {
                if (spelObjecten[x].GetType() == typeof(Muur))
                {
                    muren.Add(spelObjecten[x]);
                }

                if (spelObjecten[x].GetType() == typeof(PowerUp))
                {
                    //x en y zijn in grids, 50 is de breedte en hoogte van een grid
                    this.outfitX = spelObjecten[x].Cor_X * vakGrootte;
                    this.outfitY = spelObjecten[x].Cor_Y * vakGrootte;
                    //key in de array onthouden voor het verwijderen als de powerup wordt gepakt 

                }

                if (spelObjecten[x].GetType() == typeof(Eindpunt))
                {
                    eindpunten.Add(spelObjecten[x]);
                }

                if (spelObjecten[x].GetType() == typeof(Waterplas))
                {
                    waterplassen.Add(spelObjecten[x]);
                }
                if (spelObjecten[x].GetType() == typeof(PowerUp))
                {
                    powerups.Add(spelObjecten[x]);
                }
                aantalSchilderijen = paintArray.Count;
            }

        }
        public void PrintSpeelVeld(Graphics g)
        {
            foreach (SpelObject muur in muren)
            {
                muur.PrintSpelObject(muur.Cor_X, muur.Cor_Y, vakGrootte, g);
            }

            foreach (SpelObject schilderij in paintArray)
            {
                schilderij.PrintSpelObject(schilderij.Cor_X, schilderij.Cor_Y, vakGrootte, g);
            }
            foreach (SpelObject waterplas in waterplassen)
            {
                waterplas.PrintSpelObject(waterplas.Cor_X, waterplas.Cor_Y, vakGrootte, g);
            }
            foreach (SpelObject powerup in powerups)
            {
                powerup.PrintSpelObject(powerup.Cor_X, powerup.Cor_Y, vakGrootte, g);
            }
            foreach (SpelObject eindpunt in eindpunten)
            {
                eindpunt.PrintSpelObject(eindpunt.Cor_X, eindpunt.Cor_Y, vakGrootte, g);
            }
        }

        public void Reset()
        {
            if (takenPaintArray.Count != 0)
            {
                gepakteSchilderijen = 0;
                foreach (SpelObject schilderij in takenPaintArray)
                {
                    if (!paintArray.Contains(schilderij))
                    {
                        paintArray.Add(schilderij);
                    }
                }
            }
            if (usedPowerUps.Count != 0)
            {
                foreach (SpelObject powerUp in usedPowerUps)
                {
                    if (!powerups.Contains(powerUp))
                    {
                        powerups.Add(powerUp);
                    }
                    if (!spelObjecten.Contains(powerUp))
                    {
                        spelObjecten.Add(powerUp);
                    }
                }
                this.p = 0;

            }
            foreach (Bewaker bewaker in bewakers)
            {
                bewaker.Cor_X = bewaker.start_cor_x;
                bewaker.Cor_Y = bewaker.start_cor_y;
                bewaker.path = 1;
            }
            speler.Cor_X = speler.start_cor_x;
            speler.Cor_Y = speler.start_cor_y;
            idle = true;

            gameLoop.seconds = 0;
            gameLoop.minutes = 0;
            gameLoop.hours = 0;
            gameLoop.redraw();
            MessageBox.Show("Maak u klaar!\nHet spel begint zodra u op OK drukt!", "Klaar om te beginnnen?", MessageBoxButtons.OK);
        }
        

        //Bepaal de score en zet dit in het menu
        public int bepaalScore()
        {
            int seconds = gameLoop.seconds;
            int minutes = gameLoop.minutes;
            score = beginScore - (seconds * 10) + (gepakteSchilderijen * puntenPerSchilderij);
            score = score - minutes * 60 * 10;

            return score;


        }
        
    }
}