using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuseumSpel
{
    class GameTimer
    {
        private int p_currentTime;
        private int p_startTime;
        private int LoopCount = 0;
        private int frameTimer = 0;
        private float LoopRate = 0; // amount of loops it ran in the last sec
        private int seconds = 0;
        private int minutes = 0;
        private int hours = 0;
        private int score = 0;
        private int tpf = 16; // 16 ticks per frame is 60 frames per seconde
        private int tps = 1000; // ticks per seconde
        public int framecounter2 = 0;
        public int framerate2 = 0;
        public bool shutdown = false;
        private string time;

        public GameTimer()
        {
            this.p_currentTime = Environment.TickCount;
        }

        public void startGameTimer()
        {
            if (p_currentTime > p_startTime + tpf)
            {
                framecounter2++;
                if (p_currentTime > frameTimer + tps)
                {
                    framerate2 = framecounter2;
                    framecounter2 = 0;// framecount reset
                }
                //update timing
                p_startTime = p_currentTime;   
            }
        }

        public string getGameTime()
        {
            LoopCount++;// Counts the amount of times it runs through the game loop
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
                LoopRate = LoopCount;

                LoopCount = 0;

                
            }
            return this.time;
        }


    }
}
