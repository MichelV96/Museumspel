using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MuseumSpel
{
    public class Bewaker : SpelObject
    {
        public int[,] wayPoints;
        public int richting; //1=boven, 2=beneden, 3=rechts, 4=links
        public int startRichting;
        public int path = 1;
        public int aantalpaths;
        public int speed;
        public bool guardCollision = false;

        public Bewaker(int cor_X, int cor_Y, Direction richting) : this(cor_X, cor_Y, cor_X, cor_Y, richting)
        {
            setStartDirection(richting);
        }

        public Bewaker(int cor_X, int cor_Y, int eind_cor_X, int eind_cor_Y, Direction richting) : base("Bewaker", cor_X * 50, cor_Y * 50, "Afbeeldingen\\guard_front.png", false)
        {
            {
                if (cor_X == eind_cor_X || cor_Y == eind_cor_Y)
                {
                    wayPoints = new int[2, 2] { { cor_X, cor_Y }, { eind_cor_X, eind_cor_Y } };
                    speed = 5;
                    aantalpaths = 2;
                    Setrichting(richting);
                    setStartDirection(richting);
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Punten moeten op elkaar uit komen: x1 = x2 of y1 = y2");
                }
            }
        }

        public Bewaker(int cor_X1, int cor_Y1, int cor_X2, int cor_Y2, int cor_X3, int cor_Y3, Direction richting) : this(cor_X1, cor_Y1, cor_X2, cor_Y2, cor_X3, cor_Y3, cor_X2, cor_Y2, richting)
        {
            setStartDirection(richting);
        }

        public Bewaker(int cor_X1, int cor_Y1, int cor_X2, int cor_Y2, int cor_X3, int cor_Y3, int cor_X4, int cor_Y4, Direction richting) : base("Bewaker", cor_X1 * 50, cor_Y1 * 50, "Afbeeldingen\\guard_front.png", false)
        {
            if ((cor_X1 == cor_X2 || cor_Y1 == cor_Y2) && (cor_X2 == cor_X3 || cor_Y2 == cor_Y3) && (cor_X3 == cor_X4 || cor_Y3 == cor_Y4) && (cor_X4 == cor_X1 || cor_Y4 == cor_Y1))
            {
                wayPoints = new int[4, 2] { { cor_X1, cor_Y1 }, { cor_X2, cor_Y2 }, { cor_X3, cor_Y3 }, { cor_X4, cor_Y4 } };
                speed = 5;
                aantalpaths = 4;
                Setrichting(richting);
                setStartDirection(richting);
            } else
            {
                throw new ArgumentOutOfRangeException("Punten moeten op elkaar uit komen: x1 = x2 of y1 = y2");
            }
        }

        public void Setrichting(Direction richting)
        {
            if (richting == Direction.Up)
                this.richting = 1;
            else if (richting == Direction.Down)
                this.richting = 2;
            else if (richting == Direction.Right)
                this.richting = 3;
            else if (richting == Direction.Left)
                this.richting = 4;
        }

        public override void PrintSpelObject(int cor_X, int cor_Y, int vakGrootte, Graphics g)
        {
            if (richting == 1) //1=boven zonder collision
            {
                g.DrawImage(texture, cor_X, cor_Y -(vakGrootte*2));
            }
            else if (richting == 2)// 2 = beneden
            {
                g.DrawImage(texture, cor_X, cor_Y);

            }
            else if (richting == 3)// 3 = rechts
            {
                g.DrawImage(texture, cor_X, cor_Y);

            }
            else if (richting == 4)// 4 = links
            {
                g.DrawImage(texture, cor_X - (vakGrootte*2), cor_Y);
            }
            //else if (richting == 1 && guardCollision)// 1 = boven met collision
            //{
            //    g.DrawImage(texture, cor_X, cor_Y);

            //}
            //else if (richting == 4 && guardCollision)// 4 = links met collision
            //{
            //    g.DrawImage(texture, cor_X, cor_Y);
            //}


        }
        public override void setPicture(int number = 1)
        {
            if (!guardCollision)   //Set Guard Picture als er collision is.
            {
                if (richting == 1)//up
                {
                    texture = new Bitmap("Afbeeldingen\\guard_back.png");
                }
                else if (richting == 2)//down
                {
                    texture = new Bitmap("Afbeeldingen\\guard_front.png");
                }
                else if (richting == 3)//right
                {
                    texture = new Bitmap("Afbeeldingen\\guard_right.png");
                }
                else if (richting == 4)//left
                {
                    texture = new Bitmap("Afbeeldingen\\guard_left.png");
                }

            }
            else if(guardCollision)  //Set Guard Picture als er geen collision is.
            {

                if (richting == 1)//up
                {
                    texture = new Bitmap("Afbeeldingen\\guard_back_trans.png");
                }
                else if (richting == 2)//down
                {
                    texture = new Bitmap("Afbeeldingen\\guard_front_trans.png");
                }
                else if (richting == 3)//right
                {
                    texture = new Bitmap("Afbeeldingen\\guard_right_trans.png");
                }
                else if (richting == 4)//left
                {
                    texture = new Bitmap("Afbeeldingen\\guard_left_trans.png");
                }
            }
        }

        public void setStartDirection(Direction richting)
        {

            if (richting == Direction.Up)
                this.startRichting = 1;
            else if (richting == Direction.Down)
                this.startRichting = 2;
            else if (richting == Direction.Right)
                this.startRichting = 3;
            else if (richting == Direction.Left)
                this.startRichting = 4;
        }
    }
}

