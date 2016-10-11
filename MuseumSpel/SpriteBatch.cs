using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuseumSpel
{
    class Spritebatch
    {
        private Graphics Gfx;
        private BufferedGraphics bfgx;
        private BufferedGraphicsContext cntxt = BufferedGraphicsManager.Current;

        public Spritebatch(Size clientsize, Graphics gfx)
        {
            cntxt.MaximumBuffer = new Size(clientsize.Width + 1, clientsize.Height + 1);
            bfgx = cntxt.Allocate(gfx, new Rectangle(Point.Empty, clientsize));
            Gfx = gfx;

        }

        public void Begin()
        {
            bfgx.Graphics.Clear(Color.Black);
        }

        public void drawImage(Bitmap b, Rectangle rec)
        {
            bfgx.Graphics.DrawImageUnscaled(b, rec);
        }

        public void End()
        {
            bfgx.Render(Gfx);
        }
    }

}