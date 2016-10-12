using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MuseumSpel
{
    // Delegate => publisher
    public delegate void KeyPressedEventHandeler(KeyEventArgs e);

    public partial class Form1 : Form
    {
        private SpeelVeld speelVeld; // model
        private int penDikte;
        public bool startup = true;
        Graphics dc;
        PaintEventArgs dc2;
        Region dc3;
        // Delegeate event
        public event KeyPressedEventHandeler KeyPressed;
        public event KeyPressedEventHandeler KeyRealeased;

        public Form1(SpeelVeld speelVeld)
        {
            InitializeComponent();
            this.speelVeld = speelVeld;
            penDikte = 2;
            speelVeld.speler.Cor_X += penDikte; // overlapping
            speelVeld.speler.Cor_Y += penDikte;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           

        }
        public void OnModelChanged()
        {
            if(speelVeld.richting == 1)
                speelVeld.SpelerMovement(Direction.Up);
            if (speelVeld.richting == 2)
                speelVeld.SpelerMovement(Direction.Right);
            if (speelVeld.richting == 3)
                speelVeld.SpelerMovement(Direction.Down);
            if (speelVeld.richting == 4)
                speelVeld.SpelerMovement(Direction.Left);

            Application.DoEvents();
            this.Refresh();// Heel speelveld wordt opnieuw getekend

        }
        

        public void close()
        {
            speelVeld.paused = true;
            var result = MessageBox.Show("do you want to quit?", "closing", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if(result == DialogResult.OK)
            {
                this.Close();
            }
            if(result == DialogResult.Cancel)
            {
                speelVeld.paused = false;
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            MessageBox.Show("it's over man! gameover! gg!", "game shutdown");
            speelVeld.gameLoop.ShutDown();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            
                dc = e.Graphics;
            dc2 = e;
            
                Pen p1 = new Pen(Color.Black, penDikte);
            
                Rectangle rec1 = new Rectangle(0, 0, speelVeld.borderX, speelVeld.borderY);
                if (rec1 != Rectangle.Empty)
                {
                    dc.DrawRectangle(p1, rec1);
                }

                speelVeld.PrintSpeelVeld(dc);
            #region MyClass definition

            speelVeld.speler.PrintSpelObject(speelVeld.speler.Cor_X, speelVeld.speler.Cor_Y, speelVeld.vakGrootte, dc2.Graphics);

            #endregion
            foreach (Bewaker bewaker in speelVeld.bewakers)
                {
                    bewaker.PrintSpelObject(bewaker.Cor_X, bewaker.Cor_Y, speelVeld.vakGrootte, dc);
                }

                if (!speelVeld.started)
                {
                    speelVeld.loop();
                }
                //startup = false;
            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // event start
            if (KeyPressed != null) // Alleen doen wanneer event subscribers heeft
            KeyPressed(e);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (KeyRealeased != null)
                KeyRealeased(e);
        }
    }
}
