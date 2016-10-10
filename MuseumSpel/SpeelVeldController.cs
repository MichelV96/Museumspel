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
            if (e.KeyData == Keys.W)
            {
                speelVeld.setRichting(Direction.Up);
            }
            else if (e.KeyData == Keys.S)
            {
                speelVeld.setRichting(Direction.Down);
            }
            else if (e.KeyData == Keys.A)
            {
                speelVeld.setRichting(Direction.Left);
            }
            else if (e.KeyData == Keys.D)
            {
                speelVeld.setRichting(Direction.Right);
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
                speelVeld.speler.setPicture(Direction.UpIdle);
            }
            else if (e.KeyData == Keys.S)
            {
                speelVeld.speler.setPicture(Direction.DownIdle);
            }
            else if (e.KeyData == Keys.A)
            {
                speelVeld.speler.setPicture(Direction.LeftIdle);
            }
            else if (e.KeyData == Keys.D)
            {
                speelVeld.speler.setPicture(Direction.RightIdle);
            }
            form1.Invalidate();
        }

    }
}
