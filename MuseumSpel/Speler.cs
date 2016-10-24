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
        private int tics;
        private int picNumber;
        

        //Voor de powerup
        public bool isDisguised { get; set; }
        public DateTime endTime { get; set; }
        public int duration = 10;

        public Speler(string name, int cor_X, int cor_Y, int speed) : base(name, cor_X * 50, cor_Y * 50, "Afbeeldingen\\thief_front.png", true)
        {
            this.speed = speed;
            this.isDisguised = false;
            this.isStunned = false;
            tics = 0;
            picNumber = 1;
        }

        public void setPicture(Direction direction)
        {
            if (!isDisguised && !freezeMotion)
            {
                if (direction == Direction.Up)
                {
                    if (picNumber == 1)
                    {
                        texture = new Bitmap("Afbeeldingen\\thief_back_walk1.png");
                    }
                    else if (picNumber == 2)
                    {
                        texture = new Bitmap("Afbeeldingen\\thief_back.png");
                    }
                    else if (picNumber == 3)
                    {
                        texture = new Bitmap("Afbeeldingen\\thief_back_walk2.png");
                    }
                    else
                    {
                        texture = new Bitmap("Afbeeldingen\\thief_back.png");
                    }
                }
                else if (direction == Direction.Down)
                {
                    if (picNumber == 1)
                    {
                        texture = new Bitmap("Afbeeldingen\\thief_front_walk1.png");
                    }
                    else if (picNumber== 2)
                    {
                        texture = new Bitmap("Afbeeldingen\\thief_front.png");
                    }
                    else if (picNumber == 3)
                    {
                        texture = new Bitmap("Afbeeldingen\\thief_front_walk2.png");
                    }
                    else
                    {
                        texture = new Bitmap("Afbeeldingen\\thief_front.png");
                    }
                }
                else if (direction == Direction.Left)
                {
                    if (picNumber == 1)
                    {
                        texture = new Bitmap("Afbeeldingen\\thief_leftside_walk1.png");
                    }
                    else if (picNumber == 2)
                    {
                        texture = new Bitmap("Afbeeldingen\\thief_leftside.png");
                    }
                    else if (picNumber == 3)
                    {
                        texture = new Bitmap("Afbeeldingen\\thief_leftside_walk2.png");
                    }
                    else
                    {
                        texture = new Bitmap("Afbeeldingen\\thief_leftside.png");
                    }
                }
                else if (direction == Direction.Right)
                {
                    if (picNumber == 1)
                    {
                        texture = new Bitmap("Afbeeldingen\\thief_rightside_walk1.png");
                    }
                    else if (picNumber == 2)
                    {
                        texture = new Bitmap("Afbeeldingen\\thief_rightside.png");
                    }
                    else if (picNumber == 3)
                    {
                        texture = new Bitmap("Afbeeldingen\\thief_rightside_walk2.png");
                    } else
                    {
                        texture = new Bitmap("Afbeeldingen\\thief_rightside.png");
                    }
                }
                if (direction == Direction.UpIdle)
                {
                    texture = new Bitmap("Afbeeldingen\\thief_back.png");
                }
                else if (direction == Direction.DownIdle)
                {
                    texture = new Bitmap("Afbeeldingen\\thief_front.png");
                }
                else if (direction == Direction.LeftIdle)
                {
                    texture = new Bitmap("Afbeeldingen\\thief_leftside.png");
                }
                else if (direction == Direction.RightIdle)
                {
                    texture = new Bitmap("Afbeeldingen\\thief_rightside.png");
                }
            }
            else if(!freezeMotion)
            {
                //PowerUp();
                if (direction == Direction.Up)
                {
                    texture = new Bitmap("Afbeeldingen\\vermomming_back.png");
                }
                else if (direction == Direction.Down)
                {
                    texture = new Bitmap("Afbeeldingen\\vermomming_front.png");
                }
                else if (direction == Direction.Right)
                {
                    texture = new Bitmap("Afbeeldingen\\vermomming_right.png");
                }
                else if (direction == Direction.Left)
                {
                    texture = new Bitmap("Afbeeldingen\\vermomming_left.png");
                }
            }
            tics++;
            if (tics == 4)
            {
                if (picNumber == 4)
                    picNumber = 1;
                else
                    picNumber++;
                tics = 0;
            }
        }
        //method
  
        public void PowerDown()
        {
            //het oude plaatje
            //nieuw plaatje omdat je de powerup hebt opgepakt
            texture = new Bitmap(base.texture);
            this.isDisguised = false;
        }

        public void Waterplas(int currentTime)
        {
            Console.WriteLine("STUNNED!");
            oldSpeed = 5;
            speed = 0;
            startStun = currentTime;
            freezeMotion = true;
        }

        public void EndStun(int currentTime)
        {
            Console.WriteLine("UNSTUNNED!");
            speed = oldSpeed;
            freezeMotion = false;
            startCooldown = currentTime;
            isStunned = false;
            stunCooldown = true;
        }

        public void EndCooldown()
        {
            stunCooldown = false;
        }

        public override void PrintSpelObject(int cor_X, int cor_Y, int vakGrootte, Graphics g)
        {
            g.DrawImage(texture, cor_X, cor_Y, vakGrootte, vakGrootte);
        }
    }
}