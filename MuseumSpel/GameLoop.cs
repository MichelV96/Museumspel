using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuseumSpel
{
    public class GameLoop
    {
        private int p_startTime = 0;
        private int p_currentTime = 0;
        public bool p_gameOver = false;
        public int frameCount = 0;
        public int frameTimer = 0;
        public float frameRate = 0;
        public int seconds = 0;
        public int minutes = 0;
        public int hours = 0;
        public int score = 0;
        public int framecounter2 = 0;
        public int framerate2 = 0;
        private string time;

        public event ModelChangedEventHandeler ModelChanged; // wanneer je de View aanroepen doe je: ModelChanged();

        public void ShutDown()
        {
            
            p_gameOver = true;
            Console.WriteLine("it's over man gameover gg");
        }

        public void gameLoop()
        {
            Console.WriteLine("GameLoop got called");
            //DataReset();
            //Game();
            //Menu();
            //Form form = (Form)this;
            //timer.Start();
            //Nick = 0;

            //while (!p_gameOver)
            //{

                //if (!menuSeen)
                //{
                //    Console.WriteLine("menu not seen");
                //    Game();
                //    Menu();
                //}


                //startTime = timer.ElapsedMilliseconds;
                //Game();
                //Application.DoEvents();
                //update timer

                p_currentTime = Environment.TickCount;
                //Console.WriteLine(p_currentTime.ToString()+" current");
                //Console.WriteLine(p_startTime.ToString()+" start");
                //refresh at 60 FPS
                if (p_currentTime > p_startTime + 25)// moet 16 zijn
                {
                    framecounter2++;
                    if (p_currentTime > frameTimer + 1000)
                    {
                        framerate2 = framecounter2;
                        framecounter2 = 0;
                        //Console.WriteLine(framerate2.ToString());
                    }
                    //Console.WriteLine("hihihihihihihihihihihihihihihihihihihihihihihihihihihihihihi");
                    //update timing
                    p_startTime = p_currentTime;
                //Console.WriteLine("hohohohohohohohohohohohohohohohohohohohohohohohohohohohohohoho");
                //give the form some cycles
                //Game_Draw();
                //GuardIdleActions();
                //Guard();
                if (ModelChanged != null)
                {
                    ModelChanged();
                }
                    //Application.DoEvents();
                }
                frameCount++;
                if (p_currentTime > frameTimer + 1000)
                {
                    seconds++;

                    if (seconds == 60)
                    {
                        minutes++;
                        seconds = 0;
                    }
                    if (minutes == 60)
                    {
                        hours++;
                        minutes = 0;
                    }
                    time = hours.ToString() + ":" + minutes.ToString() + ":" + seconds.ToString();
                    Console.WriteLine(time);
                    frameTimer = p_currentTime;
                    frameRate = frameCount;

                    frameCount = 0;
                }
            //}

        }

    }
}

