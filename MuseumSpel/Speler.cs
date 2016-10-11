using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuseumSpel
{
    // Model
    public class Speler : SpelObject
    {

       
        public int speed { get; set; }
        public Bitmap normalTexture { get; set; }

        //voor de waterplas
        public bool isStunned = false;
        public bool stunCooldown = false;
        private int oldSpeed;
        public int startStun;
        public int startCooldown;
        public bool freezeMotion = false;


        //Voor de powerup
        public bool isDisguised { get; set; }
        public DateTime endTime { get; set; }
        public int duration = 10;

        public Speler(string name, int cor_X, int cor_Y, int speed) : base(name, cor_X, cor_Y, "Afbeeldingen\\0.png", true)
        {
            this.speed = speed;
            this.isDisguised = false;
            this.isStunned = false;
        }

        public void setPicture(Direction direction)
        {
            if (!isDisguised && !freezeMotion)
            {
                if (direction == Direction.Up)
                {
                    texture = new Bitmap("Afbeeldingen\\12.png");
                }
                else if (direction == Direction.Down)
                {
                    texture = new Bitmap("Afbeeldingen\\0.png");
                }
                else if (direction == Direction.Left)
                {
                    texture = new Bitmap("Afbeeldingen\\4.png");
                }
                else if (direction == Direction.Right)
                {
                    texture = new Bitmap("Afbeeldingen\\8.png");
                }
                if (direction == Direction.UpIdle)
                {
                    texture = new Bitmap("Afbeeldingen\\14.png");
                }
                else if (direction == Direction.DownIdle)
                {
                    texture = new Bitmap("Afbeeldingen\\2.png");
                }
                else if (direction == Direction.LeftIdle)
                {
                    texture = new Bitmap("Afbeeldingen\\6.png");
                }
                else if (direction == Direction.RightIdle)
                {
                    texture = new Bitmap("Afbeeldingen\\10.png");
                }
            }
            else if(!freezeMotion)
            {
                PowerUp();
            }
        }
        //method

        public void PowerUp()
        {
            //het oude plaatje
             
            //nieuw plaatje omdat je de powerup hebt opgepakt
            texture = new Bitmap("Afbeeldingen\\vermomming.png");
        }
        public void PowerDown()
        {
            //het oude plaatje
            //nieuw plaatje omdat je de powerup hebt opgepakt
            texture = new Bitmap(base.texture); ;
            this.isDisguised = false;
        }

        public void Waterplas(int currentTime)
        {
            //if (!stunCooldown)
            //{
            Console.WriteLine("STUNNED!");
            oldSpeed = 5;
            speed = 0;
            startStun = currentTime;
            freezeMotion = true;
            //isStunned = true;
            //}

        }

        public void EndStun(int currentTime)
        {
            Console.WriteLine("UNSTUNNED!");
            speed = oldSpeed;
            freezeMotion = false;
            //startCooldown = currentTime;
            isStunned = false;
            //stunCooldown = true;
        }

        public void EndCooldown()
        {
            stunCooldown = false;
        }
    }
}
