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
        public int p_currentTime = 0;
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
            Console.WriteLine("It's over man gameover: gg wp");
        }

        public void redraw()
        {
            if (ModelChanged != null)
            {
                ModelChanged();
            }
        }

        public void gameLoop()
        {
           // Console.WriteLine("GameLoop got called");
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
            //Console.WriteLine("GameLoop got called");
            //update timer

            p_currentTime = Environment.TickCount;
            
            //refresh at 60 FPS
            if (p_currentTime > p_startTime + 16)
            {
                framecounter2++;
                if (p_currentTime > frameTimer + 1000)
                {
                    framerate2 = framecounter2;
                    framecounter2 = 0;
                }
                //update timing
                p_startTime = p_currentTime;
                //give the form a cycle
                if (ModelChanged != null)
                {
                    ModelChanged();
                }
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

        }

    }
}
