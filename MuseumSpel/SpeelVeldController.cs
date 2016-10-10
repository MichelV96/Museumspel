using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MuseumSpel
{
    // Controller voor speelveld
    public class SpeelVeldController
    {
        private SpeelVeld speelVeld; // model
        private Form1 form1; //view

        public SpeelVeldController(Form1 form1, SpeelVeld speelVeld)
        {
            this.speelVeld = speelVeld;
            this.form1 = form1;
        }

        public void OnKeyPressed(KeyEventArgs e)
        {
            if (e.KeyData == Keys.W || e.KeyData == Keys.Up)
            {
                speelVeld.setRichting(Direction.Up);
                speelVeld.speler.setPicture(Direction.Up);
            }
            else if (e.KeyData == Keys.S || e.KeyData == Keys.Down)
            {
                speelVeld.setRichting(Direction.Down);
                speelVeld.speler.setPicture(Direction.Down);
            }
            else if (e.KeyData == Keys.A || e.KeyData == Keys.Left)
            {
                speelVeld.setRichting(Direction.Left);
                speelVeld.speler.setPicture(Direction.Left);
            }
            else if (e.KeyData == Keys.D || e.KeyData == Keys.Right)
            {
                speelVeld.setRichting(Direction.Right);
                speelVeld.speler.setPicture(Direction.Right);
            }
            if (e.KeyData == Keys.F)
            {
                speelVeld.pakSchilderij(true);
            }
            form1.Invalidate();
        }

        public void OnKeyUp(KeyEventArgs e)
        {
            this.speelVeld.idle = true;
            if (e.KeyData == Keys.W)
            {
                Console.WriteLine("up");
                speelVeld.speler.setPicture(Direction.UpIdle);
            }
            else if (e.KeyData == Keys.S)
            {
                Console.WriteLine("Down");
                speelVeld.speler.setPicture(Direction.DownIdle);
            }
            else if (e.KeyData == Keys.A)
            {
                Console.WriteLine("Left");
                speelVeld.speler.setPicture(Direction.LeftIdle);
            }
            else if (e.KeyData == Keys.D)
            {
                Console.WriteLine("Right");
                speelVeld.speler.setPicture(Direction.RightIdle);
            }
            form1.Invalidate();
        }

    }
}
