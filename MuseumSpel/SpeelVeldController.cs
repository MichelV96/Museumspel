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
               speelVeld.SpelerMovement("up");
            }else if (e.KeyData == Keys.S)
            {
               speelVeld.SpelerMovement("down");
            }
            else if (e.KeyData == Keys.A)
            {
                speelVeld.SpelerMovement("left");
            }
            else if (e.KeyData == Keys.D)
            {
                speelVeld.SpelerMovement("right");
            }

            if(e.KeyData == Keys.F)
            {
                speelVeld.pakSchilderij(true);
            }
                form1.Invalidate();

        }

    }
}
