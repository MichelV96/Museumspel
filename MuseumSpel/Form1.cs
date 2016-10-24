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
        public bool startup = true;
        public Menu menu;
        public bool toMenu = false;
        Graphics dc;
        PaintEventArgs dc2;
        // Delegeate events
        public event KeyPressedEventHandeler KeyPressed;
        public event KeyPressedEventHandeler KeyRealeased;

        public Form1(SpeelVeld speelVeld, Menu menu)
        {
            InitializeComponent();
            this.speelVeld = speelVeld;
            this.menu = menu;
            speelVeld.vulArraysMetObjecten();
            this.speelVeld.SetPictures(this.speelVeld.muren);
            speelVeld.gameLoop.ModelChanged += this.OnModelChanged; //Subscriber
            speelVeld.shuttingUp += this.shuttingUp; //Subscriber
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

            //if (speelVeld.opgepaktDoorBewaker)
            //{
            //    speelVeld.gameLoop.ShutDown();
            //    this.Close();
            //}
            Application.DoEvents();
            this.Refresh();// Heel speelveld wordt opnieuw getekend

        }
        public void shuttingUp()
        {
            var result = MessageBox.Show("U bent betrapt door een bewaker. U bent af! \n wil je opnieuw beginnen? \n Druk op yes om het level opnieuw te beginnen. druk op no om naar het menu te gaan. ",
                            "Gameover", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
            {
                speelVeld.Reset();
                speelVeld.opgepaktDoorBewaker = true;
            }

            else if (result == DialogResult.No)
            {
                speelVeld.gameLoop.ShutDown();
                Application.Restart();
            }
        }

        protected override void OnClosed(EventArgs e)
        {
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            
                dc = e.Graphics;
                dc2 = e;
                
                speelVeld.PrintSpeelVeld(dc);

                speelVeld.speler.PrintSpelObject(speelVeld.speler.Cor_X, speelVeld.speler.Cor_Y, speelVeld.vakGrootte, dc2.Graphics);


            foreach (Bewaker bewaker in speelVeld.bewakers)
                {
                    bewaker.PrintSpelObject(bewaker.Cor_X, bewaker.Cor_Y, speelVeld.vakGrootte, dc);
                }

                if (!speelVeld.started)
                {
                    speelVeld.loop();
                }
            //startup = false;
            //Print tijd in de menubalk
            string counter = speelVeld.gameLoop.time;
            toolStripMenuItem1.Text = counter;

            toolStripMenuItem3.Text = speelVeld.gepakteSchilderijen + "/" + speelVeld.aantalSchilderijen;

            //Als score 0 is dan sluit de applicatie
            if (speelVeld.bepaalScore() == 0)
            {
                MessageBox.Show("U hebt verloren!");
                speelVeld.gameLoop.ShutDown();
                Application.Exit();
            }
            else
            {
                toolStripMenuItem2.Text = speelVeld.bepaalScore().ToString();
            }



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

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Invalidate();
        }
        private void pauzeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.pause();
        }

        private void geluidToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pasGeluidAan() == "aan")
            {
                geluidToolStripMenuItem.Image = new Bitmap("Afbeeldingen//sound_on.png");
            }
            else
            {
                geluidToolStripMenuItem.Image = new Bitmap("Afbeeldingen//sound_off.png");
            }
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var Result = MessageBox.Show("wil je opnieuw beginnen?", "Restart", MessageBoxButtons.RetryCancel, MessageBoxIcon.Question);

            if(Result == DialogResult.Retry)
            {
                speelVeld.Reset();
            }
            else if(Result == DialogResult.Cancel)
            {
                MessageBox.Show("Maak u klaar!\nHet spel begint zodra u op OK drukt!", "Klaar om te beginnnen?", MessageBoxButtons.OK);
            }
        }

        public string pasGeluidAan()
        {
            menu.pasGeluidAan();
            bool soundAan = menu.getSoundAan();

            if (soundAan)
            {
                return "aan";
            }
            else
            {
                return "uit";
            }
        }

        public void pause()
        {
            DialogResult dialogResult = MessageBox.Show("Wilt u het spel stoppen?", "Pauzemenu", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                speelVeld.gameLoop.ShutDown();
                Application.Restart();
            }
            else
            {
                MessageBox.Show("Maak u klaar!\nHet spel begint zodra u op OK drukt!", "Klaar om te beginnnen?", MessageBoxButtons.OK);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void scoreToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

    }
}
