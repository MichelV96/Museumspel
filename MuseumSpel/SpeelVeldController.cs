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
        private List<int> controls;

        public SpeelVeldController(Form1 form1, SpeelVeld speelVeld, List<int> controls)
        {
            this.speelVeld = speelVeld;
            this.form1 = form1;
            this.controls = controls;
        }

        public void OnKeyPressed(KeyEventArgs e)
        {
            form1.startup = false;
            if (!speelVeld.speler.isStunned)
            {
                if (e.KeyValue == controls[0])
                {
                    speelVeld.setRichting(Direction.Up);
                }
                else if (e.KeyValue == controls[1])
                {
                    speelVeld.setRichting(Direction.Down);
                }
                else if (e.KeyValue == controls[2])
                {
                    speelVeld.setRichting(Direction.Left);
                }
                else if (e.KeyValue == controls[3])
                {
                    speelVeld.setRichting(Direction.Right);
                }
                if (e.KeyData == Keys.F)
                {
                    speelVeld.pakSchilderij(true);
                }
                if(e.KeyData == Keys.Escape)
                {
                    form1.pause();
                }
            }
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
        }

    }
}
